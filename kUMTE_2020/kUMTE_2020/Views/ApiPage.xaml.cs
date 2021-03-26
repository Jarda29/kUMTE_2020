using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using kUMTE_2020.Models.Covid;
using Newtonsoft.Json;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace kUMTE_2020.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ApiPage : ContentPage
    {
        public ApiPage()
        {
            InitializeComponent();
        }

        public static async Task RefreshDataAsync()
        {
            var uri = new Uri(Covid19JsonResult.Url);
            var myClient = new HttpClient();

            var response = await myClient.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var item = JsonConvert.DeserializeObject<Covid19JsonResult>(content);
            }
        }

        private void ButtonGetData_OnClicked(object sender, EventArgs e)
        {
            RefreshDataAsync();

            if (DeviceInfo.Platform.Equals(DevicePlatform.Android))
            {

            }
            else if (DeviceInfo.Platform.Equals(DevicePlatform.iOS))
            {
                
            }
            {

            }
        }
    }
}