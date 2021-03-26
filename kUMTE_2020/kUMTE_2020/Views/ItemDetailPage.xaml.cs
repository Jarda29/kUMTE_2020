using kUMTE_2020.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace kUMTE_2020.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}