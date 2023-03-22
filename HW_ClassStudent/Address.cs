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
            Country = country;
            City = city;
            Street = street;
            HouseNum = houseNum;
        }

        public string Country
        {
            get { return country; }
            set { country = (countryList.Contains(value)) ? value : "Ukraine"; }
        }

        public string City
        {
            get { return city; }
            set { city = (value.Length >= 3) ? value : "Odessa"; }
        }

        public string Street
        {
            get { return street; }
            set { street = (value.Length >= 3) ? value : "(not indicated)"; }
        }

        public int HouseNum
        {
            get { return houseNum; }
            set { houseNum = (value > 0 && value <= 1000) ? value : 0; }
        }

        public override string ToString() 
        {
            return (city + ", " + country + ", st." + street + " " + houseNum);
        }
    }
}
