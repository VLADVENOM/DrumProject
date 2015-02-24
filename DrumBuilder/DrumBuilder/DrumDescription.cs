using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrumBuilder
{
        /// <summary>
        /// Класс хранящий параметры детали
        /// </summary>
        public class DrumDescription
        {
            /// <summary>
            /// Наличие подструнника
            /// </summary>
            public bool ExistSnare = false;

            /// <summary>
            /// Наличие отверстия в кадле
            /// </summary>
            public bool ExistHoleInKadlo = false;

            /// <summary>
            /// Вид отверстия круг
            /// </summary>
            public bool Circle = false;

            /// <summary>
            /// Вид отверстия квадрат
            /// </summary>
            public bool Square = false;

            /// <summary>
            /// Вид отверстия треугольник
            /// </summary>
            public bool Triangle = false;

            /// <summary>
            /// Диаметр кадла
            /// </summary>
            public double KadloDiameter
            {  get; set ; }

            /// <summary>
            /// Высота кадла
            /// </summary>
            public double KadloHeight
            {  get; set; }
            

            /// <summary>
            /// Толщина кадла
            /// </summary>
            public double KadloThickness
            {  get;  set; }
            
            /// <summary>
            /// Высота обода
            /// </summary>
            public double RimHeight
            { get; set; }

            /// <summary>
            /// Ширина обода
            /// </summary>
            public double RimWidth
            { get; set; }

            /// <summary>
            /// Толщина нижнего пластика
            /// </summary>
            public double ThicknessBottomDrumhead
            {  get; set; }
           

            /// <summary>
            /// Толщина верхнего пластика
            /// </summary>
            public double ThicknessTopDrumhead
            {  get; set; }
            
            /// <summary>
            /// Количество креплений
            /// </summary>
            public int NumberMounting
            { get; set; }

            
          
            /// <summary>
            /// Диаметр отверстия в кадле
            /// </summary>
            public double DiametrHole
            { get; set; }

            /// <summary>
            /// Сторона квадратного отверстия в кадле
            /// </summary>
            public double SquareSide
            { get; set; }
            
            /// <summary>
            /// Сторона треугольного отвестия в кадле
            /// </summary>
            public double triangleSide
            { get;  set ; }
            
            /// <summary>
            /// Количество струн подструнника
            /// </summary>
            public int StringSnare
            { get;  set; }
            
        }
}

