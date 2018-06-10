using Placed.KR;
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
	public partial class RakeDetails : ContentPage
	{
        Rake rake;
		public RakeDetails (Rake _rake)
		{
			InitializeComponent ();
            rake = _rake;
            LblTitle.Text = "Rake Details";
            lblDeadline.Text = string.Format("Placement Deadline: {0} {1}", rake.PlacementDeadline.ToShortTimeString(),rake.PlacementDeadline.ToShortDateString());
            WagonList.ItemsSource = rake.Wagons;
		}

        private void btnPlace_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new ReportPlace());
        }
    }
}