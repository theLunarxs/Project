namespace Project.AdminPanelForms
{
    partial class frmUserData
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnDelUser = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.lblInfo = new System.Windows.Forms.Label();
            this.txtDelUser = new System.Windows.Forms.TextBox();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(20)))), ((int)(((byte)(140)))));
            this.panel2.Controls.Add(this.btnDelUser);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.lblInfo);
            this.panel2.Controls.Add(this.txtDelUser);
            this.panel2.Location = new System.Drawing.Point(422, 333);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(332, 200);
            this.panel2.TabIndex = 1;
            // 
            // btnDelUser
            // 
            this.btnDelUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(67)))), ((int)(((byte)(189)))));
            this.btnDelUser.FlatAppearance.BorderSize = 0;
            this.btnDelUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelUser.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelUser.ForeColor = System.Drawing.Color.White;
            this.btnDelUser.Location = new System.Drawing.Point(84, 145);
            this.btnDelUser.Name = "btnDelUser";
            this.btnDelUser.Size = new System.Drawing.Size(153, 30);
            this.btnDelUser.TabIndex = 10;
            this.btnDelUser.Text = "Find And Remove User";
            this.btnDelUser.UseVisualStyleBackColor = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Yu Gothic UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(15, 15);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(155, 32);
            this.label9.TabIndex = 0;
            this.label9.Text = "Remove User";
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo.ForeColor = System.Drawing.Color.Snow;
            this.lblInfo.Location = new System.Drawing.Point(30, 72);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(64, 15);
            this.lblInfo.TabIndex = 7;
            this.lblInfo.Text = "Username";
            // 
            // txtDelUser
            // 
            this.txtDelUser.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.txtDelUser.Font = new System.Drawing.Font("Yu Gothic UI", 8F);
            this.txtDelUser.Location = new System.Drawing.Point(33, 100);
            this.txtDelUser.Name = "txtDelUser";
            this.txtDelUser.Size = new System.Drawing.Size(253, 22);
            this.txtDelUser.TabIndex = 9;
            // 
            // frmUserData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(14)))), ((int)(((byte)(107)))));
            this.ClientSize = new System.Drawing.Size(766, 545);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmUserData";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmUserData";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnDelUser;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.TextBox txtDelUser;
    }
}