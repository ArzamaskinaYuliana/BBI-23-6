//using System;
//using System.Collections.Generic;
//using System.Text;

//public class Sportsman
//{
//    protected string name;
//    protected int result;

//    public int Result { get { return result; } }

//    public Sportsman(string name, int res)
//    {
//        this.name = name;
//        result = res;
//    }

//    public void Info()
//    {
//        Console.WriteLine($"результат: {result} имя: {name} ");
//    }

//    public static Sportsman[] Merge(Sportsman[] m1, Sportsman[] m2)
//    {
//        Sportsman[] new_list = new Sportsman[m1.Length + m2.Length];
//        for (int i = 0; i < m1.Length; i++)
//        {
//            new_list[i] = m1[i];
//        }
//        for (int i = 0; i < m2.Length; i++)
//        {
//            new_list[i + m1.Length] = m2[i];
//        }
//        return new_list;

//    }
//}

//class SkierWoman : Sportsman
//{
//    public SkierWoman(string name, int res) : base(name, res)
//    { }
//}

//class SkierMan : Sportsman
//{
//    public SkierMan(string name, int res) : base(name, res)
//    {
//    }
//}

//public class Program
//{
//    static Sportsman[] Sort(Sportsman[] list)
//    {
//        for (int i = 0; i < list.Length; i++)
//        {
//            for (int j = i; j < list.Length; j++)
//                if (list[i].Result < list[j].Result)
//                {
//                    Sportsman person_now = list[j];
//                    list[j] = list[i];
//                    list[i] = person_now;
//                }
//        }
//        return list;
//    }
//    public static void Main(string[] args)
//    {

//        int n_skierW1 = int.Parse(Console.ReadLine());
//        int n_skierW2 = int.Parse(Console.ReadLine());
//        int n_skierM1 = int.Parse(Console.ReadLine());
//        int n_skierM2 = int.Parse(Console.ReadLine());
//        Sportsman[] onegroup_sw = new SkierWoman[n_skierW1];
//        Sportsman[] twogroup_sw = new SkierWoman[n_skierW2];
//        Sportsman[] onegroup_sm = new SkierMan[n_skierM1];
//        Sportsman[] twogroup_sm = new SkierMan[n_skierM2];



//        for (int i = 0; i < n_skierW1; i++)
//        {
//            string name_ = Console.ReadLine();
//            int result_ = int.Parse(Console.ReadLine());

//            SkierWoman Person = new SkierWoman(name_, result_);

//            onegroup_sw[i] = Person;
//        }

//        for (int i = 0; i < n_skierW2; i++)
//        {
//            string name_ = Console.ReadLine();
//            int result_ = int.Parse(Console.ReadLine());

//            SkierWoman Person = new SkierWoman(name_, result_);

//            twogroup_sw[i] = Person;
//        }

//        for (int i = 0; i < n_skierM1; i++)
//        {
//            string name_ = Console.ReadLine();
//            int result_ = int.Parse(Console.ReadLine());

//            SkierMan Person = new SkierMan(name_, result_);

//            onegroup_sm[i] = Person;
//        }

//        for (int i = 0; i < n_skierM2; i++)
//        {
//            string name_ = Console.ReadLine();
//            int result_ = int.Parse(Console.ReadLine());

//            SkierMan Person = new SkierMan(name_, result_);

//            twogroup_sm[i] = Person;
//        }

//        onegroup_sw = Sort(onegroup_sw);
//        twogroup_sw = Sort(twogroup_sw);
//        onegroup_sm = Sort(onegroup_sm);
//        twogroup_sm = Sort(twogroup_sm);

//        Sportsman[] women = Sportsman.Merge(onegroup_sw, twogroup_sw);
//        women = Sort(women);

//        Sportsman[] men = Sportsman.Merge(onegroup_sm, twogroup_sm);
//        men = Sort(men);

//        Sportsman[] allpeople = Sportsman.Merge(women, men);
//        allpeople = Sort(allpeople);


//        Console.WriteLine("1 группа женщины:");
//        for (int i = 0; i < n_skierW1; i++)
//        {
//            Console.Write($"{i + 1} место:"); ;
//            onegroup_sw[i].Info();
//            Console.WriteLine();
//        }
//        Console.WriteLine();

//        Console.WriteLine("2 группа:");
//        for (int i = 0; i < n_skierW2; i++)
//        {
//            Console.Write($"{i + 1} место:"); ;
//            twogroup_sw[i].Info();
//            Console.WriteLine();
//        }
//        Console.WriteLine();

//        Console.WriteLine("Женщины:");
//        for (int i = 0; i < women.Length; i++)
//        {
//            Console.Write($"{i + 1} место:"); ;
//            women[i].Info();
//            Console.WriteLine();
//        }
//        Console.WriteLine();

//        Console.WriteLine("1 группа мужчины: :");
//        for (int i = 0; i < onegroup_sm.Length; i++)
//        {
//            Console.Write($"{i + 1} место:"); ;
//            onegroup_sm[i].Info();
//            Console.WriteLine();
//        }
//        Console.WriteLine();

//        Console.WriteLine("2 группа :");
//        for (int i = 0; i < twogroup_sm.Length; i++)
//        {
//            Console.Write($"{i + 1} место:"); ;
//            twogroup_sm[i].Info();
//            Console.WriteLine();
//        }
//        Console.WriteLine();

//        Console.WriteLine(" Все мужчины :");
//        for (int i = 0; i < men.Length; i++)
//        {
//            Console.Write($"{i + 1} место:"); ;
//            men[i].Info();
//            Console.WriteLine();
//        }
//        Console.WriteLine();

//        Console.WriteLine(" Все людишки :");
//        for (int i = 0; i < allpeople.Length; i++)
//        {
//            Console.Write($"{i + 1} место:"); ;
//            allpeople[i].Info();
//            Console.WriteLine();
//        }
//        Console.WriteLine();


//    }
//}