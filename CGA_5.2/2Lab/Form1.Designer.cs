namespace _2Lab
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
            this.Scene = new Tao.Platform.Windows.SimpleOpenGlControl();
            this.zoomtrackBar = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.zoomtrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // Scene
            // 
            this.Scene.AccumBits = ((byte)(0));
            this.Scene.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Scene.AutoCheckErrors = false;
            this.Scene.AutoFinish = false;
            this.Scene.AutoMakeCurrent = true;
            this.Scene.AutoSwapBuffers = true;
            this.Scene.BackColor = System.Drawing.Color.Black;
            this.Scene.ColorBits = ((byte)(32));
            this.Scene.DepthBits = ((byte)(16));
            this.Scene.Location = new System.Drawing.Point(12, 62);
            this.Scene.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Scene.Name = "Scene";
            this.Scene.Size = new System.Drawing.Size(878, 741);
            this.Scene.StencilBits = ((byte)(0));
            this.Scene.TabIndex = 0;
            this.Scene.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Scene_KeyDown);
            // 
            // zoomtrackBar
            // 
            this.zoomtrackBar.LargeChange = 10;
            this.zoomtrackBar.Location = new System.Drawing.Point(853, 174);
            this.zoomtrackBar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.zoomtrackBar.Maximum = 0;
            this.zoomtrackBar.Minimum = -45;
            this.zoomtrackBar.Name = "zoomtrackBar";
            this.zoomtrackBar.Size = new System.Drawing.Size(10, 56);
            this.zoomtrackBar.SmallChange = 5;
            this.zoomtrackBar.TabIndex = 16;
            this.zoomtrackBar.Scroll += new System.EventHandler(this.zoomtrackBar_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.label1.Location = new System.Drawing.Point(577, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 46);
            this.label1.TabIndex = 17;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F);
            this.label2.Location = new System.Drawing.Point(729, 7);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 54);
            this.label2.TabIndex = 18;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.button1.Location = new System.Drawing.Point(238, 394);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(440, 106);
            this.button1.TabIndex = 20;
            this.button1.Text = "Play";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(912, 814);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Scene);
            this.Controls.Add(this.zoomtrackBar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "WinForm1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.zoomtrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Tao.Platform.Windows.SimpleOpenGlControl Scene;
        private System.Windows.Forms.TrackBar zoomtrackBar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
    }
}

