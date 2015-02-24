using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrumBuilder
{
    /// <summary>
    /// Класс - форма
    /// </summary>
    public partial class DrumForm : Form
    {
        ///<summary>
        ///Создание экземпляра класса DrumBuilder
        ///</summary>
        private DrumBuilder obj = new DrumBuilder();

        ///<summary>
        ///Создание экземпляра класса DrumDescription
        ///</summary>
        private DrumDescription _description = new DrumDescription();

        ///<summary>
        ///Конструктор формы
        ///</summary>
        public DrumForm()
        {
            InitializeComponent();
            //Скрытие label
            LabelHiding();
        } 
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DrumForm));
            this.kadloHeight = new System.Windows.Forms.ComboBox();
            this.kadloDiameter = new System.Windows.Forms.ComboBox();
            this.kadloThickness = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.BuildModel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.ExistSnare = new System.Windows.Forms.CheckBox();
            this.stringSnare = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.numberMounting = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.rimHeight = new System.Windows.Forms.ComboBox();
            this.rimWidth = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.thicknessBottomDrumhead = new System.Windows.Forms.ComboBox();
            this.thicknessTopDrumhead = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.ExistHoleInKadlo = new System.Windows.Forms.CheckBox();
            this.label18 = new System.Windows.Forms.Label();
            this.triangle = new System.Windows.Forms.RadioButton();
            this.Square = new System.Windows.Forms.RadioButton();
            this.Circle = new System.Windows.Forms.RadioButton();
            this.comboboxHole = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox7.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // kadloHeight
            // 
            this.kadloHeight.FormattingEnabled = true;
            this.kadloHeight.Items.AddRange(new object[] {
            "75",
            "85"});
            this.kadloHeight.Location = new System.Drawing.Point(124, 19);
            this.kadloHeight.Name = "kadloHeight";
            this.kadloHeight.Size = new System.Drawing.Size(121, 21);
            this.kadloHeight.TabIndex = 0;
            this.kadloHeight.SelectedIndexChanged += new System.EventHandler(this.comboBox_SelectedIndexChanged);
            // 
            // kadloDiameter
            // 
            this.kadloDiameter.FormattingEnabled = true;
            this.kadloDiameter.Items.AddRange(new object[] {
            "150",
            "160"});
            this.kadloDiameter.Location = new System.Drawing.Point(124, 48);
            this.kadloDiameter.Name = "kadloDiameter";
            this.kadloDiameter.Size = new System.Drawing.Size(121, 21);
            this.kadloDiameter.TabIndex = 1;
            this.kadloDiameter.SelectedIndexChanged += new System.EventHandler(this.comboBox_SelectedIndexChanged);
            // 
            // kadloThickness
            // 
            this.kadloThickness.FormattingEnabled = true;
            this.kadloThickness.Items.AddRange(new object[] {
            "10",
            "12"});
            this.kadloThickness.Location = new System.Drawing.Point(124, 75);
            this.kadloThickness.Name = "kadloThickness";
            this.kadloThickness.Size = new System.Drawing.Size(121, 21);
            this.kadloThickness.TabIndex = 2;
            this.kadloThickness.SelectedIndexChanged += new System.EventHandler(this.comboBox_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Высота";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Диаметр";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 80);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Толщина";
            // 
            // BuildModel
            // 
            this.BuildModel.Location = new System.Drawing.Point(270, 368);
            this.BuildModel.Name = "BuildModel";
            this.BuildModel.Size = new System.Drawing.Size(270, 42);
            this.BuildModel.TabIndex = 6;
            this.BuildModel.Text = "Построить модель";
            this.BuildModel.UseVisualStyleBackColor = true;
            this.BuildModel.Click += new System.EventHandler(this.BuildModel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.groupBox7);
            this.groupBox1.Controls.Add(this.groupBox6);
            this.groupBox1.Controls.Add(this.groupBox5);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.BuildModel);
            this.groupBox1.Location = new System.Drawing.Point(3, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(545, 425);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Параметры барабана";
            // 
            // pictureBox1
            // 
            this.pictureBox1.ErrorImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.ErrorImage")));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(269, 19);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(270, 200);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.ExistSnare);
            this.groupBox7.Controls.Add(this.stringSnare);
            this.groupBox7.Controls.Add(this.label15);
            this.groupBox7.Controls.Add(this.label14);
            this.groupBox7.Location = new System.Drawing.Point(268, 281);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(270, 76);
            this.groupBox7.TabIndex = 12;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Подструнник (6)";
            // 
            // ExistSnare
            // 
            this.ExistSnare.AutoSize = true;
            this.ExistSnare.Location = new System.Drawing.Point(126, 19);
            this.ExistSnare.Name = "ExistSnare";
            this.ExistSnare.Size = new System.Drawing.Size(95, 17);
            this.ExistSnare.TabIndex = 3;
            this.ExistSnare.Text = "Присутствует";
            this.ExistSnare.UseVisualStyleBackColor = true;
            this.ExistSnare.CheckedChanged += new System.EventHandler(this.ExistSnare_CheckedChanged);
            // 
            // stringSnare
            // 
            this.stringSnare.FormattingEnabled = true;
            this.stringSnare.Items.AddRange(new object[] {
            "6",
            "8"});
            this.stringSnare.Location = new System.Drawing.Point(122, 44);
            this.stringSnare.Name = "stringSnare";
            this.stringSnare.Size = new System.Drawing.Size(121, 21);
            this.stringSnare.TabIndex = 2;
            this.stringSnare.SelectedIndexChanged += new System.EventHandler(this.comboBox_SelectedIndexChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 47);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(97, 13);
            this.label15.TabIndex = 1;
            this.label15.Text = "Количество струн";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 20);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(50, 13);
            this.label14.TabIndex = 0;
            this.label14.Text = "Наличие";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.numberMounting);
            this.groupBox6.Controls.Add(this.label13);
            this.groupBox6.Location = new System.Drawing.Point(270, 225);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(269, 50);
            this.groupBox6.TabIndex = 11;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Крепления (5)";
            // 
            // numberMounting
            // 
            this.numberMounting.FormattingEnabled = true;
            this.numberMounting.Items.AddRange(new object[] {
            "8",
            "10"});
            this.numberMounting.Location = new System.Drawing.Point(124, 16);
            this.numberMounting.Name = "numberMounting";
            this.numberMounting.Size = new System.Drawing.Size(121, 21);
            this.numberMounting.TabIndex = 1;
            this.numberMounting.SelectedIndexChanged += new System.EventHandler(this.comboBox_SelectedIndexChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(11, 19);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(66, 13);
            this.label13.TabIndex = 0;
            this.label13.Text = "Количество";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.rimHeight);
            this.groupBox5.Controls.Add(this.rimWidth);
            this.groupBox5.Controls.Add(this.label12);
            this.groupBox5.Controls.Add(this.label11);
            this.groupBox5.Location = new System.Drawing.Point(9, 336);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(254, 74);
            this.groupBox5.TabIndex = 10;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Обода (4)";
            // 
            // rimHeight
            // 
            this.rimHeight.FormattingEnabled = true;
            this.rimHeight.Items.AddRange(new object[] {
            "15",
            "20"});
            this.rimHeight.Location = new System.Drawing.Point(124, 42);
            this.rimHeight.Name = "rimHeight";
            this.rimHeight.Size = new System.Drawing.Size(121, 21);
            this.rimHeight.TabIndex = 3;
            this.rimHeight.SelectedIndexChanged += new System.EventHandler(this.comboBox_SelectedIndexChanged);
            // 
            // rimWidth
            // 
            this.rimWidth.FormattingEnabled = true;
            this.rimWidth.Items.AddRange(new object[] {
            "10",
            "15"});
            this.rimWidth.Location = new System.Drawing.Point(124, 15);
            this.rimWidth.Name = "rimWidth";
            this.rimWidth.Size = new System.Drawing.Size(121, 21);
            this.rimWidth.TabIndex = 2;
            this.rimWidth.SelectedIndexChanged += new System.EventHandler(this.comboBox_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(11, 45);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 13);
            this.label12.TabIndex = 0;
            this.label12.Text = "Толщина";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(11, 18);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(46, 13);
            this.label11.TabIndex = 1;
            this.label11.Text = "Ширина";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.thicknessBottomDrumhead);
            this.groupBox4.Controls.Add(this.thicknessTopDrumhead);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Location = new System.Drawing.Point(9, 263);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(254, 67);
            this.groupBox4.TabIndex = 9;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Пластики (3)";
            // 
            // thicknessBottomDrumhead
            // 
            this.thicknessBottomDrumhead.FormattingEnabled = true;
            this.thicknessBottomDrumhead.Items.AddRange(new object[] {
            "1",
            "2"});
            this.thicknessBottomDrumhead.Location = new System.Drawing.Point(124, 41);
            this.thicknessBottomDrumhead.Name = "thicknessBottomDrumhead";
            this.thicknessBottomDrumhead.Size = new System.Drawing.Size(121, 21);
            this.thicknessBottomDrumhead.TabIndex = 3;
            this.thicknessBottomDrumhead.SelectedIndexChanged += new System.EventHandler(this.comboBox_SelectedIndexChanged);
            // 
            // thicknessTopDrumhead
            // 
            this.thicknessTopDrumhead.FormattingEnabled = true;
            this.thicknessTopDrumhead.Items.AddRange(new object[] {
            "1",
            "2"});
            this.thicknessTopDrumhead.Location = new System.Drawing.Point(124, 14);
            this.thicknessTopDrumhead.Name = "thicknessTopDrumhead";
            this.thicknessTopDrumhead.Size = new System.Drawing.Size(121, 21);
            this.thicknessTopDrumhead.TabIndex = 2;
            this.thicknessTopDrumhead.SelectedIndexChanged += new System.EventHandler(this.comboBox_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(11, 17);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(102, 13);
            this.label9.TabIndex = 1;
            this.label9.Text = "Толщина верхнего";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(11, 44);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(99, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "Толщина нижнего";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.ExistHoleInKadlo);
            this.groupBox3.Controls.Add(this.label18);
            this.groupBox3.Controls.Add(this.triangle);
            this.groupBox3.Controls.Add(this.Square);
            this.groupBox3.Controls.Add(this.Circle);
            this.groupBox3.Controls.Add(this.comboboxHole);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Location = new System.Drawing.Point(9, 129);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(254, 128);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Отверстие в кадле (2)";
            // 
            // ExistHoleInKadlo
            // 
            this.ExistHoleInKadlo.AutoSize = true;
            this.ExistHoleInKadlo.Location = new System.Drawing.Point(127, 18);
            this.ExistHoleInKadlo.Name = "ExistHoleInKadlo";
            this.ExistHoleInKadlo.Size = new System.Drawing.Size(90, 17);
            this.ExistHoleInKadlo.TabIndex = 10;
            this.ExistHoleInKadlo.Text = "Присутсвует";
            this.ExistHoleInKadlo.UseVisualStyleBackColor = true;
            this.ExistHoleInKadlo.CheckedChanged += new System.EventHandler(this.ExistHoleInKadlo_CheckedChanged);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(11, 19);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(99, 13);
            this.label18.TabIndex = 9;
            this.label18.Text = "Наличие отвестия";
            // 
            // triangle
            // 
            this.triangle.AutoSize = true;
            this.triangle.Location = new System.Drawing.Point(127, 67);
            this.triangle.Name = "triangle";
            this.triangle.Size = new System.Drawing.Size(90, 17);
            this.triangle.TabIndex = 4;
            this.triangle.Text = "Треугольник";
            this.triangle.UseVisualStyleBackColor = true;
            this.triangle.CheckedChanged += new System.EventHandler(this.triangle_CheckedChanged);
            // 
            // Square
            // 
            this.Square.AutoSize = true;
            this.Square.Location = new System.Drawing.Point(184, 44);
            this.Square.Name = "Square";
            this.Square.Size = new System.Drawing.Size(67, 17);
            this.Square.TabIndex = 3;
            this.Square.Text = "Квадрат";
            this.Square.UseVisualStyleBackColor = true;
            this.Square.CheckedChanged += new System.EventHandler(this.Square_CheckedChanged);
            // 
            // Circle
            // 
            this.Circle.AutoSize = true;
            this.Circle.Location = new System.Drawing.Point(127, 44);
            this.Circle.Name = "Circle";
            this.Circle.Size = new System.Drawing.Size(48, 17);
            this.Circle.TabIndex = 2;
            this.Circle.Text = "Круг";
            this.Circle.UseVisualStyleBackColor = true;
            this.Circle.CheckedChanged += new System.EventHandler(this.Circle_CheckedChanged);
            // 
            // comboboxHole
            // 
            this.comboboxHole.FormattingEnabled = true;
            this.comboboxHole.Location = new System.Drawing.Point(124, 93);
            this.comboboxHole.Name = "comboboxHole";
            this.comboboxHole.Size = new System.Drawing.Size(121, 21);
            this.comboboxHole.TabIndex = 1;
            this.comboboxHole.SelectedIndexChanged += new System.EventHandler(this.comboBox_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 46);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Вид отверстия";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(11, 96);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(113, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Параметр отверстия";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.kadloThickness);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.kadloHeight);
            this.groupBox2.Controls.Add(this.kadloDiameter);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(9, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(254, 104);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Кадло (1)";
            // 
            // DrumForm
            // 
            this.ClientSize = new System.Drawing.Size(553, 436);
            this.Controls.Add(this.groupBox1);
            this.Name = "DrumForm";
            this.Text = "Drum";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        ///<summary>
        /// Обработчик нажатия на кнопку построить
        ///</summary> 
        private void BuildModel_Click(object sender, EventArgs e)
        {
            obj.BuildDrum(_description);
        }

        ///<summary>
        /// Процедура выбора значения паравметров из комбобоксов
        ///</summary>
        private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(((ComboBox)sender).Name)
            {
                    // Выбор значения диаметра кадла
                case "kadloDiameter":
                    _description.KadloDiameter = Double.Parse(((ComboBox)sender).SelectedItem.ToString());
                    break;
                // Выбор значения высоты кадла
                case "kadloHeight":
                    _description.KadloHeight= Double.Parse(((ComboBox)sender).SelectedItem.ToString());
                    break;
                // Выбор значения толщины кадла
                case "kadloThickness":
                    _description.KadloThickness = Double.Parse(((ComboBox)sender).SelectedItem.ToString());
                    break;
                // Выбор значения толщины верхнего пластика
                case "thicknessTopDrumhead":
                    _description.ThicknessTopDrumhead = Double.Parse(((ComboBox)sender).SelectedItem.ToString());
                    break;
                // Выбор значения толщины нижнего пластика
                case "thicknessBottomDrumhead":
                    _description.ThicknessBottomDrumhead = Double.Parse(((ComboBox)sender).SelectedItem.ToString());
                    break;
                // Выбор значения ширины обода
                case "rimWidth":
                    _description.RimWidth = Double.Parse(((ComboBox)sender).SelectedItem.ToString());
                    break;
                // Выбор значения высоты обода
                case "rimHeight":
                    _description.RimHeight = Double.Parse(((ComboBox)sender).SelectedItem.ToString());
                    break;
                // Выбор значения количества креплений
                case "numberMounting":
                    _description.NumberMounting = int.Parse(((ComboBox)sender).SelectedItem.ToString());
                    break;
                // Выбор значения количества струн подструнника
                case "stringSnare":
                    _description.StringSnare = int.Parse(((ComboBox)sender).SelectedItem.ToString());
                    break;
                // Выбор значения диаметр отверстия в кадле
                case "diametrHole":
                    _description.DiametrHole = Double.Parse(((ComboBox)sender).SelectedItem.ToString());
                    break;
                // Выбор значения стороны квадрата отвестия в кадле
                case "squareSide":
                    _description.SquareSide = Double.Parse(((ComboBox)sender).SelectedItem.ToString());
                    break;      
            }
        }

        /// <summary>
        /// Скрытие лэйблов и комбобоксов необязательных (дополнительных) параметров
        /// </summary>
        private void LabelHiding()
        {
            label7.Visible = false;
            label8.Visible = false;
            Circle.Visible = false;
            Square.Visible = false;
            triangle.Visible = false;
            comboboxHole.Visible = false;
            label15.Visible = false;
            stringSnare.Visible = false;
        }

        /// <summary>
        /// Выбор дополнительного параметра "Отверстие в кадле", при котором показываются параметры вида отверстия
        /// </summary>
        private void ExistHoleInKadlo_CheckedChanged(object sender, EventArgs e)
        {
            _description.ExistHoleInKadlo = ExistHoleInKadlo.Checked;
            label7.Visible = ExistHoleInKadlo.Checked;
            Circle.Visible = ExistHoleInKadlo.Checked;
            Square.Visible = ExistHoleInKadlo.Checked;
            triangle.Visible = ExistHoleInKadlo.Checked;
        }

        /// <summary>
        /// Выбор дополнительного параметра "Форма отверстия в кадле Круг", при котором появляется выбор диаметра отверстия
        /// </summary>
        private void Circle_CheckedChanged(object sender, EventArgs e)
        {
            label8.Text = "Диаметр";
            label8.Visible = Circle.Checked;
            comboboxHole.Name = "diametrHole";
            comboboxHole.Items.Clear();
            comboboxHole.Items.AddRange(new [] {"10" ,"15", "20", "25"});
            comboboxHole.Visible = Circle.Checked;
            _description.Circle = Circle.Checked; 
        }

        /// <summary>
        /// Выбор дополнительного параметра "Форма отверстия в кадле Квадрат", при котором появляется выбор стороны квадрата
        /// </summary>
        private void Square_CheckedChanged(object sender, EventArgs e)
        {
            label8.Text = "Сторона квадрата";
            label8.Visible = Square.Checked;
            comboboxHole.Name = "squareSide";
            comboboxHole.Items.Clear();
            comboboxHole.Items.AddRange(new[] { "10", "15", "20" });
            comboboxHole.Visible = Square.Checked;
            _description.Square = Square.Checked;
        }

        /// <summary>
        /// Выбор дополнительного параметра "Форма отверстия в кадле Треугольник", при котором появляется выбор стороны треугольника
        /// </summary>
        private void triangle_CheckedChanged(object sender, EventArgs e)
        {
            label8.Text = "Сторона треугольника";
            label8.Visible = triangle.Checked;
            comboboxHole.Name = "squareSide";
            comboboxHole.Items.Clear();
            comboboxHole.Items.AddRange(new[] { "10", "15", "20" });
            comboboxHole.Visible = triangle.Checked;
            
        }

        /// <summary>
        /// Выбор дополнительного параметра "Наличие пострунника", при котором появляется выбор количества струн в подструннике
        /// </summary>
        private void ExistSnare_CheckedChanged(object sender, EventArgs e)
        {
            label15.Visible = ExistSnare.Checked;
            stringSnare.Visible = ExistSnare.Checked;
            _description.ExistSnare = ExistSnare.Checked;
        }
    }
}