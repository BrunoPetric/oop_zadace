using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media.Imaging;

namespace zadaca5
{
    public static class WetherUtilities
    {
        public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dateTime = dateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dateTime;
        }
        public static BitmapImage getBitMap(string icon)
        {
            string fullFilePath = "https://openweathermap.org/img/w/" + icon + ".png";
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(fullFilePath, UriKind.Absolute);
            bitmap.EndInit();
            return bitmap;
        }
    }
}
