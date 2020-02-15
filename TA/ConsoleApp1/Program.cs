using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace ConsoleApp1
{
    class Program
    {
        static List<Person> peopleList = new List<Person>();
        static Person[] people = new Person [6000];
        static string Name = "Vasja";
        static string Surnam = "Petrov";
        static Random random = new Random();
        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            Stopwatch sw0 = new Stopwatch();
            Stopwatch sw1 = new Stopwatch();
            Stopwatch sw2= new Stopwatch();
            FullArray();
            FullList();
            //Re(peopleList);
            //ShowInfo(peopleList);

            //sw0.Start();
            //Array.Sort(people);
            //sw0.Stop();
            //Console.WriteLine(sw0.Elapsed);

            ///////////////SHELL_SORT////////////////
            //shellSort(people, people.Length);
            
            //Re(people);
           //ShowInfo(peopleList);
            sw.Start();
            StaticSerach(peopleList, "Vasja555");
            sw.Stop();
            //Console.WriteLine(BinarySearch(peopleList, "Vasja555"));
            //shellSort(people, people.Length);
            //shellSort(peopleList, peopleList.Count);
           // ShowInfo(peopleList);
            
            Console.WriteLine(sw.Elapsed);

            //////////////////SELECT_SORT/////////////////////

            //sw1.Start();
            //Person[] PeopleSelect = select_sort(people);
            //sw1.Stop();
            //Console.WriteLine(sw1.Elapsed);

            /////////////////SORTINSERTMETHOD//////////////////

            //sw2.Start();
            //Person[] peopleInsert = SortInsertMethod(people);
            //sw2.Stop();
            //Console.WriteLine(sw2.Elapsed);

            ///////////////////////////////////////////////


            //ShowInfo(people);
            //ShowInfo(peopleInsert);
            //ShowInfo(people);
            Console.ReadKey();
            
        }
        public static void Re(Person [] arr)
        {
            for (int i = arr.Length - 1; i >= 1; i--)
            {
                int j = random.Next(i + 1);
                // обменять значения data[j] и data[i]
                var temp = arr[j];
                arr[j] = arr[i];
                arr[i] = temp;
            }
        }
        public static void Re(List<Person> arr)
        {
            for (int i = arr.Count - 1; i >= 1; i--)
            {
                int j = random.Next(i + 1);
                // обменять значения data[j] и data[i]
                var temp = arr[j];
                arr[j] = arr[i];
                arr[i] = temp;
            }
        }
        public static void StaticSerach(Person [] arr, string item)
        {
            foreach(var a in arr)
            {
                if(a.Name == item)
                {
                    Console.WriteLine(a.ToString());
                }
            }

        }
        public static void StaticSerach(List<Person> list, string item)
        {
            foreach (var a in list)
            {
                if (a.Name == item)
                {
                    Console.WriteLine(item.ToString());
                }
            }

        }
        public static void ShowInfo(Person [] arr)
        {
            foreach(var a in arr)
                {
                    Console.WriteLine("|{0,-10}|{1,-7}|", a.Name, a.Salary.ToString("F2"));
                }
        }
        public static void ShowInfo(List<Person> arr)
        {
            foreach (var a in arr)
            {
                Console.WriteLine("|{0,-10}|{1,-7}|", a.Name, a.Salary.ToString("F2"));
            }
        }
        public static void FullArray()
        {
            int j = 6000;
            for (int i = 0; i < 6000; i++)
            {
                people[i] = new Person(Name + i, Surnam +j , random.Next(90, 200), random.Next(10, 30));
                j--;
            }
        }
        public static void FullList()
        {
            for (int i = 0; i < 6000; i++)
            {
                peopleList.Add(new Person(Name + i, Surnam, random.Next(90, 200), random.Next(10, 30)));
            }
        }
        static void shellSort(Person[] num, int size)
        {
            int increment = 50;    
            while (increment > 0)  
            {
                for (int i = 0; i < size; i++)
                {
                    int j = i; Person temp = num[i];     

                    while ((j >= increment) && (num[j - increment].Salary > temp.Salary))
                    {               
                        num[j] = num[j - increment];    
                        j = j - increment;             
                    }
                    num[j] = temp;         
                }
                if (increment > 1) increment = increment / 2;   

                else if (increment == 1)             
                    break;
            }
        }
        static void shellSort(List<Person> num, int size)
        {
            int increment = 50;
            while (increment > 0)
            {
                for (int i = 0; i < size; i++)
                {
                    int j = i; Person temp = num[i];

                    while ((j >= increment) && (num[j - increment].Salary > temp.Salary))
                    {
                        num[j] = num[j - increment];
                        j = j - increment;
                    }
                    num[j] = temp;
                }
                if (increment > 1) increment = increment / 2;

                else if (increment == 1)
                    break;
            }
        }
        static void Q_sort(int[] a, int l, int r)
        {
            int i = l, j = r, p, temp;

            p = a[(l + r) / 2];
           
            while (i <= j)
            {                       
                while (a[i] < p) i++;           
                while (a[j] > p) j--;
                if (i <= j)
                {                             
                    temp = a[i]; a[i] = a[j]; a[j] = temp;
                    i++; j--;
                }
            }
            if (l < j) Q_sort(a, l, j);       
            if (i < r) Q_sort(a, i, r);        
        }
        
        static Person[] select_sort(Person[] a)
        {
            Person temp = a[0];
            int Ind_min = 0, i, j;

            for (i = 0; i < a.Length - 1; i++)
            {
                Ind_min = i;
                for (j = i + 1; j < a.Length; j++)
                {
                    if (a[j].Salary < a[Ind_min].Salary) Ind_min = j;
                }
                temp = a[i];

                a[i] = a[Ind_min];

                a[Ind_min] = temp;
            }
            return a;
        }
        static Person [] SortInsertMethod(Person[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                Person cur = array[i];

                int j = i;

                while (j > 0 && cur.Salary < array[j - 1].Salary)
                {
                    array[j] = array[j - 1];

                    j--;
                }
                array[j] = cur;
            }
            return array;
        }
        //static int BinarySearch(Person[] array, Person item)
        //{
        //    int left = 0, mid = 0, right = array.Length;

        //    while (left <= right)
        //    {
        //        mid = left + (right - left) / 2;

        //        if (array[mid].Name == item.Name) return mid;
        //        if (array[mid].Name. > item.Name) right = mid - 1;

        //        else left = mid + 1;
        //    }
        //    return ~left;
        //}
        //static int BinarySearch(List<Person> array, string item)
        //{
        //    int left = 0, mid = 0, right = array.Count;

        //    while (left <= right)
        //    {
        //        mid = left + (right - left) / 2;

        //        if (array[mid].Name == item) return mid;
        //        if (1<(array[mid].CompareTo(item))) right = mid - 1;

        //        else left = mid + 1;
        //    }
        //    return ~left;
        //}


    }




}




