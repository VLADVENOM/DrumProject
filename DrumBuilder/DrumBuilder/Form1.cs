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
    public partial class Form1 : Form
    {
        private DrumBuilder obj = new DrumBuilder();
        private DrumDescription _description = new DrumDescription();
        public Form1()
        {
            InitializeComponent();
            //Скрытие label
            LabelHiding();
           

        } 
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.kadloHeight = new System.Windows.Forms.ComboBox();
            this.kadloDiameter = new System.Windows.Forms.ComboBox();
            this.kadloThickness = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
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
            this.triangleSide = new System.Windows.Forms.ComboBox();
            this.squareSide = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.triangle = new System.Windows.Forms.RadioButton();
            this.square = new System.Windows.Forms.RadioButton();
            this.Circle = new System.Windows.Forms.RadioButton();
            this.diametrHole = new System.Windows.Forms.ComboBox();
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
            this.kadloHeight.SelectedIndexChanged += new System.EventHandler(this.kadloHeight_SelectedIndexChanged);
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
            this.kadloThickness.SelectedIndexChanged += new System.EventHandler(this.kadloThickness_SelectedIndexChanged);
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
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Ширина";
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
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(269, 407);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(270, 42);
            this.button1.TabIndex = 6;
            this.button1.Text = "Построить модель";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
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
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Location = new System.Drawing.Point(3, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(545, 468);
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
            this.groupBox7.Size = new System.Drawing.Size(270, 100);
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
            this.stringSnare.SelectedIndexChanged += new System.EventHandler(this.stringSnare_SelectedIndexChanged);
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
            this.numberMounting.SelectedIndexChanged += new System.EventHandler(this.numberMounting_SelectedIndexChanged);
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
            this.groupBox5.Location = new System.Drawing.Point(9, 388);
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
            this.rimHeight.SelectedIndexChanged += new System.EventHandler(this.rimHeight_SelectedIndexChanged);
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
            this.rimWidth.SelectedIndexChanged += new System.EventHandler(this.rimWidth_SelectedIndexChanged);
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
            this.groupBox4.Location = new System.Drawing.Point(9, 314);
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
            this.thicknessBottomDrumhead.SelectedIndexChanged += new System.EventHandler(this.thicknessBottomDrumhead_SelectedIndexChanged);
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
            this.thicknessTopDrumhead.SelectedIndexChanged += new System.EventHandler(this.thicknessTopDrumhead_SelectedIndexChanged);
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
            this.groupBox3.Controls.Add(this.triangleSide);
            this.groupBox3.Controls.Add(this.squareSide);
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.triangle);
            this.groupBox3.Controls.Add(this.square);
            this.groupBox3.Controls.Add(this.Circle);
            this.groupBox3.Controls.Add(this.diametrHole);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Location = new System.Drawing.Point(9, 129);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(254, 179);
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
            // triangleSide
            // 
            this.triangleSide.FormattingEnabled = true;
            this.triangleSide.Items.AddRange(new object[] {
            "10",
            "15",
            ""});
            this.triangleSide.Location = new System.Drawing.Point(124, 152);
            this.triangleSide.Name = "triangleSide";
            this.triangleSide.Size = new System.Drawing.Size(121, 21);
            this.triangleSide.TabIndex = 8;
            // 
            // squareSide
            // 
            this.squareSide.FormattingEnabled = true;
            this.squareSide.Items.AddRange(new object[] {
            "10",
            "15"});
            this.squareSide.Location = new System.Drawing.Point(124, 125);
            this.squareSide.Name = "squareSide";
            this.squareSide.Size = new System.Drawing.Size(121, 21);
            this.squareSide.TabIndex = 7;
            this.squareSide.SelectedIndexChanged += new System.EventHandler(this.squareSide_SelectedIndexChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(0, 155);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(121, 13);
            this.label17.TabIndex = 6;
            this.label17.Text = "Сторона треугольника";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(11, 128);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(99, 13);
            this.label16.TabIndex = 5;
            this.label16.Text = "Сторона крадрата";
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
            // square
            // 
            this.square.AutoSize = true;
            this.square.Location = new System.Drawing.Point(184, 44);
            this.square.Name = "square";
            this.square.Size = new System.Drawing.Size(67, 17);
            this.square.TabIndex = 3;
            this.square.Text = "Квадрат";
            this.square.UseVisualStyleBackColor = true;
            this.square.CheckedChanged += new System.EventHandler(this.square_CheckedChanged);
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
            // diametrHole
            // 
            this.diametrHole.FormattingEnabled = true;
            this.diametrHole.Items.AddRange(new object[] {
            "10",
            "12"});
            this.diametrHole.Location = new System.Drawing.Point(124, 93);
            this.diametrHole.Name = "diametrHole";
            this.diametrHole.Size = new System.Drawing.Size(121, 21);
            this.diametrHole.TabIndex = 1;
            this.diametrHole.SelectedIndexChanged += new System.EventHandler(this.diametrHole_SelectedIndexChanged);
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
            this.label8.Size = new System.Drawing.Size(84, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Диаметр круга";
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
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(553, 486);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
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
        private void button1_Click(object sender, EventArgs e)
        {
            obj.BuildDrum(_description);
        }

        private void kadloHeight_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChoiseKadloHeight();
        }
        private void ChoiseKadloHeight()
        {
            switch(kadloHeight.SelectedIndex)
            {
                case 0:
                    _description.KadloHeight = 75;
                    break;
                case 1:
                    _description.KadloHeight = 85;
                    break;
            }
        }
        private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(((ComboBox)sender).Name)
            {
                case "kadloDiameter":
                    _description.KadloDiameter = Double.Parse(((ComboBox)sender).SelectedItem.ToString());
                    break;
                case "kadloDiameter1":
                    _description.KadloDiameter = Double.Parse(((ComboBox)sender).SelectedItem.ToString());
                    break;
            }
        }

        private void ChoiseKadloDiameter()
        {
            switch(kadloDiameter.SelectedIndex)
            {
                case 0:
                    _description.KadloDiameter = 150;
                    break;
                case 1:
                    _description.KadloDiameter = 160;
                    break;
            }
        }

        private void kadloThickness_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChoiseKadloThicness();
        }
        private void ChoiseKadloThicness()
        {
            switch(kadloThickness.SelectedIndex)
            {
                case 0:
                    _description.KadloThickness = 10;
                    break;
                case 1:
                    _description.KadloThickness = 12;
                    break;
            }
        }

        private void thicknessTopDrumhead_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChoiseThicknessTopDrumhead();
        }

        private void ChoiseThicknessTopDrumhead()
        {
            switch (thicknessTopDrumhead.SelectedIndex)
            {
                case 0:
                    _description.ThicknessTopDrumhead = 1;
                    break;
                case 1:
                    _description.ThicknessTopDrumhead = 2;
                    break;
            }
        }

        private void thicknessBottomDrumhead_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChoiseThicknessBottomDrumhead();
        }

        private void ChoiseThicknessBottomDrumhead()
        {
            switch (thicknessBottomDrumhead.SelectedIndex)
            {
                case 0:
                    _description.ThicknessBottomDrumhead = 1;
                    break;
                case 1:
                    _description.ThicknessBottomDrumhead = 2;
                    break;
            }
        }

        private void rimWidth_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChoiseRimWidth();
        }

        private void ChoiseRimWidth()
        {
            switch (rimWidth.SelectedIndex)
            {
                case 0:
                    _description.RimWidth = 15;
                    break;
                case 1:
                    _description.RimWidth = 20;
                    break;
            }
        }

        private void rimHeight_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChoiseRimHeight();
        }

        private void ChoiseRimHeight()
        {
            switch (rimHeight.SelectedIndex)
            {
                case 0:
                    _description.RimHeight = 10;
                    break;
                case 1:
                    _description.RimHeight = 20;
                    break;
            }
        }

        private void numberMounting_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChoiseNumberMounting();
        }
        private void ChoiseNumberMounting()
        {
            switch (numberMounting.SelectedIndex)
            {
                case 0:
                    _description.NumberMounting = 8;
                    break;
                case 1:
                    _description.NumberMounting = 10;
                    break;
            }
        }

        private void diametrHole_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChoiseDiametrHole();
        }
        private void ChoiseDiametrHole()
        { 
            switch (diametrHole.SelectedIndex)
            {
                case 0:
                    _description.diametrHole = 10;
                    break;
                case 1:
                    _description.diametrHole = 12;
                    break;
            }
        }
        private void LabelHiding()
        {
            label7.Visible = false;
            label8.Visible = false;
            label16.Visible = false;
            label17.Visible = false;
            Circle.Visible = false;
            square.Visible = false;
            triangle.Visible = false;
            diametrHole.Visible = false;
            squareSide.Visible = false;
            triangleSide.Visible = false;
            label15.Visible = false;
            stringSnare.Visible = false;
        }
        private void LabelShowing()
        {
            label7.Visible = true;
            Circle.Visible = true;
            square.Visible = true;
            triangle.Visible = true;
        }

        private void squareSide_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChoiseSquareSide();
        }
        private void ChoiseSquareSide()
        {
            switch (squareSide.SelectedIndex)
            {
                case 0:
                    _description.squareSide = 10;
                    break;
                case 1:
                    _description.squareSide = 15;
                    break;
            }
        }
        private void triangleSide_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChoiseTriangleSide();
        }
        private void ChoiseTriangleSide()
        {
            switch (triangleSide.SelectedIndex)
            {
                case 0:
                    _description.triangleSide = 10;
                    break;
                case 1:
                    _description.triangleSide = 15;
                    break;
            }
        }

        private void ExistHoleInKadlo_CheckedChanged(object sender, EventArgs e)
        {
            if (ExistHoleInKadlo.Checked) 
            {
                LabelShowing();
                _description.ExistHoleInKadlo = true;
            }
            else 
            {
                LabelHiding();
                _description.ExistHoleInKadlo = false;
            }
        }

        private void Circle_CheckedChanged(object sender, EventArgs e)
        {
            if (Circle.Checked)
            {
                label8.Visible = true;
                diametrHole.Visible = true;
                _description.circle = true;
            }
            else
            {
                label8.Visible = false;
                diametrHole.Visible = false;
                _description.circle = false;
            }
        }

        private void square_CheckedChanged(object sender, EventArgs e)
        {
            if (square.Checked)
            {
                label16.Visible = true;
                squareSide.Visible = true;
                _description.square = true;
            }
            else
            {
                label16.Visible = false;
                squareSide.Visible = false;
                _description.square = false;
            }
        }

        private void triangle_CheckedChanged(object sender, EventArgs e)
        {
            if (triangle.Checked)
            {
                label17.Visible = true;
                triangleSide.Visible = true;
            }
            else
            {
                label17.Visible = false;
                triangleSide.Visible = false;
            }
        }

        private void ExistSnare_CheckedChanged(object sender, EventArgs e)
        {
            if (ExistSnare.Checked)
            {
                label15.Visible = true;
                stringSnare.Visible = true;
                _description.ExistSnare = true;
            }
            else
            {
                label15.Visible = false;
                stringSnare.Visible = false;
                _description.ExistSnare = false;
            }
        }

        private void stringSnare_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChoiseStringSnare();
        }
        private void ChoiseStringSnare()
        {
            switch (stringSnare.SelectedIndex)
            {
                case 0:
                    _description.stringSnare = 6;
                    break;
                case 1:
                    _description.stringSnare = 8;
                    break;
            }
        }
    }
}