namespace LibraryManageSystem
{
    partial class ResetPW
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ResetPW));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabReset = new System.Windows.Forms.TabControl();
            this.tabSmsReset = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSmsReset = new System.Windows.Forms.Button();
            this.txtSmsReset = new System.Windows.Forms.TextBox();
            this.tabEmailReset = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEmailReset = new System.Windows.Forms.TextBox();
            this.btnEmailReset = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabReset.SuspendLayout();
            this.tabSmsReset.SuspendLayout();
            this.tabEmailReset.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(-3, -4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(489, 483);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // tabReset
            // 
            this.tabReset.Controls.Add(this.tabSmsReset);
            this.tabReset.Controls.Add(this.tabEmailReset);
            this.tabReset.Location = new System.Drawing.Point(488, 26);
            this.tabReset.Name = "tabReset";
            this.tabReset.SelectedIndex = 0;
            this.tabReset.Size = new System.Drawing.Size(497, 413);
            this.tabReset.TabIndex = 1;
            // 
            // tabSmsReset
            // 
            this.tabSmsReset.Controls.Add(this.label3);
            this.tabSmsReset.Controls.Add(this.label1);
            this.tabSmsReset.Controls.Add(this.btnSmsReset);
            this.tabSmsReset.Controls.Add(this.txtSmsReset);
            this.tabSmsReset.Location = new System.Drawing.Point(4, 28);
            this.tabSmsReset.Name = "tabSmsReset";
            this.tabSmsReset.Padding = new System.Windows.Forms.Padding(3);
            this.tabSmsReset.Size = new System.Drawing.Size(489, 381);
            this.tabSmsReset.TabIndex = 0;
            this.tabSmsReset.Text = "通过短信重置";
            this.tabSmsReset.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.DarkGray;
            this.label3.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(47, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(394, 72);
            this.label3.TabIndex = 5;
            this.label3.Text = "请输入注册时预留的手机号码，重置\r\n后密码会发送到您的手机上，请注意\r\n查收、";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(98, 187);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "手机号：";
            // 
            // btnSmsReset
            // 
            this.btnSmsReset.Location = new System.Drawing.Point(334, 265);
            this.btnSmsReset.Name = "btnSmsReset";
            this.btnSmsReset.Size = new System.Drawing.Size(85, 30);
            this.btnSmsReset.TabIndex = 1;
            this.btnSmsReset.Text = "重置";
            this.btnSmsReset.UseVisualStyleBackColor = true;
            this.btnSmsReset.Click += new System.EventHandler(this.btnSmsReset_Click);
            // 
            // txtSmsReset
            // 
            this.txtSmsReset.Location = new System.Drawing.Point(195, 183);
            this.txtSmsReset.Name = "txtSmsReset";
            this.txtSmsReset.Size = new System.Drawing.Size(176, 28);
            this.txtSmsReset.TabIndex = 0;
            // 
            // tabEmailReset
            // 
            this.tabEmailReset.Controls.Add(this.label4);
            this.tabEmailReset.Controls.Add(this.label2);
            this.tabEmailReset.Controls.Add(this.txtEmailReset);
            this.tabEmailReset.Controls.Add(this.btnEmailReset);
            this.tabEmailReset.Location = new System.Drawing.Point(4, 28);
            this.tabEmailReset.Name = "tabEmailReset";
            this.tabEmailReset.Padding = new System.Windows.Forms.Padding(3);
            this.tabEmailReset.Size = new System.Drawing.Size(489, 381);
            this.tabEmailReset.TabIndex = 1;
            this.tabEmailReset.Text = "通过邮箱重置";
            this.tabEmailReset.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.DarkGray;
            this.label4.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(71, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(346, 72);
            this.label4.TabIndex = 5;
            this.label4.Text = "请输入注册时预留的邮箱，重置\r\n后密码会发送到您的邮箱，请注\r\n意查收、";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(90, 191);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "电子邮箱：";
            // 
            // txtEmailReset
            // 
            this.txtEmailReset.Location = new System.Drawing.Point(193, 185);
            this.txtEmailReset.Name = "txtEmailReset";
            this.txtEmailReset.Size = new System.Drawing.Size(178, 28);
            this.txtEmailReset.TabIndex = 1;
            // 
            // btnEmailReset
            // 
            this.btnEmailReset.Location = new System.Drawing.Point(332, 265);
            this.btnEmailReset.Name = "btnEmailReset";
            this.btnEmailReset.Size = new System.Drawing.Size(85, 30);
            this.btnEmailReset.TabIndex = 0;
            this.btnEmailReset.Text = "重置";
            this.btnEmailReset.UseVisualStyleBackColor = true;
            this.btnEmailReset.Click += new System.EventHandler(this.btnEmailReset_Click);
            // 
            // ResetPW
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 472);
            this.Controls.Add(this.tabReset);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ResetPW";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "重置密码";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabReset.ResumeLayout(false);
            this.tabSmsReset.ResumeLayout(false);
            this.tabSmsReset.PerformLayout();
            this.tabEmailReset.ResumeLayout(false);
            this.tabEmailReset.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TabControl tabReset;
        private System.Windows.Forms.TabPage tabSmsReset;
        private System.Windows.Forms.TabPage tabEmailReset;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSmsReset;
        private System.Windows.Forms.TextBox txtSmsReset;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEmailReset;
        private System.Windows.Forms.Button btnEmailReset;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}