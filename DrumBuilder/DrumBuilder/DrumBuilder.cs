using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kompas6API5;
using Kompas6Constants;
using Kompas6Constants3D;

namespace DrumBuilder
{
    class DrumBuilder
    {
        /// <summary>
        /// Ссылка на объект KOMПАС-3D
        /// </summary>
        private KompasObject _kompas;
        
        /// <summary>
        /// Ссылка на компонент сборки
        /// </summary>
        private ksPart _part;

        /// <summary>
        /// Создание экземпляра класса параметров
        /// </summary>
        private DrumDescription _description = new DrumDescription();

        /// <summary>
        /// Метод построения детали
        /// </summary>
        public void BuildDrum(DrumDescription objDescription)
        {
            
            // Экземпляру присваиваем значение объекта класса
            _description = objDescription;
 
            // Присваивание параметров
            var kadloHeight = _description.KadloHeight;
            var kadloRadius = _description.KadloDiameter / 2;
            var kadloThickness = _description.KadloThickness;
            var thicknessTopDrumhead = _description.ThicknessTopDrumhead;
            var thicknessBottomDrumhead = _description.ThicknessBottomDrumhead;
            var rimWidth = _description.RimWidth;
            var rimRadius = rimWidth + kadloRadius;
            var rimHalfWidth = rimWidth / 2;
            var rimHeight = _description.RimHeight;
            var rimCenter = rimRadius - rimHalfWidth;
            var numberMounting = _description.NumberMounting;
            var radiusHole = _description.DiametrHole / 2;
            var squareSide = _description.SquareSide;
            var triangleSide = _description.triangleSide;
            var ExistHoleInKadlo = _description.ExistHoleInKadlo;
            var circle = _description.Circle;
            var square = _description.Square;
            var triangle = _description.Triangle;
            var ExistSnare = _description.ExistSnare;
            var stringSnare = _description.StringSnare;
            
            //Методы класса DrumBuilder
            
            if (_kompas == null)
            {
                Type t = Type.GetTypeFromProgID("KOMPAS.Application.5");
                _kompas = (KompasObject)Activator.CreateInstance(t);
            }

            if (_kompas != null)
            {
                _kompas.Visible = true;
                _kompas.ActivateControllerAPI();
            }
            CreateKadlo(kadloRadius, kadloHeight, kadloThickness);
            CreateDrumhead(kadloHeight, kadloRadius,  thicknessTopDrumhead, thicknessBottomDrumhead);
            CreateRim(kadloHeight, thicknessTopDrumhead, thicknessBottomDrumhead, rimRadius, rimWidth, rimHeight);
            CreateHolesInRim(kadloHeight, rimCenter, numberMounting);
            CreateHolesInRim2(kadloHeight, thicknessTopDrumhead, rimCenter, numberMounting);
            CreateMountong(kadloHeight, thicknessTopDrumhead, thicknessBottomDrumhead, rimCenter, numberMounting);
            
            // Если выбран параметр "Наличие отверстия в кадле", вызывается метод его посторения
            if (ExistHoleInKadlo == true)
            {
                CreateHoleInKadlo(kadloHeight, circle, square, triangle, radiusHole, squareSide, triangleSide);
            }
            // Если выбран параметр "Наличие подструнника", вызывается метод его посторения
            if (ExistSnare == true)
            {
                CreateSnare(ExistSnare, stringSnare, kadloRadius, thicknessBottomDrumhead);
            }
        }

        ///<summary>
        /// Процедура построения кадла
        /// </summary>
        private void CreateKadlo(double kadloRadius, double kadloHeight, double kadloThickness)
        {
            ksDocument3D iDocument3D = (ksDocument3D)_kompas.Document3D();
            if (iDocument3D.Create(false /*видимый*/, true /*деталь*/))
            {
                // новый компонент
                _part = (ksPart)iDocument3D.GetPart((short)Part_Type.pTop_Part);	
                if (_part != null)
                {
                    // получим интерфейс базовой плоскости XOY
                    ksEntity planeXOY = (ksEntity)_part.GetDefaultEntity((short)Obj3dType.o3d_planeXOY);	
                    ksEntity iSketch = (ksEntity)_part.NewEntity((short)Obj3dType.o3d_sketch);
                    if (iSketch != null)
                    {
                        // создадим новый эскиз
                        ksEntity entitySketch1 = (ksEntity)_part.NewEntity((short)Obj3dType.o3d_sketch);
                        if (entitySketch1 != null)
                        {
                            // интерфейс свойств эскиза
                            ksSketchDefinition sketchDef1 = (ksSketchDefinition)entitySketch1.GetDefinition();
                            if (sketchDef1 != null)
                            {   
                                // установим плоскость
                                sketchDef1.SetPlane(planeXOY);	
                                // создадим эскиз
                                entitySketch1.Create();			

                                // интерфейс редактора эскиза
                                ksDocument2D sketchEdit1 = (ksDocument2D)sketchDef1.BeginEdit();
                                sketchEdit1.ksCircle(0, 0, kadloRadius, 1);
                                // завершение редактирования эскиза
                                sketchDef1.EndEdit();	

                                // создание операции выдавливания
                                ksEntity entityBossExtr = (ksEntity)_part.NewEntity((short)Obj3dType.o3d_bossExtrusion);
                                if (entityBossExtr != null)
                                {
                                    // Получение свойств интерфейса выдавливания
                                    ksBossExtrusionDefinition bossExtrDef = (ksBossExtrusionDefinition)entityBossExtr.GetDefinition();
                                    if (bossExtrDef != null)
                                    {   
                                        // интерфейс структуры параметров выдавливания
                                        ksExtrusionParam extrProp = (ksExtrusionParam)bossExtrDef.ExtrusionParam(); 
                                        // интерфейс структуры параметров тонкой стенки
                                        ksThinParam thinProp = (ksThinParam)bossExtrDef.ThinParam();     
                                        if (extrProp != null && thinProp != null)
                                        {   
                                            // эскиз операции выдавливания
                                            bossExtrDef.SetSketch(entitySketch1); 
                                            // направление выдавливания (обратное)
                                            extrProp.direction = (short)Direction_Type.dtNormal; 
                                            // тип выдавливания (строго на глубину)
                                            extrProp.typeNormal = (short)End_Type.etBlind;  
                                            // глубина выдавливания
                                            extrProp.depthNormal = kadloHeight;  
                                            // наличие тонкой стенки
                                            thinProp.thin = true;   
                                            //Толщина стенки в обратном направлении
                                            thinProp.reverseThickness = kadloThickness;   
                                            //Направление формирования тонкой стенки
                                            thinProp.thinType = (short)Direction_Type.dtBoth;
                                            // создадим операцию
                                            entityBossExtr.Create();               
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        ///<summary>
        /// Процедура построениея верхнего и нижнего пластиков
        ///</summary>
        private void CreateDrumhead(double kadloHeight, double kadloRadius, double thicknessTopDrumhead, double thicknessBottomDrumhead)
        {    
            // Создание плоскости для верхнего пластика
            #region 
            ksSketchDefinition definitionSketch = null;
            // Проверка на существование компонента сборки
            if (_part != null)  
            {   
                // создадим новый эскиз
                var DrumheadSketch = (ksEntity)_part.NewEntity((short)Obj3dType.o3d_sketch);
                if (DrumheadSketch != null)
                {   
                    // Получение интерфейса свойств эскиза
                    definitionSketch = (ksSketchDefinition)DrumheadSketch.GetDefinition(); 
                    if (definitionSketch != null)
                    {
                        // Получение интерфейса базовой плоскости XOY
                        var basePlane = (ksEntity)_part.GetDefaultEntity((short)Obj3dType.o3d_planeXOY); 
                        // создаем эскиз для смещенной плоскости
                        ksEntity entityOffsetPlane = _part.NewEntity((short)Obj3dType.o3d_planeOffset);
                        // получение интерфейса свойств эскиза для смещенной плоскости
                        ksPlaneOffsetDefinition offsetDef = (ksPlaneOffsetDefinition)entityOffsetPlane.GetDefinition();
                        // расстояние смещение
                        offsetDef.offset = kadloHeight;  
                        // направление смещения
                        offsetDef.direction = true; 
                        // назначение плоскости переноса
                        offsetDef.SetPlane(basePlane); 
                        // создание смещенной плоскости
                        entityOffsetPlane.Create();       
                
                        ksEntity _sketch = _part.NewEntity((short)Obj3dType.o3d_sketch);
                        var sketchDef2 = (ksSketchDefinition)_sketch.GetDefinition();
                        sketchDef2.SetPlane(entityOffsetPlane);
                        _sketch.Create();

                        ksDocument2D sketchEdit2 = (ksDocument2D)sketchDef2.BeginEdit(); //начало редактирования эскиза
                        sketchEdit2.ksCircle(0, 0, kadloRadius, 1);    //рисуем окружность для пластика
                        sketchDef2.EndEdit(); // завершение редактирования
            #endregion          
            // Выдавливание верхнего пластика
            #region
                        ksEntity entityBossExtr1 = (ksEntity)_part.NewEntity((short)Obj3dType.o3d_bossExtrusion);
                        if (entityBossExtr1 != null)
                        {
                            ksBossExtrusionDefinition bossExtrDef = (ksBossExtrusionDefinition)entityBossExtr1.GetDefinition();
                            if (bossExtrDef != null)
                            {   
                                // интерфейс структуры параметров выдавливания
                                ksExtrusionParam extrProp = (ksExtrusionParam)bossExtrDef.ExtrusionParam(); 
                                // интерфейс структуры параметров тонкой стенки
                                ksThinParam thinProp = (ksThinParam)bossExtrDef.ThinParam();     
                                if (extrProp != null )
                                {
                                    // эскиз операции выдавливания
                                    bossExtrDef.SetSketch(_sketch); 
                                    // направление выдавливания (прямое)
                                    extrProp.direction = (short)Direction_Type.dtNormal; 
                                    // тип выдавливания (строго на глубину)    
                                    extrProp.typeNormal = (short)End_Type.etBlind;     
                                    // глубина выдавливания
                                    extrProp.depthNormal = thicknessTopDrumhead;     
                                    // создадим операцию  
                                    entityBossExtr1.Create();               
                                }
                            }
                        }
                    }
            #endregion
            // Создание плоскости для нижнего пластика
            #region
                    // получим интерфейс базовой плоскости XOY
                    ksEntity planeXOY = (ksEntity)_part.GetDefaultEntity((short)Obj3dType.o3d_planeXOY);	
                    ksEntity iSketch = (ksEntity)_part.NewEntity((short)Obj3dType.o3d_sketch);
                    if (iSketch != null)
                    {
                        ksEntity entitySketch1 = (ksEntity)_part.NewEntity((short)Obj3dType.o3d_sketch);
                        if (entitySketch1 != null)
                        {
                            // интерфейс свойств эскиза
                            ksSketchDefinition sketchDef1 = (ksSketchDefinition)entitySketch1.GetDefinition();
                            if (sketchDef1 != null)
                            {
                                // установим плоскость
                                sketchDef1.SetPlane(planeXOY);	
                                // создадим эскиз
                                entitySketch1.Create();			

                                // интерфейс редактора эскиза
                                ksDocument2D sketchEdit1 = (ksDocument2D)sketchDef1.BeginEdit();
                                sketchEdit1.ksCircle(0, 0, kadloRadius, 1);
                                // завершение редактирования эскиза
                                sketchDef1.EndEdit();	
                      #endregion  
            
            // Выдавливание нижнего пластика
            #region
                                ksEntity entityBossExtr2 = (ksEntity)_part.NewEntity((short)Obj3dType.o3d_bossExtrusion);
                                if (entityBossExtr2 != null)
                                {
                                    ksBossExtrusionDefinition bossExtrDef1 = (ksBossExtrusionDefinition)entityBossExtr2.GetDefinition();
                                    if (bossExtrDef1 != null)
                                    {
                                        // интерфейс структуры параметров выдавливания
                                        ksExtrusionParam extrProp1 = (ksExtrusionParam)bossExtrDef1.ExtrusionParam(); 
                                        // интерфейс структуры параметров тонкой стенки
                                        ksThinParam thinProp1 = (ksThinParam)bossExtrDef1.ThinParam();     
                                        if (extrProp1 != null)
                                        {
                                            // эскиз операции выдавливания
                                            bossExtrDef1.SetSketch(entitySketch1); 
                                            // направление выдавливания (обратное)
                                            extrProp1.direction = (short)Direction_Type.dtReverse;     
                                            // тип выдавливания (строго на глубину)
                                            extrProp1.typeReverse = (short)End_Type.etBlind;     
                                            // глубина выдавливания
                                            extrProp1.depthReverse = thicknessBottomDrumhead;  
                                            // создадим операцию       
                                            entityBossExtr2.Create();               
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        } 
            #endregion

        ///<summary>
        /// Создание ободов
        ///</summary>
        private void CreateRim(double kadloHeight, double thicknessTopDrumhead, double thicknessBottomDrumhead, double rimRadius, double rimWidth, double rimHeight)
        {
            
            #region Создание смещенной плоскости для верхнего обода

            ksSketchDefinition rimSketch = null;
            // Проверка на существование компонента сборки
            if (_part != null)  
            {
                // создадим новый эскиз
                var RimSketch = (ksEntity)_part.NewEntity((short)Obj3dType.o3d_sketch);   
                if (RimSketch != null)
                {
                    // Получение интерфейса свойств эскиза
                    rimSketch = (ksSketchDefinition)RimSketch.GetDefinition(); 
                    if (rimSketch != null)
                    {
                        // Получение интерфейса базовой плоскости XOY
                        var basePlane1 = (ksEntity)_part.GetDefaultEntity((short)Obj3dType.o3d_planeXOY); 
                        ksEntity entityOffsetPlane1 = _part.NewEntity((short)Obj3dType.o3d_planeOffset);
                        ksPlaneOffsetDefinition offsetDef1 = (ksPlaneOffsetDefinition)entityOffsetPlane1.GetDefinition();
                        // Высота кадла + толщина пластика+0.1
                        offsetDef1.offset = kadloHeight + thicknessTopDrumhead + 0.1;     
                        // Направление смещения  
                        offsetDef1.direction = true; 
                        offsetDef1.SetPlane(basePlane1);
                        // Создаем смещенную плоскость
                        entityOffsetPlane1.Create();

                        ksEntity _rimSketch = _part.NewEntity((short)Obj3dType.o3d_sketch);

                        var sketchDef3 = (ksSketchDefinition)_rimSketch.GetDefinition();
                        sketchDef3.SetPlane(entityOffsetPlane1);
                        _rimSketch.Create();

                        ksDocument2D sketchEdit3 = (ksDocument2D)sketchDef3.BeginEdit();
                        //рисуем окружность 
                        sketchEdit3.ksCircle(0, 0, rimRadius, 1);    
                        sketchDef3.EndEdit();

            #endregion // Создание смещенной плоскости для верхнего обода
           
            #region  Выдавливание верхнего обода
                        ksEntity entityBossExtr3 = (ksEntity)_part.NewEntity((short)Obj3dType.o3d_bossExtrusion);
                        if (entityBossExtr3 != null)
                        {
                            ksBossExtrusionDefinition bossExtrDef3 = (ksBossExtrusionDefinition)entityBossExtr3.GetDefinition();
                            if (bossExtrDef3 != null)
                            {
                                // интерфейс структуры параметров выдавливания
                                ksExtrusionParam extrProp3 = (ksExtrusionParam)bossExtrDef3.ExtrusionParam(); 
                                // интерфейс структуры параметров тонкой стенки
                                ksThinParam thinProp3 = (ksThinParam)bossExtrDef3.ThinParam();      
                                if (extrProp3 != null && thinProp3 != null)
                                {
                                    // эскиз операции выдавливания
                                    bossExtrDef3.SetSketch(_rimSketch);
                                    // направление выдавливания (прямое)
                                    extrProp3.direction = (short)Direction_Type.dtNormal;    
                                    // тип выдавливания (строго на глубину) 
                                    extrProp3.typeNormal = (short)End_Type.etBlind;  
                                    // глубина выдавливания  ВЫСОТА ОБОДА   
                                    extrProp3.depthNormal = rimHeight;         
                                    thinProp3.thin = true;
                                    // Толщина стенки в обратном направлении
                                    thinProp3.reverseThickness = rimWidth;   
                                    // Направление формирования тонкой стенки
                                    thinProp3.thinType = (short)Direction_Type.dtBoth;
                                    // создадим операцию
                                    entityBossExtr3.Create();               
                                }
                            }
                        }
                    }
            #endregion Выдавливание верхнего обода
                  
            #region Создание плоскости для нижнего обода
                    ksEntity entityBossExtr4 = (ksEntity)_part.NewEntity((short)Obj3dType.o3d_bossExtrusion);
                    ksSketchDefinition rimSketch2 = null;
                    if (entityBossExtr4 != null)
                    {
                        // создадим новый эскиз  
                        var RimSketch2 = (ksEntity)_part.NewEntity((short)Obj3dType.o3d_sketch); 
                        if (RimSketch2 != null)
                        {
                            // Получение интерфейса свойств эскиза
                            rimSketch2 = (ksSketchDefinition)RimSketch2.GetDefinition();

                            if (rimSketch2 != null)
                            {
                                // Получение интерфейса базовой плоскости XOY
                                var basePlane2 = (ksEntity)_part.GetDefaultEntity((short)Obj3dType.o3d_planeXOY);
                                ksEntity entityOffsetPlane2 = _part.NewEntity((short)Obj3dType.o3d_planeOffset);
                                ksPlaneOffsetDefinition offsetDef1 = (ksPlaneOffsetDefinition)entityOffsetPlane2.GetDefinition();
                                // толщина пластика + 0.1
                                offsetDef1.offset = thicknessBottomDrumhead + 0.1;       
                                offsetDef1.direction = false;
                                offsetDef1.SetPlane(basePlane2);
                                // создаем смещенную плоскость
                                entityOffsetPlane2.Create(); 

                                ksEntity _rimSketch2 = _part.NewEntity((short)Obj3dType.o3d_sketch);
                                var sketchDef4 = (ksSketchDefinition)_rimSketch2.GetDefinition();
                                sketchDef4.SetPlane(entityOffsetPlane2);
                                _rimSketch2.Create();

                                ksDocument2D sketchEdit4 = (ksDocument2D)sketchDef4.BeginEdit();
                                //рисуем окружность 
                                sketchEdit4.ksCircle(0, 0, rimRadius, 1);   
                                sketchDef4.EndEdit();
                    #endregion Создание плоскости для нижнего обода
                                
            #region Выдавливание нижнего обода
                                ksEntity entityBossExtr5 = (ksEntity)_part.NewEntity((short)Obj3dType.o3d_bossExtrusion);
                                if (entityBossExtr4 != null)
                                {
                                    ksBossExtrusionDefinition bossExtrDef4 = (ksBossExtrusionDefinition)entityBossExtr4.GetDefinition();
                                    if (bossExtrDef4 != null)
                                    {
                                        // интерфейс структуры параметров выдавливания
                                        ksExtrusionParam extrProp4 = (ksExtrusionParam)bossExtrDef4.ExtrusionParam(); 
                                        // интерфейс структуры параметров тонкой стенки
                                        ksThinParam thinProp4 = (ksThinParam)bossExtrDef4.ThinParam();     
                                        if (extrProp4 != null && thinProp4 != null)
                                        {
                                            // эскиз операции выдавливания
                                            bossExtrDef4.SetSketch(_rimSketch2); 
                                            // направление выдавливания (обратное)
                                            extrProp4.direction = (short)Direction_Type.dtReverse;     
                                            // тип выдавливания (строго на глубину)
                                            extrProp4.typeReverse = (short)End_Type.etBlind;    
                                            // глубина выдавливания  ВЫСОТА ОБОДА
                                            extrProp4.depthReverse = rimHeight;        
                                            thinProp4.thin = true;
                                            // Толщина стенки в обратном направлении
                                            thinProp4.reverseThickness = rimWidth;    
                                            // Направление формирования тонкой стенки
                                            thinProp4.thinType = (short)Direction_Type.dtBoth;
                                            // создадим операцию
                                            entityBossExtr4.Create();               
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
                                #endregion Выдавливание нижнего обода

        ///<summary>
        /// Создание отверситий в нижнем ободе
        ///</summary>
        private void CreateHolesInRim(double kadloHeight, double rimCenter, int numberMounting)
        {
            if (_part != null)
            {
                // интерфейс свойств эскиза
                ksEntity rimHoles = (ksEntity)_part.NewEntity((short)Obj3dType.o3d_sketch);
                if (rimHoles != null)
                {
                    // Получение интерфейса свойств эскиза
                    ksSketchDefinition rimSketch = (ksSketchDefinition)rimHoles.GetDefinition(); 
                    if (rimSketch != null)
                    {
                        ksEntity basePlane;
                        // Получение интерфейса базовой плоскости XOY
                        basePlane = (ksEntity)_part.GetDefaultEntity((short)Obj3dType.o3d_planeXOY); 
                        // установим плоскость базовой для эскиза
                        rimSketch.SetPlane(basePlane); 
                        // создадим эскиз
                        rimHoles.Create(); 
                        // интерфейс редактора эскиза
                        ksDocument2D sketchEdit = (ksDocument2D)rimSketch.BeginEdit();
                        int i = 1;
                        for (double phi = 0; phi < 2 * Math.PI; phi += 2 * Math.PI / numberMounting)
                        {
                            double x = rimCenter * Math.Cos(phi);
                            double y = rimCenter * Math.Sin(phi);
                            //круглое отверстие
                            sketchEdit.ksCircle(x, y, 2.5, 1);
                            if (i < numberMounting)
                            {
                                i++;
                            }
                            else break;
                        }
                        // завершение редактирования эскиза
                        rimSketch.EndEdit(); 
                        // вырежим выдавливанием
                        ksEntity entityCutExtr = (ksEntity)_part.NewEntity((short)Obj3dType.o3d_cutExtrusion);
                        if (entityCutExtr != null)
                        {
                            ksCutExtrusionDefinition cutExtrDef = (ksCutExtrusionDefinition)entityCutExtr.GetDefinition();
                            if (cutExtrDef != null)
                            {
                                cutExtrDef.cut = true;
                                cutExtrDef.directionType = (short)Direction_Type.dtNormal;
                                cutExtrDef.SetSideParam(true, (short)End_Type.etThroughAll);
                                cutExtrDef.SetSketch(rimSketch);
                                entityCutExtr.Create();
                            }
                        }
                    }
                }
            }
        }

        ///<summary>
        /// Создание отверстий в верхнем  ободе
        ///</summary>
        private void CreateHolesInRim2(double kadloHeight, double thicknessTopDrumhead, double rimCenter, int numberMounting)
        {
            if (_part != null)
            {
                // интерфейс свойств эскиза
                ksEntity rimHoles = (ksEntity)_part.NewEntity((short)Obj3dType.o3d_sketch);
                if (rimHoles != null)
                {
                    // Получение интерфейса свойств эскиза
                    ksSketchDefinition rimSketch1 = (ksSketchDefinition)rimHoles.GetDefinition(); 
                    if (rimSketch1 != null)
                    {
                        ksEntity basePlane;
                        // Получение интерфейса базовой плоскости XOY
                        basePlane = (ksEntity)_part.GetDefaultEntity((short)Obj3dType.o3d_planeXOY); 
                        ksEntity entityOffsetPlane = _part.NewEntity((short)Obj3dType.o3d_planeOffset);

                        ksPlaneOffsetDefinition offsetDef1 = (ksPlaneOffsetDefinition)entityOffsetPlane.GetDefinition();
                        // Расстояние смещения
                        offsetDef1.offset = kadloHeight + thicknessTopDrumhead + 0.1;      
                        offsetDef1.direction = true;
                        offsetDef1.SetPlane(basePlane);
                        // создаем смещенную плоскость
                        entityOffsetPlane.Create();
                        // установим плоскость базовой для эскиза
                        rimSketch1.SetPlane(offsetDef1);
                        // создадим эскиз
                        rimHoles.Create();
                        // интерфейс редактора эскиза
                        ksDocument2D sketchEdit = (ksDocument2D)rimSketch1.BeginEdit();
                        if (sketchEdit != null)
                        {
                            int i = 1;
                            for (double phi = 0; phi < 2 * Math.PI; phi += 2 * Math.PI / numberMounting)
                            {
                                double x = rimCenter * Math.Cos(phi);
                                double y = rimCenter * Math.Sin(phi);
                                //круглое отверстие
                                sketchEdit.ksCircle(x, y, 2.5, 1);
                                if (i < numberMounting)
                                {
                                    i++;
                                }
                                else break;
                            }  
                            // завершение редактирования эскиза
                            rimSketch1.EndEdit(); 
                            // вырежим выдавливанием
                            ksEntity entityCutExtr = (ksEntity)_part.NewEntity((short)Obj3dType.o3d_cutExtrusion);
                            if (entityCutExtr != null)
                            {
                                ksCutExtrusionDefinition cutExtrDef = (ksCutExtrusionDefinition)entityCutExtr.GetDefinition();
                                if (cutExtrDef != null)
                                {
                                    cutExtrDef.cut = true;
                                    cutExtrDef.directionType = (short)Direction_Type.dtReverse;
                                    cutExtrDef.SetSideParam(false, (short)End_Type.etThroughAll);
                                    cutExtrDef.SetSketch(rimSketch1);
                                    entityCutExtr.Create();
                                }
                            }
                        }
                    }
                }
            }
        }

        ///<summary>
        /// Создание креплений
        /// </summary>
        private void CreateMountong(double kadloHeight, double thicknessTopDrumhead, double thicknessBottomDrumhead, double rimCenter, int numberMounting)
        {
            if (_part != null)
            {
                // интерфейс свойств эскиза
                ksEntity mount = (ksEntity)_part.NewEntity((short)Obj3dType.o3d_sketch);
                if (mount != null)
                {
                    // Получение интерфейса свойств эскиза
                    ksSketchDefinition rimSketch = (ksSketchDefinition)mount.GetDefinition(); 
                    if (rimSketch != null)
                    {
                        ksEntity basePlane;
                        // Получение интерфейса базовой плоскости XOY
                        basePlane = (ksEntity)_part.GetDefaultEntity((short)Obj3dType.o3d_planeXOY);
                        // установим плоскость базовой для эскиза
                        rimSketch.SetPlane(basePlane);
                        ksEntity entityOffsetPlane = _part.NewEntity((short)Obj3dType.o3d_planeOffset);
                        ksPlaneOffsetDefinition offsetDef01 = (ksPlaneOffsetDefinition)entityOffsetPlane.GetDefinition();
                        // Расстояние смещения
                        offsetDef01.offset = thicknessBottomDrumhead;       
                        offsetDef01.direction = false;
                        offsetDef01.SetPlane(basePlane); 
                        // создаем смещенную плоскость
                        entityOffsetPlane.Create();
                        // установим плоскость базовой для эскиза
                        rimSketch.SetPlane(offsetDef01); 
                        // создадим эскиз
                        mount.Create(); 
                        // интерфейс редактора эскиза
                        ksDocument2D sketchEdit = (ksDocument2D)rimSketch.BeginEdit();
                        int i = 1;
                        for (double phi = 0; phi < 2 * Math.PI; phi += 2 * Math.PI / numberMounting)
                        {
                            double x = rimCenter * Math.Cos(phi);
                            double y = rimCenter * Math.Sin(phi);
                            //круглое отверстие
                            sketchEdit.ksCircle(x, y, 2.5, 1);
                           
                            if (i < numberMounting)
                            {
                                i++;
                            }
                            else break;
                        }
                     
                        // завершение редактирования эскиза
                        rimSketch.EndEdit(); 
                        ksEntity entityBossExtr3 = (ksEntity)_part.NewEntity((short)Obj3dType.o3d_bossExtrusion);
                        if (entityBossExtr3 != null)
                        {
                            ksBossExtrusionDefinition bossExtrDef3 = (ksBossExtrusionDefinition)entityBossExtr3.GetDefinition();
                            if (bossExtrDef3 != null)
                            {
                                // интерфейс структуры параметров выдавливания
                                ksExtrusionParam extrProp3 = (ksExtrusionParam)bossExtrDef3.ExtrusionParam();
                                // интерфейс структуры параметров тонкой стенки
                                ksThinParam thinProp3 = (ksThinParam)bossExtrDef3.ThinParam();      
                                if (extrProp3 != null)
                                {
                                    // эскиз операции выдавливания
                                    bossExtrDef3.SetSketch(rimSketch); 
                                    // направление выдавливания 
                                    extrProp3.direction = (short)Direction_Type.dtNormal;     
                                    // тип выдавливания
                                    extrProp3.typeNormal = (short)End_Type.etBlind;
                                    // Высота выдавливания
                                    extrProp3.depthNormal = kadloHeight; 
                                    // создадим операцию    
                                    entityBossExtr3.Create();                
                                }
                            }
                        }
                    }
                }
            }
        }
       
        ///<summary>
        /// Создание отверстия в кадле
        ///</summary>
        private void CreateHoleInKadlo(double kadloHeight, bool circle, bool square, bool triangle, double radiusHole, double squareSide, double triangleSide)
        {
            if (_part != null)
            {
                // интерфейс свойств эскиза
                ksEntity holeInKadlo = (ksEntity)_part.NewEntity((short)Obj3dType.o3d_sketch);
                if (holeInKadlo != null)
                {
                    // Получение интерфейса свойств эскиза
                    ksSketchDefinition holeSketch = (ksSketchDefinition)holeInKadlo.GetDefinition(); 
                    if (holeSketch != null)
                    {
                        ksEntity basePlane;
                        // Получение интерфейса базовой плоскости XOZ
                        basePlane = (ksEntity)_part.GetDefaultEntity((short)Obj3dType.o3d_planeXOZ); 
                        // установим плоскость базовой для эскиза
                        holeSketch.SetPlane(basePlane);
                        // создадим эскиз
                        holeInKadlo.Create();
                        // интерфейс редактора эскиза
                        ksDocument2D sketchEdit = (ksDocument2D)holeSketch.BeginEdit();
                        //КРУГ
                        if (circle == true)
                        {  
                            sketchEdit.ksCircle(1, -kadloHeight / 2, radiusHole, 1);
                        }
                        if (square == true)
                        {
                            sketchEdit.ksLineSeg(1 - squareSide / 2, -kadloHeight / 2 - squareSide / 2, 1 - squareSide / 2, -kadloHeight / 2 + squareSide / 2, 1);
                            sketchEdit.ksLineSeg(1 - squareSide / 2, -kadloHeight / 2 + squareSide / 2, 1 + squareSide / 2, -kadloHeight / 2 + squareSide / 2, 1);
                            sketchEdit.ksLineSeg(1 + squareSide / 2, -kadloHeight / 2 + squareSide / 2, 1 + squareSide / 2, -kadloHeight / 2 - squareSide / 2, 1);
                            sketchEdit.ksLineSeg(1 + squareSide / 2, -kadloHeight / 2 - squareSide / 2, 1 - squareSide / 2, -kadloHeight / 2 - squareSide / 2, 1);
                        }
                        //ТРЕУГОЛЬНИК
                        if (triangle == true)
                        {
                        var triangleHeight = Math.Sqrt(3) / 2 * triangleSide;
                        sketchEdit.ksLineSeg(1, -kadloHeight / 2, 1 - triangleSide / 2, -kadloHeight / 2 + triangleHeight, 1);
                        sketchEdit.ksLineSeg(1 - triangleSide / 2, -kadloHeight / 2 + triangleHeight, 1 + triangleSide / 2, -kadloHeight / 2 + triangleHeight, 1);
                        sketchEdit.ksLineSeg(1 + triangleSide / 2, -kadloHeight / 2 + triangleHeight, 1, -kadloHeight / 2, 1);
                        }
                        // завершение редактирования эскиза
                        holeSketch.EndEdit(); 
                        ksEntity entityHoleCutExtr = (ksEntity)_part.NewEntity((short)Obj3dType.o3d_cutExtrusion);
                        if (entityHoleCutExtr != null)
                        {
                            ksCutExtrusionDefinition cutExtrDef = (ksCutExtrusionDefinition)entityHoleCutExtr.GetDefinition();
                            if (cutExtrDef != null)
                            {
                                cutExtrDef.cut = true;
                                cutExtrDef.directionType = (short)Direction_Type.dtNormal;
                                cutExtrDef.SetSideParam(true, (short)End_Type.etThroughAll);
                                cutExtrDef.SetSketch(holeSketch);
                                entityHoleCutExtr.Create();
                            }
                        } 
                    }
                }
            }
        }
      
        ///<summary>
        ///Создание подструнника
        ///</summary>
        private void CreateSnare(bool ExistSnare, int stringSnare, double kadloRadius, double thicknessBottomDrumhead)
        {
            // Проверка на существование компонента сборки
            if (_part != null)  
            {
                // создадим новый эскиз
                var SnareSketch = (ksEntity)_part.NewEntity((short)Obj3dType.o3d_sketch);
                if (SnareSketch != null)
                {
                    // Получение интерфейса свойств эскиза
                    var definitionSnare = (ksSketchDefinition)SnareSketch.GetDefinition();
                    if (definitionSnare != null)
                    {
                        // Получение интерфейса базовой плоскости XOY
                        var basePlane = (ksEntity)_part.GetDefaultEntity((short)Obj3dType.o3d_planeXOY); 
                        ksEntity entityOffsetPlane = _part.NewEntity((short)Obj3dType.o3d_planeOffset);
                        ksPlaneOffsetDefinition offsetDef = (ksPlaneOffsetDefinition)entityOffsetPlane.GetDefinition();
                        offsetDef.offset = thicknessBottomDrumhead;
                        offsetDef.direction = false;
                        offsetDef.SetPlane(basePlane);
                        // создаем смещенную плоскость
                        entityOffsetPlane.Create(); 
                        ksEntity snare = (ksEntity)_part.NewEntity((short)Obj3dType.o3d_sketch);
                        var defSnare = (ksSketchDefinition)snare.GetDefinition();
                        defSnare.SetPlane(offsetDef);
                        snare.Create();
                        ksDocument2D SnareEdit = (ksDocument2D)defSnare.BeginEdit();
                        // Рисуем основание подструнника
                        SnareEdit.ksLineSeg(-15, kadloRadius - 5, 15, kadloRadius - 5, 1);
                        SnareEdit.ksLineSeg(15, kadloRadius - 5, 15, kadloRadius - 10, 1);
                        SnareEdit.ksLineSeg(15, kadloRadius - 10, -15, kadloRadius - 10, 1);
                        SnareEdit.ksLineSeg(-15, kadloRadius - 10, -15, kadloRadius - 5, 1);

                        SnareEdit.ksLineSeg(-15, -kadloRadius + 5, 15, -kadloRadius + 5, 1);
                        SnareEdit.ksLineSeg(15, -kadloRadius + 5, 15, -kadloRadius + 10, 1);
                        SnareEdit.ksLineSeg(15, -kadloRadius + 10, -15, -kadloRadius + 10, 1);
                        SnareEdit.ksLineSeg(-15, -kadloRadius + 10, -15, -kadloRadius + 5, 1);

                        defSnare.EndEdit();

                        // Выдавливание подструнника
                        ksEntity entityBossExtr3 = (ksEntity)_part.NewEntity((short)Obj3dType.o3d_bossExtrusion);
                        if (entityBossExtr3 != null)
                        {
                            ksBossExtrusionDefinition bossExtrDef3 = (ksBossExtrusionDefinition)entityBossExtr3.GetDefinition();
                            if (bossExtrDef3 != null)
                            {
                                // интерфейс структуры параметров выдавливания
                                ksExtrusionParam extrProp3 = (ksExtrusionParam)bossExtrDef3.ExtrusionParam(); 
                                if (extrProp3 != null)
                                {
                                    // эскиз операции выдавливания
                                    bossExtrDef3.SetSketch(snare); 
                                    // направление выдавливания (обратное)
                                    extrProp3.direction = (short)Direction_Type.dtReverse;      
                                    // тип выдавливания (строго на глубину)
                                    extrProp3.typeReverse = (short)End_Type.etBlind;     
                                    // глубина выдавливания 
                                    extrProp3.depthReverse = 4;       
                                    // создадим операцию
                                    entityBossExtr3.Create();                
                                }
                            }
                        }
                        // Создание струн подструнника
                        var StringSketch = (ksEntity)_part.NewEntity((short)Obj3dType.o3d_sketch);
                        if (StringSketch != null)
                        {
                            // Получение интерфейса свойств эскиза
                            var definitionString = (ksSketchDefinition)StringSketch.GetDefinition(); 
                            if (definitionString != null)
                            {
                                // Получение интерфейса базовой плоскости XOZ
                                var stringPlane = (ksEntity)_part.GetDefaultEntity((short)Obj3dType.o3d_planeXOZ); 
                                ksEntity stSnare = (ksEntity)_part.NewEntity((short)Obj3dType.o3d_sketch);
                                var defStringSnare = (ksSketchDefinition)stSnare.GetDefinition();
                                defStringSnare.SetPlane(stringPlane);
                                stSnare.Create();
                                ksDocument2D stringSnareEdit = (ksDocument2D)defStringSnare.BeginEdit();
                                // В ряд рисуются круги (сечение струн)
                                int k = 1;
                                for (double x = -11; x < 12; x += 3)
                                {
                                   stringSnareEdit.ksCircle(x, thicknessBottomDrumhead + 2, 1, 1);
                                    if (k < stringSnare)
                                    {
                                        k++;
                                    }
                                    else break;
                                }
                                defStringSnare.EndEdit();

                                // Выдавливание струн подструнника
                                ksEntity entityBossExtr4 = (ksEntity)_part.NewEntity((short)Obj3dType.o3d_bossExtrusion);
                                if (entityBossExtr4 != null)
                                {
                                    ksBossExtrusionDefinition bossExtrDef3 = (ksBossExtrusionDefinition)entityBossExtr4.GetDefinition();
                                    if (bossExtrDef3 != null)
                                    {
                                        // интерфейс структуры параметров выдавливания
                                        ksExtrusionParam extrProp3 = (ksExtrusionParam)bossExtrDef3.ExtrusionParam(); 
                                        if (extrProp3 != null)
                                        {
                                            // эскиз операции выдавливания
                                            bossExtrDef3.SetSketch(stSnare); 
                                            // направление выдавливания (обе стороны)
                                            extrProp3.direction = (short)Direction_Type.dtBoth;    
                                            // тип выдавливания (до ближайшей поверхности)
                                            extrProp3.typeReverse = (short)End_Type.etUpToNearSurface;     
                                            extrProp3.typeNormal = (short)End_Type.etUpToNearSurface; 
                                            // создадим операцию
                                            entityBossExtr4.Create();                
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }    
        }
    }
}