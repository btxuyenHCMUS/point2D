namespace miniPaint_CodeDao
{
    partial class miniPaint
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.openGLControl = new SharpGL.OpenGLControl();
            this.bt_Line = new System.Windows.Forms.Button();
            this.bt_Rectangle = new System.Windows.Forms.Button();
            this.bt_Triangle = new System.Windows.Forms.Button();
            this.bt_Circle = new System.Windows.Forms.Button();
            this.bt_Ellipse = new System.Windows.Forms.Button();
            this.bt_Pentagon = new System.Windows.Forms.Button();
            this.bt_Hexagon = new System.Windows.Forms.Button();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.bt_Clear = new System.Windows.Forms.Button();
            this.Undo = new System.Windows.Forms.Button();
            this.bt_Draw = new System.Windows.Forms.Button();
            this.bt_Change = new System.Windows.Forms.Button();
            this.bt_SelectColor = new System.Windows.Forms.Button();
            this.tb_LineWidth = new System.Windows.Forms.TextBox();
            this.lb_Line = new System.Windows.Forms.Label();
            this.bt_Brush = new System.Windows.Forms.Button();
            this.bt_Affine30 = new System.Windows.Forms.Button();
            this.bt_Affine60 = new System.Windows.Forms.Button();
            this.bt_Affine90 = new System.Windows.Forms.Button();
            this.lb_Time = new System.Windows.Forms.Label();
            this.tb_Time = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.openGLControl)).BeginInit();
            this.SuspendLayout();
            // 
            // openGLControl
            // 
            this.openGLControl.DrawFPS = false;
            this.openGLControl.Location = new System.Drawing.Point(0, 100);
            this.openGLControl.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.openGLControl.Name = "openGLControl";
            this.openGLControl.OpenGLVersion = SharpGL.Version.OpenGLVersion.OpenGL2_1;
            this.openGLControl.RenderContextType = SharpGL.RenderContextType.DIBSection;
            this.openGLControl.RenderTrigger = SharpGL.RenderTrigger.TimerBased;
            this.openGLControl.Size = new System.Drawing.Size(980, 750);
            this.openGLControl.TabIndex = 0;
            this.openGLControl.OpenGLInitialized += new System.EventHandler(this.openGLControl_OpenGLInitialized);
            this.openGLControl.OpenGLDraw += new SharpGL.RenderEventHandler(this.openGLControl_OpenGLDraw);
            this.openGLControl.Resized += new System.EventHandler(this.openGLControl_Resized);
            this.openGLControl.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ctrl_OpenGLControl_MouseClick);
            this.openGLControl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ctrl_OpenGLControl_MouseDown);
            this.openGLControl.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ctrl_OpenGLControl_MouseMove);
            this.openGLControl.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ctrl_OpenGLControl_MouseUp);
            // 
            // bt_Line
            // 
            this.bt_Line.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Line.Location = new System.Drawing.Point(0, 0);
            this.bt_Line.Name = "bt_Line";
            this.bt_Line.Size = new System.Drawing.Size(80, 30);
            this.bt_Line.TabIndex = 1;
            this.bt_Line.Text = "Line";
            this.bt_Line.UseVisualStyleBackColor = true;
            this.bt_Line.Click += new System.EventHandler(this.bt_Line_Click);
            // 
            // bt_Rectangle
            // 
            this.bt_Rectangle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Rectangle.Location = new System.Drawing.Point(78, 0);
            this.bt_Rectangle.Name = "bt_Rectangle";
            this.bt_Rectangle.Size = new System.Drawing.Size(80, 30);
            this.bt_Rectangle.TabIndex = 2;
            this.bt_Rectangle.Text = "Rectangle";
            this.bt_Rectangle.UseVisualStyleBackColor = true;
            this.bt_Rectangle.Click += new System.EventHandler(this.bt_Rectangle_Click);
            // 
            // bt_Triangle
            // 
            this.bt_Triangle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Triangle.Location = new System.Drawing.Point(156, 0);
            this.bt_Triangle.Name = "bt_Triangle";
            this.bt_Triangle.Size = new System.Drawing.Size(80, 30);
            this.bt_Triangle.TabIndex = 3;
            this.bt_Triangle.Text = "Triangle";
            this.bt_Triangle.UseVisualStyleBackColor = true;
            this.bt_Triangle.Click += new System.EventHandler(this.bt_Triangle_Click);
            // 
            // bt_Circle
            // 
            this.bt_Circle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Circle.Location = new System.Drawing.Point(234, 0);
            this.bt_Circle.Name = "bt_Circle";
            this.bt_Circle.Size = new System.Drawing.Size(80, 30);
            this.bt_Circle.TabIndex = 4;
            this.bt_Circle.Text = "Circle";
            this.bt_Circle.UseVisualStyleBackColor = true;
            this.bt_Circle.Click += new System.EventHandler(this.bt_Circle_Click);
            // 
            // bt_Ellipse
            // 
            this.bt_Ellipse.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Ellipse.Location = new System.Drawing.Point(312, 0);
            this.bt_Ellipse.Name = "bt_Ellipse";
            this.bt_Ellipse.Size = new System.Drawing.Size(80, 30);
            this.bt_Ellipse.TabIndex = 5;
            this.bt_Ellipse.Text = "Ellipse";
            this.bt_Ellipse.UseVisualStyleBackColor = true;
            this.bt_Ellipse.Click += new System.EventHandler(this.bt_Ellipse_Click);
            // 
            // bt_Pentagon
            // 
            this.bt_Pentagon.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Pentagon.Location = new System.Drawing.Point(386, 0);
            this.bt_Pentagon.Name = "bt_Pentagon";
            this.bt_Pentagon.Size = new System.Drawing.Size(80, 30);
            this.bt_Pentagon.TabIndex = 6;
            this.bt_Pentagon.Text = "Pentagon";
            this.bt_Pentagon.UseVisualStyleBackColor = true;
            this.bt_Pentagon.Click += new System.EventHandler(this.bt_Pentagon_Click);
            // 
            // bt_Hexagon
            // 
            this.bt_Hexagon.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Hexagon.Location = new System.Drawing.Point(464, 0);
            this.bt_Hexagon.Name = "bt_Hexagon";
            this.bt_Hexagon.Size = new System.Drawing.Size(80, 30);
            this.bt_Hexagon.TabIndex = 7;
            this.bt_Hexagon.Text = "Hexagon";
            this.bt_Hexagon.UseVisualStyleBackColor = true;
            this.bt_Hexagon.Click += new System.EventHandler(this.bt_Hexagon_Click);
            // 
            // bt_Clear
            // 
            this.bt_Clear.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Clear.Location = new System.Drawing.Point(0, 61);
            this.bt_Clear.Name = "bt_Clear";
            this.bt_Clear.Size = new System.Drawing.Size(100, 40);
            this.bt_Clear.TabIndex = 8;
            this.bt_Clear.Text = "Clear";
            this.bt_Clear.UseVisualStyleBackColor = true;
            this.bt_Clear.Click += new System.EventHandler(this.bt_Clear_Click);
            // 
            // Undo
            // 
            this.Undo.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Undo.Location = new System.Drawing.Point(98, 61);
            this.Undo.Name = "Undo";
            this.Undo.Size = new System.Drawing.Size(100, 40);
            this.Undo.TabIndex = 9;
            this.Undo.Text = "Undo";
            this.Undo.UseVisualStyleBackColor = true;
            this.Undo.Click += new System.EventHandler(this.bt_Undo_Click);
            // 
            // bt_Draw
            // 
            this.bt_Draw.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Draw.Location = new System.Drawing.Point(218, 61);
            this.bt_Draw.Name = "bt_Draw";
            this.bt_Draw.Size = new System.Drawing.Size(80, 20);
            this.bt_Draw.TabIndex = 10;
            this.bt_Draw.Text = "Draw";
            this.bt_Draw.UseVisualStyleBackColor = true;
            this.bt_Draw.Click += new System.EventHandler(this.bt_Draw_Click);
            // 
            // bt_Change
            // 
            this.bt_Change.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Change.Location = new System.Drawing.Point(298, 61);
            this.bt_Change.Name = "bt_Change";
            this.bt_Change.Size = new System.Drawing.Size(80, 20);
            this.bt_Change.TabIndex = 11;
            this.bt_Change.Text = "Change";
            this.bt_Change.UseVisualStyleBackColor = true;
            this.bt_Change.Click += new System.EventHandler(this.bt_Change_Click);
            // 
            // bt_SelectColor
            // 
            this.bt_SelectColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_SelectColor.Location = new System.Drawing.Point(877, 0);
            this.bt_SelectColor.Name = "bt_SelectColor";
            this.bt_SelectColor.Size = new System.Drawing.Size(102, 50);
            this.bt_SelectColor.TabIndex = 12;
            this.bt_SelectColor.Text = "Select color";
            this.bt_SelectColor.UseVisualStyleBackColor = true;
            this.bt_SelectColor.Click += new System.EventHandler(this.bt_SelectColor_Click);
            // 
            // tb_LineWidth
            // 
            this.tb_LineWidth.Location = new System.Drawing.Point(878, 76);
            this.tb_LineWidth.Name = "tb_LineWidth";
            this.tb_LineWidth.Size = new System.Drawing.Size(100, 22);
            this.tb_LineWidth.TabIndex = 13;
            this.tb_LineWidth.Text = "1";
            this.tb_LineWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tb_LineWidth.TextChanged += new System.EventHandler(this.tb_LineWidth_Changed);
            // 
            // lb_Line
            // 
            this.lb_Line.AutoSize = true;
            this.lb_Line.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_Line.Location = new System.Drawing.Point(880, 56);
            this.lb_Line.Name = "lb_Line";
            this.lb_Line.Size = new System.Drawing.Size(44, 17);
            this.lb_Line.TabIndex = 14;
            this.lb_Line.Text = "Line:";
            // 
            // bt_Brush
            // 
            this.bt_Brush.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Brush.Location = new System.Drawing.Point(218, 80);
            this.bt_Brush.Name = "bt_Brush";
            this.bt_Brush.Size = new System.Drawing.Size(80, 20);
            this.bt_Brush.TabIndex = 15;
            this.bt_Brush.Text = "Brush";
            this.bt_Brush.UseVisualStyleBackColor = true;
            this.bt_Brush.Click += new System.EventHandler(this.bt_Brush_Click);
            // 
            // bt_Affine30
            // 
            this.bt_Affine30.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Affine30.Location = new System.Drawing.Point(386, 61);
            this.bt_Affine30.Name = "bt_Affine30";
            this.bt_Affine30.Size = new System.Drawing.Size(80, 20);
            this.bt_Affine30.TabIndex = 16;
            this.bt_Affine30.Text = "Affine30";
            this.bt_Affine30.UseVisualStyleBackColor = true;
            this.bt_Affine30.Click += new System.EventHandler(this.bt_Affine30_Click);
            // 
            // bt_Affine60
            // 
            this.bt_Affine60.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Affine60.Location = new System.Drawing.Point(464, 61);
            this.bt_Affine60.Name = "bt_Affine60";
            this.bt_Affine60.Size = new System.Drawing.Size(80, 20);
            this.bt_Affine60.TabIndex = 17;
            this.bt_Affine60.Text = "Affine60";
            this.bt_Affine60.UseVisualStyleBackColor = true;
            this.bt_Affine60.Click += new System.EventHandler(this.bt_Affine60_Click);
            // 
            // bt_Affine90
            // 
            this.bt_Affine90.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Affine90.Location = new System.Drawing.Point(386, 81);
            this.bt_Affine90.Name = "bt_Affine90";
            this.bt_Affine90.Size = new System.Drawing.Size(80, 20);
            this.bt_Affine90.TabIndex = 18;
            this.bt_Affine90.Text = "Affine90";
            this.bt_Affine90.UseVisualStyleBackColor = true;
            this.bt_Affine90.Click += new System.EventHandler(this.bt_Affine90_Click);
            // 
            // lb_Time
            // 
            this.lb_Time.AutoSize = true;
            this.lb_Time.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_Time.Location = new System.Drawing.Point(760, 56);
            this.lb_Time.Name = "lb_Time";
            this.lb_Time.Size = new System.Drawing.Size(69, 17);
            this.lb_Time.TabIndex = 19;
            this.lb_Time.Text = "Tme (s):";
            // 
            // tb_Time
            // 
            this.tb_Time.Location = new System.Drawing.Point(763, 76);
            this.tb_Time.Name = "tb_Time";
            this.tb_Time.Size = new System.Drawing.Size(84, 22);
            this.tb_Time.TabIndex = 20;
            this.tb_Time.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // miniPaint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 855);
            this.Controls.Add(this.tb_Time);
            this.Controls.Add(this.lb_Time);
            this.Controls.Add(this.bt_Affine90);
            this.Controls.Add(this.bt_Affine60);
            this.Controls.Add(this.bt_Affine30);
            this.Controls.Add(this.bt_Brush);
            this.Controls.Add(this.lb_Line);
            this.Controls.Add(this.tb_LineWidth);
            this.Controls.Add(this.bt_SelectColor);
            this.Controls.Add(this.bt_Change);
            this.Controls.Add(this.bt_Draw);
            this.Controls.Add(this.Undo);
            this.Controls.Add(this.bt_Clear);
            this.Controls.Add(this.bt_Hexagon);
            this.Controls.Add(this.bt_Pentagon);
            this.Controls.Add(this.bt_Ellipse);
            this.Controls.Add(this.bt_Circle);
            this.Controls.Add(this.bt_Triangle);
            this.Controls.Add(this.bt_Rectangle);
            this.Controls.Add(this.bt_Line);
            this.Controls.Add(this.openGLControl);
            this.Name = "miniPaint";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "miniPaint";
            ((System.ComponentModel.ISupportInitialize)(this.openGLControl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SharpGL.OpenGLControl openGLControl;
        private System.Windows.Forms.Button bt_Line;
        private System.Windows.Forms.Button bt_Rectangle;
        private System.Windows.Forms.Button bt_Triangle;
        private System.Windows.Forms.Button bt_Circle;
        private System.Windows.Forms.Button bt_Ellipse;
        private System.Windows.Forms.Button bt_Pentagon;
        private System.Windows.Forms.Button bt_Hexagon;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.Button bt_Clear;
        private System.Windows.Forms.Button Undo;
        private System.Windows.Forms.Button bt_Draw;
        private System.Windows.Forms.Button bt_Change;
        private System.Windows.Forms.Button bt_SelectColor;
        private System.Windows.Forms.TextBox tb_LineWidth;
        private System.Windows.Forms.Label lb_Line;
        private System.Windows.Forms.Button bt_Brush;
        private System.Windows.Forms.Button bt_Affine30;
        private System.Windows.Forms.Button bt_Affine60;
        private System.Windows.Forms.Button bt_Affine90;
        private System.Windows.Forms.Label lb_Time;
        private System.Windows.Forms.TextBox tb_Time;
    }
}

