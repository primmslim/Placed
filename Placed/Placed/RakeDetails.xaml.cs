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

            switch (rake.Status)
            {
                case Rake.RakeStatus.Pending:
                    btnPlace.IsVisible = true;
                    break;
                case Rake.RakeStatus.PlacedLate:
                    lblPlacedOn.Text = string.Format("Actual Placement: {0} {1}", rake.PlacementCompletedOn.ToShortTimeString(), rake.PlacementCompletedOn.ToShortDateString());
                    lblPlacedOn.IsVisible = true;
                    lblLateReason.Text = "Late Reason: " + rake.LateReason;
                    lblLateReason.IsVisible = true;
                    break;
                default:
                    lblPlacedOn.Text = string.Format("Actual Placement: {0} {1}", rake.PlacementCompletedOn.ToShortTimeString(), rake.PlacementCompletedOn.ToShortDateString());
                    lblPlacedOn.IsVisible = true;
                    lblLateReason.Text = "Place on Time";
                    lblLateReason.IsVisible = true;
                    break;
            }
            
		}

        private void btnPlace_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ReportPlace(rake));
        }
    }
}