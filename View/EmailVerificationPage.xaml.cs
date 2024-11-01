using Grabby_Two.Model;
using Grabby_Two.ViewModel;

namespace Grabby_Two.View
	{

    public partial class EmailVerificationPage : ContentPage
        {
        public EmailVerificationPage()
            {
            InitializeComponent();

            BindingContext = ServiceProviderHelper.GetService<EmailVerificationPageVM>();

            }
        }
    }

