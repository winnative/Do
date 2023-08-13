using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Diagnostics.Eventing.Reader;
using System.Xaml;
using Newtonsoft.Json;
using System.IO;

namespace MelakifyMind.Behind.MelakifyML
{
    public static class ML
    {
        public static class Convert
        {
            public static Hashtable hashDay = new Hashtable();
            public static Hashtable HashMonth = new Hashtable();
            public static object MLObj { get; set; }
            public static string Seprator { get { return "."; } }

            public static object ScanReminder(string text)
            {
                HashMonth.Clear();
                HashMonth.Add("فروردین", 1);
                HashMonth.Add("اردیبهشت", 2);
                HashMonth.Add("خرداد", 3);
                HashMonth.Add("تیر", 4);
                HashMonth.Add("مرداد", 5);
                HashMonth.Add("شهریور", 6);
                HashMonth.Add("مهر", 7);
                HashMonth.Add("آبان", 8);
                HashMonth.Add("آذر", 9);
                HashMonth.Add("دی", 10);
                HashMonth.Add("بهمن", 11);
                HashMonth.Add("اسفند", 12);

                hashDay.Clear();
                hashDay.Add("یک", 1);
                hashDay.Add("دو", 2);
                hashDay.Add("سه", 3);
                hashDay.Add("چهار", 4);
                hashDay.Add("پنج", 5);
                hashDay.Add("شش", 6);
                hashDay.Add("هفت", 7);
                hashDay.Add("هشت", 8);
                hashDay.Add("نه", 9);
                hashDay.Add("ده", 10);
                hashDay.Add("یازده", 11);
                hashDay.Add("دوازده", 12);
                hashDay.Add("سیزده", 13);
                hashDay.Add("چهارده", 14);
                hashDay.Add("پانزده", 15);
                hashDay.Add("شانزده", 16);
                hashDay.Add("هفده", 17);
                hashDay.Add("هجده", 18);
                hashDay.Add("نوزده", 19);
                hashDay.Add("بیست", 20);
                hashDay.Add("بیست و یک", 21);
                hashDay.Add("بیس و یک", 21);
                hashDay.Add("بیست و دو", 22);
                hashDay.Add("بیس و دو", 22);
                hashDay.Add("بیست و سه", 23);
                hashDay.Add("بیس و سه", 23);
                hashDay.Add("بیست و چهار", 24);
                hashDay.Add("بیس و چهار", 24);
                hashDay.Add("بیست و چار", 24);
                hashDay.Add("بیس و چار", 24);
                hashDay.Add("بیست و پنج", 25);
                hashDay.Add("بیست و شش", 26);
                hashDay.Add("بیست و هفت", 27);
                hashDay.Add("بیست و هشت", 28);
                hashDay.Add("بیست و نه", 29);
                hashDay.Add("سی", 30);
                hashDay.Add("سی و یک", 31);
                hashDay.Add("سی و دو", 32);
                hashDay.Add("سی و سه", 33);
                hashDay.Add("سی و چهار", 34);
                hashDay.Add("سی و چار", 34);
                hashDay.Add("سی و پنج", 35);
                hashDay.Add("سی و شش", 36);
                hashDay.Add("سی و هفت", 37);
                hashDay.Add("سی و هشت", 38);
                hashDay.Add("سی و نه", 39);
                hashDay.Add("چهل", 40);
                hashDay.Add("چهل و یک", 41);
                hashDay.Add("چهل و دو", 42);
                hashDay.Add("چهل و سه", 43);
                hashDay.Add("چهل و چهار", 44);
                hashDay.Add("چهل و پنج", 45);
                hashDay.Add("چهل و شش", 46);
                hashDay.Add("چهل و هفت", 47);
                hashDay.Add("چهل و هشت", 48);
                hashDay.Add("چهل و نه", 49);
                hashDay.Add("پنجاه", 50);
                hashDay.Add("پنجاه و یک", 51);
                hashDay.Add("پنجاه و دو", 52);
                hashDay.Add("پنجاه و سه", 53);
                hashDay.Add("پنجاه و چهار", 54);
                hashDay.Add("پنجاه و پنج", 55);
                hashDay.Add("پنجاه و شش", 56);
                hashDay.Add("پنجاه و هفت", 57);
                hashDay.Add("پنجاه و هشت", 58);
                hashDay.Add("پنجاه و نه", 59);
                hashDay.Add("شصت", 60);
                hashDay.Add("شصت و یک", 61);
                hashDay.Add("شصت و دو", 62);
                hashDay.Add("شصت و سه", 63);
                hashDay.Add("شصت و چهار", 64);
                hashDay.Add("شصت و پنج", 65);
                hashDay.Add("شصت و شش", 66);
                hashDay.Add("شصت و هفت", 67);
                hashDay.Add("شصت و هشت", 68);
                hashDay.Add("شصت و نه", 69);
                hashDay.Add("هفتاد", 70);
                hashDay.Add("هفتاد و یک", 71);
                hashDay.Add("هفتاد و دو", 72);
                hashDay.Add("هفتاد و سه", 73);
                hashDay.Add("هفتاد و چهار", 74);
                hashDay.Add("هفتاد و پنج", 75);
                hashDay.Add("هفتاد و شش", 76);
                hashDay.Add("هفتاد و هفت", 77);
                hashDay.Add("هفتاد و هشت", 78);
                hashDay.Add("هفتاد و نه", 79);
                hashDay.Add("هشتاد", 80);
                hashDay.Add("هشتاد و یک", 81);
                hashDay.Add("هشتاد و دو", 82);
                hashDay.Add("هشتاد و سه", 83);
                hashDay.Add("هشتاد و چهار", 84);
                hashDay.Add("هشتاد و پنچ", 85);
                hashDay.Add("هشتاد و شش", 86);
                hashDay.Add("هشتاد و هفت", 87);
                hashDay.Add("هشتاد و هشت", 88);
                hashDay.Add("هشتاد و نه", 89);
                hashDay.Add("نود", 90);
                hashDay.Add("نود و یک", 91);
                hashDay.Add("نود و دو", 92);
                hashDay.Add("نود و سه", 93);
                hashDay.Add("نود و چهار", 94);
                hashDay.Add("نود و پنج", 95);
                hashDay.Add("نود و شش", 96);
                hashDay.Add("نود و هفت", 97);
                hashDay.Add("نود و هشت", 98);
                hashDay.Add("نود و نه", 99);
                hashDay.Add("صد", 100);
                hashDay.Add("دویست", 200);
                hashDay.Add("سیصد", 300);

                Reminder newReminder = new Reminder();

                if (text != "")
                {
                    if (text.Contains("."))
                    {
                        if (text.Split(".", StringSplitOptions.RemoveEmptyEntries).Length >= 2 && text.Split(".", StringSplitOptions.RemoveEmptyEntries)[1].Trim(' ') != "")
                        {
                            string newAI = text.Replace("  ", " ").Trim(' ');

                            string[] sens = text.Split(".", StringSplitOptions.RemoveEmptyEntries);
                            string[] words = sens[1].Split(" ", StringSplitOptions.RemoveEmptyEntries);

                            newReminder.Description = sens[0];

                            try
                            {
                                newReminder.DaysBefore = System.Convert.ToInt32(words[Array.IndexOf(words, "روز") - 1]);
                            }
                            catch (FormatException)
                            {
                                newReminder.DaysBefore = System.Convert.ToInt32(hashDay[words[Array.IndexOf(words, "روز") - 1]]);
                            }

                            if (words.Contains("قبل"))
                            {
                                if (words.Contains("ام") || words.Contains("م"))
                                {
                                    try
                                    {
                                        newReminder.Day = System.Convert.ToInt32(words[Array.IndexOf(words, "ام") - 1]);
                                    }
                                    catch (FormatException)
                                    {
                                        newReminder.Day = System.Convert.ToInt32(hashDay[words[Array.IndexOf(words, "ام") - 1]]);
                                    }

                                    if (words.Contains("فروردین"))
                                    {
                                        newReminder.Month = System.Convert.ToInt32(HashMonth[words[Array.IndexOf(words, "فروردین")]]);
                                    }
                                    else if (words.Contains("اردیبهشت"))
                                    {
                                        newReminder.Month = System.Convert.ToInt32(HashMonth[words[Array.IndexOf(words, "اردیبهشت")]]);
                                    }
                                    else if (words.Contains("خرداد"))
                                    {
                                        newReminder.Month = System.Convert.ToInt32(HashMonth[words[Array.IndexOf(words, "خرداد")]]);
                                    }
                                    else if (words.Contains("تیر"))
                                    {
                                        newReminder.Month = System.Convert.ToInt32(HashMonth[words[Array.IndexOf(words, "تیر")]]);
                                    }
                                    else if (words.Contains("مرداد"))
                                    {
                                        newReminder.Month = System.Convert.ToInt32(HashMonth[words[Array.IndexOf(words, "مرداد")]]);
                                    }
                                    else if (words.Contains("شهریور"))
                                    {
                                        newReminder.Month = System.Convert.ToInt32(HashMonth[words[Array.IndexOf(words, "شهریور")]]);
                                    }
                                    else if (words.Contains("مهر"))
                                    {
                                        newReminder.Month = System.Convert.ToInt32(HashMonth[words[Array.IndexOf(words, "مهر")]]);
                                    }
                                    else if (words.Contains("آبان"))
                                    {
                                        newReminder.Month = System.Convert.ToInt32(HashMonth[words[Array.IndexOf(words, "آبان")]]);
                                    }
                                    else if (words.Contains("آذر"))
                                    {
                                        newReminder.Month = System.Convert.ToInt32(HashMonth[words[Array.IndexOf(words, "آذر")]]);
                                    }
                                    else if (words.Contains("دی"))
                                    {
                                        newReminder.Month = System.Convert.ToInt32(HashMonth[words[Array.IndexOf(words, "دی")]]);
                                    }
                                    else if (words.Contains("بهمن"))
                                    {
                                        newReminder.Month = System.Convert.ToInt32(HashMonth[words[Array.IndexOf(words, "بهمن")]]);
                                    }
                                    else if (words.Contains("اسفند"))
                                    {
                                        newReminder.Month = System.Convert.ToInt32(HashMonth[words[Array.IndexOf(words, "اسفند")]]);
                                    }


                                    if (words.Contains("ماه"))
                                    {
                                        if (words.Contains("سال"))
                                        {
                                            newReminder.Year = System.Convert.ToInt32(words[Array.IndexOf(words, "سال") + 1].TrimEnd('.'));
                                        }
                                        else if (words.Contains("امسال"))
                                        {
                                            newReminder.Year = new PersianCalendar().GetYear(DateTime.Now);
                                        }
                                        else
                                        {
                                            newReminder.Year = System.Convert.ToInt32(words[Array.IndexOf(words, "ماه") + 1].TrimEnd('.'));
                                        }
                                    }
                                    else
                                    {
                                        if (words.Contains("سال"))
                                        {
                                            newReminder.Year = System.Convert.ToInt32(words[Array.IndexOf(words, "سال") + 1].TrimEnd('.'));
                                        }
                                        else if (words.Contains("امسال"))
                                        {
                                            newReminder.Year = new PersianCalendar().GetYear(DateTime.Now);
                                        }
                                        else
                                        {
                                            try
                                            {
                                                if (words.Contains("فروردین"))
                                                {
                                                    newReminder.Year = System.Convert.ToInt32(words[Array.IndexOf(words, "فروردین") + 1].TrimEnd('.'));
                                                }
                                                else if (words.Contains("اردیبهشت"))
                                                {
                                                    newReminder.Year = System.Convert.ToInt32(words[Array.IndexOf(words, "اردیبهشت") + 1].TrimEnd('.'));
                                                }
                                                else if (words.Contains("خرداد"))
                                                {
                                                    newReminder.Year = System.Convert.ToInt32(words[Array.IndexOf(words, "خرداد") + 1].TrimEnd('.'));
                                                }
                                                else if (words.Contains("تیر"))
                                                {
                                                    newReminder.Year = System.Convert.ToInt32(words[Array.IndexOf(words, "تیر") + 1].TrimEnd('.'));
                                                }
                                                else if (words.Contains("مرداد"))
                                                {
                                                    newReminder.Year = System.Convert.ToInt32(words[Array.IndexOf(words, "مرداد") + 1].TrimEnd('.'));
                                                }
                                                else if (words.Contains("شهریور"))
                                                {
                                                    newReminder.Year = System.Convert.ToInt32(words[Array.IndexOf(words, "شهریور") + 1].TrimEnd('.'));
                                                }
                                                else if (words.Contains("مهر"))
                                                {
                                                    newReminder.Year = System.Convert.ToInt32(words[Array.IndexOf(words, "مهر") + 1].TrimEnd('.'));
                                                }
                                                else if (words.Contains("آبان"))
                                                {
                                                    newReminder.Year = System.Convert.ToInt32(words[Array.IndexOf(words, "آبان") + 1].TrimEnd('.'));
                                                }
                                                else if (words.Contains("آذر"))
                                                {
                                                    newReminder.Year = System.Convert.ToInt32(words[Array.IndexOf(words, "آذر") + 1].TrimEnd('.'));
                                                }
                                                else if (words.Contains("دی"))
                                                {
                                                    newReminder.Year = System.Convert.ToInt32(words[Array.IndexOf(words, "دی") + 1].TrimEnd('.'));
                                                }
                                                else if (words.Contains("بهمن"))
                                                {
                                                    newReminder.Year = System.Convert.ToInt32(words[Array.IndexOf(words, "بهمن") + 1].TrimEnd('.'));
                                                }
                                                else if (words.Contains("اسفند"))
                                                {
                                                    newReminder.Year = System.Convert.ToInt32(words[Array.IndexOf(words, "اسفند") + 1].TrimEnd('.'));
                                                }
                                            }
                                            catch
                                            {
                                                newReminder.Year = new PersianCalendar().GetYear(DateTime.Now);
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    try
                                    {
                                        if (words.Contains("فروردین"))
                                        {
                                            newReminder.Day = System.Convert.ToInt32(words[Array.IndexOf(words, "فروردین") - 1]);
                                        }
                                        else if (words.Contains("اردیبهشت"))
                                        {
                                            newReminder.Day = System.Convert.ToInt32(words[Array.IndexOf(words, "اردیبهشت") - 1]);
                                        }
                                        else if (words.Contains("خرداد"))
                                        {
                                            newReminder.Day = System.Convert.ToInt32(words[Array.IndexOf(words, "خرداد") - 1]);
                                        }
                                        else if (words.Contains("تیر"))
                                        {
                                            newReminder.Day = System.Convert.ToInt32(words[Array.IndexOf(words, "تیر") - 1]);
                                        }
                                        else if (words.Contains("مرداد"))
                                        {
                                            newReminder.Day = System.Convert.ToInt32(words[Array.IndexOf(words, "مرداد") - 1]);
                                        }
                                        else if (words.Contains("شهریور"))
                                        {
                                            newReminder.Day = System.Convert.ToInt32(words[Array.IndexOf(words, "شهریور") - 1]);
                                        }
                                        else if (words.Contains("مهر"))
                                        {
                                            newReminder.Day = System.Convert.ToInt32(words[Array.IndexOf(words, "مهر") - 1]);
                                        }
                                        else if (words.Contains("آبان"))
                                        {
                                            newReminder.Day = System.Convert.ToInt32(words[Array.IndexOf(words, "آبان") - 1]);
                                        }
                                        else if (words.Contains("آذر"))
                                        {
                                            newReminder.Day = System.Convert.ToInt32(words[Array.IndexOf(words, "آذر") - 1]);
                                        }
                                        else if (words.Contains("دی"))
                                        {
                                            newReminder.Day = System.Convert.ToInt32(words[Array.IndexOf(words, "دی") - 1]);
                                        }
                                        else if (words.Contains("بهمن"))
                                        {
                                            newReminder.Day = System.Convert.ToInt32(words[Array.IndexOf(words, "بهمن") - 1]);
                                        }
                                        else if (words.Contains("اسفند"))
                                        {
                                            newReminder.Day = System.Convert.ToInt32(words[Array.IndexOf(words, "اسفند") - 1]);
                                        }
                                    }
                                    catch (FormatException)
                                    {
                                        if (words.Contains("فروردین"))
                                        {
                                            newReminder.Day = System.Convert.ToInt32(hashDay[words[Array.IndexOf(words, "فروردین") - 1]]);
                                        }
                                        else if (words.Contains("اردیبهشت"))
                                        {
                                            newReminder.Day = System.Convert.ToInt32(hashDay[words[Array.IndexOf(words, "اردیبهشت") - 1]]);
                                        }
                                        else if (words.Contains("خرداد"))
                                        {
                                            newReminder.Day = System.Convert.ToInt32(hashDay[words[Array.IndexOf(words, "خرداد") - 1]]);
                                        }
                                        else if (words.Contains("تیر"))
                                        {
                                            newReminder.Day = System.Convert.ToInt32(hashDay[words[Array.IndexOf(words, "تیر") - 1]]);
                                        }
                                        else if (words.Contains("مرداد"))
                                        {
                                            newReminder.Day = System.Convert.ToInt32(hashDay[words[Array.IndexOf(words, "مرداد") - 1]]);
                                        }
                                        else if (words.Contains("شهریور"))
                                        {
                                            newReminder.Day = System.Convert.ToInt32(hashDay[words[Array.IndexOf(words, "شهریور") - 1]]);
                                        }
                                        else if (words.Contains("مهر"))
                                        {
                                            newReminder.Day = System.Convert.ToInt32(hashDay[words[Array.IndexOf(words, "مهر") - 1]]);
                                        }
                                        else if (words.Contains("آبان"))
                                        {
                                            newReminder.Day = System.Convert.ToInt32(hashDay[words[Array.IndexOf(words, "آبان") - 1]]);
                                        }
                                        else if (words.Contains("آذر"))
                                        {
                                            newReminder.Day = System.Convert.ToInt32(hashDay[words[Array.IndexOf(words, "آذر") - 1]]);
                                        }
                                        else if (words.Contains("دی"))
                                        {
                                            newReminder.Day = System.Convert.ToInt32(hashDay[words[Array.IndexOf(words, "دی") - 1]]);
                                        }
                                        else if (words.Contains("بهمن"))
                                        {
                                            newReminder.Day = System.Convert.ToInt32(hashDay[words[Array.IndexOf(words, "بهمن") - 1]]);
                                        }
                                        else if (words.Contains("اسفند"))
                                        {
                                            newReminder.Day = System.Convert.ToInt32(hashDay[words[Array.IndexOf(words, "اسفند") - 1]]);
                                        }
                                    }


                                    if (words.Contains("فروردین"))
                                    {
                                        newReminder.Month = System.Convert.ToInt32(HashMonth[words[Array.IndexOf(words, "فروردین")]]);
                                    }
                                    else if (words.Contains("اردیبهشت"))
                                    {
                                        newReminder.Month = System.Convert.ToInt32(HashMonth[words[Array.IndexOf(words, "اردیبهشت")]]);
                                    }
                                    else if (words.Contains("خرداد"))
                                    {
                                        newReminder.Month = System.Convert.ToInt32(HashMonth[words[Array.IndexOf(words, "خرداد")]]);
                                    }
                                    else if (words.Contains("تیر"))
                                    {
                                        newReminder.Month = System.Convert.ToInt32(HashMonth[words[Array.IndexOf(words, "تیر")]]);
                                    }
                                    else if (words.Contains("مرداد"))
                                    {
                                        newReminder.Month = System.Convert.ToInt32(HashMonth[words[Array.IndexOf(words, "مرداد")]]);
                                    }
                                    else if (words.Contains("شهریور"))
                                    {
                                        newReminder.Month = System.Convert.ToInt32(HashMonth[words[Array.IndexOf(words, "شهریور")]]);
                                    }
                                    else if (words.Contains("مهر"))
                                    {
                                        newReminder.Month = System.Convert.ToInt32(HashMonth[words[Array.IndexOf(words, "مهر")]]);
                                    }
                                    else if (words.Contains("آبان"))
                                    {
                                        newReminder.Month = System.Convert.ToInt32(HashMonth[words[Array.IndexOf(words, "آبان")]]);
                                    }
                                    else if (words.Contains("آذر"))
                                    {
                                        newReminder.Month = System.Convert.ToInt32(HashMonth[words[Array.IndexOf(words, "آذر")]]);
                                    }
                                    else if (words.Contains("دی"))
                                    {
                                        newReminder.Month = System.Convert.ToInt32(HashMonth[words[Array.IndexOf(words, "دی")]]);
                                    }
                                    else if (words.Contains("بهمن"))
                                    {
                                        newReminder.Month = System.Convert.ToInt32(HashMonth[words[Array.IndexOf(words, "بهمن")]]);
                                    }
                                    else if (words.Contains("اسفند"))
                                    {
                                        newReminder.Month = System.Convert.ToInt32(HashMonth[words[Array.IndexOf(words, "اسفند")]]);
                                    }


                                    if (words.Contains("ماه"))
                                    {
                                        if (words.Contains("سال"))
                                        {
                                            newReminder.Year = System.Convert.ToInt32(words[Array.IndexOf(words, "سال") + 1].TrimEnd('.'));
                                        }
                                        else if (words.Contains("امسال"))
                                        {
                                            newReminder.Year = new PersianCalendar().GetYear(DateTime.Now);
                                        }
                                        else
                                        {
                                            try
                                            {
                                                newReminder.Year = System.Convert.ToInt32(words[Array.IndexOf(words, "ماه") + 1].TrimEnd('.'));
                                            }
                                            catch (FormatException)
                                            {
                                                newReminder.Year = new PersianCalendar().GetYear(DateTime.Now);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (words.Contains("سال"))
                                        {
                                            newReminder.Year = System.Convert.ToInt32(words[Array.IndexOf(words, "سال") + 1].TrimEnd('.'));
                                        }
                                        else if (words.Contains("امسال"))
                                        {
                                            newReminder.Year = new PersianCalendar().GetYear(DateTime.Now);
                                        }
                                        else
                                        {
                                            try
                                            {
                                                newReminder.Year = System.Convert.ToInt32(words[6].TrimEnd('.'));
                                            }
                                            catch (FormatException)
                                            {
                                                newReminder.Year = new PersianCalendar().GetYear(DateTime.Now);
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                if (words.Contains("ام") || words.Contains("م"))
                                {
                                    try
                                    {
                                        newReminder.Day = System.Convert.ToInt32(words[3]);
                                    }
                                    catch (FormatException)
                                    {
                                        newReminder.Day = System.Convert.ToInt32(hashDay[words[3]]);
                                    }
                                    newReminder.Month = System.Convert.ToInt32(HashMonth[words[5]]);
                                    if (words.Contains("ماه"))
                                    {
                                        if (words.Contains("سال"))
                                        {
                                            newReminder.Year = System.Convert.ToInt32(words[8].TrimEnd('.'));
                                        }
                                        else if (words.Contains("امسال"))
                                        {
                                            newReminder.Year = new PersianCalendar().GetYear(DateTime.Now);
                                        }
                                        else
                                        {
                                            try
                                            {
                                                newReminder.Year = System.Convert.ToInt32(words[7].TrimEnd('.'));
                                            }
                                            catch (FormatException)
                                            {
                                                newReminder.Year = new PersianCalendar().GetYear(DateTime.Now);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (words.Contains("سال"))
                                        {
                                            newReminder.Year = System.Convert.ToInt32(words[7].TrimEnd('.'));
                                        }
                                        else if (words.Contains("امسال"))
                                        {
                                            newReminder.Year = new PersianCalendar().GetYear(DateTime.Now);
                                        }
                                        else
                                        {
                                            try
                                            {
                                                newReminder.Year = System.Convert.ToInt32(words[6].TrimEnd('.'));
                                            }
                                            catch (FormatException)
                                            {
                                                newReminder.Year = new PersianCalendar().GetYear(DateTime.Now);
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    try
                                    {
                                        newReminder.Day = System.Convert.ToInt32(words[3]);
                                    }
                                    catch (FormatException)
                                    {
                                        newReminder.Day = System.Convert.ToInt32(hashDay[words[3]]);
                                    }
                                    newReminder.Month = System.Convert.ToInt32(HashMonth[words[4]]);
                                    if (words.Contains("ماه"))
                                    {
                                        newReminder.Year = System.Convert.ToInt32(words[6].TrimEnd('.'));
                                    }
                                    else
                                    {
                                        newReminder.Year = System.Convert.ToInt32(words[5].TrimEnd('.'));
                                    }
                                }
                            }


                            if ((newReminder.Day - newReminder.DaysBefore) < 1)
                            {
                                if (newReminder.Month == 1)
                                {
                                    if (new PersianCalendar().IsLeapYear(newReminder.Year - 1))
                                    {
                                        newReminder.ShowDay = 29 + (newReminder.Day - newReminder.DaysBefore);
                                    }
                                    else
                                    {
                                        newReminder.ShowDay = 30 + (newReminder.Day - newReminder.DaysBefore);
                                    }
                                    newReminder.ShowYear = newReminder.Year - 1;
                                    newReminder.ShowMonth = 12;
                                }
                                else if (newReminder.Month > 1 && newReminder.Month <= 6)
                                {
                                    newReminder.ShowDay = 31 + (newReminder.Day - newReminder.DaysBefore);
                                    newReminder.ShowMonth = newReminder.Month - 1;
                                    newReminder.ShowYear = newReminder.Year;
                                }
                                else if (newReminder.Month > 6 && newReminder.Month <= 12)
                                {
                                    newReminder.ShowDay = 30 + (newReminder.Day - newReminder.DaysBefore);
                                    newReminder.ShowMonth = newReminder.Month - 1;
                                    newReminder.ShowYear = newReminder.Year;
                                }
                            }
                            else
                            {
                                newReminder.ShowYear = newReminder.Year;
                                newReminder.ShowMonth = newReminder.Month;
                                newReminder.ShowDay = newReminder.Day - newReminder.DaysBefore;
                            }

                            MLObj = newReminder;
                        }
                        else
                        {
                            List<Reminder> relist = JsonConvert.DeserializeObject<List<Reminder>>(File.ReadAllText("DOs.json"));
                            DateTime time = DateTime.Now;
                            string AI = "";
                            string[] words = text.Trim('.').Split(' ', StringSplitOptions.RemoveEmptyEntries);

                            if (words.Contains("موعد"))
                            {
                                if (words.Contains("امروز"))
                                {
                                    time = DateTime.Now;

                                    var l = from a in relist
                                            where a.Day == new PersianCalendar().GetDayOfMonth(time)
                                            where a.Month == new PersianCalendar().GetMonth(time)
                                            where a.Year == new PersianCalendar().GetYear(time)
                                            select a;

                                    if (l.Count() > 0)
                                    {

                                        foreach (var a in l)
                                        {
                                            AI += $"{a.Description,-30}\n";
                                        }

                                        AI += "\n\nموعد دیگری برای امروز وجود ندارد.";
                                    }
                                    else
                                    {
                                        AI = "شما برای امروز هیچ موعدی ندارید.";
                                    }
                                }
                                else if (words.Contains("هفته"))
                                {
                                    AI = "لطفا از بازه زمانی های رسمی مانند روز، ماه و سال استفاده کنید.";
                                }
                                else if (words.Contains("این") && words.Contains("ماه"))
                                {
                                    time = DateTime.Now;

                                    var l = from a in relist
                                            where a.Month == new PersianCalendar().GetMonth(time)
                                            where a.Year == new PersianCalendar().GetYear(time)
                                            select a;

                                    if (l.Count() > 0)
                                    {

                                        foreach (var a in l)
                                        {
                                            AI += $"{a.Description,-30}. در تاریخ {a.Day:00} ام این ماه.\n";
                                        }

                                        AI += "\n\nبه غیر از این ها موعد دیگری ندارید.";
                                    }
                                    else
                                    {
                                        AI = "شما برای این ماه هیچ موعدی ندارید.";
                                    }
                                }
                                else if (words.Contains("امسال"))
                                {
                                    time = DateTime.Now;

                                    var l = from a in relist
                                            where a.Year == new PersianCalendar().GetYear(time)
                                            select a;

                                    if (l.Count() > 0)
                                    {

                                        foreach (var a in l)
                                        {
                                            AI += $"{a.Description,-30}. در تاریخ {a.Month:00}/{a.Day:00} امسال.\n";
                                        }

                                        AI += "\n\nبه غیر از این ها موعد دیگری ندارید.";
                                    }
                                    else
                                    {
                                        AI = "شما برای امسال هیچ موعدی ندارید.";
                                    }
                                }
                                else if (words.Contains("ماه"))
                                {
                                    if (Array.IndexOf(words, "ماه") != 0)
                                    {
                                        if (words[Array.IndexOf(words, "ماه") + 1].ToString().Contains("بعد"))
                                        {
                                            if (hashDay.ContainsKey(words[Array.IndexOf(words, "ماه") - 1]))
                                            {
                                                time = time.AddMonths((int)hashDay[Array.IndexOf(words, "ماه") - 1]);
                                            }
                                            else if (hashDay.ContainsValue(words[Array.IndexOf(words, "ماه") - 1]))
                                            {
                                                time = time.AddMonths(System.Convert.ToInt32(words[Array.IndexOf(words, "ماه") - 1]));
                                            }
                                            else
                                            {
                                                time = time.AddMonths(1);
                                            }

                                            var l = from a in relist
                                                    where a.Month == new PersianCalendar().GetMonth(time)
                                                    where a.Year == new PersianCalendar().GetYear(time)
                                                    select a;

                                            if (l.Count() > 0)
                                            {

                                                foreach (var a in l)
                                                {
                                                    AI += $"{a.Description,-30}. در تاریخ {a.Month:00}/{a.Day:00}\n";
                                                }

                                                AI += "\n\nبه غیر از این ها موعد دیگری ندارید.";
                                            }
                                            else
                                            {
                                                AI = "هیچ موعدی برای بازه زمانی گفته شده موجود نیست.";
                                            }
                                        }
                                        else if (words[Array.IndexOf(words, "ماه") + 1].ToString().Contains("قبل"))
                                        {
                                            if (hashDay.ContainsKey(words[Array.IndexOf(words, "ماه") - 1]))
                                            {
                                                time = time.AddMonths(-(int)hashDay[Array.IndexOf(words, "ماه") - 1]);
                                            }
                                            else if (hashDay.ContainsValue(words[Array.IndexOf(words, "ماه") - 1]))
                                            {
                                                time = time.AddMonths(-System.Convert.ToInt32(words[Array.IndexOf(words, "ماه") - 1]));
                                            }
                                            else
                                            {
                                                time = time.AddMonths(-1);
                                            }

                                            var l = from a in relist
                                                    where a.Month == new PersianCalendar().GetMonth(time)
                                                    where a.Year == new PersianCalendar().GetYear(time)
                                                    select a;

                                            if (l.Count() > 0)
                                            {

                                                foreach (var a in l)
                                                {
                                                    AI += $"{a.Description,-30}. در تاریخ {a.Month:00}/{a.Day:00}\n";
                                                }

                                                AI += "\n\nبه غیر از این ها موعد دیگری ندارید.";
                                            }
                                            else
                                            {
                                                AI = "هیچ موعدی برای بازه زمانی گفته شده موجود نیست.";
                                            }
                                        }
                                        else if (words[Array.IndexOf(words, "ماه") + 1].ToString().Contains("آینده"))
                                        {
                                            time = DateTime.Now;

                                            if (hashDay.ContainsKey(words[Array.IndexOf(words, "ماه") - 1]))
                                            {
                                                var l = from a in relist
                                                        where a.Month > new PersianCalendar().GetMonth(DateTime.Now) && a.Month < new PersianCalendar().GetMonth(time.AddMonths((int)hashDay[words[Array.IndexOf(words, "ماه") - 1]]))
                                                        where a.Year == new PersianCalendar().GetYear(time)
                                                        select a;

                                                if (l.Count() > 0)
                                                {

                                                    foreach (var a in l)
                                                    {
                                                        AI += $"{a.Description,-30}. در تاریخ {a.Month:00}/{a.Day:00}\n";
                                                    }

                                                    AI += "\n\nبه غیر از این ها موعد دیگری ندارید.";
                                                }
                                                else
                                                {
                                                    AI = "هیچ موعدی برای بازه زمانی گفته شده موجود نیست.";
                                                }
                                            }
                                            else if (hashDay.ContainsValue(words[Array.IndexOf(words, "ماه") - 1]))
                                            {
                                                var l = from a in relist
                                                        where a.Month > new PersianCalendar().GetMonth(DateTime.Now) && a.Month < new PersianCalendar().GetMonth(time.AddMonths(System.Convert.ToInt32(words[Array.IndexOf(words, "ماه") - 1])))
                                                        where a.Year == new PersianCalendar().GetYear(time)
                                                        select a;

                                                if (l.Count() > 0)
                                                {

                                                    foreach (var a in l)
                                                    {
                                                        AI += $"{a.Description,-30}. در تاریخ {a.Month:00}/{a.Day:00}\n";
                                                    }

                                                    AI += "\n\nبه غیر از این ها موعد دیگری ندارید.";
                                                }
                                                else
                                                {
                                                    AI = "هیچ موعدی برای بازه زمانی گفته شده موجود نیست.";
                                                }
                                            }
                                            else
                                            {
                                                time = time.AddMonths(1);
                                                var l = from a in relist
                                                        where a.Month == new PersianCalendar().GetMonth(time)
                                                        where a.Year == new PersianCalendar().GetYear(time)
                                                        select a;

                                                if (l.Count() > 0)
                                                {

                                                    foreach (var a in l)
                                                    {
                                                        AI += $"{a.Description,-30}. در تاریخ {a.Month:00}/{a.Day:00}\n";
                                                    }

                                                    AI += "\n\nبه غیر از این ها موعد دیگری ندارید.";
                                                }
                                                else
                                                {
                                                    AI = "هیچ موعدی برای بازه زمانی گفته شده موجود نیست.";
                                                }
                                            }

                                            
                                        }
                                        else if (words[Array.IndexOf(words, "ماه") + 1].ToString().Contains("گذشته"))
                                        {
                                            time = DateTime.Now;

                                            if (hashDay.ContainsKey(words[Array.IndexOf(words, "ماه") - 1]))
                                            {
                                                var l = from a in relist
                                                        where a.Month < new PersianCalendar().GetMonth(DateTime.Now) && a.Month > new PersianCalendar().GetMonth(time.AddMonths(-(int)hashDay[words[Array.IndexOf(words, "ماه") - 1]]))
                                                        where a.Year == new PersianCalendar().GetYear(time)
                                                        select a;

                                                if (l.Count() > 0)
                                                {

                                                    foreach (var a in l)
                                                    {
                                                        AI += $"{a.Description,-30}. در تاریخ {a.Month:00}/{a.Day:00}\n";
                                                    }

                                                    AI += "\n\nبه غیر از این ها موعد دیگری ندارید.";
                                                }
                                                else
                                                {
                                                    AI = "هیچ موعدی برای بازه زمانی گفته شده موجود نیست.";
                                                }
                                            }
                                            else if (hashDay.ContainsValue(words[Array.IndexOf(words, "ماه") - 1]))
                                            {
                                                var l = from a in relist
                                                        where a.Month < new PersianCalendar().GetMonth(DateTime.Now) && a.Month > new PersianCalendar().GetMonth(time.AddMonths(-System.Convert.ToInt32(words[Array.IndexOf(words, "ماه") - 1])))
                                                        where a.Year == new PersianCalendar().GetYear(time)
                                                        select a;

                                                if (l.Count() > 0)
                                                {

                                                    foreach (var a in l)
                                                    {
                                                        AI += $"{a.Description,-30}. در تاریخ {a.Month:00}/{a.Day:00}\n";
                                                    }

                                                    AI += "\n\nبه غیر از این ها موعد دیگری ندارید.";
                                                }
                                                else
                                                {
                                                    AI = "هیچ موعدی برای بازه زمانی گفته شده موجود نیست.";
                                                }
                                            }
                                            else
                                            {
                                                time = time.AddMonths(-1);
                                                var l = from a in relist
                                                        where a.Month == new PersianCalendar().GetMonth(time)
                                                        where a.Year == new PersianCalendar().GetYear(time)
                                                        select a;

                                                if (l.Count() > 0)
                                                {

                                                    foreach (var a in l)
                                                    {
                                                        AI += $"{a.Description,-30}. در تاریخ {a.Month:00}/{a.Day:00}\n";
                                                    }

                                                    AI += "\n\nبه غیر از این ها موعد دیگری ندارید.";
                                                }
                                                else
                                                {
                                                    AI = "هیچ موعدی برای بازه زمانی گفته شده موجود نیست.";
                                                }
                                            }
                                        }
                                        else
                                        {

                                        }
                                    }
                                    else
                                    {
                                        AI = "لطفا به من بگویید چه چیزی را به شما نشان دهم.";
                                    }
                                }
                                else
                                {
                                    AI = "بازه زمانی کمی گنگ است.";
                                }
                            }
                            else if (words.Contains("یادآور") || words.Contains("یاداور"))
                            {
                                if (words.Contains("امروز"))
                                {
                                    var l = from a in relist
                                            where a.ShowDay == new PersianCalendar().GetDayOfMonth(time)
                                            where a.ShowMonth == new PersianCalendar().GetMonth(time)
                                            where a.ShowYear == new PersianCalendar().GetYear(time)
                                            select a;

                                    if (l.Count() > 0)
                                    {

                                        foreach (var a in l)
                                        {
                                            AI += $"{a.Description} ({a.DaysBefore} روز دیگر).\n";
                                        }

                                        AI += "\n\nبه غیر از این ها یادآور دیگری برای امروز ندارید.";
                                    }
                                    else
                                    {
                                        AI = "شما برای امروز هیچ یادآور ندارید.";
                                    }
                                }
                                else if (words.Contains("هفته"))
                                {
                                    AI = "لطفا از بازه زمانی های رسمی مانند روز، ماه و سال استفاده کنید.";
                                }
                                else if (words.Contains("این") && words.Contains("ماه"))
                                {
                                    time = DateTime.Now;

                                    var l = from a in relist
                                            where a.ShowMonth == new PersianCalendar().GetMonth(time)
                                            where a.ShowYear == new PersianCalendar().GetYear(time)
                                            select a;

                                    if (l.Count() > 0)
                                    {

                                        foreach (var a in l)
                                        {
                                            AI += $"{a.Description, -30}. در تاریخ {a.Day:00} ام این ماه.\n";
                                        }

                                        AI += "\n\nبه غیر از این ها یادآور دیگری برای این ماه ندارید.";
                                    }
                                    else
                                    {
                                        AI = "شما برای این ماه هیچ موعدی ندارید.";
                                    }
                                }
                                else if (words.Contains("امسال"))
                                {
                                    time = DateTime.Now;

                                    var l = from a in relist
                                            where a.ShowYear == new PersianCalendar().GetYear(time)
                                            select a;

                                    if (l.Count() > 0)
                                    {

                                        foreach (var a in l)
                                        {
                                            AI += $"{a.Description,-30}. در تاریخ {a.Month:00}/{a.Day:00}\n";
                                        }

                                        AI += "\n\nبه غیر از این ها یادآور دیگری برای امسال ندارید.";
                                    }
                                    else
                                    {
                                        AI = "شما برای امسال هیچ یادآوری ندارید.";
                                    }
                                }
                                else if (words.Contains("ماه") && words.Contains("قبل"))
                                {
                                    time = time.AddMonths(-1);

                                    var l = from a in relist
                                            where a.ShowMonth == new PersianCalendar().GetMonth(time)
                                            where a.ShowYear == new PersianCalendar().GetYear(time)
                                            select a;

                                    if (l.Count() > 0)
                                    {

                                        foreach (var a in l)
                                        {
                                            AI += $"{a.Description, -30}. در تاریخ {a.Year:0000}/{a.Month:00}/{a.Day:00}\n";
                                        }

                                        AI += "\n\nبه غیر از این ها یادآور دیگری از ماه قبل ندارید.";
                                    }
                                    else
                                    {
                                        AI = "هیچ یادآوری در ماه قبل پیدا نشد.";
                                    }
                                }
                                else if (words.Contains("ماه") && words.Contains("بعد"))
                                {
                                    time = time.AddMonths(1);

                                    var l = from a in relist
                                            where a.ShowMonth == new PersianCalendar().GetMonth(time)
                                            where a.ShowYear == new PersianCalendar().GetYear(time)
                                            select a;

                                    if (l.Count() > 0)
                                    {

                                        foreach (var a in l)
                                        {
                                            AI += $"{a.Description, -30}. در تاریخ {a.Year:0000}/{a.Month:00}/{a.Day:00}\n";
                                        }

                                        AI += "\n\nبه غیر از این ها یادآور دیگری از ماه بعد ندارید.";
                                    }
                                    else
                                    {
                                        AI = "هیچ یادآوری در ماه بعد پیدا نشد.";
                                    }
                                }
                                else
                                {
                                    AI = "بازه زمانی کمی گنگ است.";
                                }
                            }
                            else if (words.Contains("حذف") && words.Contains("موعد"))
                            {
                                if (words.Contains("امروز"))
                                {

                                }
                                else if (words.Contains("فردا"))
                                {

                                }
                                else if (words.Contains("دیروز"))
                                {

                                }
                            }
                            else if (words.Contains("حذف") && (words.Contains("یادآور") || words.Contains("یاداور")))
                            {

                            }
                            else
                            {
                                AI = "گفته های شما از وظیفه این برنامه خارج است.";
                            }

                            MLObj = AI;
                        }
                    }
                }
                return MLObj;
            }
        }
    }
}
