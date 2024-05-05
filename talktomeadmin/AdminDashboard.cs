using SharedLibrary.Models;
using SharedLibrary.Services;

namespace talktomeadmin
{
    public partial class AdminDashboard : Form
    {
        private readonly ModerationService _moderationService;
        private readonly UserService _userService;
        private string _adminImage;
        public AdminDashboard(UserService userService, ModerationService moderationService)
        {
            InitializeComponent();
            _moderationService = moderationService;
            _userService = userService;
            LoadInfo();
        }

        private void LoadInfo()
        {
            int[] insights = _moderationService.GetInsights();
            lblUsersTotal.Text = insights[0].ToString();
            lblUsersToday.Text = insights[1].ToString();
            lblPostsTotal.Text = insights[2].ToString();
            lblPostsToday.Text = insights[3].ToString();
            lblCommentsTotal.Text = insights[4].ToString();
            lblLikesTotal.Text = insights[5].ToString();

            var flaggedUsers = _moderationService.FlaggedUsers;
            lblFlaggedUsersTotal.Text = flaggedUsers.Count.ToString();
            lstBoxFlaggedUsersDashboard.Items.Clear();
            foreach (var flag in flaggedUsers)
            {
                if (!flag.Resolved)
                {
                    string displayInfo = $"{flag.FlagId}-{flag.ToUser.Username}-{flag.Reason}";
                    lstBoxFlaggedUsersDashboard.Items.Add(displayInfo);
                    lstBoxFlaggedUsers.Items.Add(displayInfo);

                }
            }
            var flaggedPosts = _moderationService.FlaggedPosts;
            lblFlaggedPostsTotal.Text = flaggedPosts.Count.ToString();
            foreach (var flag in flaggedPosts)
            {
                if (!flag.Resolved)
                {
                    string displayInfo = $"{flag.FlagId}-{flag.PostId}-{flag.Post.Text}-{flag.Post.User.Username}";
                    lstBoxFlaggedPostsDashboard.Items.Add(displayInfo);
                    lstBoxFlaggedPosts.Items.Add(displayInfo);
                }
            }
            var flaggedComments = _moderationService.FlaggedComments;
            lblFlaggedCommentsTotal.Text = flaggedComments.Count.ToString();
            foreach (var flag in flaggedComments)
            {
                if (!flag.Resolved)
                {
                    string displayInfo = $"{flag.FlagId}-{flag.CommentId}-{flag.Comment.Text}- {flag.Comment.User.Username}";
                    lstBoxFlaggedCommentsDashboard.Items.Add(displayInfo);
                    lstBoxFlaggedComments.Items.Add(displayInfo);
                }
            }

            // Load all admins
            List<Admin> admins = _userService.GetAllAdmins();
            lstBoxAdmins.Items.Clear();
            foreach (var admin in admins)
            {
                lstBoxAdmins.Items.Add($"ID: {admin.UserId} - Name: {admin.Username}");
            }

            // Load Perms
            cmBxAdminPerms.Items.Clear();

            var permissions = Enum.GetNames(typeof(Permission));
            foreach (var permission in permissions)
            {
                cmBxAdminPerms.Items.Add(permission);
            }

            cmBxAdminPerms.SelectedIndex = 0;

        }


        private int ParseFlagIdFromDisplayInfo(string displayInfo)
        {
            var flagId = displayInfo.Split('-');
            return Int32.Parse(flagId[0]);
        }


        private void lstBoxFlaggedUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstBoxFlaggedUsers.SelectedIndex != -1)
            {
                string selectedItem = lstBoxFlaggedUsers.SelectedItem.ToString();
                int flagId = ParseFlagIdFromDisplayInfo(selectedItem);
                FlagUser flagUser = _moderationService.GetFlagUserById(flagId);
                lblUserName.Text = flagUser.ToUser.Username;
                lblUserEmail.Text = flagUser.ToUser.Email;
                // figure out bio
                lblUserFlagReason.Text = flagUser.Reason;
                try
                {
                    pictureBoxUserProfile.Image = Image.FromFile(@$"D:\talktome\talktomeweb\wwwroot\images\posts\{flagUser.ToUser.ImagePath}");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to load user image: {ex.Message}");
                }
            }
        }


        private void lstBoxFlaggedPosts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstBoxFlaggedPosts.SelectedIndex != -1)
            {
                string selectedItem = lstBoxFlaggedPosts.SelectedItem.ToString();
                int flagId = ParseFlagIdFromDisplayInfo(selectedItem);
                FlagPost flagPost = _moderationService.GetFlagPostById(flagId);
                lblUserNamePost.Text = flagPost.Post.User.Username;
                lblUserEmailPost.Text = flagPost.Post.User.Email;
                lblPostText.Text = flagPost.Post.Text;
                try
                {
                    pictureBoxPostImage.Image = Image.FromFile(@$"D:\talktome\talktomeweb\wwwroot\images\posts\{flagPost.Post.ImagePath}");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to load post image: {ex.Message}");
                }

            }
        }

        private void lstBoxFlaggedComments_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstBoxFlaggedComments.SelectedIndex != -1)
            {
                string selectedItem = lstBoxFlaggedComments.SelectedItem.ToString();
                int flagId = ParseFlagIdFromDisplayInfo(selectedItem);
                FlagComment flagComment = _moderationService.GetFlagCommentById(flagId);
                lblUserNameComment.Text = flagComment.Comment.User.Username;
                lblUserEmailComment.Text = flagComment.Comment.User.Email;
                lbCommentText.Text = flagComment.Comment.Text;
            }
        }

        private async void btnNewAdmin_Click(object sender, EventArgs e)
        {
            var username = txtAdminUsername.Text;
            var email = txtAdminEmail.Text;
            var password = txtAdminPassword.Text;
            var imagePath = _adminImage; 
            var selectedPermissionString = cmBxAdminPerms.SelectedItem?.ToString();

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(imagePath) ||
                string.IsNullOrWhiteSpace(selectedPermissionString))
            {
                MessageBox.Show("All fields must be filled and an image must be selected.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!Enum.TryParse(selectedPermissionString, out Permission selectedPermission))
            {
                MessageBox.Show("Invalid permission selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                bool success = await _userService.RegisterUserAsync(username, email, imagePath, password, DateTime.Now, "Admin", null, null, (int)selectedPermission);
                if (success)
                {
                    MessageBox.Show("Admin registered successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadInfo();
                }
                else
                {
                    MessageBox.Show("Failed to register admin.", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnEditAdmin_Click(object sender, EventArgs e)
        {

        }

        private void btnRemoveAdmin_Click(object sender, EventArgs e)
        {

        }

        private void btnAdminAttachImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";  // Default directory when the dialog opens
                openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";  // Filter to only show image files
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Get the path of specified file
                    string filePath = openFileDialog.FileName;

                    // Copy the file to the new path
                    try
                    {
                        string targetPath = @"D:\talktome\talktomeweb\wwwroot\images\users";
                        string destFile = Path.Combine(targetPath, Path.GetFileName(filePath));

                        // Ensure that the target directory exists; if not, create it
                        if (!Directory.Exists(targetPath))
                        {
                            Directory.CreateDirectory(targetPath);
                        }

                        // Copy the file to destination path
                        File.Copy(filePath, destFile, true);  // 'true' allows the file to be overwritten if it already exists

                        // Optionally, load the image into a PictureBox
                        pictureBoxAdminImage.Image = Image.FromFile(destFile);
                        _adminImage = filePath;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: Could not save the file. Original error: " + ex.Message);
                    }
                }
            }
        }

        private void lstBoxAdmins_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
