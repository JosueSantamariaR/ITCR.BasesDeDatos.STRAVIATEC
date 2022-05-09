using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace StraviaTecMobile.Views
{
    /// <summary>
    /// Page to sign in with user details.
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignUpPageView : ContentPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SignUpPageView" /> class.
        /// </summary>
        public SignUpPageView()
        {
            this.InitializeComponent();
        }

        private void DateBirthPicker_DateSelected(object sender, Xamarin.Forms.DateChangedEventArgs e)
        {

        }
    }
}