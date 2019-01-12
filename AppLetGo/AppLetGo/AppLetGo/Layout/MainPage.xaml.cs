using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppLetGo.API;
using AppLetGo.Layout;
using AppLetGo.Service;
using AppLetGo.ViewModels;
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
           // var navigationPage = new NavigationPage(new ReportPage());
            //navigationPage.Icon = "schedule.png";
            On<Xamarin.Forms.PlatformConfiguration.Android>().SetToolbarPlacement(ToolbarPlacement.Bottom);
            
            

        }


        private void mySearchBar_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            var vm = BindingContext as LoaiHoaViewModel;
            MyListView.BeginRefresh();
            if (string.IsNullOrWhiteSpace(e.NewTextValue))
                MyListView.ItemsSource = vm.HoaTheoLoai;
            else
                MyListView.ItemsSource = vm.HoaTheoLoai.Where(i => i.Tenhoa.ToLower().Contains(e.NewTextValue.ToLower()));
            MyListView.EndRefresh();
        }

        

       

        

        //private async void btnQRCode_Clicked(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        IQrScanningService scanner = DependencyService.Get<IQrScanningService>();
        //        var result = await scanner.ScanAsync();
        //        if (result != null)
        //        {
        //            //txtBarcode.Text = result;
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        throw;
        //    }

        //}
        private void btnNew_Clicked(object sender, EventArgs e)
        {

            Navigation.PushAsync(new PageThemHang());
            
        }
        private void btnThanhtoan_Clicked(object sender, EventArgs e)
        {
            //Navigation.PushAsync(new PageThanhToan());

            Device.BeginInvokeOnMainThread(async () => {
                var Items = await databaseservice.RefreshDataAsync();
            });
        }
    }
}
