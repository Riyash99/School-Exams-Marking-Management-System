namespace COSC_GroupProject
{
    partial class PrincipalActivities
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
            this.btnGetTeacherDetails = new System.Windows.Forms.Button();
            this.btnGetStudentMarks = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.btnGetStudentDetails = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.Menu;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label1.Font = new System.Drawing.Font("Showcard Gothic", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(956, 94);
            this.label1.TabIndex = 0;
            this.label1.Text = "Welcome to Ananda College Exams Information System As a Principal.";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnGetTeacherDetails
            // 
            this.btnGetTeacherDetails.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGetTeacherDetails.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetTeacherDetails.Location = new System.Drawing.Point(346, 127);
            this.btnGetTeacherDetails.Name = "btnGetTeacherDetails";
            this.btnGetTeacherDetails.Size = new System.Drawing.Size(296, 63);
            this.btnGetTeacherDetails.TabIndex = 1;
            this.btnGetTeacherDetails.Text = "Get Teacher Details";
            this.btnGetTeacherDetails.UseVisualStyleBackColor = true;
            this.btnGetTeacherDetails.Click += new System.EventHandler(this.btnGetTeacherDetails_Click);
            // 
            // btnGetStudentMarks
            // 
            this.btnGetStudentMarks.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGetStudentMarks.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetStudentMarks.Location = new System.Drawing.Point(346, 208);
            this.btnGetStudentMarks.Name = "btnGetStudentMarks";
            this.btnGetStudentMarks.Size = new System.Drawing.Size(296, 60);
            this.btnGetStudentMarks.TabIndex = 2;
            this.btnGetStudentMarks.Text = "Get Student Marks";
            this.btnGetStudentMarks.UseVisualStyleBackColor = true;
            this.btnGetStudentMarks.Click += new System.EventHandler(this.btnManageMarks_Click);
            // 
            // button3
            // 
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(399, 359);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(186, 65);
            this.button3.TabIndex = 3;
            this.button3.Text = "Log OUT";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnGetStudentDetails
            // 
            this.btnGetStudentDetails.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGetStudentDetails.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetStudentDetails.Location = new System.Drawing.Point(346, 285);
            this.btnGetStudentDetails.Name = "btnGetStudentDetails";
            this.btnGetStudentDetails.Size = new System.Drawing.Size(296, 60);
            this.btnGetStudentDetails.TabIndex = 4;
            this.btnGetStudentDetails.Text = "Get Student Details";
            this.btnGetStudentDetails.UseVisualStyleBackColor = true;
            this.btnGetStudentDetails.Click += new System.EventHandler(this.btnManageStudent_Click);
            // 
            // PrincipalActivities
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::COSC_GroupProject.Properties.Resources.desktop_wallpaper_teacher_background_teaching;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(993, 449);
            this.Controls.Add(this.btnGetStudentDetails);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnGetStudentMarks);
            this.Controls.Add(this.btnGetTeacherDetails);
            this.Controls.Add(this.label1);
            this.Name = "PrincipalActivities";
            this.Text = "PrincipalActivities";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGetTeacherDetails;
        private System.Windows.Forms.Button btnGetStudentMarks;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnGetStudentDetails;
    }
}