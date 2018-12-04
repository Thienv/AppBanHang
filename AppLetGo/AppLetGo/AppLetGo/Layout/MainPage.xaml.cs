using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppLetGo.Service;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;

namespace AppLetGo
{
    public partial class MainPage : Xamarin.Forms.TabbedPage
    {
        private List<string> source = new List<string>
        {
            //"Tan","Thien","Sang"
        };
        public MainPage()
        {
            InitializeComponent();
            On<Xamarin.Forms.PlatformConfiguration.Android>().SetToolbarPlacement(ToolbarPlacement.Bottom);
            myListView.ItemsSource = source;
        }

        private void mySearchBar_SearchButtonPressed(object sender, EventArgs e)
        {
            string searchText = mySearchBar.Text.ToLower();
            IEnumerable<string> result = source.Where(x => x.ToLower().Contains(searchText));
            if (result.Count() > 0)
                myListView.ItemsSource = result;
            else
                myListView.ItemsSource = new List<string>() { "Khong tim thay..." };
        }



        private void mySearchBar_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(e.NewTextValue.ToString()))
                myListView.ItemsSource = source; // return default
            else
            {
                string searchText = mySearchBar.Text.ToLower();
                IEnumerable<string> result = source.Where(x => x.ToLower().Contains(searchText));
                if (result.Count() > 0)
                    myListView.ItemsSource = result;
                else
                    myListView.ItemsSource = new List<string>() { "Not found" };
            }
        }

        private async void btnScan_Clicked(object sender, EventArgs e)
        {
            try
            {
                IQrScanningService scanner = DependencyService.Get<IQrScanningService>();
                var result = await scanner.ScanAsync();
                if (result != null)
                {
                    txtBarcode.Text = result;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

       

        private void btnNew_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Toolbar", "New button", "OK");
        }
    }
}
