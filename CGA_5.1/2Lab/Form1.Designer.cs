namespace WindowsApplication4
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Scene = new Tao.Platform.Windows.SimpleOpenGlControl();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.xlabel = new System.Windows.Forms.Label();
            this.xtrackBar = new System.Windows.Forms.TrackBar();
            this.ytrackBar = new System.Windows.Forms.TrackBar();
            this.ylabel = new System.Windows.Forms.Label();
            this.ztrackBar = new System.Windows.Forms.TrackBar();
            this.zlabel = new System.Windows.Forms.Label();
            this.anglelabel = new System.Windows.Forms.Label();
            this.zoomtrackBar = new System.Windows.Forms.TrackBar();
            this.zoomlabel = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.d_numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.m_numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.n_numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.загрузитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.angletrackBar = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.xtrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ytrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ztrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zoomtrackBar)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.d_numericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_numericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.n_numericUpDown)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.angletrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // Scene
            // 
            this.Scene.AccumBits = ((byte)(0));
            this.Scene.AutoCheckErrors = false;
            this.Scene.AutoFinish = false;
            this.Scene.AutoMakeCurrent = true;
            this.Scene.AutoSwapBuffers = true;
            this.Scene.BackColor = System.Drawing.Color.Black;
            this.Scene.ColorBits = ((byte)(32));
            this.Scene.DepthBits = ((byte)(16));
            this.Scene.Location = new System.Drawing.Point(18, 41);
            this.Scene.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Scene.Name = "Scene";
            this.Scene.Size = new System.Drawing.Size(662, 628);
            this.Scene.StencilBits = ((byte)(0));
            this.Scene.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(8, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Axis";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Pot";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(21, 419);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(76, 24);
            this.checkBox1.TabIndex = 3;
            this.checkBox1.Text = "Wired";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "X",
            "Y",
            "Z"});
            this.comboBox1.Location = new System.Drawing.Point(8, 59);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(283, 28);
            this.comboBox1.TabIndex = 4;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "Sphere",
            "Сylinder",
            "Cube",
            "Cone"});
            this.comboBox2.Location = new System.Drawing.Point(6, 128);
            this.comboBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(284, 28);
            this.comboBox2.TabIndex = 5;
            // 
            // xlabel
            // 
            this.xlabel.AutoSize = true;
            this.xlabel.Location = new System.Drawing.Point(30, 167);
            this.xlabel.Name = "xlabel";
            this.xlabel.Size = new System.Drawing.Size(16, 20);
            this.xlabel.TabIndex = 6;
            this.xlabel.Text = "x";
            // 
            // xtrackBar
            // 
            this.xtrackBar.LargeChange = 10;
            this.xtrackBar.Location = new System.Drawing.Point(138, 160);
            this.xtrackBar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.xtrackBar.Maximum = 50;
            this.xtrackBar.Minimum = -50;
            this.xtrackBar.Name = "xtrackBar";
            this.xtrackBar.Size = new System.Drawing.Size(231, 69);
            this.xtrackBar.SmallChange = 5;
            this.xtrackBar.TabIndex = 7;
            this.xtrackBar.Scroll += new System.EventHandler(this.xtrackBar_Scroll);
            // 
            // ytrackBar
            // 
            this.ytrackBar.LargeChange = 10;
            this.ytrackBar.Location = new System.Drawing.Point(140, 209);
            this.ytrackBar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ytrackBar.Maximum = 50;
            this.ytrackBar.Minimum = -50;
            this.ytrackBar.Name = "ytrackBar";
            this.ytrackBar.Size = new System.Drawing.Size(231, 69);
            this.ytrackBar.SmallChange = 5;
            this.ytrackBar.TabIndex = 9;
            this.ytrackBar.Scroll += new System.EventHandler(this.ytrackBar_Scroll);
            // 
            // ylabel
            // 
            this.ylabel.AutoSize = true;
            this.ylabel.Location = new System.Drawing.Point(30, 209);
            this.ylabel.Name = "ylabel";
            this.ylabel.Size = new System.Drawing.Size(16, 20);
            this.ylabel.TabIndex = 8;
            this.ylabel.Text = "y";
            // 
            // ztrackBar
            // 
            this.ztrackBar.LargeChange = 10;
            this.ztrackBar.Location = new System.Drawing.Point(138, 259);
            this.ztrackBar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ztrackBar.Maximum = 50;
            this.ztrackBar.Minimum = -50;
            this.ztrackBar.Name = "ztrackBar";
            this.ztrackBar.Size = new System.Drawing.Size(233, 69);
            this.ztrackBar.SmallChange = 5;
            this.ztrackBar.TabIndex = 11;
            this.ztrackBar.Scroll += new System.EventHandler(this.ztrackBar_Scroll);
            // 
            // zlabel
            // 
            this.zlabel.AutoSize = true;
            this.zlabel.Location = new System.Drawing.Point(29, 258);
            this.zlabel.Name = "zlabel";
            this.zlabel.Size = new System.Drawing.Size(17, 20);
            this.zlabel.TabIndex = 10;
            this.zlabel.Text = "z";
            // 
            // anglelabel
            // 
            this.anglelabel.AutoSize = true;
            this.anglelabel.Location = new System.Drawing.Point(30, 318);
            this.anglelabel.Name = "anglelabel";
            this.anglelabel.Size = new System.Drawing.Size(48, 20);
            this.anglelabel.TabIndex = 12;
            this.anglelabel.Text = "angle";
            // 
            // zoomtrackBar
            // 
            this.zoomtrackBar.LargeChange = 10;
            this.zoomtrackBar.Location = new System.Drawing.Point(145, 354);
            this.zoomtrackBar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.zoomtrackBar.Maximum = 50;
            this.zoomtrackBar.Minimum = -50;
            this.zoomtrackBar.Name = "zoomtrackBar";
            this.zoomtrackBar.Size = new System.Drawing.Size(231, 69);
            this.zoomtrackBar.SmallChange = 5;
            this.zoomtrackBar.TabIndex = 15;
            this.zoomtrackBar.Scroll += new System.EventHandler(this.zoomtrackBar_Scroll);
            // 
            // zoomlabel
            // 
            this.zoomlabel.AutoSize = true;
            this.zoomlabel.Location = new System.Drawing.Point(30, 378);
            this.zoomlabel.Name = "zoomlabel";
            this.zoomlabel.Size = new System.Drawing.Size(48, 20);
            this.zoomlabel.TabIndex = 14;
            this.zoomlabel.Text = "zoom";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.button6);
            this.groupBox1.Controls.Add(this.button5);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.d_numericUpDown);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.m_numericUpDown);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.n_numericUpDown);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(687, 41);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(230, 619);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Apple segment";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.checkBox2);
            this.groupBox2.Controls.Add(this.comboBox3);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox2.Location = new System.Drawing.Point(9, 428);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Size = new System.Drawing.Size(213, 152);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Textures segment";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 20);
            this.label3.TabIndex = 13;
            this.label3.Text = "Select object";
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(0, 34);
            this.checkBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(96, 24);
            this.checkBox2.TabIndex = 18;
            this.checkBox2.Text = "Textures";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // comboBox3
            // 
            this.comboBox3.Enabled = false;
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Items.AddRange(new object[] {
            "Apple",
            "Branch",
            "Leaf"});
            this.comboBox3.Location = new System.Drawing.Point(9, 106);
            this.comboBox3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(180, 28);
            this.comboBox3.TabIndex = 17;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(18, 228);
            this.button6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(184, 32);
            this.button6.TabIndex = 11;
            this.button6.Text = "Stop";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button2_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(63, 372);
            this.button5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(95, 35);
            this.button5.TabIndex = 10;
            this.button5.Text = "Down";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.down_button_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(118, 326);
            this.button4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(94, 42);
            this.button4.TabIndex = 9;
            this.button4.Text = "Right";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.right_button_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(0, 326);
            this.button3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(94, 42);
            this.button3.TabIndex = 8;
            this.button3.Text = "Left";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.left_button_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(64, 284);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(94, 38);
            this.button2.TabIndex = 7;
            this.button2.Text = "Up";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.up_button_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(5, 165);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(217, 42);
            this.button1.TabIndex = 7;
            this.button1.Text = "Ok";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // d_numericUpDown
            // 
            this.d_numericUpDown.Location = new System.Drawing.Point(63, 112);
            this.d_numericUpDown.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.d_numericUpDown.Name = "d_numericUpDown";
            this.d_numericUpDown.Size = new System.Drawing.Size(159, 25);
            this.d_numericUpDown.TabIndex = 6;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(24, 115);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(18, 20);
            this.label10.TabIndex = 5;
            this.label10.Text = "d";
            // 
            // m_numericUpDown
            // 
            this.m_numericUpDown.Location = new System.Drawing.Point(63, 71);
            this.m_numericUpDown.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.m_numericUpDown.Name = "m_numericUpDown";
            this.m_numericUpDown.Size = new System.Drawing.Size(159, 25);
            this.m_numericUpDown.TabIndex = 4;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(24, 71);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(22, 20);
            this.label9.TabIndex = 3;
            this.label9.Text = "m";
            // 
            // n_numericUpDown
            // 
            this.n_numericUpDown.Location = new System.Drawing.Point(64, 29);
            this.n_numericUpDown.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.n_numericUpDown.Name = "n_numericUpDown";
            this.n_numericUpDown.Size = new System.Drawing.Size(159, 25);
            this.n_numericUpDown.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(24, 28);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(18, 20);
            this.label8.TabIndex = 0;
            this.label8.Text = "n";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1331, 33);
            this.menuStrip1.TabIndex = 17;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.загрузитьToolStripMenuItem});
            this.toolStripMenuItem1.Enabled = false;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(54, 29);
            this.toolStripMenuItem1.Text = "File";
            // 
            // загрузитьToolStripMenuItem
            // 
            this.загрузитьToolStripMenuItem.Name = "загрузитьToolStripMenuItem";
            this.загрузитьToolStripMenuItem.Size = new System.Drawing.Size(181, 34);
            this.загрузитьToolStripMenuItem.Text = "Load file";
            this.загрузитьToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.angletrackBar);
            this.groupBox3.Controls.Add(this.zoomtrackBar);
            this.groupBox3.Controls.Add(this.ztrackBar);
            this.groupBox3.Controls.Add(this.ytrackBar);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.zoomlabel);
            this.groupBox3.Controls.Add(this.comboBox1);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.anglelabel);
            this.groupBox3.Controls.Add(this.comboBox2);
            this.groupBox3.Controls.Add(this.checkBox1);
            this.groupBox3.Controls.Add(this.xlabel);
            this.groupBox3.Controls.Add(this.xtrackBar);
            this.groupBox3.Controls.Add(this.zlabel);
            this.groupBox3.Controls.Add(this.ylabel);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox3.Location = new System.Drawing.Point(924, 50);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox3.Size = new System.Drawing.Size(378, 619);
            this.groupBox3.TabIndex = 18;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "View";
            // 
            // angletrackBar
            // 
            this.angletrackBar.LargeChange = 10;
            this.angletrackBar.Location = new System.Drawing.Point(145, 306);
            this.angletrackBar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.angletrackBar.Maximum = 360;
            this.angletrackBar.Name = "angletrackBar";
            this.angletrackBar.Size = new System.Drawing.Size(233, 69);
            this.angletrackBar.SmallChange = 5;
            this.angletrackBar.TabIndex = 16;
            this.angletrackBar.Scroll += new System.EventHandler(this.angletrackBar_Scroll_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1331, 678);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Scene);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.xtrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ytrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ztrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zoomtrackBar)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.d_numericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_numericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.n_numericUpDown)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.angletrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Tao.Platform.Windows.SimpleOpenGlControl Scene;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label xlabel;
        private System.Windows.Forms.TrackBar xtrackBar;
        private System.Windows.Forms.TrackBar ytrackBar;
        private System.Windows.Forms.Label ylabel;
        private System.Windows.Forms.TrackBar ztrackBar;
        private System.Windows.Forms.Label zlabel;
        private System.Windows.Forms.Label anglelabel;
        private System.Windows.Forms.TrackBar zoomtrackBar;
        private System.Windows.Forms.Label zoomlabel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NumericUpDown d_numericUpDown;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown m_numericUpDown;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown n_numericUpDown;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem загрузитьToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TrackBar angletrackBar;
    }
}

