using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace Laba_1
{
    class Date
    {
        private int day;
        private int month;
        private int year;
        public int Day { get { return day; } }
        public int Month { get { return month; } }
        public int Year { get { return year; } }
        public Date(int day,int month, int year)
        {
            this.day = day;
            this.month = month;
            this.year = year;
        }
       
        public int GetDay()
        {
            return day;
        }
      
        public int GetMonth()
        {
            return month;
        }
      
        public int GetYear()
        {
            return year;
        }
        public void serialize()
        {
            JsonSerializer serializer = new JsonSerializer();
            using (StreamWriter sw = new StreamWriter(@"C:\Education\ОП\Laba_1\date1.json"))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {

                serializer.Serialize(writer, this); 
            }
        }
        public void serialize2()
        {
            JsonSerializer serializer = new JsonSerializer();
            using (StreamWriter sw = new StreamWriter(@"C:\Education\ОП\Laba_1\date2.json"))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {

                serializer.Serialize(writer, this);
            }
        }
        public static Date DeSerialize()
        {
            Date p = JsonConvert.DeserializeObject<Date>(File.ReadAllText(@"C:\Education\ОП\Laba_1\date1.json"));
            return p;
        }
        public static Date DeSerialize2()
        {
            Date p = JsonConvert.DeserializeObject<Date>(File.ReadAllText(@"C:\Education\ОП\Laba_1\date2.json"));
            return p;
        }
    }
}
