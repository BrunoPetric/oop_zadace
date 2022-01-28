using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
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

namespace zadaca5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            printData("osijek");
        }
        public void printData(string city)
        {

            using (WebClient web = new WebClient())
            {
                string url = string.Format($"http://api.openweathermap.org/data/2.5/weather?q={city}&appid=4c11edcd1fd895eb8e55e2e57be65222&units=metric");
                var json = web.DownloadString(url);

                var tmp = System.Text.Json.JsonSerializer.Deserialize<WeatherInfo>(json);
                //WeatherInfo.forecast test = JsonConvert.DeserializeObject<WeatherInfo.forecast>(json);
                //Label1.Text = $"{tmp.coord.lat}";

                string url2 = string.Format($"https://api.openweathermap.org/data/2.5/onecall?lat={tmp.coord.lat}&lon={tmp.coord.lon}&exclude=minutely,hourly&cnt=4&appid=4c11edcd1fd895eb8e55e2e57be65222&units=metric&lang=hr");
                var jsonforecast = web.DownloadString(url2);
                var forecast = JsonConvert.DeserializeObject<WeatherForecast>(jsonforecast);


                string url3 = string.Format($"https://api.openweathermap.org/data/2.5/forecast?q={city}&appid=4c11edcd1fd895eb8e55e2e57be65222&units=metric&lang=hr&cnt=8");
                var jsonDanas = web.DownloadString(url3);
                var danas = JsonConvert.DeserializeObject<todayForecast>(jsonDanas);

                var culture = new System.Globalization.CultureInfo("hr-HR");
                //Label1.Text = $"{forecast.current.temp}";

                Title1.Text = $"  danas";
                Title2.Text = $"  sutra";
                Title3.Text = $"  {culture.DateTimeFormat.GetDayName(WetherUtilities.UnixTimeStampToDateTime(forecast.daily[2].dt).DayOfWeek)}";
                Title4.Text = $"  {culture.DateTimeFormat.GetDayName(WetherUtilities.UnixTimeStampToDateTime(forecast.daily[3].dt).DayOfWeek)}";
                Title5.Text = $"  {culture.DateTimeFormat.GetDayName(WetherUtilities.UnixTimeStampToDateTime(forecast.daily[4].dt).DayOfWeek)}";
                Title6.Text = $"  {culture.DateTimeFormat.GetDayName(WetherUtilities.UnixTimeStampToDateTime(forecast.daily[5].dt).DayOfWeek)}";
                Title7.Text = $"  {culture.DateTimeFormat.GetDayName(WetherUtilities.UnixTimeStampToDateTime(forecast.daily[6].dt).DayOfWeek)}";
                Trenutna.Text = $"   Trenutacna prognoza za grad {city}: ";
                posatima.Text = "  Vremenska prognoza za danas po satima: ";

                icon1.Source = WetherUtilities.getBitMap(forecast.daily[0].weather[0].icon);
                icon2.Source = WetherUtilities.getBitMap(forecast.daily[1].weather[0].icon);
                icon3.Source = WetherUtilities.getBitMap(forecast.daily[2].weather[0].icon);
                icon4.Source = WetherUtilities.getBitMap(forecast.daily[3].weather[0].icon);
                icon5.Source = WetherUtilities.getBitMap(forecast.daily[4].weather[0].icon);
                icon6.Source = WetherUtilities.getBitMap(forecast.daily[5].weather[0].icon);
                icon7.Source = WetherUtilities.getBitMap(forecast.daily[6].weather[0].icon);

                iconTrenutno.Source = WetherUtilities.getBitMap(forecast.current.weather[0].icon);
                iconDanas1.Source = WetherUtilities.getBitMap(danas.list[0].weather[0].icon);
                iconDanas2.Source = WetherUtilities.getBitMap(danas.list[1].weather[0].icon);
                iconDanas3.Source = WetherUtilities.getBitMap(danas.list[2].weather[0].icon);
                iconDanas4.Source = WetherUtilities.getBitMap(danas.list[3].weather[0].icon);
                iconDanas5.Source = WetherUtilities.getBitMap(danas.list[4].weather[0].icon);
                iconDanas6.Source = WetherUtilities.getBitMap(danas.list[5].weather[0].icon);
                iconDanas7.Source = WetherUtilities.getBitMap(danas.list[6].weather[0].icon);
                iconDanas8.Source = WetherUtilities.getBitMap(danas.list[7].weather[0].icon);

                Desc1.Text = $"   {forecast.daily[0].weather[0].description}";
                Desc2.Text = $"   {forecast.daily[1].weather[0].description}";
                Desc3.Text = $"   {forecast.daily[2].weather[0].description}";
                Desc4.Text = $"   {forecast.daily[3].weather[0].description}";
                Desc5.Text = $"   {forecast.daily[4].weather[0].description}";
                Desc6.Text = $"   {forecast.daily[5].weather[0].description}";
                Desc7.Text = $"   {forecast.daily[6].weather[0].description}";

                descTrenutna.Text = $"{forecast.current.weather[0].description}";
                timeDanas1.Text = $"  {DateTime.Parse(danas.list[0].dt_txt).TimeOfDay}";
                timeDanas2.Text = $"  {DateTime.Parse(danas.list[1].dt_txt).TimeOfDay}";
                timeDanas3.Text = $"  {DateTime.Parse(danas.list[2].dt_txt).TimeOfDay}";
                timeDanas4.Text = $"  {DateTime.Parse(danas.list[3].dt_txt).TimeOfDay}";
                timeDanas5.Text = $"  {DateTime.Parse(danas.list[4].dt_txt).TimeOfDay}";
                timeDanas6.Text = $"  {DateTime.Parse(danas.list[5].dt_txt).TimeOfDay}";
                timeDanas7.Text = $"  {DateTime.Parse(danas.list[6].dt_txt).TimeOfDay}";
                timeDanas8.Text = $"  {DateTime.Parse(danas.list[7].dt_txt).TimeOfDay}";

                descDanas1.Text = $"{danas.list[0].weather[0].description}";
                descDanas2.Text = $"{danas.list[1].weather[0].description}";
                descDanas3.Text = $"{danas.list[2].weather[0].description}";
                descDanas4.Text = $"{danas.list[3].weather[0].description}";
                descDanas5.Text = $"{danas.list[4].weather[0].description}";
                descDanas6.Text = $"{danas.list[5].weather[0].description}";
                descDanas7.Text = $"{danas.list[6].weather[0].description}";
                descDanas8.Text = $"{danas.list[7].weather[0].description}";


                Wind1.Text = $"   Brzina vjetra: {forecast.daily[0].wind_speed}m/s";
                Wind2.Text = $"   Brzina vjetra: {forecast.daily[1].wind_speed}m/s";
                Wind3.Text = $"   Brzina vjetra: {forecast.daily[2].wind_speed}m/s";
                Wind4.Text = $"   Brzina vjetra: {forecast.daily[3].wind_speed}m/s";
                Wind5.Text = $"   Brzina vjetra: {forecast.daily[4].wind_speed}m/s";
                Wind6.Text = $"   Brzina vjetra: {forecast.daily[5].wind_speed}m/s";
                Wind7.Text = $"   Brzina vjetra: {forecast.daily[6].wind_speed}m/s";
                windTrenutna.Text = $"Brzina vjetra: {forecast.current.wind_speed}m/s";
                windDanas1.Text = $"Vjetar : {danas.list[0].wind.speed}m/s";
                windDanas2.Text = $"Vjetar : {danas.list[1].wind.speed}m/s";
                windDanas3.Text = $"Vjetar : {danas.list[2].wind.speed}m/s";
                windDanas4.Text = $"Vjetar : {danas.list[3].wind.speed}m/s";
                windDanas5.Text = $"Vjetar : {danas.list[4].wind.speed}m/s";
                windDanas6.Text = $"Vjetar : {danas.list[5].wind.speed}m/s";
                windDanas7.Text = $"Vjetar : {danas.list[6].wind.speed}m/s";
                windDanas8.Text = $"Vjetar : {danas.list[7].wind.speed}m/s";

                Border1.Visibility = Visibility.Visible;
                Border2.Visibility = Visibility.Visible;
                Border3.Visibility = Visibility.Visible;
                Border4.Visibility = Visibility.Visible;
                Border5.Visibility = Visibility.Visible;
                Border6.Visibility = Visibility.Visible;
                Border7.Visibility = Visibility.Visible;
                Border8.Visibility = Visibility.Visible;
                Border9.Visibility = Visibility.Visible;
                Border10.Visibility = Visibility.Visible;

                Temp1.Text = $"   Temperatura: {Convert.ToInt32(forecast.daily[0].temp.max) }°C | {Convert.ToInt32(forecast.daily[0].temp.min) }°C";
                Temp2.Text = $"   Temperatura: {Convert.ToInt32(forecast.daily[1].temp.max) }°C | {Convert.ToInt32(forecast.daily[1].temp.min) }°C";
                Temp3.Text = $"   Temperatura: {Convert.ToInt32(forecast.daily[2].temp.max) }°C | {Convert.ToInt32(forecast.daily[2].temp.min) }°C";
                Temp4.Text = $"   Temperatura: {Convert.ToInt32(forecast.daily[3].temp.max) }°C | {Convert.ToInt32(forecast.daily[3].temp.min) }°C";
                Temp5.Text = $"   Temperatura: {Convert.ToInt32(forecast.daily[4].temp.max) }°C | {Convert.ToInt32(forecast.daily[4].temp.min) }°C";
                Temp6.Text = $"   Temperatura: {Convert.ToInt32(forecast.daily[5].temp.max) }°C | {Convert.ToInt32(forecast.daily[5].temp.min) }°C";
                Temp7.Text = $"   Temperatura: {Convert.ToInt32(forecast.daily[6].temp.max) }°C | {Convert.ToInt32(forecast.daily[6].temp.min) }°C";
                tempTranutna.Text = $"Temperatura: {Convert.ToInt32(forecast.current.temp)}°C";
                tempDanas1.Text = $"Temperatura: {Convert.ToInt32(danas.list[0].main.temp)}°C";
                tempDanas2.Text = $"Temperatura: {Convert.ToInt32(danas.list[1].main.temp)}°C";
                tempDanas3.Text = $"Temperatura: {Convert.ToInt32(danas.list[2].main.temp)}°C";
                tempDanas4.Text = $"Temperatura: {Convert.ToInt32(danas.list[3].main.temp)}°C";
                tempDanas5.Text = $"Temperatura: {Convert.ToInt32(danas.list[4].main.temp)}°C";
                tempDanas6.Text = $"Temperatura: {Convert.ToInt32(danas.list[5].main.temp)}°C";
                tempDanas7.Text = $"Temperatura: {Convert.ToInt32(danas.list[6].main.temp)}°C";
                tempDanas8.Text = $"Temperatura: {Convert.ToInt32(danas.list[7].main.temp)}°C";

                Hum1.Text = $"   Vlaznost zraka: {forecast.daily[0].humidity}%";
                Hum2.Text = $"   Vlaznost zraka: {forecast.daily[1].humidity}%";
                Hum3.Text = $"   Vlaznost zraka: {forecast.daily[2].humidity}%";
                Hum4.Text = $"   Vlaznost zraka: {forecast.daily[3].humidity}%";
                Hum5.Text = $"   Vlaznost zraka: {forecast.daily[4].humidity}%";
                Hum6.Text = $"   Vlaznost zraka: {forecast.daily[5].humidity}%";
                Hum7.Text = $"   Vlaznost zraka: {forecast.daily[6].humidity}%";
                humTrenutna.Text = $"Vlaznost zraka: {forecast.current.humidity}%";
                humDanas1.Text = $"Vlaznost: {danas.list[0].main.humidity}%";
                humDanas2.Text = $"Vlaznost: {danas.list[1].main.humidity}%";
                humDanas3.Text = $"Vlaznost: {danas.list[2].main.humidity}%";
                humDanas4.Text = $"Vlaznost: {danas.list[3].main.humidity}%";
                humDanas5.Text = $"Vlaznost: {danas.list[4].main.humidity}%";
                humDanas6.Text = $"Vlaznost: {danas.list[5].main.humidity}%";
                humDanas7.Text = $"Vlaznost: {danas.list[6].main.humidity}%";
                humDanas8.Text = $"Vlaznost: {danas.list[7].main.humidity}%";
            }
        }
        private void GetCurrentWeather(object sender, RoutedEventArgs e)
        {

            string city = CityInput.Text;
            printData(city);
            //Label1.Text = $"{ culture.DateTimeFormat.GetDayName(WetherUtilities.UnixTimeStampToDateTime(1643450400).DayOfWeek)}";
        }
    }
}
