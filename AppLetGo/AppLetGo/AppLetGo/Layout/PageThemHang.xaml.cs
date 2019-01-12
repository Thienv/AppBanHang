using AppLetGo.Models;
using AppLetGo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppLetGo
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageThemHang : ContentPage
    {
        public PageThemHang()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            int a = int.Parse(txtmahang.Text);
            int b = int.Parse(txtmaloaihang.Text);
            string c = txttenhang.Text;
            string d = txthinh.Text;
            string f = txtmota.Text;
            double g = double.Parse(txtgiaban.Text);

            Hoa h = new Hoa { Mahoa = a, Maloai = b, Tenhoa = c, Hinh = d, Mota = f, Gia = g };
            var vm = BindingContext as LoaiHoaViewModel;
            vm.Insert(h);
            DisplayAlert("Alert", "Them hang thanh cong","OK");
        }
    }
}