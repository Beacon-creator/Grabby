using Grabby_Two.Model;

namespace Grabby_Two.View
    {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CodeVerificationSignUpPage : ContentPage
        {



        public CodeVerificationSignUpPage()
            {
            InitializeComponent();

            BindingContext = ServiceProviderHelper.GetService<CodeVerificationSignUpPage>();

            }

        }
}