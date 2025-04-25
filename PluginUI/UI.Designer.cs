namespace PluginUI
{
    partial class UI
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
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxCentralZ = new System.Windows.Forms.TextBox();
            this.textBoxCentralY = new System.Windows.Forms.TextBox();
            this.textBoxCentralX = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxObliqueAngle = new System.Windows.Forms.TextBox();
            this.buttonObliqueView = new System.Windows.Forms.Button();
            this.buttonCentralProject = new System.Windows.Forms.Button();
            this.buttonProject = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonMoveAll = new System.Windows.Forms.Button();
            this.TextBoxScale = new System.Windows.Forms.TextBox();
            this.TextBoxRotateOZ = new System.Windows.Forms.TextBox();
            this.TextBoxRotateOY = new System.Windows.Forms.TextBox();
            this.TextBoxRotateOX = new System.Windows.Forms.TextBox();
            this.TextBoxMoveZ = new System.Windows.Forms.TextBox();
            this.TextBoxMoveY = new System.Windows.Forms.TextBox();
            this.TextBoxMoveX = new System.Windows.Forms.TextBox();
            this.buttonRotateOZ = new System.Windows.Forms.Button();
            this.buttonRotateOY = new System.Windows.Forms.Button();
            this.buttonRotateOX = new System.Windows.Forms.Button();
            this.buttonScale = new System.Windows.Forms.Button();
            this.buttonMirrorXOZ = new System.Windows.Forms.Button();
            this.buttonMirrorYOZ = new System.Windows.Forms.Button();
            this.buttonMirrorXOY = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(175, 283);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 20);
            this.label8.TabIndex = 62;
            this.label8.Text = "scale:=";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(480, 335);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 20);
            this.label5.TabIndex = 61;
            this.label5.Text = "z:=";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(480, 277);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 20);
            this.label6.TabIndex = 60;
            this.label6.Text = "y:=";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(480, 224);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 20);
            this.label7.TabIndex = 59;
            this.label7.Text = "x:=";
            // 
            // textBoxCentralZ
            // 
            this.textBoxCentralZ.Location = new System.Drawing.Point(516, 335);
            this.textBoxCentralZ.Name = "textBoxCentralZ";
            this.textBoxCentralZ.Size = new System.Drawing.Size(100, 26);
            this.textBoxCentralZ.TabIndex = 58;
            this.textBoxCentralZ.Leave += new System.EventHandler(this.TextBox_Leave);
            // 
            // textBoxCentralY
            // 
            this.textBoxCentralY.Location = new System.Drawing.Point(515, 274);
            this.textBoxCentralY.Name = "textBoxCentralY";
            this.textBoxCentralY.Size = new System.Drawing.Size(100, 26);
            this.textBoxCentralY.TabIndex = 57;
            this.textBoxCentralY.Leave += new System.EventHandler(this.TextBox_Leave);
            // 
            // textBoxCentralX
            // 
            this.textBoxCentralX.Location = new System.Drawing.Point(515, 221);
            this.textBoxCentralX.Name = "textBoxCentralX";
            this.textBoxCentralX.Size = new System.Drawing.Size(100, 26);
            this.textBoxCentralX.TabIndex = 56;
            this.textBoxCentralX.Leave += new System.EventHandler(this.TextBox_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(280, 395);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 20);
            this.label4.TabIndex = 55;
            this.label4.Text = "ф:=";
            // 
            // textBoxObliqueAngle
            // 
            this.textBoxObliqueAngle.Location = new System.Drawing.Point(323, 389);
            this.textBoxObliqueAngle.Name = "textBoxObliqueAngle";
            this.textBoxObliqueAngle.Size = new System.Drawing.Size(100, 26);
            this.textBoxObliqueAngle.TabIndex = 54;
            this.textBoxObliqueAngle.Leave += new System.EventHandler(this.TextBox_Leave);
            // 
            // buttonObliqueView
            // 
            this.buttonObliqueView.Location = new System.Drawing.Point(450, 386);
            this.buttonObliqueView.Name = "buttonObliqueView";
            this.buttonObliqueView.Size = new System.Drawing.Size(125, 32);
            this.buttonObliqueView.TabIndex = 53;
            this.buttonObliqueView.Text = "ObliqueView";
            this.buttonObliqueView.UseVisualStyleBackColor = true;
            this.buttonObliqueView.Click += new System.EventHandler(this.buttonObliqueView_Click);
            // 
            // buttonCentralProject
            // 
            this.buttonCentralProject.Location = new System.Drawing.Point(632, 273);
            this.buttonCentralProject.Name = "buttonCentralProject";
            this.buttonCentralProject.Size = new System.Drawing.Size(125, 32);
            this.buttonCentralProject.TabIndex = 52;
            this.buttonCentralProject.Text = "CentralView";
            this.buttonCentralProject.UseVisualStyleBackColor = true;
            this.buttonCentralProject.Click += new System.EventHandler(this.buttonCentralProject_Click);
            // 
            // buttonProject
            // 
            this.buttonProject.Location = new System.Drawing.Point(638, 383);
            this.buttonProject.Name = "buttonProject";
            this.buttonProject.Size = new System.Drawing.Size(119, 32);
            this.buttonProject.TabIndex = 51;
            this.buttonProject.Text = "FrontView";
            this.buttonProject.UseVisualStyleBackColor = true;
            this.buttonProject.Click += new System.EventHandler(this.buttonProject_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(41, 144);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 20);
            this.label3.TabIndex = 50;
            this.label3.Text = "z:=";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 20);
            this.label2.TabIndex = 49;
            this.label2.Text = "y:=";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 20);
            this.label1.TabIndex = 48;
            this.label1.Text = "x:=";
            // 
            // buttonMoveAll
            // 
            this.buttonMoveAll.Location = new System.Drawing.Point(225, 83);
            this.buttonMoveAll.Name = "buttonMoveAll";
            this.buttonMoveAll.Size = new System.Drawing.Size(82, 29);
            this.buttonMoveAll.TabIndex = 47;
            this.buttonMoveAll.Text = "Move";
            this.buttonMoveAll.UseVisualStyleBackColor = true;
            this.buttonMoveAll.Click += new System.EventHandler(this.buttonMoveAll_Click);
            // 
            // TextBoxScale
            // 
            this.TextBoxScale.Location = new System.Drawing.Point(240, 277);
            this.TextBoxScale.Name = "TextBoxScale";
            this.TextBoxScale.Size = new System.Drawing.Size(100, 26);
            this.TextBoxScale.TabIndex = 46;
            this.TextBoxScale.Leave += new System.EventHandler(this.TextBox_Leave);
            // 
            // TextBoxRotateOZ
            // 
            this.TextBoxRotateOZ.Location = new System.Drawing.Point(629, 135);
            this.TextBoxRotateOZ.Name = "TextBoxRotateOZ";
            this.TextBoxRotateOZ.Size = new System.Drawing.Size(100, 26);
            this.TextBoxRotateOZ.TabIndex = 45;
            this.TextBoxRotateOZ.Leave += new System.EventHandler(this.TextBox_Leave);
            // 
            // TextBoxRotateOY
            // 
            this.TextBoxRotateOY.Location = new System.Drawing.Point(629, 74);
            this.TextBoxRotateOY.Name = "TextBoxRotateOY";
            this.TextBoxRotateOY.Size = new System.Drawing.Size(100, 26);
            this.TextBoxRotateOY.TabIndex = 44;
            this.TextBoxRotateOY.Leave += new System.EventHandler(this.TextBox_Leave);
            // 
            // TextBoxRotateOX
            // 
            this.TextBoxRotateOX.Location = new System.Drawing.Point(629, 21);
            this.TextBoxRotateOX.Name = "TextBoxRotateOX";
            this.TextBoxRotateOX.Size = new System.Drawing.Size(100, 26);
            this.TextBoxRotateOX.TabIndex = 43;
            this.TextBoxRotateOX.Leave += new System.EventHandler(this.TextBox_Leave);
            // 
            // TextBoxMoveZ
            // 
            this.TextBoxMoveZ.Location = new System.Drawing.Point(77, 144);
            this.TextBoxMoveZ.Name = "TextBoxMoveZ";
            this.TextBoxMoveZ.Size = new System.Drawing.Size(100, 26);
            this.TextBoxMoveZ.TabIndex = 42;
            this.TextBoxMoveZ.Leave += new System.EventHandler(this.TextBox_Leave);
            // 
            // TextBoxMoveY
            // 
            this.TextBoxMoveY.Location = new System.Drawing.Point(76, 83);
            this.TextBoxMoveY.Name = "TextBoxMoveY";
            this.TextBoxMoveY.Size = new System.Drawing.Size(100, 26);
            this.TextBoxMoveY.TabIndex = 41;
            this.TextBoxMoveY.Leave += new System.EventHandler(this.TextBox_Leave);
            // 
            // TextBoxMoveX
            // 
            this.TextBoxMoveX.Location = new System.Drawing.Point(76, 30);
            this.TextBoxMoveX.Name = "TextBoxMoveX";
            this.TextBoxMoveX.Size = new System.Drawing.Size(100, 26);
            this.TextBoxMoveX.TabIndex = 40;
            this.TextBoxMoveX.Leave += new System.EventHandler(this.TextBox_Leave);
            // 
            // buttonRotateOZ
            // 
            this.buttonRotateOZ.AutoSize = true;
            this.buttonRotateOZ.Location = new System.Drawing.Point(516, 132);
            this.buttonRotateOZ.Name = "buttonRotateOZ";
            this.buttonRotateOZ.Size = new System.Drawing.Size(96, 32);
            this.buttonRotateOZ.TabIndex = 39;
            this.buttonRotateOZ.Text = "RotateOZ";
            this.buttonRotateOZ.UseVisualStyleBackColor = true;
            this.buttonRotateOZ.Click += new System.EventHandler(this.buttonRotateOZ_Click);
            // 
            // buttonRotateOY
            // 
            this.buttonRotateOY.AutoSize = true;
            this.buttonRotateOY.Location = new System.Drawing.Point(516, 74);
            this.buttonRotateOY.Name = "buttonRotateOY";
            this.buttonRotateOY.Size = new System.Drawing.Size(96, 32);
            this.buttonRotateOY.TabIndex = 38;
            this.buttonRotateOY.Text = "RotateOY";
            this.buttonRotateOY.UseVisualStyleBackColor = true;
            this.buttonRotateOY.Click += new System.EventHandler(this.buttonRotateOY_Click);
            // 
            // buttonRotateOX
            // 
            this.buttonRotateOX.AutoSize = true;
            this.buttonRotateOX.Location = new System.Drawing.Point(516, 18);
            this.buttonRotateOX.Name = "buttonRotateOX";
            this.buttonRotateOX.Size = new System.Drawing.Size(96, 32);
            this.buttonRotateOX.TabIndex = 37;
            this.buttonRotateOX.Text = "RotateOX";
            this.buttonRotateOX.UseVisualStyleBackColor = true;
            this.buttonRotateOX.Click += new System.EventHandler(this.buttonRotateOX_Click);
            // 
            // buttonScale
            // 
            this.buttonScale.Location = new System.Drawing.Point(346, 274);
            this.buttonScale.Name = "buttonScale";
            this.buttonScale.Size = new System.Drawing.Size(96, 32);
            this.buttonScale.TabIndex = 36;
            this.buttonScale.Text = "Scale";
            this.buttonScale.UseVisualStyleBackColor = true;
            this.buttonScale.Click += new System.EventHandler(this.buttonScale_Click);
            // 
            // buttonMirrorXOZ
            // 
            this.buttonMirrorXOZ.Location = new System.Drawing.Point(14, 335);
            this.buttonMirrorXOZ.Name = "buttonMirrorXOZ";
            this.buttonMirrorXOZ.Size = new System.Drawing.Size(96, 32);
            this.buttonMirrorXOZ.TabIndex = 35;
            this.buttonMirrorXOZ.Text = "MirrorXOZ";
            this.buttonMirrorXOZ.UseVisualStyleBackColor = true;
            this.buttonMirrorXOZ.Click += new System.EventHandler(this.buttonMirrorXOZ_Click);
            // 
            // buttonMirrorYOZ
            // 
            this.buttonMirrorYOZ.Location = new System.Drawing.Point(14, 273);
            this.buttonMirrorYOZ.Name = "buttonMirrorYOZ";
            this.buttonMirrorYOZ.Size = new System.Drawing.Size(96, 32);
            this.buttonMirrorYOZ.TabIndex = 34;
            this.buttonMirrorYOZ.Text = "MirrorYOZ";
            this.buttonMirrorYOZ.UseVisualStyleBackColor = true;
            this.buttonMirrorYOZ.Click += new System.EventHandler(this.buttonMirrorYOZ_Click);
            // 
            // buttonMirrorXOY
            // 
            this.buttonMirrorXOY.Location = new System.Drawing.Point(14, 209);
            this.buttonMirrorXOY.Name = "buttonMirrorXOY";
            this.buttonMirrorXOY.Size = new System.Drawing.Size(96, 32);
            this.buttonMirrorXOY.TabIndex = 33;
            this.buttonMirrorXOY.Text = "MirrorXOY";
            this.buttonMirrorXOY.UseVisualStyleBackColor = true;
            this.buttonMirrorXOY.Click += new System.EventHandler(this.buttonMirrorXOY_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBoxCentralZ);
            this.Controls.Add(this.textBoxCentralY);
            this.Controls.Add(this.textBoxCentralX);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxObliqueAngle);
            this.Controls.Add(this.buttonObliqueView);
            this.Controls.Add(this.buttonCentralProject);
            this.Controls.Add(this.buttonProject);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonMoveAll);
            this.Controls.Add(this.TextBoxScale);
            this.Controls.Add(this.TextBoxRotateOZ);
            this.Controls.Add(this.TextBoxRotateOY);
            this.Controls.Add(this.TextBoxRotateOX);
            this.Controls.Add(this.TextBoxMoveZ);
            this.Controls.Add(this.TextBoxMoveY);
            this.Controls.Add(this.TextBoxMoveX);
            this.Controls.Add(this.buttonRotateOZ);
            this.Controls.Add(this.buttonRotateOY);
            this.Controls.Add(this.buttonRotateOX);
            this.Controls.Add(this.buttonScale);
            this.Controls.Add(this.buttonMirrorXOZ);
            this.Controls.Add(this.buttonMirrorYOZ);
            this.Controls.Add(this.buttonMirrorXOY);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxCentralZ;
        private System.Windows.Forms.TextBox textBoxCentralY;
        private System.Windows.Forms.TextBox textBoxCentralX;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxObliqueAngle;
        private System.Windows.Forms.Button buttonObliqueView;
        private System.Windows.Forms.Button buttonCentralProject;
        private System.Windows.Forms.Button buttonProject;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonMoveAll;
        private System.Windows.Forms.TextBox TextBoxScale;
        private System.Windows.Forms.TextBox TextBoxRotateOZ;
        private System.Windows.Forms.TextBox TextBoxRotateOY;
        private System.Windows.Forms.TextBox TextBoxRotateOX;
        private System.Windows.Forms.TextBox TextBoxMoveZ;
        private System.Windows.Forms.TextBox TextBoxMoveY;
        private System.Windows.Forms.TextBox TextBoxMoveX;
        private System.Windows.Forms.Button buttonRotateOZ;
        private System.Windows.Forms.Button buttonRotateOY;
        private System.Windows.Forms.Button buttonRotateOX;
        private System.Windows.Forms.Button buttonScale;
        private System.Windows.Forms.Button buttonMirrorXOZ;
        private System.Windows.Forms.Button buttonMirrorYOZ;
        private System.Windows.Forms.Button buttonMirrorXOY;
    }
}

