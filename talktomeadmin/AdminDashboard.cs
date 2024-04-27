using SharedLibrary.Models;
using SharedLibrary.Services;

namespace talktomeadmin
{
    public partial class AdminDashboard : Form
    {
        private readonly ModerationService _moderationService;
        public AdminDashboard(ModerationService moderationService)
        {
            InitializeComponent();
            _moderationService = moderationService;
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
                pictureBoxUserProfile.Image = new Bitmap($""); // how do I get image from website
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
                // pictureBoxPostImage.Image = new Bitmap($"");
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

    }
}
