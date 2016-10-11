namespace InterceptClient
{
    partial class Form1
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
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.gbKeyboard = new System.Windows.Forms.GroupBox();
            this.btnSaveKeyboard = new System.Windows.Forms.Button();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.gbMouse = new System.Windows.Forms.GroupBox();
            this.btnSaveMouse = new System.Windows.Forms.Button();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.SFD = new System.Windows.Forms.SaveFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.tbEndPoint = new System.Windows.Forms.TextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.gbKeyboard.SuspendLayout();
            this.gbMouse.SuspendLayout();
            this.SuspendLayout();
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(21, 19);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(47, 17);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.Text = "Start";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.Click += new System.EventHandler(this.rbKeyboard_Click);
            // 
            // gbKeyboard
            // 
            this.gbKeyboard.Controls.Add(this.btnSaveKeyboard);
            this.gbKeyboard.Controls.Add(this.radioButton3);
            this.gbKeyboard.Controls.Add(this.radioButton1);
            this.gbKeyboard.Location = new System.Drawing.Point(12, 56);
            this.gbKeyboard.Name = "gbKeyboard";
            this.gbKeyboard.Size = new System.Drawing.Size(156, 106);
            this.gbKeyboard.TabIndex = 1;
            this.gbKeyboard.TabStop = false;
            this.gbKeyboard.Text = "Keyboard";
            // 
            // btnSaveKeyboard
            // 
            this.btnSaveKeyboard.Location = new System.Drawing.Point(39, 42);
            this.btnSaveKeyboard.Name = "btnSaveKeyboard";
            this.btnSaveKeyboard.Size = new System.Drawing.Size(75, 23);
            this.btnSaveKeyboard.TabIndex = 2;
            this.btnSaveKeyboard.Text = "Save";
            this.btnSaveKeyboard.UseVisualStyleBackColor = true;
            this.btnSaveKeyboard.Click += new System.EventHandler(this.btnSaveKeyboard_Click);
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Checked = true;
            this.radioButton3.Location = new System.Drawing.Point(91, 19);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(47, 17);
            this.radioButton3.TabIndex = 1;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "Stop";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.Click += new System.EventHandler(this.rbKeyboard_Click);
            // 
            // gbMouse
            // 
            this.gbMouse.Controls.Add(this.btnSaveMouse);
            this.gbMouse.Controls.Add(this.radioButton4);
            this.gbMouse.Controls.Add(this.radioButton2);
            this.gbMouse.Location = new System.Drawing.Point(174, 56);
            this.gbMouse.Name = "gbMouse";
            this.gbMouse.Size = new System.Drawing.Size(156, 106);
            this.gbMouse.TabIndex = 2;
            this.gbMouse.TabStop = false;
            this.gbMouse.Text = "Mouse";
            // 
            // btnSaveMouse
            // 
            this.btnSaveMouse.Location = new System.Drawing.Point(41, 42);
            this.btnSaveMouse.Name = "btnSaveMouse";
            this.btnSaveMouse.Size = new System.Drawing.Size(75, 23);
            this.btnSaveMouse.TabIndex = 3;
            this.btnSaveMouse.Text = "Save";
            this.btnSaveMouse.UseVisualStyleBackColor = true;
            this.btnSaveMouse.Click += new System.EventHandler(this.btnSaveMouse_Click);
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Checked = true;
            this.radioButton4.Location = new System.Drawing.Point(91, 19);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(47, 17);
            this.radioButton4.TabIndex = 1;
            this.radioButton4.TabStop = true;
            this.radioButton4.Text = "Stop";
            this.radioButton4.UseVisualStyleBackColor = true;
            this.radioButton4.Click += new System.EventHandler(this.rbMouse_Click);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(21, 19);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(47, 17);
            this.radioButton2.TabIndex = 0;
            this.radioButton2.Text = "Start";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.Click += new System.EventHandler(this.rbMouse_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "EndPoint";
            // 
            // tbEndPoint
            // 
            this.tbEndPoint.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbEndPoint.Location = new System.Drawing.Point(15, 26);
            this.tbEndPoint.Name = "tbEndPoint";
            this.tbEndPoint.Size = new System.Drawing.Size(244, 18);
            this.tbEndPoint.TabIndex = 0;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(265, 26);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(65, 20);
            this.btnConnect.TabIndex = 4;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(342, 172);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.tbEndPoint);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gbMouse);
            this.Controls.Add(this.gbKeyboard);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.gbKeyboard.ResumeLayout(false);
            this.gbKeyboard.PerformLayout();
            this.gbMouse.ResumeLayout(false);
            this.gbMouse.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.GroupBox gbKeyboard;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.GroupBox gbMouse;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.Button btnSaveKeyboard;
        private System.Windows.Forms.Button btnSaveMouse;
        private System.Windows.Forms.SaveFileDialog SFD;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbEndPoint;
        private System.Windows.Forms.Button btnConnect;
    }
}

