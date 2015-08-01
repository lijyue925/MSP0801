using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Newtonsoft.Json;

//空白頁項目範本收錄在 http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace MSP0801
{
    /// <summary>
    /// 可以在本身使用或巡覽至框架內的空白頁面。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private BMIData data;
        private People people;
        
        public MainPage()
        {
            this.InitializeComponent();
            data = new BMIData();
            people = BuildData();
            //this.DataContext = people;
            
        }

        private async void MainPage_OnLoaded(object sender, RoutedEventArgs e)
        {
            progressringGrid.Visibility = Visibility.Visible;
            ring.IsActive = true;

            HttpClient client = new HttpClient();
            string source = await client.GetStringAsync("http://data.ntpc.gov.tw/od/data/api/A886239B-D7C1-4309-870F-E0F64D088025?$format=json");
            Attractions attractionsdata = new Attractions();
            attractionsdata.Items = JsonConvert.DeserializeObject<ObservableCollection<Attraction>>(source);
            // 因為資料中所有的圖片都是空的, 所以故意加上一張圖片
            attractionsdata.Items[0].Picture1 = "https://upload.wikimedia.org/wikipedia/commons/3/36/Mount_Yu_Shan_-_Taiwan.jpg";

            ring.IsActive = false;
            progressringGrid.Visibility = Visibility.Collapsed;

            this.DataContext = attractionsdata;
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            data.Result = data.Weight/Math.Pow(data.Height, 2);
            await TextFileHelper.SaveTextFileAsync("data", JsonConvert.SerializeObject(data));
            var store = await TextFileHelper.LoadTextFileAsync("data");
            MessageDialog dialog = new MessageDialog(store);
            await dialog.ShowAsync();
        }

        private People BuildData()
        {
            People people = new People();

            // 比較囉嗦的寫法
            Person person = new Person();
            person.Name = "小叮噹";
            person.Address = "台北市忠孝東路一段126號7樓";
            people.Items.Add(person);

            // 比較短的寫法
            people.Items.Add(new Person() { Name = "胖虎", Address = "台北市松江路290號10樓" });
            people.Items.Add(new Person() { Name = "小夫", Address = "台北市信義路三段20號7樓" });
            people.Items.Add(new Person() { Name = "魯夫", Address = "台中市中華路10號10樓" });
            people.Items.Add(new Person() { Name = "喬巴", Address = "台中市市政北七路125號4樓" });

            return people;
        }

       
    }
}
