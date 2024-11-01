
using Grabby_Two.ViewModel;
using Grabby_Two.Model;
namespace Grabby_Two.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignInPage : ContentPage
        {
       
        public SignInPage()
            {
            InitializeComponent();
            BindingContext = ServiceProviderHelper.GetService<SignInPageVM>();
            }

        private void RememberMecheck_CheckedChanged(object sender, CheckedChangedEventArgs e)
            {

            }
        }
}