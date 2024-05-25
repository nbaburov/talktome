using System;
using System.Windows.Forms;
using SharedLibrary.Helpers;
using SharedLibrary.Interface;
using SharedLibrary.Repository;
using SharedLibrary.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace talktomeadmin
{
    internal static class Program
    {
        public static IServiceProvider ServiceProvider;

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

                var serviceCollection = new ServiceCollection();
                ConfigureServices(serviceCollection, configuration);

                ServiceProvider = serviceCollection.BuildServiceProvider();

                var authService = ServiceProvider.GetRequiredService<AuthService>();

                using (AdminLogin loginForm = new AdminLogin(authService))
                {
                    if (loginForm.ShowDialog() == DialogResult.OK)
                    {
                        var moderationRepository = ServiceProvider.GetRequiredService<ModerationRepository>();
                        var flaggedCommentService = ServiceProvider.GetRequiredService<FlaggedCommentService>();
                        var flaggedPostService = ServiceProvider.GetRequiredService<FlaggedPostService>();
                        var flaggedUserService = ServiceProvider.GetRequiredService<FlaggedUserService>();

                        Application.Run(new AdminDashboard(authService, moderationRepository, flaggedCommentService, flaggedPostService, flaggedUserService));
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

        private static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            var userContext = new WinFormUserContext();
            var serviceConfig = new WinFormServiceConfig(configuration.GetConnectionString("DefaultConnection"), userContext);

            services.AddSingleton<IServiceConfig>(serviceConfig);
            services.AddSingleton<IUserContext>(userContext);

            // Register the HashWrapper helper
            services.AddSingleton<HashWrapper>();

            // Registering the repositories
            services.AddScoped<IUserRepository, UserRepository>();

            // Registering the services
            services.AddScoped<AuthService>();
            services.AddScoped<UserService>();
            services.AddScoped<ContentRepository>();
            services.AddScoped<PostService>();
            services.AddScoped<CommentService>();
            services.AddScoped<LikeService>();
            services.AddScoped<CategoryService>();
            services.AddScoped<ModerationRepository>();
            services.AddScoped<FlaggedUserService>();
            services.AddScoped<FlaggedPostService>();
            services.AddScoped<FlaggedCommentService>();
        }
    }
}
