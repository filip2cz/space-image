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
        private string _imageDescriptionString;
        public string ImageDescriptionString
        {
            get
            {
                return _imageDescriptionString;
            }
            set
            {
                _imageDescriptionString = value;
                OnPropertyChanged(nameof(ImageDescriptionString));
            }
        }
        private string _inputYear;
        public string InputYear
        {
            get
            {
                return _inputYear;
            }
            set
            {
                _inputYear = value;
                OnPropertyChanged(nameof(InputYear));
            }
        }
        private string _inputMonth;
        public string InputMonth
        {
            get
            {
                return _inputMonth;
            }
            set
            {
                _inputMonth = value;
                OnPropertyChanged(nameof(InputMonth));
            }
        }
        private string _inputDay;
        public string InputDay
        {
            get
            {
                return _inputDay;
            }
            set
            {
                _inputDay = value;
                OnPropertyChanged(nameof(InputDay));
            }
        }
        private string _apiKey;
        public string ApiKey
        {
            get
            {
                return _apiKey;
            }
            set
            {
                _apiKey = value;
                OnPropertyChanged(nameof(ApiKey));
            }
        }
        public MainPage()
        {
            InitializeComponent();

            Button refreshButton = new Button
            {
                Text = "Data refresh"
            };

            DatePicker datePicker = new DatePicker
            {
                MinimumDate = new DateTime(1995, 5, 16),
            };

            Debug.WriteLine(datePicker.Date);

            DateTime selectedDate = datePicker.Date;

            string year = selectedDate.Year.ToString();
            string month = selectedDate.Month.ToString().PadLeft(2, '0');
            string day = selectedDate.Day.ToString().PadLeft(2, '0');

            Debug.WriteLine("-----------------------");
            Debug.WriteLine(year);
            Debug.WriteLine(month);
            Debug.WriteLine(day);
            Debug.WriteLine("-----------------------");

            InputYear = year;
            InputMonth = month;
            InputDay = day;

            LoadData();
            imageOfTheDay.Source = ImageUrl;
            // https://stackoverflow.com/questions/38910715/show-image-from-url-with-xamarin-forms
            imageDate.Text = $"{ImageDateString}";

        }
        public async Task GetImage()
        {
            Debug.WriteLine("GetImage() started");

            // get Image of the day
            ApiKey = "DEMO_KEY";
            string APIUrl = $"https://api.nasa.gov/planetary/apod?api_key={ApiKey}&date={InputYear}-{InputMonth}-{InputDay}";
            string response = string.Empty;

            int i = 0;
            while (i < 3)
            {
                using (HttpClient client = new HttpClient())
                {
                    try
                    {
                        response = await client.GetStringAsync(APIUrl);
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
                ImageDescriptionString = jsonObj["explanation"].Value<string>();
            }
            else
            {
                Debug.WriteLine("GetImage() ended with error:");
                Debug.WriteLine("all requests failed");
                ImageDateString = "Loading failed";
            }
        }
        /*
        private async void RefreshButton_Clicked(object sender, EventArgs e)
        {
            LoadData();
        }
        */
        private void DatePicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            DateTime selectedDate = e.NewDate;
            DateTime minDate = new DateTime(1995, 5, 16);
            DateTime maxDate = DateTime.Now;

            if (selectedDate < minDate || selectedDate > maxDate)
            {
                DisplayAlert("Error", "The selected date must be between May 16, 1995 and today.", "OK");

                datePicker.Date = maxDate;
            }
            else
            {
                LoadData();
            }
        }
        public async Task LoadData()
        {
            DateTime selectedDate = datePicker.Date;

            string year = selectedDate.Year.ToString();
            string month = selectedDate.Month.ToString().PadLeft(2, '0');
            string day = selectedDate.Day.ToString().PadLeft(2, '0');

            Debug.WriteLine("-----------------------");
            Debug.WriteLine(year);
            Debug.WriteLine(month);
            Debug.WriteLine(day);
            Debug.WriteLine("-----------------------");

            InputYear = year;
            InputMonth = month;
            InputDay = day;

            GetImage();
            imageOfTheDay.Source = ImageUrl;
            // https://stackoverflow.com/questions/38910715/show-image-from-url-with-xamarin-forms
            imageDate.Text = $"{ImageDateString}";
            imageDescription.Text = ImageDescriptionString;
        }

    }
}
