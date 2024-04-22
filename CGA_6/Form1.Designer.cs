namespace lab4
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
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.trackBarX = new System.Windows.Forms.TrackBar();
            this.trackBarY = new System.Windows.Forms.TrackBar();
            this.trackBarZ = new System.Windows.Forms.TrackBar();
            this.trackBarAngle = new System.Windows.Forms.TrackBar();
            this.trackBarZoom = new System.Windows.Forms.TrackBar();
            this.RenderTimer = new System.Windows.Forms.Timer(this.components);
            this.AnT = new Tao.Platform.Windows.SimpleOpenGlControl();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label_dataX = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label_dataY = new System.Windows.Forms.Label();
            this.label_dataZ = new System.Windows.Forms.Label();
            this.label_dataAngle = new System.Windows.Forms.Label();
            this.label_dataZoom = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarAngle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarZoom)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(791, 114);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "По оси";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "вращать вдоль X",
            "вращать вдоль Y",
            "вращать вдоль Z"});
            this.comboBox1.Location = new System.Drawing.Point(795, 149);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(229, 28);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // trackBarX
            // 
            this.trackBarX.LargeChange = 5000;
            this.trackBarX.Location = new System.Drawing.Point(795, 215);
            this.trackBarX.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.trackBarX.Maximum = 50000;
            this.trackBarX.Minimum = -50000;
            this.trackBarX.Name = "trackBarX";
            this.trackBarX.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBarX.Size = new System.Drawing.Size(69, 462);
            this.trackBarX.SmallChange = 500;
            this.trackBarX.TabIndex = 4;
            this.trackBarX.TickFrequency = 5000;
            this.trackBarX.Scroll += new System.EventHandler(this.trackBarX_Scroll);
            // 
            // trackBarY
            // 
            this.trackBarY.BackColor = System.Drawing.SystemColors.Control;
            this.trackBarY.LargeChange = 5000;
            this.trackBarY.Location = new System.Drawing.Point(870, 215);
            this.trackBarY.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.trackBarY.Maximum = 50000;
            this.trackBarY.Minimum = -50000;
            this.trackBarY.Name = "trackBarY";
            this.trackBarY.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBarY.Size = new System.Drawing.Size(69, 462);
            this.trackBarY.SmallChange = 500;
            this.trackBarY.TabIndex = 5;
            this.trackBarY.TickFrequency = 5000;
            this.trackBarY.Scroll += new System.EventHandler(this.trackBarY_Scroll);
            // 
            // trackBarZ
            // 
            this.trackBarZ.AccessibleDescription = "";
            this.trackBarZ.AccessibleName = "";
            this.trackBarZ.BackColor = System.Drawing.SystemColors.Control;
            this.trackBarZ.LargeChange = 5000;
            this.trackBarZ.Location = new System.Drawing.Point(945, 215);
            this.trackBarZ.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.trackBarZ.Maximum = 50000;
            this.trackBarZ.Minimum = -50000;
            this.trackBarZ.Name = "trackBarZ";
            this.trackBarZ.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBarZ.Size = new System.Drawing.Size(69, 462);
            this.trackBarZ.SmallChange = 500;
            this.trackBarZ.TabIndex = 6;
            this.trackBarZ.Tag = "";
            this.trackBarZ.TickFrequency = 5000;
            this.trackBarZ.Scroll += new System.EventHandler(this.trackBarZ_Scroll);
            // 
            // trackBarAngle
            // 
            this.trackBarAngle.BackColor = System.Drawing.SystemColors.Control;
            this.trackBarAngle.LargeChange = 30;
            this.trackBarAngle.Location = new System.Drawing.Point(1020, 215);
            this.trackBarAngle.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.trackBarAngle.Maximum = 360;
            this.trackBarAngle.Minimum = -360;
            this.trackBarAngle.Name = "trackBarAngle";
            this.trackBarAngle.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBarAngle.Size = new System.Drawing.Size(69, 462);
            this.trackBarAngle.SmallChange = 10;
            this.trackBarAngle.TabIndex = 7;
            this.trackBarAngle.TickFrequency = 30;
            this.trackBarAngle.Scroll += new System.EventHandler(this.trackBarAngle_Scroll);
            // 
            // trackBarZoom
            // 
            this.trackBarZoom.BackColor = System.Drawing.SystemColors.Control;
            this.trackBarZoom.Location = new System.Drawing.Point(1095, 215);
            this.trackBarZoom.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.trackBarZoom.Maximum = 5000;
            this.trackBarZoom.Minimum = -5000;
            this.trackBarZoom.Name = "trackBarZoom";
            this.trackBarZoom.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBarZoom.Size = new System.Drawing.Size(69, 462);
            this.trackBarZoom.TabIndex = 8;
            this.trackBarZoom.TickFrequency = 500;
            this.trackBarZoom.Scroll += new System.EventHandler(this.trackBarZoom_Scroll);
            // 
            // RenderTimer
            // 
            this.RenderTimer.Enabled = true;
            this.RenderTimer.Interval = 30;
            this.RenderTimer.Tick += new System.EventHandler(this.RenderTimer_Tick);
            // 
            // AnT
            // 
            this.AnT.AccumBits = ((byte)(0));
            this.AnT.AutoCheckErrors = false;
            this.AnT.AutoFinish = false;
            this.AnT.AutoMakeCurrent = true;
            this.AnT.AutoSwapBuffers = true;
            this.AnT.BackColor = System.Drawing.Color.Black;
            this.AnT.ColorBits = ((byte)(32));
            this.AnT.DepthBits = ((byte)(16));
            this.AnT.Location = new System.Drawing.Point(18, 38);
            this.AnT.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.AnT.Name = "AnT";
            this.AnT.Size = new System.Drawing.Size(750, 677);
            this.AnT.StencilBits = ((byte)(0));
            this.AnT.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(810, 200);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "X";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(960, 200);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(19, 20);
            this.label5.TabIndex = 12;
            this.label5.Text = "Z";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1020, 200);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 20);
            this.label6.TabIndex = 13;
            this.label6.Text = "Angle";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1095, 200);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 20);
            this.label7.TabIndex = 14;
            this.label7.Text = "Zoom";
            // 
            // label_dataX
            // 
            this.label_dataX.AutoSize = true;
            this.label_dataX.Location = new System.Drawing.Point(795, 685);
            this.label_dataX.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_dataX.Name = "label_dataX";
            this.label_dataX.Size = new System.Drawing.Size(18, 20);
            this.label_dataX.TabIndex = 16;
            this.label_dataX.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(885, 200);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 20);
            this.label4.TabIndex = 17;
            this.label4.Text = "Y";
            // 
            // label_dataY
            // 
            this.label_dataY.AutoSize = true;
            this.label_dataY.Location = new System.Drawing.Point(870, 685);
            this.label_dataY.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_dataY.Name = "label_dataY";
            this.label_dataY.Size = new System.Drawing.Size(18, 20);
            this.label_dataY.TabIndex = 18;
            this.label_dataY.Text = "0";
            // 
            // label_dataZ
            // 
            this.label_dataZ.AutoSize = true;
            this.label_dataZ.Location = new System.Drawing.Point(945, 685);
            this.label_dataZ.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_dataZ.Name = "label_dataZ";
            this.label_dataZ.Size = new System.Drawing.Size(18, 20);
            this.label_dataZ.TabIndex = 19;
            this.label_dataZ.Text = "0";
            // 
            // label_dataAngle
            // 
            this.label_dataAngle.AutoSize = true;
            this.label_dataAngle.Location = new System.Drawing.Point(1020, 685);
            this.label_dataAngle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_dataAngle.Name = "label_dataAngle";
            this.label_dataAngle.Size = new System.Drawing.Size(18, 20);
            this.label_dataAngle.TabIndex = 20;
            this.label_dataAngle.Text = "0";
            // 
            // label_dataZoom
            // 
            this.label_dataZoom.AutoSize = true;
            this.label_dataZoom.Location = new System.Drawing.Point(1095, 685);
            this.label_dataZoom.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_dataZoom.Name = "label_dataZoom";
            this.label_dataZoom.Size = new System.Drawing.Size(18, 20);
            this.label_dataZoom.TabIndex = 21;
            this.label_dataZoom.Text = "0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1176, 740);
            this.Controls.Add(this.label_dataZoom);
            this.Controls.Add(this.label_dataAngle);
            this.Controls.Add(this.label_dataZ);
            this.Controls.Add(this.label_dataY);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label_dataX);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.AnT);
            this.Controls.Add(this.trackBarZoom);
            this.Controls.Add(this.trackBarAngle);
            this.Controls.Add(this.trackBarZ);
            this.Controls.Add(this.trackBarY);
            this.Controls.Add(this.trackBarX);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarAngle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarZoom)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TrackBar trackBarX;
        private System.Windows.Forms.TrackBar trackBarY;
        private System.Windows.Forms.TrackBar trackBarZ;
        private System.Windows.Forms.TrackBar trackBarAngle;
        private System.Windows.Forms.TrackBar trackBarZoom;
        private System.Windows.Forms.Timer RenderTimer;
        private Tao.Platform.Windows.SimpleOpenGlControl AnT;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label_dataX;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label_dataY;
        private System.Windows.Forms.Label label_dataZ;
        private System.Windows.Forms.Label label_dataAngle;
        private System.Windows.Forms.Label label_dataZoom;
    }
}

