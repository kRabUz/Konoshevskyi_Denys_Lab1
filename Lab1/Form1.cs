using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;


namespace Laba_1
{
    public partial class Form1 : Form
    {
        int n = 0;
        DateTime Date1, Date2;
        bool truedate1, truedate2;
        public Form1()
        {
            InitializeComponent();
        }

        private void Info1_Click(object sender, EventArgs e)
        {
            Date date1;
            try
            {
                date1 = new Date(Convert.ToInt32(Day1.Text), Convert.ToInt32(Month1.Text), Convert.ToInt32(Year1.Text));
                truedate1 = true;
                int day = date1.GetDay();
                int month = date1.GetMonth();
                int year = date1.GetYear();
                if (month == 1 || month == 3 || month == 5
                    || month == 7 || month == 8 || month == 10
                    || month == 12) // я перепробував різні варіанти перевірки на існування, також шукав різні варіанти в інтернеті, але так і не вийшло нічого
                {
                    if (day < 1 || day > 31)
                    {
                        MessageBox.Show("Першої дати не існує. Введіть іншу дату", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        truedate1 = false;
                    }
                }
                else if (month == 4 || month == 6 ||
                  month == 9 || month == 11)
                {
                    if (day < 1 || day > 30)
                    {
                        MessageBox.Show("Першої дати не існує. Введіть іншу дату", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        truedate1 = false;
                    }
                }
                else if (month == 2)
                {
                    if (year % 4 == 0)
                    {
                        if (day < 1 || day > 29)
                        {
                            MessageBox.Show("Першої дати не існує. Введіть іншу дату", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            truedate1 = false;
                        }
                    }
                    else
                    {
                        if (day < 1 || day > 28)
                        {
                            MessageBox.Show("Першої дати не існує. Введіть іншу дату", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            truedate1 = false;
                        }
                    }
                }
                else if (month < 1 || month > 12)
                {
                    MessageBox.Show("Першої дати не існує. Введіть іншу дату", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    truedate1 = false;
                }
                if (truedate1)
                {
                    Date1 = new DateTime(year, month, day);
                    DayOfWeek1.Text = Convert.ToString(Date1.DayOfWeek);
                }
            
            }
            catch
            {
                truedate1 = false;
                MessageBox.Show("Неправильно введено першу дату. Перевірте введення", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

}
        private void Info2_Click(object sender, EventArgs e)
        {

            Date date2;
            try
            {
                date2 = new Date(Convert.ToInt32(Day2.Text), Convert.ToInt32(Month2.Text), Convert.ToInt32(Year2.Text));
                truedate2 = true;
                int day = date2.GetDay();
                int month = date2.GetMonth();
                int year = date2.GetYear();
                if (month == 1 || month == 3 || month == 5
                    || month == 7 || month == 8 || month == 10
                    || month == 12) // я перепробував різні варіанти перевірки на існування, також шукав різні варіанти в інтернеті, але так і не вийшло нічого
                {
                    if (day < 1 || day > 31)
                    {
                        MessageBox.Show("Другої дати не існує. Введіть іншу дату", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        truedate2 = false;
                    }
                }
                else if (month == 4 || month == 6 ||
                  month == 9 || month == 11)
                {
                    if (day < 1 || day > 30)
                    {
                        MessageBox.Show("Другої дати не існує. Введіть іншу дату", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        truedate2 = false;
                    }
                }
                else if (month == 2)
                {
                    if (year % 4 == 0)
                    {
                        if (day < 1 || day > 29)
                        {
                            MessageBox.Show("Другої дати не існує. Введіть іншу дату", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            truedate2 = false;
                        }
                    }
                    else
                    {
                        if (day < 1 || day > 28)
                        {
                            MessageBox.Show("Другої дати не існує. Введіть іншу дату", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            truedate2 = false;
                        }
                    }
                }
                else if (month < 1 || month > 12)
                {
                    MessageBox.Show("Другої дати не існує. Введіть іншу дату", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    truedate2 = false;
                }
                if (truedate2)
                {
                    Date2 = new DateTime(year, month, day);
                    DayOfWeek2.Text = Convert.ToString(Date2.DayOfWeek);
                }
            }
            catch
            {
                truedate2 = false;
                MessageBox.Show("Неправильно введено другу дату. Перевірте введення", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void Difference()
        {
            Date date1 = new Date(Convert.ToInt32(Day1.Text), Convert.ToInt32(Month1.Text), Convert.ToInt32(Year1.Text));
            Date date2 = new Date(Convert.ToInt32(Day2.Text), Convert.ToInt32(Month2.Text), Convert.ToInt32(Year2.Text));
            int D1 = date1.GetDay();
            int M1 = date1.GetMonth();
            int Y1 = date1.GetYear();
            int D2 = date2.GetDay();
            int M2 = date2.GetMonth();
            int Y2 = date2.GetYear();
            int day1, month1, year1, day2, month2, year2;
            DateTime Dat1 = new DateTime(Y1, M1, D1);
            DateTime Dat2 = new DateTime(Y2, M2, D2);
            if(Dat1 > Dat2)
            {
                day1 = date2.GetDay();
                month1 = date2.GetMonth();
                year1 = date2.GetYear();
                day2 = date1.GetDay();
                month2 = date1.GetMonth();
                year2 = date1.GetYear();
            } else
            {
                day1 = date1.GetDay();
                month1 = date1.GetMonth();
                year1 = date1.GetYear();
                day2 = date2.GetDay();
                month2 = date2.GetMonth();
                year2 = date2.GetYear();
            }
            int year = year2 - year1;
            if (month2<month1)
            {
                --year;
            } else if (month2 == month1)
            {
                if (day2 < day1)
                {
                    --year;
                }
            }
            int month = 12+month2 - month1;
            if (month > 12) month -= 12;
            if (day2 < day1)
            {
                --month;
            }
            DateTime Dat3 = new DateTime(year2, month2-1, 1);
            DateTime Dat4 = new DateTime(year2, month2, 1);
            var days = (Dat4-Dat3).Duration();
            int daysE;
            if (day2 < day1)
            {
                daysE = days.Days - day1 + day2;
            }
            else daysE = day2 - day1;  
            YearD.Text = Convert.ToString(year);
            MonthD1.Text = Convert.ToString(month);
            MonthD2.Text = Convert.ToString(month+year*12);
            WeekD1.Text = Convert.ToString(daysE/ 7);
            WeekD2.Text = Convert.ToString(daysE/ 7);
            DayD1.Text = Convert.ToString((daysE) % 7);
            DayD2.Text = Convert.ToString((daysE) % 7);
        }


        private void DateDifference_Click(object sender, EventArgs e)
        {
            Info1_Click(sender,e);
            Info2_Click(sender,e);
            if (truedate1 && truedate2) 
            {
                    var DateDifference = (Date2 - Date1).Duration();
                    Difference();
                    WeekD3.Text = Convert.ToString((DateDifference.Days) / 7);
                    DayD3.Text = Convert.ToString((DateDifference.Days) % 7);
                    DayD4.Text = Convert.ToString(DateDifference.Days);
            }
        }
        private void toJson_Click(object sender, EventArgs e)
        {
            Info1_Click(sender, e);
            Info2_Click(sender, e);
            if (truedate1 && truedate2)
            {
                    Date p1 = new Date(Convert.ToInt32(Day1.Text), Convert.ToInt32(Month1.Text), Convert.ToInt32(Year1.Text));
                    p1.serialize();
                    Date p2 = new Date(Convert.ToInt32(Day2.Text), Convert.ToInt32(Month2.Text), Convert.ToInt32(Year2.Text));
                    p2.serialize2();

            }
        }
        private void fromJson_Click(object sender, EventArgs e)
        {
            Date p1 = Date.DeSerialize();
            Day1.Text = Convert.ToString(p1.Day);
            Month1.Text = Convert.ToString(p1.Month);
            Year1.Text = Convert.ToString(p1.Year);
            Date p2 = Date.DeSerialize2();
            Day2.Text = Convert.ToString(p2.Day);
            Month2.Text = Convert.ToString(p2.Month);
            Year2.Text = Convert.ToString(p2.Year);

        }
        private void Cleaner_Click(object sender, EventArgs e)
        {
            Day1.Clear();
            Day2.Clear();
            Month1.Clear();
            Month2.Clear();
            Year1.Clear();
            Year2.Clear();
            DayOfWeek1.Clear();
            DayOfWeek2.Clear();
            DayD1.Clear();
            DayD2.Clear();
            DayD3.Clear();
            DayD4.Clear();
            MonthD1.Clear();
            MonthD2.Clear();
            WeekD1.Clear();
            WeekD2.Clear();
            WeekD3.Clear();
            YearD.Clear();
        }
    }
}