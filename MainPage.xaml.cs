using MVVM_15520419.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MVVM_15520419
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void cmdThemloai_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddFlowerTypePage());
        }

        private void cmdThemHoa_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddFlowerPage());
        }

        private void cmdDSHoa_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new FlowersPage());
        }

        private void cmdTabbedPage_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new FlowerTabbedPage());
        }

        private void cmdCarrouselPage_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new FlowerCarouselPage());
        }

        private void cmdMasterDetailPage_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new FlowerTypeAndFlowerMasterDetailPage());
        }
    }
}
