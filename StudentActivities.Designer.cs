namespace COSC_GroupProject
{
    partial class StudentActivities
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
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btnStudentMarksheet = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AccessibleRole = System.Windows.Forms.AccessibleRole.Text;
            this.label1.BackColor = System.Drawing.SystemColors.MenuBar;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label1.Font = new System.Drawing.Font("Showcard Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label1.Location = new System.Drawing.Point(38, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(733, 71);
            this.label1.TabIndex = 0;
            this.label1.Text = "Welcome to Ananda College Exams Information System as a Student.";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(232, 124);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(339, 62);
            this.button1.TabIndex = 1;
            this.button1.Text = "Are You a Prize Winner?";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnStudentMarksheet
            // 
            this.btnStudentMarksheet.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnStudentMarksheet.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStudentMarksheet.Location = new System.Drawing.Point(232, 230);
            this.btnStudentMarksheet.Name = "btnStudentMarksheet";
            this.btnStudentMarksheet.Size = new System.Drawing.Size(339, 64);
            this.btnStudentMarksheet.TabIndex = 2;
            this.btnStudentMarksheet.Text = "See My Marksheet";
            this.btnStudentMarksheet.UseVisualStyleBackColor = true;
            this.btnStudentMarksheet.Click += new System.EventHandler(this.btnStudentMarksheet_Click);
            // 
            // button3
            // 
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(312, 338);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(191, 64);
            this.button3.TabIndex = 3;
            this.button3.Text = "Log OUT";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // StudentActivities
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::COSC_GroupProject.Properties.Resources.desktop_wallpaper_teacher_background_teaching;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 449);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnStudentMarksheet);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Name = "StudentActivities";
            this.Text = "StudentActivities";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnStudentMarksheet;
        private System.Windows.Forms.Button button3;
    }
}