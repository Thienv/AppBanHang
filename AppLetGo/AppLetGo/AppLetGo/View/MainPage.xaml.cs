using System;
using System.Collections.Generic;
using System.Linq;
using AppLetGo.API;
using AppLetGo.Service;
using AppLetGo.View;
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
       
        private void btnNew_Clicked(object sender, EventArgs e)
        {
            PageThemHang p = new PageThemHang();
            Navigation.PushAsync(p);
            p.vm = (BindingContext as LoaiHoaViewModel).HoaList;
        }

        private void Thanhtoan_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PageThemLoai());
        }

        //private void btnThanhtoan_Clicked(object sender, EventArgs e)
        //{
        //    //Navigation.PushAsync(new PageThanhToan());

        //    Device.BeginInvokeOnMainThread(async () => {
        //        var Items = await databaseservice.RefreshDataAsync();
        //    });
        //}


        private async void BtnScan_Clicked(object sender, EventArgs e)
        {
            try
            {
                //var scanner = DependencyService.Get<IQrScanningService1>();
                //var result = await scanner.ScanAsync();
                //if (result != null)
                //{
                //    mySearchBar.Text = result;
                //}
                var scanner = DependencyService.Get<IQrScanningService1>();
                var scanResult = await scanner.ScanAsync();
                if (scanResult != null)
                { mySearchBar.Text = scanResult; }
                else { mySearchBar.Text = null; }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        //private async void Button_Clicked(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        var scanner = DependencyService.Get<IQrScanningService1>();               
        //        var scanResult = await scanner.ScanAsync();
        //        if (scanResult != null)
        //            { mySearchBar.Text=  scanResult; }
        //        else
        //            { mySearchBar.Text = ""; }
        //    }
        //    catch (Exception ex)
        //    {

        //        throw;
        //    }
        //}

       
    }
}
