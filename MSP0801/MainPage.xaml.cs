using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

//空白頁項目範本收錄在 http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace MSP0801
{
    /// <summary>
    /// 可以在本身使用或巡覽至框架內的空白頁面。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private BMIData data;
        
        public MainPage()
        {
            this.InitializeComponent();
            data = new BMIData();
            this.DataContext = data;
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            data.Result = data.Weight/Math.Pow(data.Height, 2);
            await TextFileHelper.SaveTextFileAsync("data", data.Result.ToString());
            var store = await TextFileHelper.LoadTextFileAsync("data");
            Height.Text = store;
        }
    }
}
