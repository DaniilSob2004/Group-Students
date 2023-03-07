using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;


namespace HW_Address
{
    public class Address
    {
        private string country;
        private string city;
        private string street;
        private int houseNum;

        private static List<string> countryList = new List<string>();

        // получаем список всех стран для дальнейшей проверки
        private static void InitialCountryList()
        {
            CultureInfo[] cultures = CultureInfo.GetCultures(CultureTypes.SpecificCultures);

            foreach (CultureInfo culture in cultures)
            {
                // CultureInfo.LCID - возвращает идентификатор языка и региональных параметров для текущего объекта CultureInfo.
                RegionInfo region = new RegionInfo(culture.LCID);
                if (!(countryList.Contains(region.EnglishName)))
                {
                    countryList.Add(region.EnglishName);
                }
            }
        }

        public Address() : this("Ukraine", "Odessa", "", 0) {}

        public Address(string country, string city, string street, int houseNum)
        {
            InitialCountryList();
            SetCountry(country);
            SetCity(city);
            SetStreet(street);
            SetHouseNum(houseNum);
        }

        public void SetCountry(string country)
        {
            this.country = (countryList.Contains(country)) ? country : "Ukraine";
        }

        public void SetCity(string city)
        {
            this.city = (city.Length >= 3) ? city : "Odessa";
        }

        public void SetStreet(string street)
        {
            this.street = (street.Length >= 3) ? street : "(not indicated)";
        }

        public void SetHouseNum(int houseNum)
        {
            this.houseNum = (houseNum > 0 && houseNum <= 1000) ? houseNum : 0;
        }

        public override string ToString() 
        {
            return (city + ", " + country + ", st." + street + " " + houseNum);
        }
    }
}
