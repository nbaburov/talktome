using System;
using System.Windows.Forms;
using SharedLibrary.Services;
using SharedLibrary.Interface;
using Microsoft.Extensions.Configuration;

namespace talktomeadmin
{
    internal static class Program
    {
        public static IServiceConfig ServiceConfig;
        public static UserService UserService;
        public static PostService PostService;
        public static ModerationService ModerationService;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            var userContext = new WinFormUserContext();
            ServiceConfig = new WinFormServiceConfig(configuration.GetConnectionString("DefaultConnection"), userContext);

            UserService = new UserService(ServiceConfig);
            PostService = new PostService(ServiceConfig, UserService);
            ModerationService = new ModerationService(ServiceConfig, UserService, PostService);

            Application.Run(new AdminDashboard(ModerationService)); 
        }
    }
}
