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
            groupBox10 = new GroupBox();
            btnBanUser = new Button();
            btnUnbanUser = new Button();
            groupBox11 = new GroupBox();
            lblUserStatus = new Label();
            label24 = new Label();
            lblUserBio = new Label();
            label30 = new Label();
            lblUserEmail = new Label();
            label46 = new Label();
            lblUserName = new Label();
            label48 = new Label();
            label49 = new Label();
            pictureBoxUserImage = new PictureBox();
            label50 = new Label();
            lstBoxUsers = new ListBox();
            tabPageAdmins = new TabPage();
            groupBox9 = new GroupBox();
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
            tabPageFUsers = new TabPage();
            groupBox4 = new GroupBox();
            btnRemoveFlagUser = new Button();
            btnBanFlaggedUser = new Button();
            btnUnbanFlaggedUser = new Button();
            groupBox3 = new GroupBox();
            lblFlaggedUserStatus = new Label();
            label44 = new Label();
            lblFlaggedUserBio = new Label();
            label23 = new Label();
            lblUserFlagReason = new Label();
            label15 = new Label();
            lblFlaggedUserEmail = new Label();
            label14 = new Label();
            lblFlaggedUserName = new Label();
            label12 = new Label();
            label8 = new Label();
            pictureBoxFlaggedUserProfile = new PictureBox();
            label3 = new Label();
            lstBoxFlaggedUsers = new ListBox();
            tabPageFPosts = new TabPage();
            groupBox5 = new GroupBox();
            label26 = new Label();
            btnRemovePost = new Button();
            btnRemoveFlagPost = new Button();
            btnBanUserFromPost = new Button();
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
            tabPageFComments = new TabPage();
            groupBox7 = new GroupBox();
            label27 = new Label();
            btnDeleteComment = new Button();
            btnRemoveFlagComment = new Button();
            btnBanUserFromComment = new Button();
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
            groupBox10.SuspendLayout();
            groupBox11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxUserImage).BeginInit();
            tabPageAdmins.SuspendLayout();
            groupBox9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxAdminImage).BeginInit();
            tabPageFUsers.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxFlaggedUserProfile).BeginInit();
            tabPageFPosts.SuspendLayout();
            groupBox5.SuspendLayout();
            groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxPostImage).BeginInit();
            tabPageFComments.SuspendLayout();
            groupBox7.SuspendLayout();
            groupBox8.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPageDashboard);
            tabControl1.Controls.Add(tabPageUsers);
            tabControl1.Controls.Add(tabPageAdmins);
            tabControl1.Controls.Add(tabPageFUsers);
            tabControl1.Controls.Add(tabPageFPosts);
            tabControl1.Controls.Add(tabPageFComments);
            tabControl1.Location = new Point(14, 14);
            tabControl1.Margin = new Padding(4, 3, 4, 3);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1190, 620);
            tabControl1.TabIndex = 0;
            // 
            // tabPageDashboard
            // 
            tabPageDashboard.Controls.Add(groupBox2);
            tabPageDashboard.Controls.Add(groupBox1);
            tabPageDashboard.Controls.Add(label1);
            tabPageDashboard.Location = new Point(4, 24);
            tabPageDashboard.Margin = new Padding(4, 3, 4, 3);
            tabPageDashboard.Name = "tabPageDashboard";
            tabPageDashboard.Padding = new Padding(4, 3, 4, 3);
            tabPageDashboard.Size = new Size(1182, 592);
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
            groupBox2.Location = new Point(7, 183);
            groupBox2.Margin = new Padding(4, 3, 4, 3);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(4, 3, 4, 3);
            groupBox2.Size = new Size(1167, 399);
            groupBox2.TabIndex = 12;
            groupBox2.TabStop = false;
            groupBox2.Text = "Moderation Information";
            // 
            // lstBoxFlaggedCommentsDashboard
            // 
            lstBoxFlaggedCommentsDashboard.FormattingEnabled = true;
            lstBoxFlaggedCommentsDashboard.ItemHeight = 15;
            lstBoxFlaggedCommentsDashboard.Location = new Point(858, 43);
            lstBoxFlaggedCommentsDashboard.Margin = new Padding(4, 3, 4, 3);
            lstBoxFlaggedCommentsDashboard.Name = "lstBoxFlaggedCommentsDashboard";
            lstBoxFlaggedCommentsDashboard.Size = new Size(261, 334);
            lstBoxFlaggedCommentsDashboard.TabIndex = 12;
            // 
            // lstBoxFlaggedPostsDashboard
            // 
            lstBoxFlaggedPostsDashboard.FormattingEnabled = true;
            lstBoxFlaggedPostsDashboard.ItemHeight = 15;
            lstBoxFlaggedPostsDashboard.Location = new Point(438, 43);
            lstBoxFlaggedPostsDashboard.Margin = new Padding(4, 3, 4, 3);
            lstBoxFlaggedPostsDashboard.Name = "lstBoxFlaggedPostsDashboard";
            lstBoxFlaggedPostsDashboard.Size = new Size(261, 334);
            lstBoxFlaggedPostsDashboard.TabIndex = 11;
            // 
            // lstBoxFlaggedUsersDashboard
            // 
            lstBoxFlaggedUsersDashboard.FormattingEnabled = true;
            lstBoxFlaggedUsersDashboard.ItemHeight = 15;
            lstBoxFlaggedUsersDashboard.Location = new Point(10, 43);
            lstBoxFlaggedUsersDashboard.Margin = new Padding(4, 3, 4, 3);
            lstBoxFlaggedUsersDashboard.Name = "lstBoxFlaggedUsersDashboard";
            lstBoxFlaggedUsersDashboard.Size = new Size(261, 334);
            lstBoxFlaggedUsersDashboard.TabIndex = 10;
            // 
            // lblFlaggedCommentsTotal
            // 
            lblFlaggedCommentsTotal.AutoSize = true;
            lblFlaggedCommentsTotal.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblFlaggedCommentsTotal.Location = new Point(1030, 18);
            lblFlaggedCommentsTotal.Margin = new Padding(4, 0, 4, 0);
            lblFlaggedCommentsTotal.Name = "lblFlaggedCommentsTotal";
            lblFlaggedCommentsTotal.Size = new Size(44, 16);
            lblFlaggedCommentsTotal.TabIndex = 9;
            lblFlaggedCommentsTotal.Text = "None";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label11.Location = new Point(832, 18);
            label11.Margin = new Padding(4, 0, 4, 0);
            label11.Name = "label11";
            label11.Size = new Size(164, 18);
            label11.TabIndex = 8;
            label11.Text = "Flagged Comments: ";
            // 
            // lblFlaggedUsersTotal
            // 
            lblFlaggedUsersTotal.AutoSize = true;
            lblFlaggedUsersTotal.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblFlaggedUsersTotal.Location = new Point(156, 21);
            lblFlaggedUsersTotal.Margin = new Padding(4, 0, 4, 0);
            lblFlaggedUsersTotal.Name = "lblFlaggedUsersTotal";
            lblFlaggedUsersTotal.Size = new Size(44, 16);
            lblFlaggedUsersTotal.TabIndex = 3;
            lblFlaggedUsersTotal.Text = "None";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label17.Location = new Point(7, 18);
            label17.Margin = new Padding(4, 0, 4, 0);
            label17.Name = "label17";
            label17.Size = new Size(122, 18);
            label17.TabIndex = 2;
            label17.Text = "Flagged Users:";
            // 
            // lblFlaggedPostsTotal
            // 
            lblFlaggedPostsTotal.AutoSize = true;
            lblFlaggedPostsTotal.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblFlaggedPostsTotal.Location = new Point(582, 21);
            lblFlaggedPostsTotal.Margin = new Padding(4, 0, 4, 0);
            lblFlaggedPostsTotal.Name = "lblFlaggedPostsTotal";
            lblFlaggedPostsTotal.Size = new Size(44, 16);
            lblFlaggedPostsTotal.TabIndex = 1;
            lblFlaggedPostsTotal.Text = "None";
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label19.Location = new Point(434, 18);
            label19.Margin = new Padding(4, 0, 4, 0);
            label19.Name = "label19";
            label19.Size = new Size(121, 18);
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
            groupBox1.Location = new Point(7, 66);
            groupBox1.Margin = new Padding(4, 3, 4, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(4, 3, 4, 3);
            groupBox1.Size = new Size(1167, 99);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Platform Information";
            // 
            // lblCommentsTotal
            // 
            lblCommentsTotal.AutoSize = true;
            lblCommentsTotal.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblCommentsTotal.Location = new Point(950, 53);
            lblCommentsTotal.Margin = new Padding(4, 0, 4, 0);
            lblCommentsTotal.Name = "lblCommentsTotal";
            lblCommentsTotal.Size = new Size(44, 16);
            lblCommentsTotal.TabIndex = 11;
            lblCommentsTotal.Text = "None";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(832, 51);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(95, 18);
            label7.TabIndex = 10;
            label7.Text = "Comments:";
            // 
            // lblLikesTotal
            // 
            lblLikesTotal.AutoSize = true;
            lblLikesTotal.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblLikesTotal.Location = new Point(899, 21);
            lblLikesTotal.Margin = new Padding(4, 0, 4, 0);
            lblLikesTotal.Name = "lblLikesTotal";
            lblLikesTotal.Size = new Size(44, 16);
            lblLikesTotal.TabIndex = 9;
            lblLikesTotal.Text = "None";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.Location = new Point(832, 18);
            label9.Margin = new Padding(4, 0, 4, 0);
            label9.Name = "label9";
            label9.Size = new Size(53, 18);
            label9.TabIndex = 8;
            label9.Text = "Likes:";
            // 
            // lblPostsToday
            // 
            lblPostsToday.AutoSize = true;
            lblPostsToday.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblPostsToday.Location = new Point(626, 53);
            lblPostsToday.Margin = new Padding(4, 0, 4, 0);
            lblPostsToday.Name = "lblPostsToday";
            lblPostsToday.Size = new Size(44, 16);
            lblPostsToday.TabIndex = 7;
            lblPostsToday.Text = "None";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(434, 51);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(158, 18);
            label5.TabIndex = 6;
            label5.Text = "New Posts (Today):";
            // 
            // lblUsersToday
            // 
            lblUsersToday.AutoSize = true;
            lblUsersToday.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblUsersToday.Location = new Point(200, 53);
            lblUsersToday.Margin = new Padding(4, 0, 4, 0);
            lblUsersToday.Name = "lblUsersToday";
            lblUsersToday.Size = new Size(44, 16);
            lblUsersToday.TabIndex = 5;
            lblUsersToday.Text = "None";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(7, 51);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(159, 18);
            label6.TabIndex = 4;
            label6.Text = "New Users (Today):";
            // 
            // lblUsersTotal
            // 
            lblUsersTotal.AutoSize = true;
            lblUsersTotal.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblUsersTotal.Location = new Point(80, 21);
            lblUsersTotal.Margin = new Padding(4, 0, 4, 0);
            lblUsersTotal.Name = "lblUsersTotal";
            lblUsersTotal.Size = new Size(44, 16);
            lblUsersTotal.TabIndex = 3;
            lblUsersTotal.Text = "None";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(7, 18);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(58, 18);
            label4.TabIndex = 2;
            label4.Text = "Users:";
            // 
            // lblPostsTotal
            // 
            lblPostsTotal.AutoSize = true;
            lblPostsTotal.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblPostsTotal.Location = new Point(507, 21);
            lblPostsTotal.Margin = new Padding(4, 0, 4, 0);
            lblPostsTotal.Name = "lblPostsTotal";
            lblPostsTotal.Size = new Size(44, 16);
            lblPostsTotal.TabIndex = 1;
            lblPostsTotal.Text = "None";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(434, 18);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(57, 18);
            label2.TabIndex = 0;
            label2.Text = "Posts:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(290, 14);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(518, 42);
            label1.TabIndex = 0;
            label1.Text = "TalkToMe Admin Dashboard";
            // 
            // tabPageUsers
            // 
            tabPageUsers.Controls.Add(groupBox10);
            tabPageUsers.Controls.Add(groupBox11);
            tabPageUsers.Controls.Add(label50);
            tabPageUsers.Controls.Add(lstBoxUsers);
            tabPageUsers.Location = new Point(4, 24);
            tabPageUsers.Name = "tabPageUsers";
            tabPageUsers.Size = new Size(1182, 592);
            tabPageUsers.TabIndex = 5;
            tabPageUsers.Text = "Users";
            tabPageUsers.UseVisualStyleBackColor = true;
            // 
            // groupBox10
            // 
            groupBox10.Controls.Add(btnBanUser);
            groupBox10.Controls.Add(btnUnbanUser);
            groupBox10.Location = new Point(303, 336);
            groupBox10.Margin = new Padding(4, 3, 4, 3);
            groupBox10.Name = "groupBox10";
            groupBox10.Padding = new Padding(4, 3, 4, 3);
            groupBox10.Size = new Size(872, 245);
            groupBox10.TabIndex = 18;
            groupBox10.TabStop = false;
            groupBox10.Text = "Actions";
            // 
            // btnBanUser
            // 
            btnBanUser.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBanUser.Location = new Point(107, 167);
            btnBanUser.Margin = new Padding(4, 3, 4, 3);
            btnBanUser.Name = "btnBanUser";
            btnBanUser.Size = new Size(148, 50);
            btnBanUser.TabIndex = 25;
            btnBanUser.Text = "Ban";
            btnBanUser.UseVisualStyleBackColor = true;
            btnBanUser.Click += btnBanUser_Click_1Async;
            // 
            // btnUnbanUser
            // 
            btnUnbanUser.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnUnbanUser.Location = new Point(107, 78);
            btnUnbanUser.Margin = new Padding(4, 3, 4, 3);
            btnUnbanUser.Name = "btnUnbanUser";
            btnUnbanUser.Size = new Size(148, 50);
            btnUnbanUser.TabIndex = 24;
            btnUnbanUser.Text = "Unban";
            btnUnbanUser.UseVisualStyleBackColor = true;
            btnUnbanUser.Click += btnUnbanUser_Click_1Async;
            // 
            // groupBox11
            // 
            groupBox11.Controls.Add(lblUserStatus);
            groupBox11.Controls.Add(label24);
            groupBox11.Controls.Add(lblUserBio);
            groupBox11.Controls.Add(label30);
            groupBox11.Controls.Add(lblUserEmail);
            groupBox11.Controls.Add(label46);
            groupBox11.Controls.Add(lblUserName);
            groupBox11.Controls.Add(label48);
            groupBox11.Controls.Add(label49);
            groupBox11.Controls.Add(pictureBoxUserImage);
            groupBox11.Location = new Point(303, 36);
            groupBox11.Margin = new Padding(4, 3, 4, 3);
            groupBox11.Name = "groupBox11";
            groupBox11.Padding = new Padding(4, 3, 4, 3);
            groupBox11.Size = new Size(872, 293);
            groupBox11.TabIndex = 17;
            groupBox11.TabStop = false;
            groupBox11.Text = "Information";
            // 
            // lblUserStatus
            // 
            lblUserStatus.AutoSize = true;
            lblUserStatus.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblUserStatus.Location = new Point(82, 264);
            lblUserStatus.Margin = new Padding(4, 0, 4, 0);
            lblUserStatus.Name = "lblUserStatus";
            lblUserStatus.Size = new Size(44, 16);
            lblUserStatus.TabIndex = 24;
            lblUserStatus.Text = "None";
            // 
            // label24
            // 
            label24.AutoSize = true;
            label24.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label24.Location = new Point(9, 262);
            label24.Margin = new Padding(4, 0, 4, 0);
            label24.Name = "label24";
            label24.Size = new Size(61, 18);
            label24.TabIndex = 23;
            label24.Text = "Status:";
            // 
            // lblUserBio
            // 
            lblUserBio.AutoSize = true;
            lblUserBio.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblUserBio.Location = new Point(59, 95);
            lblUserBio.Margin = new Padding(4, 0, 4, 0);
            lblUserBio.MaximumSize = new Size(198, 0);
            lblUserBio.Name = "lblUserBio";
            lblUserBio.Size = new Size(44, 16);
            lblUserBio.TabIndex = 22;
            lblUserBio.Text = "None";
            // 
            // label30
            // 
            label30.AutoSize = true;
            label30.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label30.Location = new Point(8, 92);
            label30.Margin = new Padding(4, 0, 4, 0);
            label30.Name = "label30";
            label30.Size = new Size(38, 18);
            label30.TabIndex = 21;
            label30.Text = "Bio:";
            // 
            // lblUserEmail
            // 
            lblUserEmail.AutoSize = true;
            lblUserEmail.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblUserEmail.Location = new Point(81, 63);
            lblUserEmail.Margin = new Padding(4, 0, 4, 0);
            lblUserEmail.Name = "lblUserEmail";
            lblUserEmail.Size = new Size(44, 16);
            lblUserEmail.TabIndex = 18;
            lblUserEmail.Text = "None";
            // 
            // label46
            // 
            label46.AutoSize = true;
            label46.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label46.Location = new Point(8, 61);
            label46.Margin = new Padding(4, 0, 4, 0);
            label46.Name = "label46";
            label46.Size = new Size(55, 18);
            label46.TabIndex = 17;
            label46.Text = "Email:";
            // 
            // lblUserName
            // 
            lblUserName.AutoSize = true;
            lblUserName.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblUserName.Location = new Point(81, 31);
            lblUserName.Margin = new Padding(4, 0, 4, 0);
            lblUserName.Name = "lblUserName";
            lblUserName.Size = new Size(44, 16);
            lblUserName.TabIndex = 16;
            lblUserName.Text = "None";
            // 
            // label48
            // 
            label48.AutoSize = true;
            label48.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label48.Location = new Point(8, 29);
            label48.Margin = new Padding(4, 0, 4, 0);
            label48.Name = "label48";
            label48.Size = new Size(57, 18);
            label48.TabIndex = 15;
            label48.Text = "Name:";
            // 
            // label49
            // 
            label49.AutoSize = true;
            label49.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label49.Location = new Point(687, 18);
            label49.Margin = new Padding(4, 0, 4, 0);
            label49.Name = "label49";
            label49.Size = new Size(58, 18);
            label49.TabIndex = 15;
            label49.Text = "Image:";
            // 
            // pictureBoxUserImage
            // 
            pictureBoxUserImage.Location = new Point(690, 44);
            pictureBoxUserImage.Margin = new Padding(4, 3, 4, 3);
            pictureBoxUserImage.Name = "pictureBoxUserImage";
            pictureBoxUserImage.Size = new Size(175, 173);
            pictureBoxUserImage.TabIndex = 0;
            pictureBoxUserImage.TabStop = false;
            // 
            // label50
            // 
            label50.AutoSize = true;
            label50.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label50.Location = new Point(8, 11);
            label50.Margin = new Padding(4, 0, 4, 0);
            label50.Name = "label50";
            label50.Size = new Size(58, 18);
            label50.TabIndex = 16;
            label50.Text = "Users:";
            // 
            // lstBoxUsers
            // 
            lstBoxUsers.FormattingEnabled = true;
            lstBoxUsers.ItemHeight = 15;
            lstBoxUsers.Location = new Point(8, 36);
            lstBoxUsers.Margin = new Padding(4, 3, 4, 3);
            lstBoxUsers.Name = "lstBoxUsers";
            lstBoxUsers.Size = new Size(261, 544);
            lstBoxUsers.TabIndex = 15;
            lstBoxUsers.SelectedIndexChanged += lstBoxUsers_SelectedIndexChanged;
            // 
            // tabPageAdmins
            // 
            tabPageAdmins.Controls.Add(groupBox9);
            tabPageAdmins.Controls.Add(label10);
            tabPageAdmins.Controls.Add(lstBoxAdmins);
            tabPageAdmins.Location = new Point(4, 24);
            tabPageAdmins.Margin = new Padding(2);
            tabPageAdmins.Name = "tabPageAdmins";
            tabPageAdmins.Size = new Size(1182, 592);
            tabPageAdmins.TabIndex = 4;
            tabPageAdmins.Text = "Admins";
            tabPageAdmins.UseVisualStyleBackColor = true;
            // 
            // groupBox9
            // 
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
            groupBox9.Location = new Point(312, 34);
            groupBox9.Margin = new Padding(2);
            groupBox9.Name = "groupBox9";
            groupBox9.Padding = new Padding(2);
            groupBox9.Size = new Size(862, 202);
            groupBox9.TabIndex = 15;
            groupBox9.TabStop = false;
            groupBox9.Text = "Manage";
            // 
            // btnRemoveAdmin
            // 
            btnRemoveAdmin.Location = new Point(10, 161);
            btnRemoveAdmin.Margin = new Padding(2);
            btnRemoveAdmin.Name = "btnRemoveAdmin";
            btnRemoveAdmin.Size = new Size(167, 37);
            btnRemoveAdmin.TabIndex = 14;
            btnRemoveAdmin.Text = "Remove Admin";
            btnRemoveAdmin.UseVisualStyleBackColor = true;
            btnRemoveAdmin.Click += btnRemoveAdmin_Click;
            // 
            // btnEditAdmin
            // 
            btnEditAdmin.Location = new Point(10, 121);
            btnEditAdmin.Margin = new Padding(2);
            btnEditAdmin.Name = "btnEditAdmin";
            btnEditAdmin.Size = new Size(167, 37);
            btnEditAdmin.TabIndex = 13;
            btnEditAdmin.Text = "Edit Admin";
            btnEditAdmin.UseVisualStyleBackColor = true;
            btnEditAdmin.Click += btnEditAdmin_Click;
            // 
            // btnNewAdmin
            // 
            btnNewAdmin.Location = new Point(10, 80);
            btnNewAdmin.Margin = new Padding(2);
            btnNewAdmin.Name = "btnNewAdmin";
            btnNewAdmin.Size = new Size(167, 37);
            btnNewAdmin.TabIndex = 12;
            btnNewAdmin.Text = "New Admin";
            btnNewAdmin.UseVisualStyleBackColor = true;
            btnNewAdmin.Click += btnNewAdmin_Click;
            // 
            // label40
            // 
            label40.AutoSize = true;
            label40.Location = new Point(706, 19);
            label40.Margin = new Padding(2, 0, 2, 0);
            label40.Name = "label40";
            label40.Size = new Size(40, 15);
            label40.TabIndex = 11;
            label40.Text = "Image";
            // 
            // pictureBoxAdminImage
            // 
            pictureBoxAdminImage.Location = new Point(709, 36);
            pictureBoxAdminImage.Margin = new Padding(2);
            pictureBoxAdminImage.Name = "pictureBoxAdminImage";
            pictureBoxAdminImage.Size = new Size(149, 128);
            pictureBoxAdminImage.TabIndex = 10;
            pictureBoxAdminImage.TabStop = false;
            // 
            // btnAdminAttachImage
            // 
            btnAdminAttachImage.Location = new Point(709, 167);
            btnAdminAttachImage.Margin = new Padding(2);
            btnAdminAttachImage.Name = "btnAdminAttachImage";
            btnAdminAttachImage.Size = new Size(149, 20);
            btnAdminAttachImage.TabIndex = 9;
            btnAdminAttachImage.Text = "Attach Image";
            btnAdminAttachImage.UseVisualStyleBackColor = true;
            btnAdminAttachImage.Click += btnAdminAttachImage_Click;
            // 
            // cmBxAdminPerms
            // 
            cmBxAdminPerms.FormattingEnabled = true;
            cmBxAdminPerms.Location = new Point(584, 36);
            cmBxAdminPerms.Margin = new Padding(2);
            cmBxAdminPerms.Name = "cmBxAdminPerms";
            cmBxAdminPerms.Size = new Size(122, 23);
            cmBxAdminPerms.TabIndex = 8;
            // 
            // label38
            // 
            label38.AutoSize = true;
            label38.Location = new Point(584, 19);
            label38.Margin = new Padding(2, 0, 2, 0);
            label38.Name = "label38";
            label38.Size = new Size(70, 15);
            label38.TabIndex = 7;
            label38.Text = "Permissions";
            // 
            // label36
            // 
            label36.AutoSize = true;
            label36.Location = new Point(199, 19);
            label36.Margin = new Padding(2, 0, 2, 0);
            label36.Name = "label36";
            label36.Size = new Size(36, 15);
            label36.TabIndex = 5;
            label36.Text = "Email";
            // 
            // txtAdminEmail
            // 
            txtAdminEmail.Location = new Point(199, 36);
            txtAdminEmail.Margin = new Padding(2);
            txtAdminEmail.Name = "txtAdminEmail";
            txtAdminEmail.Size = new Size(185, 23);
            txtAdminEmail.TabIndex = 4;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new Point(393, 19);
            label18.Margin = new Padding(2, 0, 2, 0);
            label18.Name = "label18";
            label18.Size = new Size(57, 15);
            label18.TabIndex = 3;
            label18.Text = "Password";
            // 
            // txtAdminPassword
            // 
            txtAdminPassword.Location = new Point(393, 36);
            txtAdminPassword.Margin = new Padding(2);
            txtAdminPassword.Name = "txtAdminPassword";
            txtAdminPassword.Size = new Size(185, 23);
            txtAdminPassword.TabIndex = 2;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(4, 19);
            label16.Margin = new Padding(2, 0, 2, 0);
            label16.Name = "label16";
            label16.Size = new Size(60, 15);
            label16.TabIndex = 1;
            label16.Text = "Username";
            // 
            // txtAdminUsername
            // 
            txtAdminUsername.Location = new Point(4, 36);
            txtAdminUsername.Margin = new Padding(2);
            txtAdminUsername.Name = "txtAdminUsername";
            txtAdminUsername.Size = new Size(185, 23);
            txtAdminUsername.TabIndex = 0;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.Location = new Point(12, 9);
            label10.Margin = new Padding(4, 0, 4, 0);
            label10.Name = "label10";
            label10.Size = new Size(63, 18);
            label10.TabIndex = 14;
            label10.Text = "Admins";
            // 
            // lstBoxAdmins
            // 
            lstBoxAdmins.FormattingEnabled = true;
            lstBoxAdmins.ItemHeight = 15;
            lstBoxAdmins.Location = new Point(12, 34);
            lstBoxAdmins.Margin = new Padding(4, 3, 4, 3);
            lstBoxAdmins.Name = "lstBoxAdmins";
            lstBoxAdmins.Size = new Size(261, 544);
            lstBoxAdmins.TabIndex = 13;
            lstBoxAdmins.SelectedIndexChanged += lstBoxAdmins_SelectedIndexChanged;
            // 
            // tabPageFUsers
            // 
            tabPageFUsers.Controls.Add(groupBox4);
            tabPageFUsers.Controls.Add(groupBox3);
            tabPageFUsers.Controls.Add(label3);
            tabPageFUsers.Controls.Add(lstBoxFlaggedUsers);
            tabPageFUsers.Location = new Point(4, 24);
            tabPageFUsers.Margin = new Padding(4, 3, 4, 3);
            tabPageFUsers.Name = "tabPageFUsers";
            tabPageFUsers.Padding = new Padding(4, 3, 4, 3);
            tabPageFUsers.Size = new Size(1182, 592);
            tabPageFUsers.TabIndex = 1;
            tabPageFUsers.Text = "Flagged Users";
            tabPageFUsers.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(btnRemoveFlagUser);
            groupBox4.Controls.Add(btnBanFlaggedUser);
            groupBox4.Controls.Add(btnUnbanFlaggedUser);
            groupBox4.Location = new Point(302, 342);
            groupBox4.Margin = new Padding(4, 3, 4, 3);
            groupBox4.Name = "groupBox4";
            groupBox4.Padding = new Padding(4, 3, 4, 3);
            groupBox4.Size = new Size(872, 245);
            groupBox4.TabIndex = 14;
            groupBox4.TabStop = false;
            groupBox4.Text = "Actions";
            // 
            // btnRemoveFlagUser
            // 
            btnRemoveFlagUser.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRemoveFlagUser.Location = new Point(524, 114);
            btnRemoveFlagUser.Margin = new Padding(4, 3, 4, 3);
            btnRemoveFlagUser.Name = "btnRemoveFlagUser";
            btnRemoveFlagUser.Size = new Size(273, 50);
            btnRemoveFlagUser.TabIndex = 27;
            btnRemoveFlagUser.Text = "Remove Flag";
            btnRemoveFlagUser.UseVisualStyleBackColor = true;
            btnRemoveFlagUser.Click += btnRemoveFlagUser_Click;
            // 
            // btnBanFlaggedUser
            // 
            btnBanFlaggedUser.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBanFlaggedUser.Location = new Point(107, 167);
            btnBanFlaggedUser.Margin = new Padding(4, 3, 4, 3);
            btnBanFlaggedUser.Name = "btnBanFlaggedUser";
            btnBanFlaggedUser.Size = new Size(148, 50);
            btnBanFlaggedUser.TabIndex = 25;
            btnBanFlaggedUser.Text = "Ban User";
            btnBanFlaggedUser.UseVisualStyleBackColor = true;
            btnBanFlaggedUser.Click += btnBanUser_Click;
            // 
            // btnUnbanFlaggedUser
            // 
            btnUnbanFlaggedUser.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnUnbanFlaggedUser.Location = new Point(107, 78);
            btnUnbanFlaggedUser.Margin = new Padding(4, 3, 4, 3);
            btnUnbanFlaggedUser.Name = "btnUnbanFlaggedUser";
            btnUnbanFlaggedUser.Size = new Size(148, 50);
            btnUnbanFlaggedUser.TabIndex = 24;
            btnUnbanFlaggedUser.Text = "Unban";
            btnUnbanFlaggedUser.UseVisualStyleBackColor = true;
            btnUnbanFlaggedUser.Click += btnUnbanUser_Click;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(lblFlaggedUserStatus);
            groupBox3.Controls.Add(label44);
            groupBox3.Controls.Add(lblFlaggedUserBio);
            groupBox3.Controls.Add(label23);
            groupBox3.Controls.Add(lblUserFlagReason);
            groupBox3.Controls.Add(label15);
            groupBox3.Controls.Add(lblFlaggedUserEmail);
            groupBox3.Controls.Add(label14);
            groupBox3.Controls.Add(lblFlaggedUserName);
            groupBox3.Controls.Add(label12);
            groupBox3.Controls.Add(label8);
            groupBox3.Controls.Add(pictureBoxFlaggedUserProfile);
            groupBox3.Location = new Point(302, 42);
            groupBox3.Margin = new Padding(4, 3, 4, 3);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new Padding(4, 3, 4, 3);
            groupBox3.Size = new Size(872, 293);
            groupBox3.TabIndex = 13;
            groupBox3.TabStop = false;
            groupBox3.Text = "Information";
            // 
            // lblFlaggedUserStatus
            // 
            lblFlaggedUserStatus.AutoSize = true;
            lblFlaggedUserStatus.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblFlaggedUserStatus.Location = new Point(81, 264);
            lblFlaggedUserStatus.Margin = new Padding(4, 0, 4, 0);
            lblFlaggedUserStatus.Name = "lblFlaggedUserStatus";
            lblFlaggedUserStatus.Size = new Size(44, 16);
            lblFlaggedUserStatus.TabIndex = 24;
            lblFlaggedUserStatus.Text = "None";
            // 
            // label44
            // 
            label44.AutoSize = true;
            label44.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label44.Location = new Point(8, 262);
            label44.Margin = new Padding(4, 0, 4, 0);
            label44.Name = "label44";
            label44.Size = new Size(61, 18);
            label44.TabIndex = 23;
            label44.Text = "Status:";
            // 
            // lblFlaggedUserBio
            // 
            lblFlaggedUserBio.AutoSize = true;
            lblFlaggedUserBio.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblFlaggedUserBio.Location = new Point(58, 95);
            lblFlaggedUserBio.Margin = new Padding(4, 0, 4, 0);
            lblFlaggedUserBio.MaximumSize = new Size(198, 0);
            lblFlaggedUserBio.Name = "lblFlaggedUserBio";
            lblFlaggedUserBio.Size = new Size(44, 16);
            lblFlaggedUserBio.TabIndex = 22;
            lblFlaggedUserBio.Text = "None";
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label23.Location = new Point(7, 92);
            label23.Margin = new Padding(4, 0, 4, 0);
            label23.Name = "label23";
            label23.Size = new Size(38, 18);
            label23.TabIndex = 21;
            label23.Text = "Bio:";
            // 
            // lblUserFlagReason
            // 
            lblUserFlagReason.AutoSize = true;
            lblUserFlagReason.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblUserFlagReason.Location = new Point(80, 158);
            lblUserFlagReason.Margin = new Padding(4, 0, 4, 0);
            lblUserFlagReason.MaximumSize = new Size(350, 0);
            lblUserFlagReason.Name = "lblUserFlagReason";
            lblUserFlagReason.Size = new Size(44, 16);
            lblUserFlagReason.TabIndex = 20;
            lblUserFlagReason.Text = "None";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label15.Location = new Point(7, 156);
            label15.Margin = new Padding(4, 0, 4, 0);
            label15.Name = "label15";
            label15.Size = new Size(71, 18);
            label15.TabIndex = 19;
            label15.Text = "Reason:";
            // 
            // lblFlaggedUserEmail
            // 
            lblFlaggedUserEmail.AutoSize = true;
            lblFlaggedUserEmail.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblFlaggedUserEmail.Location = new Point(80, 63);
            lblFlaggedUserEmail.Margin = new Padding(4, 0, 4, 0);
            lblFlaggedUserEmail.Name = "lblFlaggedUserEmail";
            lblFlaggedUserEmail.Size = new Size(44, 16);
            lblFlaggedUserEmail.TabIndex = 18;
            lblFlaggedUserEmail.Text = "None";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label14.Location = new Point(7, 61);
            label14.Margin = new Padding(4, 0, 4, 0);
            label14.Name = "label14";
            label14.Size = new Size(55, 18);
            label14.TabIndex = 17;
            label14.Text = "Email:";
            // 
            // lblFlaggedUserName
            // 
            lblFlaggedUserName.AutoSize = true;
            lblFlaggedUserName.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblFlaggedUserName.Location = new Point(80, 31);
            lblFlaggedUserName.Margin = new Padding(4, 0, 4, 0);
            lblFlaggedUserName.Name = "lblFlaggedUserName";
            lblFlaggedUserName.Size = new Size(44, 16);
            lblFlaggedUserName.TabIndex = 16;
            lblFlaggedUserName.Text = "None";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label12.Location = new Point(7, 29);
            label12.Margin = new Padding(4, 0, 4, 0);
            label12.Name = "label12";
            label12.Size = new Size(57, 18);
            label12.TabIndex = 15;
            label12.Text = "Name:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(686, 18);
            label8.Margin = new Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new Size(58, 18);
            label8.TabIndex = 15;
            label8.Text = "Image:";
            // 
            // pictureBoxFlaggedUserProfile
            // 
            pictureBoxFlaggedUserProfile.Location = new Point(690, 44);
            pictureBoxFlaggedUserProfile.Margin = new Padding(4, 3, 4, 3);
            pictureBoxFlaggedUserProfile.Name = "pictureBoxFlaggedUserProfile";
            pictureBoxFlaggedUserProfile.Size = new Size(175, 173);
            pictureBoxFlaggedUserProfile.TabIndex = 0;
            pictureBoxFlaggedUserProfile.TabStop = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(7, 17);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(122, 18);
            label3.TabIndex = 12;
            label3.Text = "Flagged Users:";
            // 
            // lstBoxFlaggedUsers
            // 
            lstBoxFlaggedUsers.FormattingEnabled = true;
            lstBoxFlaggedUsers.ItemHeight = 15;
            lstBoxFlaggedUsers.Location = new Point(7, 42);
            lstBoxFlaggedUsers.Margin = new Padding(4, 3, 4, 3);
            lstBoxFlaggedUsers.Name = "lstBoxFlaggedUsers";
            lstBoxFlaggedUsers.Size = new Size(261, 544);
            lstBoxFlaggedUsers.TabIndex = 11;
            lstBoxFlaggedUsers.SelectedIndexChanged += lstBoxFlaggedUsers_SelectedIndexChanged;
            // 
            // tabPageFPosts
            // 
            tabPageFPosts.Controls.Add(groupBox5);
            tabPageFPosts.Controls.Add(groupBox6);
            tabPageFPosts.Controls.Add(label35);
            tabPageFPosts.Controls.Add(lstBoxFlaggedPosts);
            tabPageFPosts.Location = new Point(4, 24);
            tabPageFPosts.Margin = new Padding(4, 3, 4, 3);
            tabPageFPosts.Name = "tabPageFPosts";
            tabPageFPosts.Size = new Size(1182, 592);
            tabPageFPosts.TabIndex = 2;
            tabPageFPosts.Text = "Flagged Posts";
            tabPageFPosts.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(label26);
            groupBox5.Controls.Add(btnRemovePost);
            groupBox5.Controls.Add(btnRemoveFlagPost);
            groupBox5.Controls.Add(btnBanUserFromPost);
            groupBox5.Location = new Point(302, 335);
            groupBox5.Margin = new Padding(4, 3, 4, 3);
            groupBox5.Name = "groupBox5";
            groupBox5.Padding = new Padding(4, 3, 4, 3);
            groupBox5.Size = new Size(872, 245);
            groupBox5.TabIndex = 18;
            groupBox5.TabStop = false;
            groupBox5.Text = "Actions";
            // 
            // label26
            // 
            label26.AutoSize = true;
            label26.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label26.Location = new Point(592, 75);
            label26.Margin = new Padding(4, 0, 4, 0);
            label26.MaximumSize = new Size(350, 0);
            label26.Name = "label26";
            label26.Size = new Size(167, 15);
            label26.TabIndex = 29;
            label26.Text = "Deleting a post is irreversible.";
            label26.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnRemovePost
            // 
            btnRemovePost.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRemovePost.Location = new Point(541, 93);
            btnRemovePost.Margin = new Padding(4, 3, 4, 3);
            btnRemovePost.Name = "btnRemovePost";
            btnRemovePost.Size = new Size(273, 50);
            btnRemovePost.TabIndex = 28;
            btnRemovePost.Text = "Delete Post";
            btnRemovePost.UseVisualStyleBackColor = true;
            btnRemovePost.Click += btnRemovePost_Click;
            // 
            // btnRemoveFlagPost
            // 
            btnRemoveFlagPost.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRemoveFlagPost.Location = new Point(541, 171);
            btnRemoveFlagPost.Margin = new Padding(4, 3, 4, 3);
            btnRemoveFlagPost.Name = "btnRemoveFlagPost";
            btnRemoveFlagPost.Size = new Size(273, 50);
            btnRemoveFlagPost.TabIndex = 27;
            btnRemoveFlagPost.Text = "Remove Flag";
            btnRemoveFlagPost.UseVisualStyleBackColor = true;
            btnRemoveFlagPost.Click += btnRemoveFlagPost_Click;
            // 
            // btnBanUserFromPost
            // 
            btnBanUserFromPost.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBanUserFromPost.Location = new Point(109, 138);
            btnBanUserFromPost.Margin = new Padding(4, 3, 4, 3);
            btnBanUserFromPost.Name = "btnBanUserFromPost";
            btnBanUserFromPost.Size = new Size(148, 50);
            btnBanUserFromPost.TabIndex = 25;
            btnBanUserFromPost.Text = "Ban User";
            btnBanUserFromPost.UseVisualStyleBackColor = true;
            btnBanUserFromPost.Click += btnBanUserFromPost_Click;
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
            groupBox6.Location = new Point(302, 35);
            groupBox6.Margin = new Padding(4, 3, 4, 3);
            groupBox6.Name = "groupBox6";
            groupBox6.Padding = new Padding(4, 3, 4, 3);
            groupBox6.Size = new Size(872, 293);
            groupBox6.TabIndex = 17;
            groupBox6.TabStop = false;
            groupBox6.Text = "Information";
            // 
            // lblPostText
            // 
            lblPostText.AutoSize = true;
            lblPostText.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblPostText.Location = new Point(114, 110);
            lblPostText.Margin = new Padding(4, 0, 4, 0);
            lblPostText.MaximumSize = new Size(327, 0);
            lblPostText.Name = "lblPostText";
            lblPostText.Size = new Size(44, 16);
            lblPostText.TabIndex = 20;
            lblPostText.Text = "None";
            // 
            // label29
            // 
            label29.AutoSize = true;
            label29.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label29.Location = new Point(8, 110);
            label29.Margin = new Padding(4, 0, 4, 0);
            label29.Name = "label29";
            label29.Size = new Size(85, 18);
            label29.TabIndex = 19;
            label29.Text = "Post Text:";
            // 
            // lblUserEmailPost
            // 
            lblUserEmailPost.AutoSize = true;
            lblUserEmailPost.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblUserEmailPost.Location = new Point(128, 63);
            lblUserEmailPost.Margin = new Padding(4, 0, 4, 0);
            lblUserEmailPost.Name = "lblUserEmailPost";
            lblUserEmailPost.Size = new Size(44, 16);
            lblUserEmailPost.TabIndex = 18;
            lblUserEmailPost.Text = "None";
            // 
            // label31
            // 
            label31.AutoSize = true;
            label31.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label31.Location = new Point(7, 61);
            label31.Margin = new Padding(4, 0, 4, 0);
            label31.Name = "label31";
            label31.Size = new Size(96, 18);
            label31.TabIndex = 17;
            label31.Text = "User Email:";
            // 
            // lblUserNamePost
            // 
            lblUserNamePost.AutoSize = true;
            lblUserNamePost.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblUserNamePost.Location = new Point(128, 31);
            lblUserNamePost.Margin = new Padding(4, 0, 4, 0);
            lblUserNamePost.Name = "lblUserNamePost";
            lblUserNamePost.Size = new Size(44, 16);
            lblUserNamePost.TabIndex = 16;
            lblUserNamePost.Text = "None";
            // 
            // label33
            // 
            label33.AutoSize = true;
            label33.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label33.Location = new Point(7, 29);
            label33.Margin = new Padding(4, 0, 4, 0);
            label33.Name = "label33";
            label33.Size = new Size(98, 18);
            label33.TabIndex = 15;
            label33.Text = "User Name:";
            // 
            // label34
            // 
            label34.AutoSize = true;
            label34.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label34.Location = new Point(686, 24);
            label34.Margin = new Padding(4, 0, 4, 0);
            label34.Name = "label34";
            label34.Size = new Size(98, 18);
            label34.TabIndex = 15;
            label34.Text = "Post Image:";
            // 
            // pictureBoxPostImage
            // 
            pictureBoxPostImage.Location = new Point(690, 50);
            pictureBoxPostImage.Margin = new Padding(4, 3, 4, 3);
            pictureBoxPostImage.Name = "pictureBoxPostImage";
            pictureBoxPostImage.Size = new Size(175, 173);
            pictureBoxPostImage.TabIndex = 0;
            pictureBoxPostImage.TabStop = false;
            // 
            // label35
            // 
            label35.AutoSize = true;
            label35.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label35.Location = new Point(7, 10);
            label35.Margin = new Padding(4, 0, 4, 0);
            label35.Name = "label35";
            label35.Size = new Size(121, 18);
            label35.TabIndex = 16;
            label35.Text = "Flagged Posts:";
            // 
            // lstBoxFlaggedPosts
            // 
            lstBoxFlaggedPosts.FormattingEnabled = true;
            lstBoxFlaggedPosts.ItemHeight = 15;
            lstBoxFlaggedPosts.Location = new Point(7, 35);
            lstBoxFlaggedPosts.Margin = new Padding(4, 3, 4, 3);
            lstBoxFlaggedPosts.Name = "lstBoxFlaggedPosts";
            lstBoxFlaggedPosts.Size = new Size(261, 544);
            lstBoxFlaggedPosts.TabIndex = 15;
            lstBoxFlaggedPosts.SelectedIndexChanged += lstBoxFlaggedPosts_SelectedIndexChanged;
            // 
            // tabPageFComments
            // 
            tabPageFComments.Controls.Add(groupBox7);
            tabPageFComments.Controls.Add(groupBox8);
            tabPageFComments.Controls.Add(label43);
            tabPageFComments.Controls.Add(lstBoxFlaggedComments);
            tabPageFComments.Location = new Point(4, 24);
            tabPageFComments.Margin = new Padding(4, 3, 4, 3);
            tabPageFComments.Name = "tabPageFComments";
            tabPageFComments.Size = new Size(1182, 592);
            tabPageFComments.TabIndex = 3;
            tabPageFComments.Text = "Flagged Comments";
            tabPageFComments.UseVisualStyleBackColor = true;
            // 
            // groupBox7
            // 
            groupBox7.Controls.Add(label27);
            groupBox7.Controls.Add(btnDeleteComment);
            groupBox7.Controls.Add(btnRemoveFlagComment);
            groupBox7.Controls.Add(btnBanUserFromComment);
            groupBox7.Location = new Point(302, 335);
            groupBox7.Margin = new Padding(4, 3, 4, 3);
            groupBox7.Name = "groupBox7";
            groupBox7.Padding = new Padding(4, 3, 4, 3);
            groupBox7.Size = new Size(872, 245);
            groupBox7.TabIndex = 22;
            groupBox7.TabStop = false;
            groupBox7.Text = "Actions";
            // 
            // label27
            // 
            label27.AutoSize = true;
            label27.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label27.Location = new Point(579, 73);
            label27.Margin = new Padding(4, 0, 4, 0);
            label27.MaximumSize = new Size(350, 0);
            label27.Name = "label27";
            label27.Size = new Size(196, 15);
            label27.TabIndex = 29;
            label27.Text = "Deleting a comment is irreversible.";
            label27.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnDeleteComment
            // 
            btnDeleteComment.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDeleteComment.Location = new Point(541, 93);
            btnDeleteComment.Margin = new Padding(4, 3, 4, 3);
            btnDeleteComment.Name = "btnDeleteComment";
            btnDeleteComment.Size = new Size(273, 50);
            btnDeleteComment.TabIndex = 28;
            btnDeleteComment.Text = "Delete Comment";
            btnDeleteComment.UseVisualStyleBackColor = true;
            btnDeleteComment.Click += btnDeleteComment_Click;
            // 
            // btnRemoveFlagComment
            // 
            btnRemoveFlagComment.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRemoveFlagComment.Location = new Point(541, 171);
            btnRemoveFlagComment.Margin = new Padding(4, 3, 4, 3);
            btnRemoveFlagComment.Name = "btnRemoveFlagComment";
            btnRemoveFlagComment.Size = new Size(273, 50);
            btnRemoveFlagComment.TabIndex = 27;
            btnRemoveFlagComment.Text = "Remove Flag";
            btnRemoveFlagComment.UseVisualStyleBackColor = true;
            btnRemoveFlagComment.Click += btnRemoveFlagComment_Click;
            // 
            // btnBanUserFromComment
            // 
            btnBanUserFromComment.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBanUserFromComment.Location = new Point(108, 138);
            btnBanUserFromComment.Margin = new Padding(4, 3, 4, 3);
            btnBanUserFromComment.Name = "btnBanUserFromComment";
            btnBanUserFromComment.Size = new Size(148, 50);
            btnBanUserFromComment.TabIndex = 25;
            btnBanUserFromComment.Text = "Ban User";
            btnBanUserFromComment.UseVisualStyleBackColor = true;
            btnBanUserFromComment.Click += btnBanUserFromComment_Click;
            // 
            // groupBox8
            // 
            groupBox8.Controls.Add(lbCommentText);
            groupBox8.Controls.Add(label37);
            groupBox8.Controls.Add(lblUserEmailComment);
            groupBox8.Controls.Add(label39);
            groupBox8.Controls.Add(lblUserNameComment);
            groupBox8.Controls.Add(label41);
            groupBox8.Location = new Point(302, 35);
            groupBox8.Margin = new Padding(4, 3, 4, 3);
            groupBox8.Name = "groupBox8";
            groupBox8.Padding = new Padding(4, 3, 4, 3);
            groupBox8.Size = new Size(872, 293);
            groupBox8.TabIndex = 21;
            groupBox8.TabStop = false;
            groupBox8.Text = "Information";
            // 
            // lbCommentText
            // 
            lbCommentText.AutoSize = true;
            lbCommentText.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lbCommentText.Location = new Point(158, 95);
            lbCommentText.Margin = new Padding(4, 0, 4, 0);
            lbCommentText.MaximumSize = new Size(327, 0);
            lbCommentText.Name = "lbCommentText";
            lbCommentText.Size = new Size(44, 16);
            lbCommentText.TabIndex = 20;
            lbCommentText.Text = "None";
            // 
            // label37
            // 
            label37.AutoSize = true;
            label37.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label37.Location = new Point(8, 95);
            label37.Margin = new Padding(4, 0, 4, 0);
            label37.Name = "label37";
            label37.Size = new Size(123, 18);
            label37.TabIndex = 19;
            label37.Text = "Comment Text:";
            // 
            // lblUserEmailComment
            // 
            lblUserEmailComment.AutoSize = true;
            lblUserEmailComment.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblUserEmailComment.Location = new Point(128, 63);
            lblUserEmailComment.Margin = new Padding(4, 0, 4, 0);
            lblUserEmailComment.Name = "lblUserEmailComment";
            lblUserEmailComment.Size = new Size(44, 16);
            lblUserEmailComment.TabIndex = 18;
            lblUserEmailComment.Text = "None";
            // 
            // label39
            // 
            label39.AutoSize = true;
            label39.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label39.Location = new Point(7, 61);
            label39.Margin = new Padding(4, 0, 4, 0);
            label39.Name = "label39";
            label39.Size = new Size(96, 18);
            label39.TabIndex = 17;
            label39.Text = "User Email:";
            // 
            // lblUserNameComment
            // 
            lblUserNameComment.AutoSize = true;
            lblUserNameComment.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblUserNameComment.Location = new Point(128, 31);
            lblUserNameComment.Margin = new Padding(4, 0, 4, 0);
            lblUserNameComment.Name = "lblUserNameComment";
            lblUserNameComment.Size = new Size(44, 16);
            lblUserNameComment.TabIndex = 16;
            lblUserNameComment.Text = "None";
            // 
            // label41
            // 
            label41.AutoSize = true;
            label41.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label41.Location = new Point(7, 29);
            label41.Margin = new Padding(4, 0, 4, 0);
            label41.Name = "label41";
            label41.Size = new Size(98, 18);
            label41.TabIndex = 15;
            label41.Text = "User Name:";
            // 
            // label43
            // 
            label43.AutoSize = true;
            label43.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label43.Location = new Point(7, 10);
            label43.Margin = new Padding(4, 0, 4, 0);
            label43.Name = "label43";
            label43.Size = new Size(159, 18);
            label43.TabIndex = 20;
            label43.Text = "Flagged Comments:";
            // 
            // lstBoxFlaggedComments
            // 
            lstBoxFlaggedComments.FormattingEnabled = true;
            lstBoxFlaggedComments.ItemHeight = 15;
            lstBoxFlaggedComments.Location = new Point(7, 35);
            lstBoxFlaggedComments.Margin = new Padding(4, 3, 4, 3);
            lstBoxFlaggedComments.Name = "lstBoxFlaggedComments";
            lstBoxFlaggedComments.Size = new Size(261, 544);
            lstBoxFlaggedComments.TabIndex = 19;
            lstBoxFlaggedComments.SelectedIndexChanged += lstBoxFlaggedComments_SelectedIndexChanged;
            // 
            // AdminDashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1218, 647);
            Controls.Add(tabControl1);
            Margin = new Padding(4, 3, 4, 3);
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
            groupBox10.ResumeLayout(false);
            groupBox11.ResumeLayout(false);
            groupBox11.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxUserImage).EndInit();
            tabPageAdmins.ResumeLayout(false);
            tabPageAdmins.PerformLayout();
            groupBox9.ResumeLayout(false);
            groupBox9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxAdminImage).EndInit();
            tabPageFUsers.ResumeLayout(false);
            tabPageFUsers.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxFlaggedUserProfile).EndInit();
            tabPageFPosts.ResumeLayout(false);
            tabPageFPosts.PerformLayout();
            groupBox5.ResumeLayout(false);
            groupBox5.PerformLayout();
            groupBox6.ResumeLayout(false);
            groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxPostImage).EndInit();
            tabPageFComments.ResumeLayout(false);
            tabPageFComments.PerformLayout();
            groupBox7.ResumeLayout(false);
            groupBox7.PerformLayout();
            groupBox8.ResumeLayout(false);
            groupBox8.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageDashboard;
        private System.Windows.Forms.TabPage tabPageFUsers;
        private System.Windows.Forms.TabPage tabPageFPosts;
        private System.Windows.Forms.TabPage tabPageFComments;
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
        private System.Windows.Forms.Label lblFlaggedUserEmail;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblFlaggedUserName;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox pictureBoxFlaggedUserProfile;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox lstBoxFlaggedUsers;
        private System.Windows.Forms.Label lblUserStatus;
        private System.Windows.Forms.TextBox txtBoxSuspendDays;
        private System.Windows.Forms.Button btnBanFlaggedUser;
        private System.Windows.Forms.Button btnSuspendUser;
        private System.Windows.Forms.Label lblFlaggedUserBio;
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
        private System.Windows.Forms.Button btnBanUserFromPost;
        private System.Windows.Forms.Button btnSuspendUserFromPost;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox txtBoxSuspendDaysPosts;
        private System.Windows.Forms.Label lblUserBio;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Button btnDeleteComment;
        private System.Windows.Forms.Button btnRemoveFlagComment;
        private System.Windows.Forms.Button btnBanUserFromComment;
        private System.Windows.Forms.Button btnUnbanFlaggedUser;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.TextBox txtBoxSuspendDaysComments;
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
        private PictureBox pictureBoxUserImage;
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
        private Button btnRemoveAdmin;
        private Button btnEditAdmin;
        private Button btnNewAdmin;
        private Label lblFlaggedUserStatus;
        private Label label44;
        private TabPage tabPageUsers;
        private GroupBox groupBox10;
        private Button btnBanUser;
        private Button btnUnbanUser;
        private GroupBox groupBox11;
        private Label lblUserEmail;
        private Label label46;
        private Label lblUserName;
        private Label label48;
        private Label label49;
        private Label label50;
        private ListBox lstBoxUsers;
    }
}

