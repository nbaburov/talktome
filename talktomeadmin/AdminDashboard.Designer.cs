namespace talktomeadmin
{
    partial class AdminDashboard
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
            tabControl1 = new TabControl();
            tabPageDashboard = new TabPage();
            groupBox2 = new GroupBox();
            lstBoxFlaggedCommentsDashboard = new ListBox();
            lstBoxFlaggedPostsDashboard = new ListBox();
            lstBoxFlaggedUsersDashboard = new ListBox();
            lblFlaggedCommentsTotal = new Label();
            label11 = new Label();
            lblFlaggedUsersTotal = new Label();
            label17 = new Label();
            lblFlaggedPostsTotal = new Label();
            label19 = new Label();
            groupBox1 = new GroupBox();
            lblCommentsTotal = new Label();
            label7 = new Label();
            lblLikesTotal = new Label();
            label9 = new Label();
            lblPostsToday = new Label();
            label5 = new Label();
            lblUsersToday = new Label();
            label6 = new Label();
            lblUsersTotal = new Label();
            label4 = new Label();
            lblPostsTotal = new Label();
            label2 = new Label();
            label1 = new Label();
            tabPageUsers = new TabPage();
            groupBox4 = new GroupBox();
            btnRemoveFlagUser = new Button();
            label21 = new Label();
            btnBanUser = new Button();
            btnSuspendUser = new Button();
            label20 = new Label();
            txtBoxSuspendDays = new TextBox();
            label13 = new Label();
            groupBox3 = new GroupBox();
            lblUserBio = new Label();
            label23 = new Label();
            lblUserFlagReason = new Label();
            label15 = new Label();
            lblUserEmail = new Label();
            label14 = new Label();
            lblUserName = new Label();
            label12 = new Label();
            label8 = new Label();
            pictureBoxUserProfile = new PictureBox();
            label3 = new Label();
            lstBoxFlaggedUsers = new ListBox();
            tabPageAdmins = new TabPage();
            groupBox9 = new GroupBox();
            lblAdminStatus = new Label();
            btnRemoveAdmin = new Button();
            btnEditAdmin = new Button();
            btnNewAdmin = new Button();
            label40 = new Label();
            pictureBoxAdminImage = new PictureBox();
            btnAdminAttachImage = new Button();
            cmBxAdminPerms = new ComboBox();
            label38 = new Label();
            label36 = new Label();
            txtAdminEmail = new TextBox();
            label18 = new Label();
            txtAdminPassword = new TextBox();
            label16 = new Label();
            txtAdminUsername = new TextBox();
            label10 = new Label();
            lstBoxAdmins = new ListBox();
            tabPagePosts = new TabPage();
            groupBox5 = new GroupBox();
            label26 = new Label();
            btnRemovePost = new Button();
            btnRemoveFlagPost = new Button();
            label22 = new Label();
            btnBanUserFromPost = new Button();
            btnSuspendUserFromPost = new Button();
            label24 = new Label();
            txtBoxSuspendDaysPosts = new TextBox();
            label25 = new Label();
            groupBox6 = new GroupBox();
            lblPostText = new Label();
            label29 = new Label();
            lblUserEmailPost = new Label();
            label31 = new Label();
            lblUserNamePost = new Label();
            label33 = new Label();
            label34 = new Label();
            pictureBoxPostImage = new PictureBox();
            label35 = new Label();
            lstBoxFlaggedPosts = new ListBox();
            tabPageComments = new TabPage();
            groupBox7 = new GroupBox();
            label27 = new Label();
            btnDeleteComment = new Button();
            btnRemoveFlagComment = new Button();
            label28 = new Label();
            btnBanUserFromComment = new Button();
            btnSupsendUserFromComment = new Button();
            label30 = new Label();
            txtBoxSuspendDaysComments = new TextBox();
            label32 = new Label();
            groupBox8 = new GroupBox();
            lbCommentText = new Label();
            label37 = new Label();
            lblUserEmailComment = new Label();
            label39 = new Label();
            lblUserNameComment = new Label();
            label41 = new Label();
            label43 = new Label();
            lstBoxFlaggedComments = new ListBox();
            tabControl1.SuspendLayout();
            tabPageDashboard.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            tabPageUsers.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxUserProfile).BeginInit();
            tabPageAdmins.SuspendLayout();
            groupBox9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxAdminImage).BeginInit();
            tabPagePosts.SuspendLayout();
            groupBox5.SuspendLayout();
            groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxPostImage).BeginInit();
            tabPageComments.SuspendLayout();
            groupBox7.SuspendLayout();
            groupBox8.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPageDashboard);
            tabControl1.Controls.Add(tabPageUsers);
            tabControl1.Controls.Add(tabPageAdmins);
            tabControl1.Controls.Add(tabPagePosts);
            tabControl1.Controls.Add(tabPageComments);
            tabControl1.Location = new Point(20, 23);
            tabControl1.Margin = new Padding(6, 5, 6, 5);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1700, 1033);
            tabControl1.TabIndex = 0;
            // 
            // tabPageDashboard
            // 
            tabPageDashboard.Controls.Add(groupBox2);
            tabPageDashboard.Controls.Add(groupBox1);
            tabPageDashboard.Controls.Add(label1);
            tabPageDashboard.Location = new Point(4, 34);
            tabPageDashboard.Margin = new Padding(6, 5, 6, 5);
            tabPageDashboard.Name = "tabPageDashboard";
            tabPageDashboard.Padding = new Padding(6, 5, 6, 5);
            tabPageDashboard.Size = new Size(1692, 995);
            tabPageDashboard.TabIndex = 0;
            tabPageDashboard.Text = "Dashboard";
            tabPageDashboard.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(lstBoxFlaggedCommentsDashboard);
            groupBox2.Controls.Add(lstBoxFlaggedPostsDashboard);
            groupBox2.Controls.Add(lstBoxFlaggedUsersDashboard);
            groupBox2.Controls.Add(lblFlaggedCommentsTotal);
            groupBox2.Controls.Add(label11);
            groupBox2.Controls.Add(lblFlaggedUsersTotal);
            groupBox2.Controls.Add(label17);
            groupBox2.Controls.Add(lblFlaggedPostsTotal);
            groupBox2.Controls.Add(label19);
            groupBox2.Location = new Point(10, 305);
            groupBox2.Margin = new Padding(6, 5, 6, 5);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(6, 5, 6, 5);
            groupBox2.Size = new Size(1667, 665);
            groupBox2.TabIndex = 12;
            groupBox2.TabStop = false;
            groupBox2.Text = "Moderation Information";
            // 
            // lstBoxFlaggedCommentsDashboard
            // 
            lstBoxFlaggedCommentsDashboard.FormattingEnabled = true;
            lstBoxFlaggedCommentsDashboard.ItemHeight = 25;
            lstBoxFlaggedCommentsDashboard.Location = new Point(1226, 72);
            lstBoxFlaggedCommentsDashboard.Margin = new Padding(6, 5, 6, 5);
            lstBoxFlaggedCommentsDashboard.Name = "lstBoxFlaggedCommentsDashboard";
            lstBoxFlaggedCommentsDashboard.Size = new Size(371, 554);
            lstBoxFlaggedCommentsDashboard.TabIndex = 12;
            // 
            // lstBoxFlaggedPostsDashboard
            // 
            lstBoxFlaggedPostsDashboard.FormattingEnabled = true;
            lstBoxFlaggedPostsDashboard.ItemHeight = 25;
            lstBoxFlaggedPostsDashboard.Location = new Point(626, 72);
            lstBoxFlaggedPostsDashboard.Margin = new Padding(6, 5, 6, 5);
            lstBoxFlaggedPostsDashboard.Name = "lstBoxFlaggedPostsDashboard";
            lstBoxFlaggedPostsDashboard.Size = new Size(371, 554);
            lstBoxFlaggedPostsDashboard.TabIndex = 11;
            // 
            // lstBoxFlaggedUsersDashboard
            // 
            lstBoxFlaggedUsersDashboard.FormattingEnabled = true;
            lstBoxFlaggedUsersDashboard.ItemHeight = 25;
            lstBoxFlaggedUsersDashboard.Location = new Point(14, 72);
            lstBoxFlaggedUsersDashboard.Margin = new Padding(6, 5, 6, 5);
            lstBoxFlaggedUsersDashboard.Name = "lstBoxFlaggedUsersDashboard";
            lstBoxFlaggedUsersDashboard.Size = new Size(371, 554);
            lstBoxFlaggedUsersDashboard.TabIndex = 10;
            // 
            // lblFlaggedCommentsTotal
            // 
            lblFlaggedCommentsTotal.AutoSize = true;
            lblFlaggedCommentsTotal.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblFlaggedCommentsTotal.Location = new Point(1471, 30);
            lblFlaggedCommentsTotal.Margin = new Padding(6, 0, 6, 0);
            lblFlaggedCommentsTotal.Name = "lblFlaggedCommentsTotal";
            lblFlaggedCommentsTotal.Size = new Size(140, 25);
            lblFlaggedCommentsTotal.TabIndex = 9;
            lblFlaggedCommentsTotal.Text = "{postamount}";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label11.Location = new Point(1189, 30);
            label11.Margin = new Padding(6, 0, 6, 0);
            label11.Name = "label11";
            label11.Size = new Size(255, 29);
            label11.TabIndex = 8;
            label11.Text = "Flagged Comments: ";
            // 
            // lblFlaggedUsersTotal
            // 
            lblFlaggedUsersTotal.AutoSize = true;
            lblFlaggedUsersTotal.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblFlaggedUsersTotal.Location = new Point(223, 35);
            lblFlaggedUsersTotal.Margin = new Padding(6, 0, 6, 0);
            lblFlaggedUsersTotal.Name = "lblFlaggedUsersTotal";
            lblFlaggedUsersTotal.Size = new Size(140, 25);
            lblFlaggedUsersTotal.TabIndex = 3;
            lblFlaggedUsersTotal.Text = "{postamount}";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label17.Location = new Point(10, 30);
            label17.Margin = new Padding(6, 0, 6, 0);
            label17.Name = "label17";
            label17.Size = new Size(192, 29);
            label17.TabIndex = 2;
            label17.Text = "Flagged Users:";
            // 
            // lblFlaggedPostsTotal
            // 
            lblFlaggedPostsTotal.AutoSize = true;
            lblFlaggedPostsTotal.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblFlaggedPostsTotal.Location = new Point(831, 35);
            lblFlaggedPostsTotal.Margin = new Padding(6, 0, 6, 0);
            lblFlaggedPostsTotal.Name = "lblFlaggedPostsTotal";
            lblFlaggedPostsTotal.Size = new Size(140, 25);
            lblFlaggedPostsTotal.TabIndex = 1;
            lblFlaggedPostsTotal.Text = "{postamount}";
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label19.Location = new Point(620, 30);
            label19.Margin = new Padding(6, 0, 6, 0);
            label19.Name = "label19";
            label19.Size = new Size(189, 29);
            label19.TabIndex = 0;
            label19.Text = "Flagged Posts:";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lblCommentsTotal);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(lblLikesTotal);
            groupBox1.Controls.Add(label9);
            groupBox1.Controls.Add(lblPostsToday);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(lblUsersToday);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(lblUsersTotal);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(lblPostsTotal);
            groupBox1.Controls.Add(label2);
            groupBox1.Location = new Point(10, 110);
            groupBox1.Margin = new Padding(6, 5, 6, 5);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(6, 5, 6, 5);
            groupBox1.Size = new Size(1667, 165);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Platform Information";
            // 
            // lblCommentsTotal
            // 
            lblCommentsTotal.AutoSize = true;
            lblCommentsTotal.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblCommentsTotal.Location = new Point(1357, 88);
            lblCommentsTotal.Margin = new Padding(6, 0, 6, 0);
            lblCommentsTotal.Name = "lblCommentsTotal";
            lblCommentsTotal.Size = new Size(140, 25);
            lblCommentsTotal.TabIndex = 11;
            lblCommentsTotal.Text = "{postamount}";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(1189, 85);
            label7.Margin = new Padding(6, 0, 6, 0);
            label7.Name = "label7";
            label7.Size = new Size(144, 29);
            label7.TabIndex = 10;
            label7.Text = "Comments:";
            // 
            // lblLikesTotal
            // 
            lblLikesTotal.AutoSize = true;
            lblLikesTotal.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblLikesTotal.Location = new Point(1284, 35);
            lblLikesTotal.Margin = new Padding(6, 0, 6, 0);
            lblLikesTotal.Name = "lblLikesTotal";
            lblLikesTotal.Size = new Size(140, 25);
            lblLikesTotal.TabIndex = 9;
            lblLikesTotal.Text = "{postamount}";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.Location = new Point(1189, 30);
            label9.Margin = new Padding(6, 0, 6, 0);
            label9.Name = "label9";
            label9.Size = new Size(82, 29);
            label9.TabIndex = 8;
            label9.Text = "Likes:";
            // 
            // lblPostsToday
            // 
            lblPostsToday.AutoSize = true;
            lblPostsToday.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblPostsToday.Location = new Point(894, 88);
            lblPostsToday.Margin = new Padding(6, 0, 6, 0);
            lblPostsToday.Name = "lblPostsToday";
            lblPostsToday.Size = new Size(140, 25);
            lblPostsToday.TabIndex = 7;
            lblPostsToday.Text = "{postamount}";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(620, 85);
            label5.Margin = new Padding(6, 0, 6, 0);
            label5.Name = "label5";
            label5.Size = new Size(243, 29);
            label5.TabIndex = 6;
            label5.Text = "New Posts (Today):";
            // 
            // lblUsersToday
            // 
            lblUsersToday.AutoSize = true;
            lblUsersToday.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblUsersToday.Location = new Point(286, 88);
            lblUsersToday.Margin = new Padding(6, 0, 6, 0);
            lblUsersToday.Name = "lblUsersToday";
            lblUsersToday.Size = new Size(140, 25);
            lblUsersToday.TabIndex = 5;
            lblUsersToday.Text = "{postamount}";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(10, 85);
            label6.Margin = new Padding(6, 0, 6, 0);
            label6.Name = "label6";
            label6.Size = new Size(246, 29);
            label6.TabIndex = 4;
            label6.Text = "New Users (Today):";
            // 
            // lblUsersTotal
            // 
            lblUsersTotal.AutoSize = true;
            lblUsersTotal.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblUsersTotal.Location = new Point(114, 35);
            lblUsersTotal.Margin = new Padding(6, 0, 6, 0);
            lblUsersTotal.Name = "lblUsersTotal";
            lblUsersTotal.Size = new Size(140, 25);
            lblUsersTotal.TabIndex = 3;
            lblUsersTotal.Text = "{postamount}";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(10, 30);
            label4.Margin = new Padding(6, 0, 6, 0);
            label4.Name = "label4";
            label4.Size = new Size(88, 29);
            label4.TabIndex = 2;
            label4.Text = "Users:";
            // 
            // lblPostsTotal
            // 
            lblPostsTotal.AutoSize = true;
            lblPostsTotal.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblPostsTotal.Location = new Point(724, 35);
            lblPostsTotal.Margin = new Padding(6, 0, 6, 0);
            lblPostsTotal.Name = "lblPostsTotal";
            lblPostsTotal.Size = new Size(140, 25);
            lblPostsTotal.TabIndex = 1;
            lblPostsTotal.Text = "{postamount}";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(620, 30);
            label2.Margin = new Padding(6, 0, 6, 0);
            label2.Name = "label2";
            label2.Size = new Size(85, 29);
            label2.TabIndex = 0;
            label2.Text = "Posts:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(414, 23);
            label1.Margin = new Padding(6, 0, 6, 0);
            label1.Name = "label1";
            label1.Size = new Size(762, 64);
            label1.TabIndex = 0;
            label1.Text = "TalkToMe Admin Dashboard";
            // 
            // tabPageUsers
            // 
            tabPageUsers.Controls.Add(groupBox4);
            tabPageUsers.Controls.Add(groupBox3);
            tabPageUsers.Controls.Add(label3);
            tabPageUsers.Controls.Add(lstBoxFlaggedUsers);
            tabPageUsers.Location = new Point(4, 34);
            tabPageUsers.Margin = new Padding(6, 5, 6, 5);
            tabPageUsers.Name = "tabPageUsers";
            tabPageUsers.Padding = new Padding(6, 5, 6, 5);
            tabPageUsers.Size = new Size(1692, 995);
            tabPageUsers.TabIndex = 1;
            tabPageUsers.Text = "Users";
            tabPageUsers.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(btnRemoveFlagUser);
            groupBox4.Controls.Add(label21);
            groupBox4.Controls.Add(btnBanUser);
            groupBox4.Controls.Add(btnSuspendUser);
            groupBox4.Controls.Add(label20);
            groupBox4.Controls.Add(txtBoxSuspendDays);
            groupBox4.Controls.Add(label13);
            groupBox4.Location = new Point(431, 570);
            groupBox4.Margin = new Padding(6, 5, 6, 5);
            groupBox4.Name = "groupBox4";
            groupBox4.Padding = new Padding(6, 5, 6, 5);
            groupBox4.Size = new Size(1246, 408);
            groupBox4.TabIndex = 14;
            groupBox4.TabStop = false;
            groupBox4.Text = "Actions";
            // 
            // btnRemoveFlagUser
            // 
            btnRemoveFlagUser.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRemoveFlagUser.Location = new Point(749, 190);
            btnRemoveFlagUser.Margin = new Padding(6, 5, 6, 5);
            btnRemoveFlagUser.Name = "btnRemoveFlagUser";
            btnRemoveFlagUser.Size = new Size(390, 83);
            btnRemoveFlagUser.TabIndex = 27;
            btnRemoveFlagUser.Text = "Remove Flag";
            btnRemoveFlagUser.UseVisualStyleBackColor = true;
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label21.Location = new Point(30, 237);
            label21.Margin = new Padding(6, 0, 6, 0);
            label21.MaximumSize = new Size(500, 0);
            label21.Name = "label21";
            label21.Size = new Size(445, 44);
            label21.TabIndex = 26;
            label21.Text = "Banning a user is irreversible. User will be able to view content but nothing else.";
            label21.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnBanUser
            // 
            btnBanUser.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBanUser.Location = new Point(153, 313);
            btnBanUser.Margin = new Padding(6, 5, 6, 5);
            btnBanUser.Name = "btnBanUser";
            btnBanUser.Size = new Size(211, 83);
            btnBanUser.TabIndex = 25;
            btnBanUser.Text = "Ban";
            btnBanUser.UseVisualStyleBackColor = true;
            // 
            // btnSuspendUser
            // 
            btnSuspendUser.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSuspendUser.Location = new Point(153, 130);
            btnSuspendUser.Margin = new Padding(6, 5, 6, 5);
            btnSuspendUser.Name = "btnSuspendUser";
            btnSuspendUser.Size = new Size(211, 83);
            btnSuspendUser.TabIndex = 24;
            btnSuspendUser.Text = "Suspend";
            btnSuspendUser.UseVisualStyleBackColor = true;
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label20.Location = new Point(413, 75);
            label20.Margin = new Padding(6, 0, 6, 0);
            label20.Name = "label20";
            label20.Size = new Size(74, 29);
            label20.TabIndex = 23;
            label20.Text = "days.";
            // 
            // txtBoxSuspendDays
            // 
            txtBoxSuspendDays.Location = new Point(247, 75);
            txtBoxSuspendDays.Margin = new Padding(6, 5, 6, 5);
            txtBoxSuspendDays.Name = "txtBoxSuspendDays";
            txtBoxSuspendDays.Size = new Size(164, 31);
            txtBoxSuspendDays.TabIndex = 22;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label13.Location = new Point(14, 75);
            label13.Margin = new Padding(6, 0, 6, 0);
            label13.Name = "label13";
            label13.Size = new Size(219, 29);
            label13.TabIndex = 21;
            label13.Text = "Suspend user for:";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(lblUserBio);
            groupBox3.Controls.Add(label23);
            groupBox3.Controls.Add(lblUserFlagReason);
            groupBox3.Controls.Add(label15);
            groupBox3.Controls.Add(lblUserEmail);
            groupBox3.Controls.Add(label14);
            groupBox3.Controls.Add(lblUserName);
            groupBox3.Controls.Add(label12);
            groupBox3.Controls.Add(label8);
            groupBox3.Controls.Add(pictureBoxUserProfile);
            groupBox3.Location = new Point(431, 70);
            groupBox3.Margin = new Padding(6, 5, 6, 5);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new Padding(6, 5, 6, 5);
            groupBox3.Size = new Size(1246, 488);
            groupBox3.TabIndex = 13;
            groupBox3.TabStop = false;
            groupBox3.Text = "Information";
            // 
            // lblUserBio
            // 
            lblUserBio.AutoSize = true;
            lblUserBio.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblUserBio.Location = new Point(83, 158);
            lblUserBio.Margin = new Padding(6, 0, 6, 0);
            lblUserBio.MaximumSize = new Size(283, 0);
            lblUserBio.Name = "lblUserBio";
            lblUserBio.Size = new Size(282, 75);
            lblUserBio.TabIndex = 22;
            lblUserBio.Text = "{value}fjijwbfhjibfbwhjbfehbefbwhbfhebfwbhfehbbwefhwfhefbhwf";
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label23.Location = new Point(10, 153);
            label23.Margin = new Padding(6, 0, 6, 0);
            label23.Name = "label23";
            label23.Size = new Size(59, 29);
            label23.TabIndex = 21;
            label23.Text = "Bio:";
            // 
            // lblUserFlagReason
            // 
            lblUserFlagReason.AutoSize = true;
            lblUserFlagReason.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblUserFlagReason.Location = new Point(391, 52);
            lblUserFlagReason.Margin = new Padding(6, 0, 6, 0);
            lblUserFlagReason.MaximumSize = new Size(500, 0);
            lblUserFlagReason.Name = "lblUserFlagReason";
            lblUserFlagReason.Size = new Size(497, 50);
            lblUserFlagReason.TabIndex = 20;
            lblUserFlagReason.Text = "{value}fjijwbfhjibfbwhjbfehbefbwhbfhebfwbhfehbbwefhwfhefbhwf";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label15.Location = new Point(287, 48);
            label15.Margin = new Padding(6, 0, 6, 0);
            label15.Name = "label15";
            label15.Size = new Size(109, 29);
            label15.TabIndex = 19;
            label15.Text = "Reason:";
            // 
            // lblUserEmail
            // 
            lblUserEmail.AutoSize = true;
            lblUserEmail.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblUserEmail.Location = new Point(114, 105);
            lblUserEmail.Margin = new Padding(6, 0, 6, 0);
            lblUserEmail.Name = "lblUserEmail";
            lblUserEmail.Size = new Size(80, 25);
            lblUserEmail.TabIndex = 18;
            lblUserEmail.Text = "{value}";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label14.Location = new Point(10, 102);
            label14.Margin = new Padding(6, 0, 6, 0);
            label14.Name = "label14";
            label14.Size = new Size(86, 29);
            label14.TabIndex = 17;
            label14.Text = "Email:";
            // 
            // lblUserName
            // 
            lblUserName.AutoSize = true;
            lblUserName.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblUserName.Location = new Point(114, 52);
            lblUserName.Margin = new Padding(6, 0, 6, 0);
            lblUserName.Name = "lblUserName";
            lblUserName.Size = new Size(80, 25);
            lblUserName.TabIndex = 16;
            lblUserName.Text = "{value}";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label12.Location = new Point(10, 48);
            label12.Margin = new Padding(6, 0, 6, 0);
            label12.Name = "label12";
            label12.Size = new Size(89, 29);
            label12.TabIndex = 15;
            label12.Text = "Name:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(980, 30);
            label8.Margin = new Padding(6, 0, 6, 0);
            label8.Name = "label8";
            label8.Size = new Size(92, 29);
            label8.TabIndex = 15;
            label8.Text = "Image:";
            // 
            // pictureBoxUserProfile
            // 
            pictureBoxUserProfile.Location = new Point(986, 73);
            pictureBoxUserProfile.Margin = new Padding(6, 5, 6, 5);
            pictureBoxUserProfile.Name = "pictureBoxUserProfile";
            pictureBoxUserProfile.Size = new Size(250, 288);
            pictureBoxUserProfile.TabIndex = 0;
            pictureBoxUserProfile.TabStop = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(10, 28);
            label3.Margin = new Padding(6, 0, 6, 0);
            label3.Name = "label3";
            label3.Size = new Size(192, 29);
            label3.TabIndex = 12;
            label3.Text = "Flagged Users:";
            // 
            // lstBoxFlaggedUsers
            // 
            lstBoxFlaggedUsers.FormattingEnabled = true;
            lstBoxFlaggedUsers.ItemHeight = 25;
            lstBoxFlaggedUsers.Location = new Point(10, 70);
            lstBoxFlaggedUsers.Margin = new Padding(6, 5, 6, 5);
            lstBoxFlaggedUsers.Name = "lstBoxFlaggedUsers";
            lstBoxFlaggedUsers.Size = new Size(371, 904);
            lstBoxFlaggedUsers.TabIndex = 11;
            lstBoxFlaggedUsers.SelectedIndexChanged += lstBoxFlaggedUsers_SelectedIndexChanged;
            // 
            // tabPageAdmins
            // 
            tabPageAdmins.Controls.Add(groupBox9);
            tabPageAdmins.Controls.Add(label10);
            tabPageAdmins.Controls.Add(lstBoxAdmins);
            tabPageAdmins.Location = new Point(4, 34);
            tabPageAdmins.Name = "tabPageAdmins";
            tabPageAdmins.Size = new Size(1692, 995);
            tabPageAdmins.TabIndex = 4;
            tabPageAdmins.Text = "Admins";
            tabPageAdmins.UseVisualStyleBackColor = true;
            // 
            // groupBox9
            // 
            groupBox9.Controls.Add(lblAdminStatus);
            groupBox9.Controls.Add(btnRemoveAdmin);
            groupBox9.Controls.Add(btnEditAdmin);
            groupBox9.Controls.Add(btnNewAdmin);
            groupBox9.Controls.Add(label40);
            groupBox9.Controls.Add(pictureBoxAdminImage);
            groupBox9.Controls.Add(btnAdminAttachImage);
            groupBox9.Controls.Add(cmBxAdminPerms);
            groupBox9.Controls.Add(label38);
            groupBox9.Controls.Add(label36);
            groupBox9.Controls.Add(txtAdminEmail);
            groupBox9.Controls.Add(label18);
            groupBox9.Controls.Add(txtAdminPassword);
            groupBox9.Controls.Add(label16);
            groupBox9.Controls.Add(txtAdminUsername);
            groupBox9.Location = new Point(445, 57);
            groupBox9.Name = "groupBox9";
            groupBox9.Size = new Size(1232, 337);
            groupBox9.TabIndex = 15;
            groupBox9.TabStop = false;
            groupBox9.Text = "Manage";
            // 
            // lblAdminStatus
            // 
            lblAdminStatus.AutoSize = true;
            lblAdminStatus.Location = new Point(321, 134);
            lblAdminStatus.Name = "lblAdminStatus";
            lblAdminStatus.Size = new Size(69, 25);
            lblAdminStatus.TabIndex = 15;
            lblAdminStatus.Text = "Status: ";
            // 
            // btnRemoveAdmin
            // 
            btnRemoveAdmin.Location = new Point(15, 268);
            btnRemoveAdmin.Name = "btnRemoveAdmin";
            btnRemoveAdmin.Size = new Size(238, 61);
            btnRemoveAdmin.TabIndex = 14;
            btnRemoveAdmin.Text = "Remove Admin";
            btnRemoveAdmin.UseVisualStyleBackColor = true;
            btnRemoveAdmin.Click += btnRemoveAdmin_Click;
            // 
            // btnEditAdmin
            // 
            btnEditAdmin.Location = new Point(15, 201);
            btnEditAdmin.Name = "btnEditAdmin";
            btnEditAdmin.Size = new Size(238, 61);
            btnEditAdmin.TabIndex = 13;
            btnEditAdmin.Text = "Edit Admin";
            btnEditAdmin.UseVisualStyleBackColor = true;
            btnEditAdmin.Click += btnEditAdmin_Click;
            // 
            // btnNewAdmin
            // 
            btnNewAdmin.Location = new Point(15, 134);
            btnNewAdmin.Name = "btnNewAdmin";
            btnNewAdmin.Size = new Size(238, 61);
            btnNewAdmin.TabIndex = 12;
            btnNewAdmin.Text = "New Admin";
            btnNewAdmin.UseVisualStyleBackColor = true;
            btnNewAdmin.Click += btnNewAdmin_Click;
            // 
            // label40
            // 
            label40.AutoSize = true;
            label40.Location = new Point(1009, 32);
            label40.Name = "label40";
            label40.Size = new Size(62, 25);
            label40.TabIndex = 11;
            label40.Text = "Image";
            // 
            // pictureBoxAdminImage
            // 
            pictureBoxAdminImage.Location = new Point(1013, 60);
            pictureBoxAdminImage.Name = "pictureBoxAdminImage";
            pictureBoxAdminImage.Size = new Size(213, 213);
            pictureBoxAdminImage.TabIndex = 10;
            pictureBoxAdminImage.TabStop = false;
            // 
            // btnAdminAttachImage
            // 
            btnAdminAttachImage.Location = new Point(1013, 279);
            btnAdminAttachImage.Name = "btnAdminAttachImage";
            btnAdminAttachImage.Size = new Size(213, 34);
            btnAdminAttachImage.TabIndex = 9;
            btnAdminAttachImage.Text = "Attach Image";
            btnAdminAttachImage.UseVisualStyleBackColor = true;
            btnAdminAttachImage.Click += btnAdminAttachImage_Click;
            // 
            // cmBxAdminPerms
            // 
            cmBxAdminPerms.FormattingEnabled = true;
            cmBxAdminPerms.Location = new Point(835, 60);
            cmBxAdminPerms.Name = "cmBxAdminPerms";
            cmBxAdminPerms.Size = new Size(172, 33);
            cmBxAdminPerms.TabIndex = 8;
            // 
            // label38
            // 
            label38.AutoSize = true;
            label38.Location = new Point(835, 32);
            label38.Name = "label38";
            label38.Size = new Size(105, 25);
            label38.TabIndex = 7;
            label38.Text = "Permissions";
            // 
            // label36
            // 
            label36.AutoSize = true;
            label36.Location = new Point(284, 32);
            label36.Name = "label36";
            label36.Size = new Size(54, 25);
            label36.TabIndex = 5;
            label36.Text = "Email";
            // 
            // txtAdminEmail
            // 
            txtAdminEmail.Location = new Point(284, 60);
            txtAdminEmail.Name = "txtAdminEmail";
            txtAdminEmail.Size = new Size(262, 31);
            txtAdminEmail.TabIndex = 4;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new Point(562, 32);
            label18.Name = "label18";
            label18.Size = new Size(87, 25);
            label18.TabIndex = 3;
            label18.Text = "Password";
            // 
            // txtAdminPassword
            // 
            txtAdminPassword.Location = new Point(562, 60);
            txtAdminPassword.Name = "txtAdminPassword";
            txtAdminPassword.Size = new Size(262, 31);
            txtAdminPassword.TabIndex = 2;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(6, 32);
            label16.Name = "label16";
            label16.Size = new Size(91, 25);
            label16.TabIndex = 1;
            label16.Text = "Username";
            // 
            // txtAdminUsername
            // 
            txtAdminUsername.Location = new Point(6, 60);
            txtAdminUsername.Name = "txtAdminUsername";
            txtAdminUsername.Size = new Size(262, 31);
            txtAdminUsername.TabIndex = 0;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.Location = new Point(17, 15);
            label10.Margin = new Padding(6, 0, 6, 0);
            label10.Name = "label10";
            label10.Size = new Size(99, 29);
            label10.TabIndex = 14;
            label10.Text = "Admins";
            // 
            // lstBoxAdmins
            // 
            lstBoxAdmins.FormattingEnabled = true;
            lstBoxAdmins.ItemHeight = 25;
            lstBoxAdmins.Location = new Point(17, 57);
            lstBoxAdmins.Margin = new Padding(6, 5, 6, 5);
            lstBoxAdmins.Name = "lstBoxAdmins";
            lstBoxAdmins.Size = new Size(371, 904);
            lstBoxAdmins.TabIndex = 13;
            lstBoxAdmins.SelectedIndexChanged += lstBoxAdmins_SelectedIndexChanged;
            // 
            // tabPagePosts
            // 
            tabPagePosts.Controls.Add(groupBox5);
            tabPagePosts.Controls.Add(groupBox6);
            tabPagePosts.Controls.Add(label35);
            tabPagePosts.Controls.Add(lstBoxFlaggedPosts);
            tabPagePosts.Location = new Point(4, 34);
            tabPagePosts.Margin = new Padding(6, 5, 6, 5);
            tabPagePosts.Name = "tabPagePosts";
            tabPagePosts.Size = new Size(1692, 995);
            tabPagePosts.TabIndex = 2;
            tabPagePosts.Text = "Posts";
            tabPagePosts.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(label26);
            groupBox5.Controls.Add(btnRemovePost);
            groupBox5.Controls.Add(btnRemoveFlagPost);
            groupBox5.Controls.Add(label22);
            groupBox5.Controls.Add(btnBanUserFromPost);
            groupBox5.Controls.Add(btnSuspendUserFromPost);
            groupBox5.Controls.Add(label24);
            groupBox5.Controls.Add(txtBoxSuspendDaysPosts);
            groupBox5.Controls.Add(label25);
            groupBox5.Location = new Point(431, 558);
            groupBox5.Margin = new Padding(6, 5, 6, 5);
            groupBox5.Name = "groupBox5";
            groupBox5.Padding = new Padding(6, 5, 6, 5);
            groupBox5.Size = new Size(1246, 408);
            groupBox5.TabIndex = 18;
            groupBox5.TabStop = false;
            groupBox5.Text = "Actions";
            // 
            // label26
            // 
            label26.AutoSize = true;
            label26.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label26.Location = new Point(827, 122);
            label26.Margin = new Padding(6, 0, 6, 0);
            label26.MaximumSize = new Size(500, 0);
            label26.Name = "label26";
            label26.Size = new Size(246, 22);
            label26.TabIndex = 29;
            label26.Text = "Deleting a post is irreversible.";
            label26.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnRemovePost
            // 
            btnRemovePost.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRemovePost.Location = new Point(773, 155);
            btnRemovePost.Margin = new Padding(6, 5, 6, 5);
            btnRemovePost.Name = "btnRemovePost";
            btnRemovePost.Size = new Size(390, 83);
            btnRemovePost.TabIndex = 28;
            btnRemovePost.Text = "Delete Post";
            btnRemovePost.UseVisualStyleBackColor = true;
            // 
            // btnRemoveFlagPost
            // 
            btnRemoveFlagPost.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRemoveFlagPost.Location = new Point(773, 285);
            btnRemoveFlagPost.Margin = new Padding(6, 5, 6, 5);
            btnRemoveFlagPost.Name = "btnRemoveFlagPost";
            btnRemoveFlagPost.Size = new Size(390, 83);
            btnRemoveFlagPost.TabIndex = 27;
            btnRemoveFlagPost.Text = "Remove Flag";
            btnRemoveFlagPost.UseVisualStyleBackColor = true;
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label22.Location = new Point(30, 237);
            label22.Margin = new Padding(6, 0, 6, 0);
            label22.MaximumSize = new Size(500, 0);
            label22.Name = "label22";
            label22.Size = new Size(445, 44);
            label22.TabIndex = 26;
            label22.Text = "Banning a user is irreversible. User will be able to view content but nothing else.";
            label22.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnBanUserFromPost
            // 
            btnBanUserFromPost.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBanUserFromPost.Location = new Point(153, 313);
            btnBanUserFromPost.Margin = new Padding(6, 5, 6, 5);
            btnBanUserFromPost.Name = "btnBanUserFromPost";
            btnBanUserFromPost.Size = new Size(211, 83);
            btnBanUserFromPost.TabIndex = 25;
            btnBanUserFromPost.Text = "Ban";
            btnBanUserFromPost.UseVisualStyleBackColor = true;
            // 
            // btnSuspendUserFromPost
            // 
            btnSuspendUserFromPost.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSuspendUserFromPost.Location = new Point(153, 130);
            btnSuspendUserFromPost.Margin = new Padding(6, 5, 6, 5);
            btnSuspendUserFromPost.Name = "btnSuspendUserFromPost";
            btnSuspendUserFromPost.Size = new Size(211, 83);
            btnSuspendUserFromPost.TabIndex = 24;
            btnSuspendUserFromPost.Text = "Suspend";
            btnSuspendUserFromPost.UseVisualStyleBackColor = true;
            // 
            // label24
            // 
            label24.AutoSize = true;
            label24.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label24.Location = new Point(413, 75);
            label24.Margin = new Padding(6, 0, 6, 0);
            label24.Name = "label24";
            label24.Size = new Size(74, 29);
            label24.TabIndex = 23;
            label24.Text = "days.";
            // 
            // txtBoxSuspendDaysPosts
            // 
            txtBoxSuspendDaysPosts.Location = new Point(247, 75);
            txtBoxSuspendDaysPosts.Margin = new Padding(6, 5, 6, 5);
            txtBoxSuspendDaysPosts.Name = "txtBoxSuspendDaysPosts";
            txtBoxSuspendDaysPosts.Size = new Size(164, 31);
            txtBoxSuspendDaysPosts.TabIndex = 22;
            // 
            // label25
            // 
            label25.AutoSize = true;
            label25.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label25.Location = new Point(14, 75);
            label25.Margin = new Padding(6, 0, 6, 0);
            label25.Name = "label25";
            label25.Size = new Size(219, 29);
            label25.TabIndex = 21;
            label25.Text = "Suspend user for:";
            // 
            // groupBox6
            // 
            groupBox6.Controls.Add(lblPostText);
            groupBox6.Controls.Add(label29);
            groupBox6.Controls.Add(lblUserEmailPost);
            groupBox6.Controls.Add(label31);
            groupBox6.Controls.Add(lblUserNamePost);
            groupBox6.Controls.Add(label33);
            groupBox6.Controls.Add(label34);
            groupBox6.Controls.Add(pictureBoxPostImage);
            groupBox6.Location = new Point(431, 58);
            groupBox6.Margin = new Padding(6, 5, 6, 5);
            groupBox6.Name = "groupBox6";
            groupBox6.Padding = new Padding(6, 5, 6, 5);
            groupBox6.Size = new Size(1246, 488);
            groupBox6.TabIndex = 17;
            groupBox6.TabStop = false;
            groupBox6.Text = "Information";
            // 
            // lblPostText
            // 
            lblPostText.AutoSize = true;
            lblPostText.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblPostText.Location = new Point(489, 52);
            lblPostText.Margin = new Padding(6, 0, 6, 0);
            lblPostText.MaximumSize = new Size(467, 0);
            lblPostText.Name = "lblPostText";
            lblPostText.Size = new Size(458, 50);
            lblPostText.TabIndex = 20;
            lblPostText.Text = "{value}fjijwbfhjibfbwhjbfehbefbwhbfhebfwbhfehbbwefhwfhefbhwf";
            // 
            // label29
            // 
            label29.AutoSize = true;
            label29.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label29.Location = new Point(337, 52);
            label29.Margin = new Padding(6, 0, 6, 0);
            label29.Name = "label29";
            label29.Size = new Size(130, 29);
            label29.TabIndex = 19;
            label29.Text = "Post Text:";
            // 
            // lblUserEmailPost
            // 
            lblUserEmailPost.AutoSize = true;
            lblUserEmailPost.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblUserEmailPost.Location = new Point(183, 105);
            lblUserEmailPost.Margin = new Padding(6, 0, 6, 0);
            lblUserEmailPost.Name = "lblUserEmailPost";
            lblUserEmailPost.Size = new Size(80, 25);
            lblUserEmailPost.TabIndex = 18;
            lblUserEmailPost.Text = "{value}";
            // 
            // label31
            // 
            label31.AutoSize = true;
            label31.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label31.Location = new Point(10, 102);
            label31.Margin = new Padding(6, 0, 6, 0);
            label31.Name = "label31";
            label31.Size = new Size(148, 29);
            label31.TabIndex = 17;
            label31.Text = "User Email:";
            // 
            // lblUserNamePost
            // 
            lblUserNamePost.AutoSize = true;
            lblUserNamePost.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblUserNamePost.Location = new Point(183, 52);
            lblUserNamePost.Margin = new Padding(6, 0, 6, 0);
            lblUserNamePost.Name = "lblUserNamePost";
            lblUserNamePost.Size = new Size(80, 25);
            lblUserNamePost.TabIndex = 16;
            lblUserNamePost.Text = "{value}";
            // 
            // label33
            // 
            label33.AutoSize = true;
            label33.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label33.Location = new Point(10, 48);
            label33.Margin = new Padding(6, 0, 6, 0);
            label33.Name = "label33";
            label33.Size = new Size(151, 29);
            label33.TabIndex = 15;
            label33.Text = "User Name:";
            // 
            // label34
            // 
            label34.AutoSize = true;
            label34.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label34.Location = new Point(980, 40);
            label34.Margin = new Padding(6, 0, 6, 0);
            label34.Name = "label34";
            label34.Size = new Size(151, 29);
            label34.TabIndex = 15;
            label34.Text = "Post Image:";
            // 
            // pictureBoxPostImage
            // 
            pictureBoxPostImage.Location = new Point(986, 83);
            pictureBoxPostImage.Margin = new Padding(6, 5, 6, 5);
            pictureBoxPostImage.Name = "pictureBoxPostImage";
            pictureBoxPostImage.Size = new Size(250, 288);
            pictureBoxPostImage.TabIndex = 0;
            pictureBoxPostImage.TabStop = false;
            // 
            // label35
            // 
            label35.AutoSize = true;
            label35.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label35.Location = new Point(10, 17);
            label35.Margin = new Padding(6, 0, 6, 0);
            label35.Name = "label35";
            label35.Size = new Size(189, 29);
            label35.TabIndex = 16;
            label35.Text = "Flagged Posts:";
            // 
            // lstBoxFlaggedPosts
            // 
            lstBoxFlaggedPosts.FormattingEnabled = true;
            lstBoxFlaggedPosts.ItemHeight = 25;
            lstBoxFlaggedPosts.Location = new Point(10, 58);
            lstBoxFlaggedPosts.Margin = new Padding(6, 5, 6, 5);
            lstBoxFlaggedPosts.Name = "lstBoxFlaggedPosts";
            lstBoxFlaggedPosts.Size = new Size(371, 904);
            lstBoxFlaggedPosts.TabIndex = 15;
            lstBoxFlaggedPosts.SelectedIndexChanged += lstBoxFlaggedPosts_SelectedIndexChanged;
            // 
            // tabPageComments
            // 
            tabPageComments.Controls.Add(groupBox7);
            tabPageComments.Controls.Add(groupBox8);
            tabPageComments.Controls.Add(label43);
            tabPageComments.Controls.Add(lstBoxFlaggedComments);
            tabPageComments.Location = new Point(4, 34);
            tabPageComments.Margin = new Padding(6, 5, 6, 5);
            tabPageComments.Name = "tabPageComments";
            tabPageComments.Size = new Size(1692, 995);
            tabPageComments.TabIndex = 3;
            tabPageComments.Text = "Comments";
            tabPageComments.UseVisualStyleBackColor = true;
            // 
            // groupBox7
            // 
            groupBox7.Controls.Add(label27);
            groupBox7.Controls.Add(btnDeleteComment);
            groupBox7.Controls.Add(btnRemoveFlagComment);
            groupBox7.Controls.Add(label28);
            groupBox7.Controls.Add(btnBanUserFromComment);
            groupBox7.Controls.Add(btnSupsendUserFromComment);
            groupBox7.Controls.Add(label30);
            groupBox7.Controls.Add(txtBoxSuspendDaysComments);
            groupBox7.Controls.Add(label32);
            groupBox7.Location = new Point(431, 558);
            groupBox7.Margin = new Padding(6, 5, 6, 5);
            groupBox7.Name = "groupBox7";
            groupBox7.Padding = new Padding(6, 5, 6, 5);
            groupBox7.Size = new Size(1246, 408);
            groupBox7.TabIndex = 22;
            groupBox7.TabStop = false;
            groupBox7.Text = "Actions";
            // 
            // label27
            // 
            label27.AutoSize = true;
            label27.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label27.Location = new Point(827, 122);
            label27.Margin = new Padding(6, 0, 6, 0);
            label27.MaximumSize = new Size(500, 0);
            label27.Name = "label27";
            label27.Size = new Size(284, 22);
            label27.TabIndex = 29;
            label27.Text = "Deleting a comment is irreversible.";
            label27.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnDeleteComment
            // 
            btnDeleteComment.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDeleteComment.Location = new Point(773, 155);
            btnDeleteComment.Margin = new Padding(6, 5, 6, 5);
            btnDeleteComment.Name = "btnDeleteComment";
            btnDeleteComment.Size = new Size(390, 83);
            btnDeleteComment.TabIndex = 28;
            btnDeleteComment.Text = "Delete Comment";
            btnDeleteComment.UseVisualStyleBackColor = true;
            // 
            // btnRemoveFlagComment
            // 
            btnRemoveFlagComment.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRemoveFlagComment.Location = new Point(773, 285);
            btnRemoveFlagComment.Margin = new Padding(6, 5, 6, 5);
            btnRemoveFlagComment.Name = "btnRemoveFlagComment";
            btnRemoveFlagComment.Size = new Size(390, 83);
            btnRemoveFlagComment.TabIndex = 27;
            btnRemoveFlagComment.Text = "Remove Flag";
            btnRemoveFlagComment.UseVisualStyleBackColor = true;
            // 
            // label28
            // 
            label28.AutoSize = true;
            label28.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label28.Location = new Point(30, 237);
            label28.Margin = new Padding(6, 0, 6, 0);
            label28.MaximumSize = new Size(500, 0);
            label28.Name = "label28";
            label28.Size = new Size(445, 44);
            label28.TabIndex = 26;
            label28.Text = "Banning a user is irreversible. User will be able to view content but nothing else.";
            label28.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnBanUserFromComment
            // 
            btnBanUserFromComment.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBanUserFromComment.Location = new Point(153, 313);
            btnBanUserFromComment.Margin = new Padding(6, 5, 6, 5);
            btnBanUserFromComment.Name = "btnBanUserFromComment";
            btnBanUserFromComment.Size = new Size(211, 83);
            btnBanUserFromComment.TabIndex = 25;
            btnBanUserFromComment.Text = "Ban";
            btnBanUserFromComment.UseVisualStyleBackColor = true;
            // 
            // btnSupsendUserFromComment
            // 
            btnSupsendUserFromComment.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSupsendUserFromComment.Location = new Point(153, 130);
            btnSupsendUserFromComment.Margin = new Padding(6, 5, 6, 5);
            btnSupsendUserFromComment.Name = "btnSupsendUserFromComment";
            btnSupsendUserFromComment.Size = new Size(211, 83);
            btnSupsendUserFromComment.TabIndex = 24;
            btnSupsendUserFromComment.Text = "Suspend";
            btnSupsendUserFromComment.UseVisualStyleBackColor = true;
            // 
            // label30
            // 
            label30.AutoSize = true;
            label30.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label30.Location = new Point(413, 75);
            label30.Margin = new Padding(6, 0, 6, 0);
            label30.Name = "label30";
            label30.Size = new Size(74, 29);
            label30.TabIndex = 23;
            label30.Text = "days.";
            // 
            // txtBoxSuspendDaysComments
            // 
            txtBoxSuspendDaysComments.Location = new Point(247, 75);
            txtBoxSuspendDaysComments.Margin = new Padding(6, 5, 6, 5);
            txtBoxSuspendDaysComments.Name = "txtBoxSuspendDaysComments";
            txtBoxSuspendDaysComments.Size = new Size(164, 31);
            txtBoxSuspendDaysComments.TabIndex = 22;
            // 
            // label32
            // 
            label32.AutoSize = true;
            label32.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label32.Location = new Point(14, 75);
            label32.Margin = new Padding(6, 0, 6, 0);
            label32.Name = "label32";
            label32.Size = new Size(219, 29);
            label32.TabIndex = 21;
            label32.Text = "Suspend user for:";
            // 
            // groupBox8
            // 
            groupBox8.Controls.Add(lbCommentText);
            groupBox8.Controls.Add(label37);
            groupBox8.Controls.Add(lblUserEmailComment);
            groupBox8.Controls.Add(label39);
            groupBox8.Controls.Add(lblUserNameComment);
            groupBox8.Controls.Add(label41);
            groupBox8.Location = new Point(431, 58);
            groupBox8.Margin = new Padding(6, 5, 6, 5);
            groupBox8.Name = "groupBox8";
            groupBox8.Padding = new Padding(6, 5, 6, 5);
            groupBox8.Size = new Size(1246, 488);
            groupBox8.TabIndex = 21;
            groupBox8.TabStop = false;
            groupBox8.Text = "Information";
            // 
            // lbCommentText
            // 
            lbCommentText.AutoSize = true;
            lbCommentText.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lbCommentText.Location = new Point(551, 52);
            lbCommentText.Margin = new Padding(6, 0, 6, 0);
            lbCommentText.MaximumSize = new Size(467, 0);
            lbCommentText.Name = "lbCommentText";
            lbCommentText.Size = new Size(458, 50);
            lbCommentText.TabIndex = 20;
            lbCommentText.Text = "{value}fjijwbfhjibfbwhjbfehbefbwhbfhebfwbhfehbbwefhwfhefbhwf";
            // 
            // label37
            // 
            label37.AutoSize = true;
            label37.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label37.Location = new Point(337, 52);
            label37.Margin = new Padding(6, 0, 6, 0);
            label37.Name = "label37";
            label37.Size = new Size(189, 29);
            label37.TabIndex = 19;
            label37.Text = "Comment Text:";
            // 
            // lblUserEmailComment
            // 
            lblUserEmailComment.AutoSize = true;
            lblUserEmailComment.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblUserEmailComment.Location = new Point(183, 105);
            lblUserEmailComment.Margin = new Padding(6, 0, 6, 0);
            lblUserEmailComment.Name = "lblUserEmailComment";
            lblUserEmailComment.Size = new Size(80, 25);
            lblUserEmailComment.TabIndex = 18;
            lblUserEmailComment.Text = "{value}";
            // 
            // label39
            // 
            label39.AutoSize = true;
            label39.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label39.Location = new Point(10, 102);
            label39.Margin = new Padding(6, 0, 6, 0);
            label39.Name = "label39";
            label39.Size = new Size(148, 29);
            label39.TabIndex = 17;
            label39.Text = "User Email:";
            // 
            // lblUserNameComment
            // 
            lblUserNameComment.AutoSize = true;
            lblUserNameComment.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblUserNameComment.Location = new Point(183, 52);
            lblUserNameComment.Margin = new Padding(6, 0, 6, 0);
            lblUserNameComment.Name = "lblUserNameComment";
            lblUserNameComment.Size = new Size(80, 25);
            lblUserNameComment.TabIndex = 16;
            lblUserNameComment.Text = "{value}";
            // 
            // label41
            // 
            label41.AutoSize = true;
            label41.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label41.Location = new Point(10, 48);
            label41.Margin = new Padding(6, 0, 6, 0);
            label41.Name = "label41";
            label41.Size = new Size(151, 29);
            label41.TabIndex = 15;
            label41.Text = "User Name:";
            // 
            // label43
            // 
            label43.AutoSize = true;
            label43.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label43.Location = new Point(10, 17);
            label43.Margin = new Padding(6, 0, 6, 0);
            label43.Name = "label43";
            label43.Size = new Size(248, 29);
            label43.TabIndex = 20;
            label43.Text = "Flagged Comments:";
            // 
            // lstBoxFlaggedComments
            // 
            lstBoxFlaggedComments.FormattingEnabled = true;
            lstBoxFlaggedComments.ItemHeight = 25;
            lstBoxFlaggedComments.Location = new Point(10, 58);
            lstBoxFlaggedComments.Margin = new Padding(6, 5, 6, 5);
            lstBoxFlaggedComments.Name = "lstBoxFlaggedComments";
            lstBoxFlaggedComments.Size = new Size(371, 904);
            lstBoxFlaggedComments.TabIndex = 19;
            lstBoxFlaggedComments.SelectedIndexChanged += lstBoxFlaggedComments_SelectedIndexChanged;
            // 
            // AdminDashboard
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1740, 1078);
            Controls.Add(tabControl1);
            Margin = new Padding(6, 5, 6, 5);
            Name = "AdminDashboard";
            Text = "Admin Dashboard - TalkToMe";
            tabControl1.ResumeLayout(false);
            tabPageDashboard.ResumeLayout(false);
            tabPageDashboard.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            tabPageUsers.ResumeLayout(false);
            tabPageUsers.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxUserProfile).EndInit();
            tabPageAdmins.ResumeLayout(false);
            tabPageAdmins.PerformLayout();
            groupBox9.ResumeLayout(false);
            groupBox9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxAdminImage).EndInit();
            tabPagePosts.ResumeLayout(false);
            tabPagePosts.PerformLayout();
            groupBox5.ResumeLayout(false);
            groupBox5.PerformLayout();
            groupBox6.ResumeLayout(false);
            groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxPostImage).EndInit();
            tabPageComments.ResumeLayout(false);
            tabPageComments.PerformLayout();
            groupBox7.ResumeLayout(false);
            groupBox7.PerformLayout();
            groupBox8.ResumeLayout(false);
            groupBox8.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageDashboard;
        private System.Windows.Forms.TabPage tabPageUsers;
        private System.Windows.Forms.TabPage tabPagePosts;
        private System.Windows.Forms.TabPage tabPageComments;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblPostsToday;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblUsersToday;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblUsersTotal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblPostsTotal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox lstBoxFlaggedCommentsDashboard;
        private System.Windows.Forms.ListBox lstBoxFlaggedPostsDashboard;
        private System.Windows.Forms.ListBox lstBoxFlaggedUsersDashboard;
        private System.Windows.Forms.Label lblFlaggedCommentsTotal;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblFlaggedUsersTotal;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label lblFlaggedPostsTotal;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label lblCommentsTotal;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblLikesTotal;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblUserFlagReason;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lblUserEmail;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox pictureBoxUserProfile;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox lstBoxFlaggedUsers;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txtBoxSuspendDays;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Button btnBanUser;
        private System.Windows.Forms.Button btnSuspendUser;
        private System.Windows.Forms.Label lblUserBio;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label lblPostText;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label lblUserEmailPost;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label lblUserNamePost;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.PictureBox pictureBoxPostImage;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.ListBox lstBoxFlaggedPosts;
        private System.Windows.Forms.Button btnRemoveFlagUser;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Button btnRemovePost;
        private System.Windows.Forms.Button btnRemoveFlagPost;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Button btnBanUserFromPost;
        private System.Windows.Forms.Button btnSuspendUserFromPost;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox txtBoxSuspendDaysPosts;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Button btnDeleteComment;
        private System.Windows.Forms.Button btnRemoveFlagComment;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Button btnBanUserFromComment;
        private System.Windows.Forms.Button btnSupsendUserFromComment;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.TextBox txtBoxSuspendDaysComments;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Label lbCommentText;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Label lblUserEmailComment;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.Label lblUserNameComment;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.ListBox lstBoxFlaggedComments;
        private TabPage tabPageAdmins;
        private GroupBox groupBox9;
        private Label label10;
        private ListBox lstBoxAdmins;
        private Label label40;
        private PictureBox pictureBox1;
        private Button btnAdminAttachImage;
        private PictureBox pictureBoxAdminImage;
        private ComboBox comboBox1;
        private Label label38;
        private ComboBox cmBxAdminPerms;
        private TextBox textBox4;
        private Label label36;
        private TextBox txtAdminEmail;
        private TextBox textBox3;
        private Label label18;
        private TextBox txtAdminPassword;
        private TextBox textBox2;
        private Label label16;
        private TextBox txtAdminUsername;
        private Label lblAdminStatus;
        private Button btnRemoveAdmin;
        private Button btnEditAdmin;
        private Button btnNewAdmin;
    }
}

