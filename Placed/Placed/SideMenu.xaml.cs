using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Placed
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SideMenu : MasterDetailPage
	{
		public SideMenu ()
		{
			InitializeComponent ();
            Detail = new NavigationPage(new MainPage());
		}



        private void btnHome_Clicked(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new MainPage());
            IsPresented = false;
        }

        private void btnAbout_Clicked(object sender, EventArgs e)
        {

        }

        private void btnDegub_Clicked(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new Debug());
            IsPresented = false;
        }
    }
}