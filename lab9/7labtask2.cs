//using ProtoBuf;
//using System.Xml.Linq;
//using System.Xml.Serialization;
//using static System.Runtime.InteropServices.JavaScript.JSType;

//[ProtoContract]
//[Serializable]
//public class Golos
//{
//    [XmlAttribute]
//    [ProtoMember(5)]
//    private int num;
//    [XmlAttribute]
//    [ProtoMember(6)]
//    private int[] num_golos;

//    public int Num
//    {
//        get => num;
//        set => num = value;
//    }
//    public int[] Num_golos
//    {
//        get => num_golos;
//        set => num_golos = value;
//    }

//    public Golos() { }
//    public Golos(int num, int[] num_golos)
//    {
//        this.num = num;
//        this.num_golos = num_golos;
//    }
//}

//[ProtoContract]
//[Serializable]
//public struct Sportsman
//{
//    [XmlAttribute]
//    [ProtoMember(3)]
//    private string name;
//    [XmlAttribute]
//    [ProtoMember(4)]
//    private List<Golos> golos_jumps;
//    public string Name
//    {
//        get => name;
//        set => name = value;
//    }
//    public List<Golos> Golos_jumps
//    {
//        get => golos_jumps;
//        set => golos_jumps = value;
//    }
//    public Sportsman() { }
//    public Sportsman(string name, List<Golos> jumps_)
//    {
//        this.name = name;
//        golos_jumps = jumps_;
//    }
//    public override string ToString()
//    {
//        return name;
//    }
//}

//[ProtoContract]
//[ProtoInclude(10, typeof(Jump3))]
//[ProtoInclude(11, typeof(Jump5))]
//[XmlInclude(typeof(Jump3))]
//[XmlInclude(typeof(Jump5))]
//[Serializable]
//public class JumpWater
//{
//    [XmlAttribute]
//    [ProtoMember(1)]
//    protected string dist;
//    [XmlAttribute]
//    [ProtoMember(2)]
//    protected Sportsman[] sportsmen;
//    [XmlAttribute]
//    [ProtoMember(3)]
//    protected double[] indexx;

//    public string Dist
//    {
//        get => dist;
//        set => dist = value;
//    }
//    public Sportsman[] Sportsmen
//    {
//        get => sportsmen;
//        set => sportsmen = value;
//    }
//    public double[] Indexx
//    {
//        get => indexx;
//        set => indexx = value;
//    }

//    public JumpWater() { }

//    public JumpWater(Sportsman[] sportsmen, string dist, double[] indexx)
//    {
//        this.sportsmen = sportsmen;
//        this.dist = dist;
//        this.indexx = indexx;
//    }

//    protected double RezultForPerson(List<Golos> list)
//    {
//        // проход по каждому прыжку 
//        for (int number = 0; number < 4; number++)
//        {
//            Golos golosa_now = list[number];
//            // очки по одному прыжку
//            for (int i = 1; i < 7; i++)
//            {
//                int k = golosa_now.Num_golos[i];
//                int j = i - 1;

//                while (j >= 0 && golosa_now.Num_golos[j] < k)
//                {
//                    golosa_now.Num_golos[j+1] = golosa_now.Num_golos[j];
//                    j--;
//                }
//                golosa_now.Num_golos[j+1] = k;
//            }
//        }
//        int[] res_jumps = new int[4] { 0, 0, 0, 0 };
//        for (int i = 0; i < 4; i++)
//        {
//            Golos golosa_now = list[i];
//            for (int j = 1; j < 6; j++)
//            {
//                res_jumps[i] += golosa_now.Num_golos[j];
//            }
//        }
//        double s = 0;
//        for (int i = 0; i < 4; i++)
//        {
//            s += res_jumps[i] * indexx[i];
//        }
//        return s;
//    }

//    protected Sportsman[] Sort()
//    {
//        for (int i = 0; i < sportsmen.Length; i++)
//        {
//            for (int j = i; j < sportsmen.Length; j++)
//                if (RezultForPerson(sportsmen[i].Golos_jumps) < RezultForPerson(sportsmen[j].Golos_jumps))
//                {
//                    Sportsman person_now = sportsmen[j];
//                    sportsmen[j] = sportsmen[i];
//                    sportsmen[i] = person_now;
//                }
//        }
//        return sportsmen;
//    }

//    protected void Sorevnovan()
//    {
//        Sort();
//    }

//    protected string Print_table()
//    {
//        string s = "\n" + dist + "\n";
//        for (int i = 0; i < sportsmen.Length; i++)
//        { 
//            s += $"{i + 1} место:" + "\n" + $"имя: {sportsmen[i].Name} результат: {RezultForPerson(sportsmen[i].Golos_jumps)}" + "\n";
//        }
//        return s;
//    }
//    public override string ToString()
//    {
//        return Print_table();
//    }
//}

//[ProtoContract]
//[Serializable]
//public class Jump3 : JumpWater
//{
//    public Jump3() { }
//    public Jump3(Sportsman[] sportsmen, string dist, double[] indexx) : base(sportsmen, dist, indexx)
//    {
//        Sorevnovan();
//    }
//}

//[ProtoContract]
//[Serializable]
//public class Jump5 : JumpWater
//{
//    public Jump5() { }
//    public Jump5(Sportsman[] sportsmen, string dist, double[] indexx) : base(sportsmen, dist, indexx)
//    {
//        Sorevnovan();
//    }
//}


//public class Program2
//{
//    public static void Main(string[] args)
//    {
//        double[] Indexx = new double[] { 1.2, 1.6, 1.5, 2.1 };
//        Sportsman[] peoplelist = new Sportsman[] {
//        new Sportsman("Антон", 
//        new List<Golos> 
//        { 
//            new Golos(1, new int[] { 9, 8, 7, 6, 5, 4, 3 }),  
//            new Golos(2, new int[] { 1, 4, 5, 6, 7, 8, 9 }), 
//            new Golos(3, new int[] { 1, 4, 5, 6, 7, 8, 9 }), 
//            new Golos(4, new int[] { 1, 4, 5, 6, 7, 8, 9 }) 
//        }),
//         new Sportsman("Витя",
//        new List<Golos>
//        {
//            new Golos(1, new int[] { 7, 8, 7, 7, 5, 4, 3 }),
//            new Golos(2, new int[] { 1, 4, 5, 6, 1, 8, 9 }),
//            new Golos(3, new int[] { 1, 3, 3, 1, 7, 8, 9 }),
//            new Golos(4, new int[] { 1, 6, 6, 6, 7, 8, 9 })
//        }),
//         new Sportsman("Глеб",
//        new List<Golos>
//        {
//            new Golos(1, new int[] { 2, 8, 7, 8, 8, 4, 3 }),
//            new Golos(2, new int[] { 1, 4, 5, 6, 1, 8, 9 }),
//            new Golos(3, new int[] { 1, 5, 5, 5, 7, 8, 9 }),
//            new Golos(4, new int[] { 1, 8, 9, 9, 9, 8, 9 })
//        }),
//         new Sportsman("Саша",
//        new List<Golos>
//        {
//            new Golos(1, new int[] { 9, 9, 9, 8, 5, 4, 3 }),
//            new Golos(2, new int[] { 1, 4, 4, 4, 7, 8, 9 }),
//            new Golos(3, new int[] { 1, 4, 2, 6, 7, 8, 9 }),
//            new Golos(4, new int[] { 1, 4, 1, 8, 9, 9, 9 })
//        }),
//         new Sportsman("Паша",
//        new List<Golos>
//        {
//            new Golos(1, new int[] { 9, 3, 3, 3, 5, 4, 3 }),
//            new Golos(2, new int[] { 1, 4, 5, 3, 7, 8, 9 }),
//            new Golos(3, new int[] { 1, 4, 3, 6, 7, 8, 9 }),
//            new Golos(4, new int[] { 1, 3, 3, 6, 6, 8, 9 })
//        })};

        
//        Jump3 Sorev = new Jump3(peoplelist, "Прыжки в воду 3 метра", Indexx);

//        double[] Indexx2 = new double[] { 1.9, 1.5, 1.1, 3.1 };
//        Sportsman[] peoplelist2 = new Sportsman[] {
//        new Sportsman("Алеша",
//        new List<Golos>
//        {
//            new Golos(1, new int[] { 9, 8, 7, 6, 5, 4, 3 }),
//            new Golos(2, new int[] { 1, 1, 5, 6, 7, 8, 9 }),
//            new Golos(3, new int[] { 1, 4, 5, 3, 7, 8, 9 }),
//            new Golos(4, new int[] { 1, 4, 4, 6, 7, 8, 9 })
//        }),
//         new Sportsman("Толя",
//        new List<Golos>
//        {
//            new Golos(1, new int[] { 7, 8, 9, 7, 5, 4, 3 }),
//            new Golos(2, new int[] { 1, 5, 5, 6, 5, 8, 9 }),
//            new Golos(3, new int[] { 1, 3, 3, 1, 7, 8, 9 }),
//            new Golos(4, new int[] { 1, 6, 6, 6, 7, 8, 9 })
//        }),
//         new Sportsman("Андрей",
//        new List<Golos>
//        {
//            new Golos(1, new int[] { 2, 8, 7, 8, 8, 4, 3 }),
//            new Golos(2, new int[] { 1, 7, 5, 6, 1, 8, 9 }),
//            new Golos(3, new int[] { 1, 5, 7, 5, 7, 8, 9 }),
//            new Golos(4, new int[] { 1, 8, 9, 7, 9, 8, 9 })
//        }),
//         new Sportsman("Эдуард",
//        new List<Golos>
//        {
//            new Golos(1, new int[] { 9, 9, 9, 8, 5, 4, 3 }),
//            new Golos(2, new int[] { 1, 4, 4, 4, 7, 8, 9 }),
//            new Golos(3, new int[] { 1, 4, 2, 6, 7, 8, 9 }),
//            new Golos(4, new int[] { 7, 8, 9, 4, 4, 4, 9 })
//        }),
//         new Sportsman("Юлиан",
//        new List<Golos>
//        {
//            new Golos(1, new int[] { 9, 9, 9, 3, 5, 4, 3 }),
//            new Golos(2, new int[] { 1, 4, 5, 9, 7, 8, 9 }),
//            new Golos(3, new int[] { 8, 9, 3, 9, 7, 8, 9 }),
//            new Golos(4, new int[] { 1, 3, 9, 6, 6, 8, 9 })
//        })};
//        Jump5 Sorev2 = new Jump5(peoplelist2, "Прыжки в воду 5 метров", Indexx2);


//        string path = @"C:\Users\ADM\Desktop";
//        string folder = "Files_for_task2";
//        path = Path.Combine(path, folder);
//        if (!Directory.Exists(path))
//        {
//            Directory.CreateDirectory(path);
//        }
//        BinaryFile<JumpWater> test1 = new BinaryFile<JumpWater>();

//        Console.WriteLine("BINARY");

//        string file1 = "taskJump3.bin";
//        file1 = Path.Combine(path, file1);
//        if (!System.IO.File.Exists(file1))
//        {
//            test1.Serialize(Sorev, file1);
//        }
//        else
//        {
//            var f1 = test1.Deserialize(file1);
//            Console.WriteLine(f1);
//        }

//        string file2 = "taskJump5.bin";
//        file2 = Path.Combine(path, file2);
//        if (!System.IO.File.Exists(file2))
//        {
//            test1.Serialize(Sorev2, file2);
//        }
//        else
//        {
//            var f2 = test1.Deserialize(file2);
//            Console.WriteLine(f2);
//        }

//        JSONfile<JumpWater> test2 = new JSONfile<JumpWater>();

//        Console.WriteLine("JSON");

//        string file11 = "taskJump3.json";
//        file11 = Path.Combine(path, file11);
//        if (!System.IO.File.Exists(file11))
//        {
//            test2.Serialize(Sorev, file11);
//        }
//        else
//        {
//            var f11 = test2.Deserialize(file11);
//            Console.WriteLine(f11);
//        }

//        string file22 = "taskJump5.json";
//        file22 = Path.Combine(path, file22);
//        if (!System.IO.File.Exists(file22))
//        {
//            test2.Serialize(Sorev2, file22);
//        }
//        else
//        {
//            var f22 = test2.Deserialize(file22);
//            Console.WriteLine(f22);
//        }

//        XMLfile<JumpWater> test3 = new XMLfile<JumpWater>();

//        Console.WriteLine("XML");

//        string file111 = "taskJump3.xml";
//        file111 = Path.Combine(path, file111);
//        if (!System.IO.File.Exists(file111))
//        {
//            test3.Serialize(Sorev, file111);
//        }
//        else
//        {
//            var f111 = test3.Deserialize(file111);
//            Console.WriteLine(f111);
//        }

//        string file222 = "taskJump5.xml";
//        file222 = Path.Combine(path, file222);
//        if (!System.IO.File.Exists(file222))
//        {
//            test3.Serialize(Sorev2, file222);
//        }
//        else
//        {
//            var f222 = test3.Deserialize(file222);
//            Console.WriteLine(f222);
//        }
//    }
//}

