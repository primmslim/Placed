using Placed.KR;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing.Net.Mobile.Forms;

namespace Placed
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ReportPlace : ContentPage
	{
        Rake rake;
        bool IsLate;
		public ReportPlace (Rake _rake)
		{
			InitializeComponent ();
            FillPicker();
            rake = _rake;
            rake.PlacementCompletedOn = DateTime.Now;
            if (rake.PlacementCompletedOn > rake.PlacementDeadline)
            {
                pckLateReason.IsVisible = true;
                IsLate = true;
            }
            else {
                IsLate = false;
                pckLateReason.IsVisible = false;
            }

		}

        void FillPicker()
        {
            var Reasons = new ObservableCollection<string>();
            Reasons.Add("Customer Siding not Open");
            Reasons.Add("Weather");
            Reasons.Add("Late inbound Train");
            Reasons.Add("Other");
            pckLateReason.ItemsSource = Reasons;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(rake.PlaceLocation))
            {
                DisplayAlert("", "Please scan a siding barcode", "Back");
                return;
            }
            if (IsLate)
            {
                if (pckLateReason.SelectedItem == null)
                {
                    DisplayAlert("", "Please select a late reason", "Back");
                    return;
                }
                if (pckLateReason.SelectedItem.ToString() == "Other" && string.IsNullOrEmpty(txtOther.Text))
                {
                    DisplayAlert("", "Please type a reason in or select one from the list", "Back");
                    return;
                }

            }

            if (IsLate)
            {
                rake.Status = Rake.RakeStatus.PlacedLate;
                rake.LateReason = (pckLateReason.SelectedItem?.ToString() == "Other") ? txtOther.Text : pckLateReason.SelectedItem.ToString();
            }
            else
            {
                rake.Status = Rake.RakeStatus.PlacedOnTime;
            }

            var rl = new RakeList();
            rl.PopulateList();
            var removed = rl.rakes.Single(x => x.ID == rake.ID);
            rl.rakes.Remove(removed);
            rl.rakes.Add(rake);
            rl.SaveList();

            MessagingCenter.Send<ContentPage>(this, "RefreshMainPage");
            Navigation.PopToRootAsync();

        }

        private async void StartScan_Clicked(object sender, EventArgs e)
        {
            var scanPage = new ZXingScannerPage();
            ZXingDefaultOverlay overlay = new ZXingDefaultOverlay();




            await Navigation.PushAsync(scanPage);
            scanPage.OnScanResult += (result) =>
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    if (!result.Text.Substring(0, 1).Equals("P"))
                    {
                        DisplayAlert(result.Text, "This is not a siding code, please try again", "OK");
                        return;
                    }

                    await Navigation.PopAsync();
                    rake.PlaceLocation = (result.Text.Substring(1, result.Text.Length - 1));
                    btnScanLocation.IsVisible = false;
                    lblLocationCode.IsVisible = true;
                    lblLocationCode.Text = rake.PlaceLocation;
                }
                    );
            };



        }

        private void pckLateReason_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtOther.IsVisible = pckLateReason.SelectedItem.Equals("Other") ? true : false;

        }
    }
}