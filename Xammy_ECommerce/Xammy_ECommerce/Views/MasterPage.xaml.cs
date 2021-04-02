using Xamarin.Forms;

namespace Xammy_ECommerce.Views
{
    public partial class MasterPage : MasterDetailPage
    {
        public MasterPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
        }
    }
}