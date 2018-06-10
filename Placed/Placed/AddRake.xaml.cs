using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing.Net.Mobile.Forms;
using ZXing;
using Placed.KR;
using System.Runtime.Serialization;

namespace Placed
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddRake : ContentPage
	{
        Rake rake;
		public AddRake ()
		{
			InitializeComponent();
            rake = new Rake();
            WagonList.ItemsSource = rake.Wagons;

		}

        private async void StartScan_Clicked(object sender, EventArgs e)
        {
            var scanPage = new ZXingScannerPage();
            ZXingDefaultOverlay overlay = new ZXingDefaultOverlay();
            overlay.TopText = "Please scan QR code on Wagon";



            await Navigation.PushAsync(scanPage);
            scanPage.OnScanResult += (result) =>
            {
                Device.BeginInvokeOnMainThread( async () =>
                {
                    if (!result.Text.Substring(0, 1).Equals("W"))
                    {
                        DisplayAlert(result.Text, "This is not a wagon, please try again", "OK");
                        return;
                    }

                    await Navigation.PopAsync();
                    AddWagonToRake( result.Text.Substring(1,result.Text.Length-1));
                }
                    );
            };
            


        }

        private void AddWagonToRake(string WagonID)
        {
            rake.Wagons.Add(new Wagon {ID = WagonID,MarshalOrder = rake.Wagons.Count+1 });
            
            
        }

        private void btnSave_Clicked(object sender, EventArgs e)
        {
            if (rake.Wagons.Count < 1) {
                DisplayAlert("No Wagons", "You need to add wagons before saving", "OK");
                return;
            }

            if (dtpDeadlineDate.Date == null || dtpDeadlineTime.Time == null)
            {
                DisplayAlert("No Deadline", "You need to set the deadline before saving", "OK");
                return;
            }

            rake.PlacementDeadline = dtpDeadlineDate.Date + dtpDeadlineTime.Time;
            rake.CreatedOn = DateTime.Now;
            rake.Status = Rake.RakeStatus.Pending;
            RakeList rakeList = new RakeList();
            rakeList.PopulateList();
            rakeList.rakes.Add(rake);
            rakeList.SaveList();
            MessagingCenter.Send<ContentPage>(this, "RefreshMainPage");
            Navigation.PopAsync(true);


            
        }

    }
}