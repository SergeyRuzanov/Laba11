using Laba10;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Laba11
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Task 1
            SortedList SortedListPeople = new SortedList()
             {
                 {"ИвинаАлена", new Administration("Алена", "Ивина", Gender.Female, 2) },
                 {"БетевИван", new Administration("Иван", "Бетев", Gender.Male, 5) },
                 {"ГаукДана", new Working("Дана", "Гаук", Gender.Female, Category.Middle) },
                 {"ИвановАндрей", new Engineer("Андрей", "Иванов", Gender.Male, Category.God) }
             };
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("*****************---------------------++++++++++++++++++++++////////////////");
            Console.ForegroundColor = ConsoleColor.White;

            foreach (DictionaryEntry ob in SortedListPeople)
            {
                Console.WriteLine($"{ob.Key}: {ob.Value}");
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("*****************---------------------++++++++++++++++++++++////////////////");
            Console.ForegroundColor = ConsoleColor.White;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormAddDel(SortedListPeople));

            SortedList AdminList = GetAdministration(SortedListPeople);
            Console.WriteLine("GetAdministration");
            foreach (DictionaryEntry ob in AdminList)
            {
                Console.WriteLine($"{ob.Key}: {ob.Value}");
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("*****************---------------------++++++++++++++++++++++////////////////");
            Console.ForegroundColor = ConsoleColor.White;

            SortedList FemList = GetFemale(SortedListPeople);
            Console.WriteLine("GetFemale");
            foreach (DictionaryEntry ob in FemList)
            {
                Console.WriteLine($"{ob.Key}: {ob.Value}");
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("*****************---------------------++++++++++++++++++++++////////////////");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("GetExperianceBetter");
            SortedList ExperList = GetExperianceBetter(SortedListPeople, 3);
            foreach (DictionaryEntry ob in ExperList)
            {
                Console.WriteLine($"{ob.Key}: {ob.Value}");
            }


            SortedList newSortedList = (SortedList)SortedListPeople.Clone();
            #endregion

            #region Task 2
            List<Person> listPeople = new List<Person>()
            {
                new Administration("Алена", "Ивина", Gender.Female, 2),
                new Administration("Иван", "Бетев", Gender.Male, 5) ,
                new Working("Дана", "Гаук", Gender.Female, Category.God) ,
                new Engineer("Андрей", "Иванов", Gender.Male, Category.Middle)
            };

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("TASK 2");
            Console.WriteLine("*****************---------------------++++++++++++++++++++++////////////////");
            Console.ForegroundColor = ConsoleColor.White;

            foreach (Person ob in listPeople)
            {
                Console.WriteLine($"{ob}");
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("*****************---------------------++++++++++++++++++++++////////////////");
            Console.ForegroundColor = ConsoleColor.White;

            Application.EnableVisualStyles();
            Application.Run(new FormAddDelList(listPeople));

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("*****************---------------------++++++++++++++++++++++////////////////");
            Console.WriteLine("GetEngeneers");
            Console.ForegroundColor = ConsoleColor.White;
            List<Person> Engeneers = GetEngeneers(listPeople);
            foreach (Person ob in Engeneers)
            {
                Console.WriteLine($"{ob}");
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("*****************---------------------++++++++++++++++++++++////////////////");
            Console.ForegroundColor = ConsoleColor.White;

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("*****************---------------------++++++++++++++++++++++////////////////");
            Console.WriteLine("NumberMale");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(NumberMale(listPeople) + " of male.");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("*****************---------------------++++++++++++++++++++++////////////////");
            Console.ForegroundColor = ConsoleColor.White;

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("*****************---------------------++++++++++++++++++++++////////////////");
            Console.WriteLine("NumberGotOfWorking");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(NumberGotOfWorking(listPeople) + " of Got of Working.");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("*****************---------------------++++++++++++++++++++++////////////////");
            Console.ForegroundColor = ConsoleColor.White;
            #endregion

            #region Task 3
            MySortedDictionary<string, Person> mySortedDictionary = new MySortedDictionary<string, Person>();
            mySortedDictionary.Add("ИвинаАлена", new Administration("Алена", "Ивина", Gender.Female, 2));
            mySortedDictionary.Add("БетевИван", new Administration("Иван", "Бетев", Gender.Male, 5));
            mySortedDictionary.Add("ГаукДана", new Working("Дана", "Гаук", Gender.Female, Category.Middle));
            mySortedDictionary.Add("ИвановАндрей", new Engineer("Андрей", "Иванов", Gender.Male, Category.God));

            foreach ((string, Person) ob in mySortedDictionary)
            {
                Console.WriteLine($"{ob.Item1}: {ob.Item2}");
            }

            Console.WriteLine();

            Console.WriteLine($"ContainsKey(\"ГаукДана\"): {mySortedDictionary.ContainsKey("ГаукДана")}");
            Console.WriteLine($"ContainsValue(): {mySortedDictionary.ContainsValue(new Administration("Иван", "Бетев", Gender.Male, 5))}");
            Console.WriteLine($"GetByIndex(2): {mySortedDictionary.GetByIndex(2)}");
            Console.WriteLine($"GetKey(3): {mySortedDictionary.GetKey(3)}");
            Console.WriteLine($"IndexOfKey(\"ИвановАндрей\"): {mySortedDictionary.IndexOfKey("ИвановАндрей")}");
            Console.WriteLine($"IndexOfValue(): {mySortedDictionary.IndexOfValue(new Administration("Иван", "Бетев", Gender.Male, 5))}");
            mySortedDictionary.SetByIndex(2, new Engineer("Петр", "Ильин", Gender.Male, Category.God));
            Console.WriteLine($"SetByIndex(2, new Engineer(\"Петр\", \"Ильин\", Gender.Male, Category.God): {mySortedDictionary}");
            mySortedDictionary.RemoveAt(2);
            Console.WriteLine($"RemoveAt(2): {mySortedDictionary}");
            mySortedDictionary.Remove(new Administration("Иван", "Бетев", Gender.Male, 5));
            Console.WriteLine($"Remove(): {mySortedDictionary}");
            mySortedDictionary.Clear();
            Console.WriteLine($"Clear(): {mySortedDictionary}");
            #endregion

            Console.ReadKey();

        }

        #region Task 1 Methods
        static SortedList GetAdministration(SortedList sortedList)
        {
            SortedList AdminSortList = new SortedList();
            foreach (DictionaryEntry ob in sortedList)
            {
                if (ob.Value is Administration)
                {
                    AdminSortList.Add(ob.Key, ob.Value);
                }
            }
            return AdminSortList;
        }

        static SortedList GetFemale(SortedList sortedList)
        {
            SortedList FemaleSortList = new SortedList();
            foreach (DictionaryEntry ob in sortedList)
            {
                if (((Person)ob.Value).gender == Gender.Female)
                {
                    FemaleSortList.Add(ob.Key, ob.Value);
                }
            }
            return FemaleSortList;
        }

        static SortedList GetExperianceBetter(SortedList sortedList, int experianceMin)
        {
            SortedList ExperSortList = new SortedList();
            foreach (DictionaryEntry ob in sortedList)
            {
                if ((ob.Value is Administration) && (((Administration)ob.Value).Experience >= experianceMin))
                {
                    ExperSortList.Add(ob.Key, ob.Value);
                }
            }
            return ExperSortList;
        }
        #endregion

        #region Task 2 Methods
        static List<Person> GetEngeneers(List<Person> people)
        {
            List<Person> engen = new List<Person>();
            foreach (Person per in people)
            {
                if (per is Engineer)
                {
                    engen.Add(per);
                }
            }
            return engen;
        }

        static int NumberMale(List<Person> people)
        {
            int num = 0;
            foreach (Person per in people)
            {
                if (per.gender == Gender.Male)
                {
                    num++;
                }
            }
            return num;
        }

        static int NumberGotOfWorking(List<Person> people)
        {
            int num = 0;
            foreach (Person per in people)
            {
                if (per is Working && !(per is Engineer) && ((Working)per).category == Category.God)
                {
                    num++;
                }
            }
            return num;
        }
        #endregion
    }
}
