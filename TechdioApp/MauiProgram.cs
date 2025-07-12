using Firebase.Auth;
using Firebase.Auth.Providers;
using Firebase.Auth.Repository;
using Firebase.Database;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using TechdioApp.Controls;
using TechdioApp.Dashboard;
using TechdioApp.Dashboard.Pages;
using TechdioApp.Dashboard.ViewModels;
using TechdioApp.Pages;
using TechdioApp.Services;


namespace TechdioApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();

            // Basic app setup
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(static fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            // Global exception handling
            AppDomain.CurrentDomain.UnhandledException += (sender, args) =>
            {
                // Log the exception
                Console.WriteLine($"Unhandled exception: {args.ExceptionObject}");
            };

            // Debug logging setup
#if DEBUG
            builder.Logging.AddDebug();
#endif


            // Firebase Database setup
            builder.Services.AddSingleton(new FirebaseClient("Your-Firebase-DatabaseURL-key-here/"));

            // Firebase Authentication setup
            var firebaseAuthConfig = new FirebaseAuthConfig
            {
                ApiKey = "Your-Firebase-API-key-here",
                AuthDomain = "techdio-maui-d729d.firebaseapp.com",
                Providers = new FirebaseAuthProvider[]
                {
            new EmailProvider() // Add more providers here as needed
                },
                UserRepository = new FileUserRepository("TechdioApp")
            };
            builder.Services.AddSingleton(new FirebaseAuthClient(firebaseAuthConfig));

            // Register pages, controls, and view models
            RegisterViewsAndViewModels(builder);

            return builder.Build();
        }
        private static void RegisterViewsAndViewModels(MauiAppBuilder builder)
        {
            builder.Services.AddSingleton<AppShell>();
            // Views
            builder.Services.AddSingleton<SigninView>();
            builder.Services.AddSingleton<SignUpView>();
            builder.Services.AddSingleton<DashboardView>();
            builder.Services.AddSingleton<HomePage>();
            builder.Services.AddSingleton<CoursePage>();
            builder.Services.AddSingleton<TutorPage>();
            builder.Services.AddSingleton<TutorPageViewModel>();
            builder.Services.AddSingleton<ProfilePage>();
            builder.Services.AddSingleton<EditProfilePage>();
            builder.Services.AddSingleton<AboutPage>();


            // Flyout
            builder.Services.AddSingleton<FlyoutHeaderControl>();
            builder.Services.AddSingleton<FirebaseService>();
            builder.Services.AddSingleton<LoadingPage>();
         
            // ViewModels
            builder.Services.AddSingleton<SignInViewModel>();
            builder.Services.AddSingleton<SignUpViewModel>();
            builder.Services.AddSingleton<DashboardViewModel>();
            builder.Services.AddSingleton<TutorPageViewModel>();
            builder.Services.AddSingleton<AppShellViewModel>();
            builder.Services.AddSingleton<CoursePageViewModel>();
            
            // Register ViewModels
        }
    }
}
