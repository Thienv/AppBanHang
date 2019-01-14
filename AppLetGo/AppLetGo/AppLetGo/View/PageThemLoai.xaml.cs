using AppLetGo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppLetGo.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageThemLoai : ContentPage
    {
        public PageThemLoai()
        {
            InitializeComponent();
        }

        private void Txtid_TextChanged(object sender, TextChangedEventArgs e)
        {
            //var vm = BindingContext as LoaiHoaViewModel;
            //vm.ID.
        }

        private void Button_Clicked(object sender, EventArgs e)
        {

        }
    }
}