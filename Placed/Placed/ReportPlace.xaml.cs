using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Placed
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ReportPlace : ContentPage
	{
		public ReportPlace ()
		{
			InitializeComponent ();
            FillPicker();
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
            if (pckLateReason.SelectedItem == null)
            {
                DisplayAlert("", "Please select a late reason", "Back");
                return;
            }
            if (pckLateReason.SelectedItem.ToString() == "Other" && txtOther.Text == null)
            {
                DisplayAlert("", "Please type a reason in or select one from the list", "Back");
                return;
            }
        }

        private void pckLateReason_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtOther.IsVisible = pckLateReason.SelectedItem.Equals("Other") ? true : false;

        }
    }
}