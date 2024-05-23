using System;
using System.Windows.Forms;
using SharedLibrary.Services;
using SharedLibrary.Interface;
using SharedLibrary.Repository;
using Microsoft.Extensions.Configuration;
using SharedLibrary.Helpers;
using System.Data.SqlClient;

namespace talktomeadmin
{
    internal static class Program
    {
        public static IServiceConfig ServiceConfig;
        public static UserRepository UserRepository;
        public static UserService UserService;
        public static AuthService AuthService;
        public static Hash Hash;


        public static ContentRepository ContentRepository;
        public static PostService PostService;
        public static CommentService CommentService;
        public static LikeService LikeService;

        public static ModerationRepository ModerationRepository;
        public static FlaggedUserService FlaggedUserService;
        public static FlaggedPostService FlaggedPostService;
        public static FlaggedCommentService FlaggedCommentService;

        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);


                IConfiguration configuration = new ConfigurationBuilder()
                    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .Build();

                var userContext = new WinFormUserContext();
                ServiceConfig = new WinFormServiceConfig(configuration.GetConnectionString("DefaultConnection"), userContext);

                UserRepository = new UserRepository(ServiceConfig);
                Hash = new Hash();
                UserService = new UserService(UserRepository, Hash);
                AuthService = new AuthService(UserRepository, Hash);

                ContentRepository = new ContentRepository(ServiceConfig, UserService);
                PostService = new PostService(ContentRepository);
                CommentService = new CommentService(ContentRepository);
                LikeService = new LikeService(ContentRepository);

                ModerationRepository = new ModerationRepository(ServiceConfig, UserService, PostService, CommentService, LikeService);
                FlaggedUserService = new FlaggedUserService(ModerationRepository);
                FlaggedPostService = new FlaggedPostService(ModerationRepository);
                FlaggedCommentService = new FlaggedCommentService(ModerationRepository);

                using (AdminLogin loginForm = new AdminLogin(AuthService))
                {
                    if (loginForm.ShowDialog() == DialogResult.OK)
                    {
                        Application.Run(new AdminDashboard(AuthService, ModerationRepository, FlaggedCommentService, FlaggedPostService, FlaggedUserService));
                    }
                    else
                    {
                        Application.Exit();
                    }
                }
            }
            catch (System.AggregateException ex)
            {
                MessageBox.Show("☠️ No VPN Connected! Shutting down Windows Forms application.");
                Application.Exit();
            }



        }
    }
}
