using System;
using System.Collections.Generic;
using Xamarin.Forms;
using RestSharp;
using Newtonsoft.Json;
using CryptoTracker.Model;

namespace CryptoTracker
{
    public partial class MainPage : ContentPage
    {
        private string key = "FD80ABE9-BC03-45EF-9EEF-52DB651E400E";
        private string baseimageurl = "https://s3.eu-central-1.amazonaws.com/bbxt-static-icons/type-id/png_64/";
        public MainPage()
        {
            InitializeComponent();
            tokenListView.ItemsSource = RetrieveToken();
        }
        private void Refresh_Clicked(object sender, EventArgs e)
        {
            tokenListView.ItemsSource = RetrieveToken();
        }

        private List<Token> RetrieveToken()
        {
            //Token retrieval method
            List<Token> token;
            var client = new RestClient("http://rest.coinapi.io/v1/assets?filter_asset_id=BTC;ETH;DOGE;LTC;KRW;");
            var request = new RestRequest();
            request.AddHeader("X-CoinAPI-Key", key);
            var response = client.Execute(request);
            token = JsonConvert.DeserializeObject<List<Token>>(response.Content);

            //icon_URL
            foreach (var x in token)
            {
                x.icon_url = baseimageurl + x.id_icon.Replace("-", "") + ".png";
            }
            return token;
        }
    }
}