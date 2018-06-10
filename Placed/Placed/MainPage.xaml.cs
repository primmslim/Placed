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
		public MainPage()
		{
			InitializeComponent();
            FillList();
        }

        void FillList()
        {
            ObservableCollection<Rake> rakes = new ObservableCollection<Rake>();

            var r1 = new Rake();
            
            r1.Wagons.Add(new Wagon("UKK1234", 1));
            r1.Wagons.Add(new Wagon("IAB123", 2));
            r1.Wagons.Add(new Wagon("PKK123", 3));
            r1.Wagons.Add(new Wagon("Pkk987", 4));
            r1.Wagons.Add(new Wagon("IH10291", 5));
            r1.PlacementDeadline = new DateTime(2018, 06, 10, 09, 00, 05);
            rakes.Add(r1);
            var r2 = new Rake();
            
            r2.Wagons.Add(new Wagon("UKK1235", 1));
            r2.Wagons.Add(new Wagon("IAB123", 2));
            r2.Wagons.Add(new Wagon("PKK123", 3));
            r2.Wagons.Add(new Wagon("Pkk987", 4));
            r2.Wagons.Add(new Wagon("IH10292", 5));
            r2.PlacementDeadline = new DateTime(2018, 06, 10, 22, 00, 05);
            rakes.Add(r2);
            RakeList.ItemsSource = rakes;

            

        }

        private void LoadData_Clicked(object sender, EventArgs e)
        {
            
            Navigation.PushAsync(new AddRake());
        }


        private void RakeList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var item = (Rake)e.Item;
            RakeDetails rakeDetails = new RakeDetails(item);
            Navigation.PushAsync(rakeDetails);

        }
    }


}
