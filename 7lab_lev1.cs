//using System;
//using System.Collections.Generic;
//using System.Text;

//class Participant
//{
//    private string name;
//    private int id;
//    private int best_result;
//    private int flag = 1;

//    public int Flag { get { return flag; } }

//    public Participant(string name, int i, int res)
//    {
//        this.name = name;
//        id = i;
//        best_result = res;
//    }

//    public int SECOND_RES
//    {
//        set
//        {
//            if (value > best_result) best_result = value;
//        }
//    }

//    public void Diskfalif()
//    {
//        flag = 0;
//    }

//    public void Info()
//    {
//        Console.WriteLine($"результат: {best_result} имя: {name} ");
//    }

//    public static void Sort(Participant[] list)
//    {
//        for (int i = 1; i < list.Length; i++)
//        {
//            int k = list[i].best_result;
//            Participant now = list[i];
//            int j = i - 1;

//            while (j >= 0 && list[j].best_result < k)
//            {
//                list[j + 1] = list[j];
//                j--;
//            }
//            list[j + 1] = now;
//        }
//    }

//}

//public class Program
//{

//    public static void Main(string[] args)
//    {
//        int n = int.Parse(Console.ReadLine());
//        Participant[] peoplelist = new Participant[n];

//        for (int i = 0; i < n; i++)
//        {
//            string name_people = Console.ReadLine();
//            int first_res = int.Parse(Console.ReadLine());
//            int second_res = int.Parse(Console.ReadLine());

//            Participant Person = new Participant(name_people, i + 1, first_res);
//            Person.SECOND_RES = second_res;

//            Console.WriteLine("Дисквалифицирован? Ответ: да/нет");
//            string f = Console.ReadLine();
//            if (f == "да")
//            {
//                Person.Diskfalif();
//            }
//            peoplelist[i] = Person;
//        }

//        Participant.Sort(peoplelist);

//        int m = 1;
//        for (int i = 0; i < n; i++)
//        {
//            if (peoplelist[i].Flag == 1)
//            {
//                Console.Write($"{m} место:"); ;
//                peoplelist[i].Info();
//                Console.WriteLine();
//                m += 1;
//            }
//        }
//        Console.WriteLine();
//    }
//}