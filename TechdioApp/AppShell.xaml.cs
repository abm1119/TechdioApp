using LiteDB; 
using Microsoft.Maui.Controls;
using TechdioApp.Dashboard;
using TechdioApp.Dashboard.Pages;
using TechdioApp.Pages;


namespace TechdioApp
{
    public partial class AppShell : Shell
    {
       
        public AppShell(AppShellViewModel appShellViewModel)
        {
            InitializeComponent();

            BindingContext = appShellViewModel;
            Routing.RegisterRoute("AboutPage", typeof(AboutPage));
            Routing.RegisterRoute("SignIn", typeof(SigninView));
            Routing.RegisterRoute("SignUp", typeof(SignUpView));
            Routing.RegisterRoute("Dashboard", typeof(DashboardView));
            Routing.RegisterRoute("LoadingPage", typeof(LoadingPage));
            Routing.RegisterRoute("Home", typeof(HomePage));
            Routing.RegisterRoute("Courses", typeof(CoursePage));
            Routing.RegisterRoute("Tutors", typeof(TutorPage));
            Routing.RegisterRoute("Profile", typeof(ProfilePage));
            Routing.RegisterRoute("EditProfile", typeof(EditProfilePage));
            Routing.RegisterRoute("CourseDetail", typeof(CourseDetailPage));
            Routing.RegisterRoute("custom", typeof(CustomCourse));
            Routing.RegisterRoute("HireTutorForm", typeof(HireTutorFormPage));
            Routing.RegisterRoute("JoinWaitlist", typeof(JoinWaitlist));
            Routing.RegisterRoute("ComingSoon", typeof(ComingSoonPopup));


        }

    }
}
