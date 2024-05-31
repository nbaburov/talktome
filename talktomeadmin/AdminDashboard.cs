using SharedLibrary.Models;
using SharedLibrary.Repository;
using SharedLibrary.Services;

namespace talktomeadmin
{
    public partial class AdminDashboard : Form
    {
        private readonly ModerationRepository _moderationRepo;
        private readonly FlaggedCommentService _flagCommentService;
        private readonly FlaggedPostService _flagPostService;
        private readonly FlaggedUserService _flagUserService;
        private readonly UserService _userService;
        private readonly AuthService _authService;
        private string _adminImage;
        public AdminDashboard(AuthService authService, ModerationRepository moderationRepository, FlaggedCommentService flaggedCommentService, FlaggedPostService flaggedPostService, FlaggedUserService flaggedUserService)
        {
            InitializeComponent();
            _moderationRepo = moderationRepository;
            _flagCommentService = flaggedCommentService;
            _flagPostService = flaggedPostService;
            _flagUserService = flaggedUserService;

            _userService = _moderationRepo.GetUserService();
            _authService = authService;
            LoadPermissions();
            LoadInfo();
        }

        // Loading Functions
        private void LoadInfo()
        {
            int[] insights = _moderationRepo.GetInsights();
            lblUsersTotal.Text = insights[0].ToString();
            lblUsersToday.Text = insights[1].ToString();
            lblPostsTotal.Text = insights[2].ToString();
            lblPostsToday.Text = insights[3].ToString();
            lblCommentsTotal.Text = insights[4].ToString();
            lblLikesTotal.Text = insights[5].ToString();

            var flaggedUsers = _moderationRepo.GetFlaggedUsers()
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

            var flaggedPosts = _moderationRepo.GetFlaggedPosts()
                .OrderByDescending(flag => flag.CreationDate)
                .ToList();

            lblFlaggedPostsTotal.Text = flaggedPosts.Count.ToString();
            lstBoxFlaggedPostsDashboard.Items.Clear();
            lstBoxFlaggedPosts.Items.Clear();
            foreach (var flag in flaggedPosts)
            {
                var displayInfo = "";
                if (flag.Post != null)
                {
                    displayInfo = $"{flag.FlagId}-{flag.Post?.User.Username}-Ok:{flag.Resolved}";
                }
                else
                {
                    displayInfo = $"{flag.FlagId}-DeletedPost-Ok:{flag.Resolved}";
                }
                lstBoxFlaggedPostsDashboard.Items.Add(displayInfo);
                lstBoxFlaggedPosts.Items.Add(displayInfo);
            }

            var flaggedComments = _moderationRepo.GetFlaggedComments()
                .OrderByDescending(flag => flag.CreationDate)
                .ToList();

            lblFlaggedCommentsTotal.Text = flaggedComments.Count.ToString();
            lstBoxFlaggedCommentsDashboard.Items.Clear();
            lstBoxFlaggedComments.Items.Clear();
            foreach (var flag in flaggedComments)
            {
                var displayInfo = "";
                if (flag.Comment != null)
                {
                    displayInfo = $"{flag.FlagId}-{flag.Comment?.User.Username}-Ok:{flag.Resolved}";
                }
                else
                {
                    displayInfo = $"{flag.FlagId}-DeletedComment-Ok:{flag.Resolved}";
                }
                
                lstBoxFlaggedCommentsDashboard.Items.Add(displayInfo);
                lstBoxFlaggedComments.Items.Add(displayInfo);
            }

            // Load all clients
            List<Client> clients = _userService.GetAllClients();
            lstBoxUsers.Items.Clear();
            foreach (var client in clients)
            {
                lstBoxUsers.Items.Add($"{client.UserId}-{client.Username}-{client.Status.ToString()}");
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
            pictureBoxFlaggedUserProfile.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxUserImage.SizeMode = PictureBoxSizeMode.Zoom;

        }
        private void LoadPermissions()
        {
            Admin CurrentUser = _authService.GetCurrentlyLoggedInUser();
            switch (CurrentUser.Permission)
            {
                case Permission.Basic:
                    btnAdminAttachImage.Enabled = false;
                    btnNewAdmin.Enabled = false;
                    btnEditAdmin.Enabled = true;
                    btnRemoveAdmin.Enabled = false;

                    btnBanUser.Enabled = true;
                    btnUnbanUser.Enabled = false;
                    btnBanFlaggedUser.Enabled = true;
                    btnUnbanFlaggedUser.Enabled = false;
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
                    btnBanFlaggedUser.Enabled = true;
                    btnUnbanFlaggedUser.Enabled = true;
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
                    btnBanFlaggedUser.Enabled = true;
                    btnUnbanFlaggedUser.Enabled = true;
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
        private int ParseFlagIdFromDisplayInfo(string displayInfo) // ! String Manipulation
        {
            var flagId = displayInfo.Split('-');
            return Int32.Parse(flagId[0]);
        }

        // Method to get the root path of the solution
        private string GetSolutionRoot()
        {
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            DirectoryInfo directoryInfo = new DirectoryInfo(baseDirectory);

            while (directoryInfo != null && directoryInfo.Name != "talktome")
            {
                directoryInfo = directoryInfo.Parent;
            }

            if (directoryInfo == null)
            {
                throw new DirectoryNotFoundException("Solution root directory 'talktome' not found.");
            }

            return directoryInfo.FullName;
        }

        // Flagged Users Tab
        private void lstBoxFlaggedUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstBoxFlaggedUsers.SelectedIndex != -1)
            {
                string selectedItem = lstBoxFlaggedUsers.SelectedItem.ToString();
                int flagId = ParseFlagIdFromDisplayInfo(selectedItem);
                FlagUser flagUser = _flagUserService.GetFlagUserById(flagId);
                if (flagUser.ToUser != null)
                {
                    lblFlaggedUserName.Text = flagUser.ToUser.Username;
                    lblFlaggedUserEmail.Text = flagUser.ToUser.Email;
                    // Get flagged user
                    var flaggedUser = _userService.GetUserById(flagUser.ToUserId);
                    lblFlaggedUserBio.Text = flaggedUser.Bio;
                    lblUserFlagReason.Text = flagUser.Reason;
                    lblFlaggedUserStatus.Text = flaggedUser.Status.ToString();
                    try
                    {
                        // Get the root path of the solution
                        string solutionRoot = GetSolutionRoot();
                        // Construct the path to the image in talktomeweb
                        string imagePath = Path.Combine(solutionRoot, "talktomeweb", "wwwroot", "images", "users", flagUser.ToUser.ImagePath);

                        if (File.Exists(imagePath))
                        {
                            pictureBoxFlaggedUserProfile.Image = Image.FromFile(imagePath);
                        }
                        else
                        {
                            MessageBox.Show("Image file not found: " + imagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Failed to load user image: {ex.Message}");
                    }
                }
                else
                {
                    lblFlaggedUserName.Text = "Flagged User Deleted.";
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
                bool success = await _flagUserService.RemoveFlaggedUser(flagId);
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
            FlagUser flagUser = _flagUserService.GetFlagUserById(flagId);
            if (flagUser != null)
            {
                bool success = await _flagUserService.UnBanUser(flagUser.ToUserId);
                if (success)
                {
                    await _moderationRepo.ResolveFlag(flagId);
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
            FlagUser flagUser = _flagUserService.GetFlagUserById(flagId);
            if (flagUser != null)
            {
                bool success = await _flagUserService.BanUser(flagUser.ToUserId);
                if (success)
                {
                    await _moderationRepo.ResolveFlag(flagId);
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
                FlagPost flagPost = _flagPostService.GetFlagPostById(flagId);
                if (flagPost.Post != null)
                {
                    lblUserNamePost.Text = flagPost.Post.User.Username;
                    lblUserEmailPost.Text = flagPost.Post.User.Email;
                    lblPostText.Text = flagPost.Post.Text;
                    if (flagPost.Post.ImagePath != null && flagPost.Post.ImagePath != "")
                    {
                        try
                        {
                            // Get the root path of the solution
                            string solutionRoot = GetSolutionRoot();
                            // Construct the path to the image in talktomeweb
                            string imagePath = Path.Combine(solutionRoot, "talktomeweb", "wwwroot", "images", "posts", flagPost.Post.ImagePath);

                            if (File.Exists(imagePath))
                            {
                                pictureBoxPostImage.Image = Image.FromFile(imagePath);
                            }
                            else
                            {
                                MessageBox.Show("Image file not found: " + imagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Failed to load post image: {ex.Message}");
                        }
                    }
                }
                else
                {
                    lblUserNamePost.Text = "Flagged Post Deleted.";
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
                bool success = await _flagPostService.DeleteFlaggedPost(flagId);
                if (success)
                {
                    await _moderationRepo.ResolveFlag(flagId);
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
                bool success = await _flagPostService.RemoveFlaggedPost(flagId);
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
            FlagPost flagPost = _flagPostService.GetFlagPostById(flagId);
            if (flagPost != null)
            {
                bool success = await _flagUserService.BanUser(flagPost.Post.UserId);
                if (success)
                {
                    await _moderationRepo.ResolveFlag(flagId);
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
                FlagComment flagComment = _flagCommentService.GetFlagCommentById(flagId);
                if (flagComment.Comment != null)
                {
                    lblUserNameComment.Text = flagComment.Comment.User.Username;
                    lblUserEmailComment.Text = flagComment.Comment.User.Email;
                    lbCommentText.Text = flagComment.Comment.Text;
                }
                else
                {
                    lblUserNameComment.Text = "Flagged Comment Deleted";
                }
                
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
                bool success = await _flagCommentService.DeleteFlaggedComment(flagId);
                if (success)
                {
                    await _moderationRepo.ResolveFlag(flagId);
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
                bool success = await _flagCommentService.RemoveFlaggedComment(flagId);
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
            FlagComment flagComment = _flagCommentService.GetFlagCommentById(flagId);
            if (flagComment != null)
            {
                bool success = await _flagUserService.BanUser(flagComment.Comment.UserId);
                if (success)
                {
                    await _moderationRepo.ResolveFlag(flagId);
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
                            // Get the root path of the solution
                            string solutionRoot = GetSolutionRoot();
                            // Construct the path to the image in talktomeweb
                            string imagePath = Path.Combine(solutionRoot, "talktomeweb", "wwwroot", "images", "users", selectedAdmin.ImagePath);

                            if (File.Exists(imagePath))
                            {
                                pictureBoxAdminImage.Image = Image.FromFile(imagePath);
                                _adminImage = selectedAdmin.ImagePath;
                            }
                            else
                            {
                                MessageBox.Show("Image file not found: " + imagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
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
                bool success = await _authService.RegisterUserAsync(username, email, Path.GetFileName(imagePath), password, DateTime.Now, "Admin", null, null, (int)selectedPermission);
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
                        string solutionRoot = GetSolutionRoot();
                        string targetPath = Path.Combine(solutionRoot, "talktomeweb", "wwwroot", "images", "users");
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

        private void lstBoxUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstBoxUsers.SelectedIndex != -1)
            {
                string selectedItem = lstBoxUsers.SelectedItem.ToString();
                int userId = ParseFlagIdFromDisplayInfo(selectedItem);
                Client user = _userService.GetUserById(userId);
                lblUserName.Text = user.Username;
                lblUserEmail.Text = user.Email;
                lblUserBio.Text = user.Bio;
                lblUserStatus.Text = user.Status.ToString();
                try
                {
                    // Get the root path of the solution
                    string solutionRoot = GetSolutionRoot();
                    // Construct the path to the image in talktomeweb
                    string imagePath = Path.Combine(solutionRoot, "talktomeweb", "wwwroot", "images", "users", user.ImagePath);

                    if (File.Exists(imagePath))
                    {
                        pictureBoxUserImage.Image = Image.FromFile(imagePath);
                    }
                    else
                    {
                        MessageBox.Show("Image file not found: " + imagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to load user image: {ex.Message}");
                }
            }
        }

        private async void btnBanUser_Click_1Async(object sender, EventArgs e)
        {
            if (lstBoxUsers.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a user to ban.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int userId = ParseFlagIdFromDisplayInfo(lstBoxUsers.SelectedItem.ToString());
            Client client = _userService.GetUserById(userId);
            if (client != null)
            {
                bool success = await _flagUserService.BanUser(userId);
                if (success)
                {
                    LoadInfo();
                    MessageBox.Show("User has been banned successfully.", "Ban Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Failed to ban the user.", "Unban Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void btnUnbanUser_Click_1Async(object sender, EventArgs e)
        {
            if (lstBoxUsers.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a user to unban.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int userId = ParseFlagIdFromDisplayInfo(lstBoxUsers.SelectedItem.ToString());
            Client client = _userService.GetUserById(userId);
            if (client != null)
            {
                bool success = await _flagUserService.UnBanUser(userId);
                if (success)
                {
                    LoadInfo();
                    MessageBox.Show("User has been unbanned successfully.", "Unban Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Failed to unban the user.", "Unban Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
