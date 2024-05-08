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
            LoadPermissions();
            LoadInfo();
        }

        // Loading Functions
        private void LoadInfo()
        {
            int[] insights = _moderationService.GetInsights();
            lblUsersTotal.Text = insights[0].ToString();
            lblUsersToday.Text = insights[1].ToString();
            lblPostsTotal.Text = insights[2].ToString();
            lblPostsToday.Text = insights[3].ToString();
            lblCommentsTotal.Text = insights[4].ToString();
            lblLikesTotal.Text = insights[5].ToString();

            var flaggedUsers = _moderationService.FlaggedUsers
                .OrderByDescending(flag => flag.CreationDate)
                .ToList();

            lblFlaggedUsersTotal.Text = flaggedUsers.Count.ToString();
            lstBoxFlaggedUsersDashboard.Items.Clear();
            lstBoxFlaggedUsers.Items.Clear();
            foreach (var flag in flaggedUsers)
            {
                string displayInfo = $"{flag.FlagId}-{flag.ToUser.Username}-{flag.Reason}-Ok:{flag.Resolved}";
                lstBoxFlaggedUsersDashboard.Items.Add(displayInfo);
                lstBoxFlaggedUsers.Items.Add(displayInfo);
            }

            var flaggedPosts = _moderationService.FlaggedPosts
                .OrderByDescending(flag => flag.CreationDate)
                .ToList();

            lblFlaggedPostsTotal.Text = flaggedPosts.Count.ToString();
            lstBoxFlaggedPostsDashboard.Items.Clear();
            lstBoxFlaggedPosts.Items.Clear();
            foreach (var flag in flaggedPosts)
            {
                string displayInfo = $"{flag.FlagId}-{flag.Post.User.Username}-Ok:{flag.Resolved}";
                lstBoxFlaggedPostsDashboard.Items.Add(displayInfo);
                lstBoxFlaggedPosts.Items.Add(displayInfo);
            }

            var flaggedComments = _moderationService.FlaggedComments
                .OrderByDescending(flag => flag.CreationDate)
                .ToList();

            lblFlaggedCommentsTotal.Text = flaggedComments.Count.ToString();
            lstBoxFlaggedCommentsDashboard.Items.Clear();
            lstBoxFlaggedComments.Items.Clear();
            foreach (var flag in flaggedComments)
            {
                string displayInfo = $"{flag.FlagId}-{flag.Comment.User.Username}-Ok:{flag.Resolved}";
                lstBoxFlaggedCommentsDashboard.Items.Add(displayInfo);
                lstBoxFlaggedComments.Items.Add(displayInfo);
            }


            // Load all admins
            List<Admin> admins = _userService.GetAllAdmins();
            lstBoxAdmins.Items.Clear();
            foreach (var admin in admins)
            {
                lstBoxAdmins.Items.Add($"{admin.UserId}-{admin.Username}");
            }

            // Load Perms
            cmBxAdminPerms.Items.Clear();

            var permissions = Enum.GetNames(typeof(Permission));
            foreach (var permission in permissions)
            {
                cmBxAdminPerms.Items.Add(permission);
            }

            cmBxAdminPerms.SelectedIndex = 0;

            // Set picture boxes settings
            pictureBoxAdminImage.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxPostImage.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxUserProfile.SizeMode = PictureBoxSizeMode.Zoom;

        }
        private void LoadPermissions()
        {
            Admin CurrentUser = _userService.GetCurrentlyLoggedInUser();
            switch (CurrentUser.Permission)
            {
                case Permission.Basic:
                    btnAdminAttachImage.Enabled = false;
                    btnNewAdmin.Enabled = false;
                    btnEditAdmin.Enabled = true;
                    btnRemoveAdmin.Enabled = false;

                    btnBanUser.Enabled = true;
                    btnUnbanUser.Enabled = false;
                    btnBanUserFromComment.Enabled = true;
                    btnBanUserFromPost.Enabled = true;

                    btnRemoveFlagUser.Enabled = false;

                    btnRemoveFlagPost.Enabled = false;
                    btnRemovePost.Enabled = false;

                    btnRemoveFlagComment.Enabled = false;
                    btnDeleteComment.Enabled = false;
                    break;
                case Permission.Moderate:
                    btnAdminAttachImage.Enabled = true;
                    btnNewAdmin.Enabled = false;
                    btnEditAdmin.Enabled = true;
                    btnRemoveAdmin.Enabled = false;

                    btnBanUser.Enabled = true;
                    btnUnbanUser.Enabled = true;
                    btnBanUserFromComment.Enabled = true;
                    btnBanUserFromPost.Enabled = true;

                    btnRemoveFlagUser.Enabled = false;

                    btnRemoveFlagPost.Enabled = false;
                    btnRemovePost.Enabled = false;

                    btnRemoveFlagComment.Enabled = false;
                    btnDeleteComment.Enabled = false;
                    break;
                case Permission.Full:
                    btnAdminAttachImage.Enabled = true;
                    btnNewAdmin.Enabled = true;
                    btnEditAdmin.Enabled = true;
                    btnRemoveAdmin.Enabled = true;

                    btnBanUser.Enabled = true;
                    btnUnbanUser.Enabled = true;
                    btnBanUserFromComment.Enabled = true;
                    btnBanUserFromPost.Enabled = true;

                    btnRemoveFlagUser.Enabled = true;

                    btnRemoveFlagPost.Enabled = true;
                    btnRemovePost.Enabled = true;

                    btnRemoveFlagComment.Enabled = true;
                    btnDeleteComment.Enabled = true;
                    break;
            }

        }
        // Helpers
        private int ParseFlagIdFromDisplayInfo(string displayInfo)
        {
            var flagId = displayInfo.Split('-');
            return Int32.Parse(flagId[0]);
        }

        // Flagged Users Tab
        private void lstBoxFlaggedUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstBoxFlaggedUsers.SelectedIndex != -1)
            {
                string selectedItem = lstBoxFlaggedUsers.SelectedItem.ToString();
                int flagId = ParseFlagIdFromDisplayInfo(selectedItem);
                FlagUser flagUser = _moderationService.GetFlagUserById(flagId);
                lblUserName.Text = flagUser.ToUser.Username;
                lblUserEmail.Text = flagUser.ToUser.Email;
                // Get flagged user
                var flaggedUser = _userService.GetUserById(flagUser.ToUserId);
                lblUserBio.Text = flaggedUser.Bio;
                lblUserFlagReason.Text = flagUser.Reason;
                lblUserStatus.Text = flaggedUser.Status.ToString();
                try
                {
                    pictureBoxUserProfile.Image = Image.FromFile(@$"D:\talktome\talktomeweb\wwwroot\images\users\{flagUser.ToUser.ImagePath}");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to load user image: {ex.Message}");
                }
            }
        }

        private async void btnRemoveFlagUser_Click(object sender, EventArgs e)
        {
            if (lstBoxFlaggedUsers.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a flagged user to remove the flag.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int flagId = ParseFlagIdFromDisplayInfo(lstBoxFlaggedUsers.SelectedItem.ToString());

            var confirmationResult = MessageBox.Show("Are you sure you want to remove this flag?", "Confirm Flag Removal", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmationResult == DialogResult.Yes)
            {
                bool success = await _moderationService.RemoveFlaggedUser(flagId);
                if (success)
                {
                    MessageBox.Show("Flag removed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadInfo();
                }
                else
                {
                    MessageBox.Show("Failed to remove flag.", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void btnUnbanUser_Click(object sender, EventArgs e)
        {
            if (lstBoxFlaggedUsers.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a banned user to unban.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int flagId = ParseFlagIdFromDisplayInfo(lstBoxFlaggedUsers.SelectedItem.ToString());
            FlagUser flagUser = _moderationService.GetFlagUserById(flagId);
            if (flagUser != null)
            {
                bool success = await _moderationService.UnBanUser(flagUser.ToUserId);
                if (success)
                {
                    await _moderationService.ResolveFlag(flagId);
                    LoadInfo();
                    MessageBox.Show("User has been unbanned successfully.", "Unban Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Failed to unban the user.", "Unban Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void btnBanUser_Click(object sender, EventArgs e)
        {
            if (lstBoxFlaggedUsers.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a user to ban.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int flagId = ParseFlagIdFromDisplayInfo(lstBoxFlaggedUsers.SelectedItem.ToString());
            FlagUser flagUser = _moderationService.GetFlagUserById(flagId);
            if (flagUser != null)
            {
                bool success = await _moderationService.BanUser(flagUser.ToUserId);
                if (success)
                {
                    await _moderationService.ResolveFlag(flagId);
                    LoadInfo();
                    MessageBox.Show("User has been banned successfully.", "Ban Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Failed to ban the user.", "Ban Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Flagged Posts Tab
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
                if (flagPost.Post.ImagePath != null)
                {
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
        }

        private async void btnRemovePost_Click(object sender, EventArgs e)
        {
            if (lstBoxFlaggedPosts.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a post to delete.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int flagId = ParseFlagIdFromDisplayInfo(lstBoxFlaggedPosts.SelectedItem.ToString());

            var confirmationResult = MessageBox.Show("Are you sure you want to delete this post?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmationResult == DialogResult.Yes)
            {
                bool success = await _moderationService.DeleteFlaggedPost(flagId);
                if (success)
                {
                    MessageBox.Show("Post deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadInfo();
                }
                else
                {
                    MessageBox.Show("Failed to delete post.", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void btnRemoveFlagPost_Click(object sender, EventArgs e)
        {
            if (lstBoxFlaggedPosts.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a flagged post to remove the flag.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int flagId = ParseFlagIdFromDisplayInfo(lstBoxFlaggedPosts.SelectedItem.ToString());

            var confirmationResult = MessageBox.Show("Are you sure you want to remove this flag?", "Confirm Flag Removal", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmationResult == DialogResult.Yes)
            {
                bool success = await _moderationService.RemoveFlaggedPost(flagId);
                if (success)
                {
                    MessageBox.Show("Flag removed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadInfo();
                }
                else
                {
                    MessageBox.Show("Failed to remove flag.", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void btnBanUserFromPost_Click(object sender, EventArgs e)
        {
            if (lstBoxFlaggedPosts.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a post to ban the user.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int flagId = ParseFlagIdFromDisplayInfo(lstBoxFlaggedPosts.SelectedItem.ToString());
            FlagPost flagPost = _moderationService.GetFlagPostById(flagId);
            if (flagPost != null)
            {
                bool success = await _moderationService.BanUser(flagPost.Post.UserId);
                if (success)
                {
                    await _moderationService.ResolveFlag(flagId);
                    LoadInfo();
                    MessageBox.Show("User from the post has been banned successfully.", "Ban Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Failed to ban the user from the post.", "Ban Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Flagged Comments Tab
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

        private async void btnDeleteComment_Click(object sender, EventArgs e)
        {
            if (lstBoxFlaggedComments.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a comment to delete.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int flagId = ParseFlagIdFromDisplayInfo(lstBoxFlaggedComments.SelectedItem.ToString());

            var confirmationResult = MessageBox.Show("Are you sure you want to delete this comment?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmationResult == DialogResult.Yes)
            {
                bool success = await _moderationService.DeleteFlaggedComment(flagId);
                if (success)
                {
                    MessageBox.Show("Comment deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadInfo();
                }
                else
                {
                    MessageBox.Show("Failed to delete comment.", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void btnRemoveFlagComment_Click(object sender, EventArgs e)
        {
            if (lstBoxFlaggedComments.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a flagged comment to remove the flag.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int flagId = ParseFlagIdFromDisplayInfo(lstBoxFlaggedComments.SelectedItem.ToString());

            var confirmationResult = MessageBox.Show("Are you sure you want to remove this flag?", "Confirm Flag Removal", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmationResult == DialogResult.Yes)
            {
                bool success = await _moderationService.RemoveFlaggedComment(flagId);
                if (success)
                {
                    MessageBox.Show("Flag removed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadInfo();
                }
                else
                {
                    MessageBox.Show("Failed to remove flag.", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void btnBanUserFromComment_Click(object sender, EventArgs e)
        {
            if (lstBoxFlaggedComments.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a comment to ban the user.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int flagId = ParseFlagIdFromDisplayInfo(lstBoxFlaggedComments.SelectedItem.ToString());
            FlagComment flagComment = _moderationService.GetFlagCommentById(flagId);
            if (flagComment != null)
            {
                bool success = await _moderationService.BanUser(flagComment.Comment.UserId);
                if (success)
                {
                    await _moderationService.ResolveFlag(flagId);
                    LoadInfo();
                    MessageBox.Show("User from the comment has been banned successfully.", "Ban Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Failed to ban the user from the comment.", "Ban Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Admins Tab
        private void lstBoxAdmins_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstBoxAdmins.SelectedItem != null)
            {
                int selectedUserId = Convert.ToInt32(lstBoxAdmins.SelectedItem.ToString().Split('-')[0]);
                var selectedAdmin = _userService.GetUserById(selectedUserId) as Admin;

                if (selectedAdmin != null)
                {
                    txtAdminUsername.Text = selectedAdmin.Username;
                    txtAdminEmail.Text = selectedAdmin.Email;
                    txtAdminPassword.Clear();
                    if (!string.IsNullOrWhiteSpace(selectedAdmin.ImagePath))
                    {
                        try
                        {
                            _adminImage = selectedAdmin.ImagePath;
                            pictureBoxAdminImage.Image = Image.FromFile(@$"D:\talktome\talktomeweb\wwwroot\images\users\{selectedAdmin.ImagePath}");
                        }
                        catch
                        {
                            pictureBoxAdminImage.Image = null;
                        }
                    }
                    else
                    {
                        pictureBoxAdminImage.Image = null;
                    }

                    if (selectedAdmin.Permission != null)
                    {
                        cmBxAdminPerms.SelectedItem = selectedAdmin.Permission.ToString();
                    }
                }
            }
            else
            {

                txtAdminUsername.Clear();
                txtAdminEmail.Clear();
                txtAdminPassword.Clear();
                _adminImage = null;
                pictureBoxAdminImage.Image = null;
                cmBxAdminPerms.SelectedIndex = -1;
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
                bool success = await _userService.RegisterUserAsync(username, email, Path.GetFileName(imagePath), password, DateTime.Now, "Admin", null, null, (int)selectedPermission);
                if (success)
                {
                    MessageBox.Show("Admin registered successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _adminImage = null;
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

        private async void btnEditAdmin_Click(object sender, EventArgs e)
        {
            if (lstBoxAdmins.SelectedItem == null)
            {
                MessageBox.Show("Please select an admin to edit.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int selectedUserId = Convert.ToInt32(lstBoxAdmins.SelectedItem.ToString().Split('-')[0]);
            var username = txtAdminUsername.Text;
            var email = txtAdminEmail.Text;
            var imagePath = _adminImage;
            var password = txtAdminPassword.Text;
            var selectedPermissionString = cmBxAdminPerms.SelectedItem?.ToString();

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(imagePath) ||
                string.IsNullOrWhiteSpace(selectedPermissionString))
            {
                MessageBox.Show("All fields must be filled (except password), and an image must be selected.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!Enum.TryParse(selectedPermissionString, out Permission selectedPermission))
            {
                MessageBox.Show("Invalid permission selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                await _userService.EditUser(selectedUserId, username, email, Path.GetFileName(imagePath), string.IsNullOrWhiteSpace(password) ? null : password, DateTime.Now, "Admin", null, null, (int)selectedPermission);
                _adminImage = null;
                MessageBox.Show("Admin updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadInfo();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnRemoveAdmin_Click(object sender, EventArgs e)
        {
            if (lstBoxAdmins.SelectedItem == null)
            {
                MessageBox.Show("Please select an admin to delete.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int selectedUserId = Convert.ToInt32(lstBoxAdmins.SelectedItem.ToString().Split('-')[0]);

            var confirmationResult = MessageBox.Show("Are you sure you want to delete this admin?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmationResult == DialogResult.Yes)
            {
                try
                {
                    await _userService.DeleteUser(selectedUserId);
                    _adminImage = null;
                    MessageBox.Show("Admin deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadInfo();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnAdminAttachImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";  // Filter to only show image files
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;

                    try
                    {
                        string targetPath = @"D:\talktome\talktomeweb\wwwroot\images\users";
                        string destFile = Path.Combine(targetPath, Path.GetFileName(filePath));

                        if (!Directory.Exists(targetPath))
                        {
                            Directory.CreateDirectory(targetPath);
                        }

                        File.Copy(filePath, destFile, true);  // 'true' allows the file to be overwritten if it already exists

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

    }
}
