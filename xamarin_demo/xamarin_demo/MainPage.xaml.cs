using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

using System.Net.Http;

namespace xamarin_demo
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            this.BtnPost.Clicked += BtnPost_Clicked;
        }

        private async void BtnPost_Clicked(object sender, EventArgs e)
        {
            var res = await Api();
            var msg = "";
            foreach (var s in res)
                msg += s;

            this.LblResponse.Text = msg;
        }

        private async Task<String> Api()
        {
            ; const string url = @"http://zipcloud.ibsnet.co.jp/api/search?zipcode=7830060";
            var hc = new HttpClient();
            var res = new HttpResponseMessage();
            res = await hc.GetAsync(url);
            var result = await res.Content.ReadAsStringAsync();
            //return await hc.GetStringAsync(url);
            return result;
        }
    }
}
