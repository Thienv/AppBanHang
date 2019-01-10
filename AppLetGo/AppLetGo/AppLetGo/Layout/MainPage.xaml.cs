using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            
        };
        public MainPage()
        {
            InitializeComponent();
            var navigationPage = new NavigationPage(new ReportPage());
            navigationPage.Icon = "schedule.png";
            On<Xamarin.Forms.PlatformConfiguration.Android>().SetToolbarPlacement(ToolbarPlacement.Bottom);
            
        }

        private void mySearchBar_SearchButtonPressed(object sender, EventArgs e)
        {
            
            string searchText = mySearchBar.Text.ToLower();
            IEnumerable<string> result = source.Where(x => x.ToLower().Contains(searchText));
            //if (result.Count() > 0)
            //    myListView.ItemsSource = result;
            //else
            //    myListView.ItemsSource = new List<string>() { "Khong tim thay..." };
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

            Navigation.PushAsync(new PageThemHang());
        }

        //private async void btnQRCode_Clicked(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        IQrScanningService scanner = DependencyService.Get<IQrScanningService>();
        //        var result = await scanner.ScanAsync();
        //        if (result != null)
        //        {
        //            txtBarcode.Text = result;
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        throw;
        //    }

        //}

        private void btnThanhtoan_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PageThanhToan());
        }
    }
}
