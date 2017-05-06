namespace FileTransfer
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
            this.lbl_source_folder = new System.Windows.Forms.Label();
            this.lbl_target_folder = new System.Windows.Forms.Label();
            this.lbl_file_list = new System.Windows.Forms.Label();
            this.txt_source_folder = new System.Windows.Forms.TextBox();
            this.txt_target_folder = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txt_screenID = new System.Windows.Forms.TextBox();
            this.btn_screenIDsubmit = new System.Windows.Forms.Button();
            this.lbl_screenid = new System.Windows.Forms.Label();
            this.txt_request_user = new System.Windows.Forms.TextBox();
            this.lbl_request_user = new System.Windows.Forms.Label();
            this.btn_deploy = new System.Windows.Forms.Button();
            this.chk_fixed_source = new System.Windows.Forms.CheckBox();
            this.chk_fixed_target = new System.Windows.Forms.CheckBox();
            this.txt_deployedfile = new System.Windows.Forms.RichTextBox();
            this.btn_svn_commit = new System.Windows.Forms.Button();
            this.btn_new_session = new System.Windows.Forms.Button();
            this.btn_exit = new System.Windows.Forms.Button();
            this.chk_batchscr = new System.Windows.Forms.CheckBox();
            this.btn_fileImport = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_source_folder
            // 
            this.lbl_source_folder.AutoSize = true;
            this.lbl_source_folder.Location = new System.Drawing.Point(14, 310);
            this.lbl_source_folder.Name = "lbl_source_folder";
            this.lbl_source_folder.Size = new System.Drawing.Size(98, 13);
            this.lbl_source_folder.TabIndex = 1;
            this.lbl_source_folder.Text = "SOURCE FOLDER";
            // 
            // lbl_target_folder
            // 
            this.lbl_target_folder.AutoSize = true;
            this.lbl_target_folder.Location = new System.Drawing.Point(14, 350);
            this.lbl_target_folder.Name = "lbl_target_folder";
            this.lbl_target_folder.Size = new System.Drawing.Size(97, 13);
            this.lbl_target_folder.TabIndex = 2;
            this.lbl_target_folder.Text = "TARGET FOLDER";
            // 
            // lbl_file_list
            // 
            this.lbl_file_list.AutoSize = true;
            this.lbl_file_list.Location = new System.Drawing.Point(12, 47);
            this.lbl_file_list.Name = "lbl_file_list";
            this.lbl_file_list.Size = new System.Drawing.Size(0, 13);
            this.lbl_file_list.TabIndex = 3;
            // 
            // txt_source_folder
            // 
            this.txt_source_folder.Location = new System.Drawing.Point(130, 310);
            this.txt_source_folder.Name = "txt_source_folder";
            this.txt_source_folder.Size = new System.Drawing.Size(645, 20);
            this.txt_source_folder.TabIndex = 4;
            // 
            // txt_target_folder
            // 
            this.txt_target_folder.Location = new System.Drawing.Point(130, 350);
            this.txt_target_folder.Name = "txt_target_folder";
            this.txt_target_folder.Size = new System.Drawing.Size(645, 20);
            this.txt_target_folder.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(130, 392);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "SVN UPDATE";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btn_svn_update_Click);
            // 
            // txt_screenID
            // 
            this.txt_screenID.Location = new System.Drawing.Point(96, 6);
            this.txt_screenID.Name = "txt_screenID";
            this.txt_screenID.Size = new System.Drawing.Size(100, 20);
            this.txt_screenID.TabIndex = 7;
            // 
            // btn_screenIDsubmit
            // 
            this.btn_screenIDsubmit.Location = new System.Drawing.Point(790, 3);
            this.btn_screenIDsubmit.Name = "btn_screenIDsubmit";
            this.btn_screenIDsubmit.Size = new System.Drawing.Size(82, 23);
            this.btn_screenIDsubmit.TabIndex = 8;
            this.btn_screenIDsubmit.Text = "SUBMITED";
            this.btn_screenIDsubmit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_screenIDsubmit.UseVisualStyleBackColor = true;
            this.btn_screenIDsubmit.Click += new System.EventHandler(this.btn_submited_click);
            // 
            // lbl_screenid
            // 
            this.lbl_screenid.AutoSize = true;
            this.lbl_screenid.Location = new System.Drawing.Point(11, 9);
            this.lbl_screenid.Name = "lbl_screenid";
            this.lbl_screenid.Size = new System.Drawing.Size(65, 13);
            this.lbl_screenid.TabIndex = 9;
            this.lbl_screenid.Text = "SCREEN ID";
            // 
            // txt_request_user
            // 
            this.txt_request_user.Location = new System.Drawing.Point(493, 5);
            this.txt_request_user.Name = "txt_request_user";
            this.txt_request_user.Size = new System.Drawing.Size(172, 20);
            this.txt_request_user.TabIndex = 10;
            // 
            // lbl_request_user
            // 
            this.lbl_request_user.AutoSize = true;
            this.lbl_request_user.Location = new System.Drawing.Point(395, 9);
            this.lbl_request_user.Name = "lbl_request_user";
            this.lbl_request_user.Size = new System.Drawing.Size(92, 13);
            this.lbl_request_user.TabIndex = 11;
            this.lbl_request_user.Text = "REQUEST USER";
            // 
            // btn_deploy
            // 
            this.btn_deploy.Location = new System.Drawing.Point(416, 392);
            this.btn_deploy.Name = "btn_deploy";
            this.btn_deploy.Size = new System.Drawing.Size(94, 23);
            this.btn_deploy.TabIndex = 12;
            this.btn_deploy.Text = "DEPLOY";
            this.btn_deploy.UseVisualStyleBackColor = true;
            this.btn_deploy.Click += new System.EventHandler(this.btn_deploy_Click);
            // 
            // chk_fixed_source
            // 
            this.chk_fixed_source.AutoSize = true;
            this.chk_fixed_source.Location = new System.Drawing.Point(790, 313);
            this.chk_fixed_source.Name = "chk_fixed_source";
            this.chk_fixed_source.Size = new System.Drawing.Size(85, 17);
            this.chk_fixed_source.TabIndex = 13;
            this.chk_fixed_source.Text = "Source fixed";
            this.chk_fixed_source.UseVisualStyleBackColor = true;
            this.chk_fixed_source.MouseClick += new System.Windows.Forms.MouseEventHandler(this.chk_fixed_source_MouseClick);
            // 
            // chk_fixed_target
            // 
            this.chk_fixed_target.AutoSize = true;
            this.chk_fixed_target.Location = new System.Drawing.Point(790, 352);
            this.chk_fixed_target.Name = "chk_fixed_target";
            this.chk_fixed_target.Size = new System.Drawing.Size(82, 17);
            this.chk_fixed_target.TabIndex = 14;
            this.chk_fixed_target.Text = "Target fixed";
            this.chk_fixed_target.UseVisualStyleBackColor = true;
            this.chk_fixed_target.MouseClick += new System.Windows.Forms.MouseEventHandler(this.chk_fixed_target_MouseClick);
            // 
            // txt_deployedfile
            // 
            this.txt_deployedfile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_deployedfile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_deployedfile.Location = new System.Drawing.Point(18, 44);
            this.txt_deployedfile.Name = "txt_deployedfile";
            this.txt_deployedfile.Size = new System.Drawing.Size(854, 240);
            this.txt_deployedfile.TabIndex = 15;
            this.txt_deployedfile.Text = "";
            // 
            // btn_svn_commit
            // 
            this.btn_svn_commit.Location = new System.Drawing.Point(272, 392);
            this.btn_svn_commit.Name = "btn_svn_commit";
            this.btn_svn_commit.Size = new System.Drawing.Size(94, 23);
            this.btn_svn_commit.TabIndex = 16;
            this.btn_svn_commit.Text = "SVN COMMIT";
            this.btn_svn_commit.UseVisualStyleBackColor = true;
            this.btn_svn_commit.Click += new System.EventHandler(this.btn_svn_commit_Click);
            // 
            // btn_new_session
            // 
            this.btn_new_session.Location = new System.Drawing.Point(551, 392);
            this.btn_new_session.Name = "btn_new_session";
            this.btn_new_session.Size = new System.Drawing.Size(94, 23);
            this.btn_new_session.TabIndex = 17;
            this.btn_new_session.Text = "NEW SESSION";
            this.btn_new_session.UseVisualStyleBackColor = true;
            this.btn_new_session.Click += new System.EventHandler(this.btn_new_session_Click);
            // 
            // btn_exit
            // 
            this.btn_exit.Location = new System.Drawing.Point(681, 391);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(94, 24);
            this.btn_exit.TabIndex = 18;
            this.btn_exit.Text = "EXIT";
            this.btn_exit.UseVisualStyleBackColor = true;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // chk_batchscr
            // 
            this.chk_batchscr.AutoSize = true;
            this.chk_batchscr.Location = new System.Drawing.Point(236, 8);
            this.chk_batchscr.Name = "chk_batchscr";
            this.chk_batchscr.Size = new System.Drawing.Size(109, 17);
            this.chk_batchscr.TabIndex = 19;
            this.chk_batchscr.Text = "BATCH SCREEN";
            this.chk_batchscr.UseVisualStyleBackColor = true;
            // 
            // btn_fileImport
            // 
            this.btn_fileImport.Location = new System.Drawing.Point(681, 3);
            this.btn_fileImport.Name = "btn_fileImport";
            this.btn_fileImport.Size = new System.Drawing.Size(94, 23);
            this.btn_fileImport.TabIndex = 20;
            this.btn_fileImport.Text = "FILE IMPORT";
            this.btn_fileImport.UseVisualStyleBackColor = true;
            this.btn_fileImport.Click += new System.EventHandler(this.btn_fileImport_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 623);
            this.Controls.Add(this.btn_fileImport);
            this.Controls.Add(this.chk_batchscr);
            this.Controls.Add(this.btn_exit);
            this.Controls.Add(this.btn_new_session);
            this.Controls.Add(this.btn_svn_commit);
            this.Controls.Add(this.txt_deployedfile);
            this.Controls.Add(this.chk_fixed_target);
            this.Controls.Add(this.chk_fixed_source);
            this.Controls.Add(this.btn_deploy);
            this.Controls.Add(this.lbl_request_user);
            this.Controls.Add(this.txt_request_user);
            this.Controls.Add(this.lbl_screenid);
            this.Controls.Add(this.btn_screenIDsubmit);
            this.Controls.Add(this.txt_screenID);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txt_target_folder);
            this.Controls.Add(this.txt_source_folder);
            this.Controls.Add(this.lbl_file_list);
            this.Controls.Add(this.lbl_target_folder);
            this.Controls.Add(this.lbl_source_folder);
            this.Name = "Form1";
            this.Text = "File transfer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbl_source_folder;
        private System.Windows.Forms.Label lbl_target_folder;
        private System.Windows.Forms.Label lbl_file_list;
        private System.Windows.Forms.TextBox txt_source_folder;
        private System.Windows.Forms.TextBox txt_target_folder;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txt_screenID;
        private System.Windows.Forms.Button btn_screenIDsubmit;
        private System.Windows.Forms.Label lbl_screenid;
        private System.Windows.Forms.TextBox txt_request_user;
        private System.Windows.Forms.Label lbl_request_user;
        private System.Windows.Forms.Button btn_deploy;
        private System.Windows.Forms.CheckBox chk_fixed_source;
        private System.Windows.Forms.CheckBox chk_fixed_target;
        private System.Windows.Forms.RichTextBox txt_deployedfile;
        private System.Windows.Forms.Button btn_svn_commit;
        private System.Windows.Forms.Button btn_new_session;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.CheckBox chk_batchscr;
        private System.Windows.Forms.Button btn_fileImport;
    }
}

