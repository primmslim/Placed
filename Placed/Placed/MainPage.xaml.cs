using Placed.KR;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Placed
{
	public partial class MainPage : ContentPage
	{
        public RakeList rakeList;

        public MainPage()
		{
			InitializeComponent();
            FillList();
            MessagingCenter.Subscribe<ContentPage>(this, "RefreshMainPage", (sender) => {
                FillList();
            });
            MessagingCenter.Subscribe<ContentPage>(this, "SaveRakeList", (sender) => {
                rakeList.SaveList();
                FillList();
                
            });
        }

        void FillList()
        {
            rakeList = new RakeList();
            rakeList.PopulateList();
            RakeList.ItemsSource = rakeList.rakes;

        }



        private void RakeList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var item = (Rake)e.Item;
            var rakeDetails = new RakeDetails(item);
            Navigation.PushAsync(rakeDetails);

        }

        private void AddNewRake_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddRake());
            
        }

        private void RakeList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ((ListView)sender).SelectedItem = null;
        }
    }


}
