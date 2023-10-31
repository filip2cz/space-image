using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Xml.Linq;

namespace space_image
{
    public partial class MainPage : ContentPage, INotifyPropertyChanged
    {
        private string _apiJsonOutput;
        public string ApiJsonOutput
        {
            get
            {
                return _apiJsonOutput;
            }
            set
            {
                _apiJsonOutput = value;
                OnPropertyChanged(nameof(ApiJsonOutput));
            }
        }
        private bool _apiSuccefull;
        public bool ApiSuccefull
        {
            get
            {
                return _apiSuccefull;
            }
            set
            {
                _apiSuccefull = value;
                OnPropertyChanged(nameof(ApiSuccefull));
            }
        }
        private string _imageDateString;
        public string ImageDateString
        {
            get
            {
                return _imageDateString;
            }
            set
            {
                _imageDateString = value;
                OnPropertyChanged(nameof(ImageDateString));
            }
        }
        private string _imageUrl;
        public string ImageUrl
        {
            get
            {
                return _imageUrl;
            }
            set
            {
                _imageUrl = value;
                OnPropertyChanged(nameof(ImageUrl));
            }
        }
        public MainPage()
        {
            InitializeComponent();
            GetImage();
            imageOfTheDay.Source = ImageUrl;
            // https://stackoverflow.com/questions/38910715/show-image-from-url-with-xamarin-forms
            imageDate.Text = $"{ImageDateString}";

        }
        public async Task GetImage()
        {
            Debug.WriteLine("GetImage() started");

            // get Image of the day
            string APIUrl = "https://api.nasa.gov/planetary/apod?api_key=DEMO_KEY";
            string response = string.Empty;

            int i = 0;
            while (i < 3)
            {
                using (HttpClient client = new HttpClient())
                {
                    try
                    {
                        response = client.GetStringAsync(APIUrl).Result;
                        ApiJsonOutput = response;
                        ApiSuccefull = true;
                        i = 3;
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine("API request failed");
                        Debug.WriteLine(ex);
                        i++;
                        if (i < 3)
                        {
                            Debug.WriteLine("Trying API again");
                        }
                        ApiSuccefull = false;
                    }
                }
            }

            if (ApiSuccefull)
            {
                Debug.WriteLine("GetImage() finished");
                Debug.WriteLine(response);

                JObject jsonObj = JsonConvert.DeserializeObject<JObject>(response);
                string ImageDateStringRaw = jsonObj["date"].Value<string>();
                ImageDateString = $"Date: {ImageDateStringRaw}";
                ImageUrl = jsonObj["url"].Value<string>();
            }
            else
            {
                Debug.WriteLine("GetImage() ended with error:");
                Debug.WriteLine("all requests failed");
                ImageDateString = "Loading failed";
            }
        }
    }
}
