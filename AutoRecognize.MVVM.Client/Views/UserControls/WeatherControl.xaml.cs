using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AutoRecognize.MVVM.Client.Views.UserControls
{
    /// <summary>
    /// WeatherControl.xaml 的交互逻辑
    /// </summary>
    public partial class WeatherControl : UserControl
    {
        public WeatherControl()
        {
            InitializeComponent();
            RefreshData();
        }
        public async Task RefreshData()
        {
            var url = "http://www.sojson.com/open/api/weather/json.shtml?city=上海";
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Add(
              new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = httpClient.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                string result =await response.Content.ReadAsStringAsync();
                this.Dispatcher.Invoke(()=> {
                    textBox.Text = result;
                });
            }
        }
    }
}
