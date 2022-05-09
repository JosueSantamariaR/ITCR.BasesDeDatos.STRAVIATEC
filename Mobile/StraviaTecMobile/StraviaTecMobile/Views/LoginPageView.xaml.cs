using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace StraviaTecMobile.Views
{
    /// <summary>
    /// Page to login with user name and password
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPageView
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LoginwithSocialIconPageView" /> class.
        /// </summary>
        public LoginPageView()
        {
            this.InitializeComponent();
        }
    }
}