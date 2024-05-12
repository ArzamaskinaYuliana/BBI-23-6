
class Program
{
    public static void Main()
    {
        Shelter[] shelters = new Shelter[] { new Shelter("first", 20, true), new Shelter("second", 20, true), new Shelter("third", 20, false) };

        Animal[] homeless_animals = new Animal[] {
        new Dog("Бобик", 50, 46, 5, 10, "в полоску", "голубой"),
        new Cat("Стёпа", 50, 45, 5, 3, "серый", 10),
        new Rabbit("Муся", 50, 45, 5, 2, "белый", 15),
        new Dog("Шарик", 50, 46, 5, 30, "в полоску", "голубой"),
        new Cat("Дуня", 50, 45, 5, 15, "рыжая", 10),
        new Rabbit("Клаус", 50, 45, 5, 18, "белый", 15),
        new Dog("Бублик", 50, 46, 5, 9, "черная", "зеленый"),
        new Cat("Мурка", 50, 45, 5, 11, "рыжая", 10),
        new Rabbit("Ушастик", 50, 45, 5, 3, "серый", 20),
        new Dog("Йоу", 50, 46, 5, 3, "в полоску", "голубой"),
        new Cat("Киса", 50, 45, 5, 7, "лысая", 10),
        new Rabbit("Леденец", 50, 45, 5, 9, "черный", 10),
        new Dog("Бобик", 50, 46, 5, 3, "в полоску", "карие"),
        new Cat("Лапочка", 50, 45, 5, 4, "серая", 10),
        new Rabbit("Корн", 50, 45, 5, 1, "белый", 15),
        new Dog("Брат Бобика", 50, 46, 5, 2, "в полоску", "голубой"),
        new Cat("Муся", 50, 45, 5, 5, "рыжая", 10),
        new Rabbit("Заика", 50, 45, 5, 2, "белый", 15),
        new Dog("Лайка", 50, 46, 5, 4, "в полоску", "голубой"),
        new Cat("Лена", 50, 45, 5, 7, "рыжая", 10),
        new Rabbit("Лотос", 50, 45, 5, 8, "белый", 15),
        new Dog("Мяу", 50, 46, 5, 9, "черная", "зеленый"),
        new Cat("Гав", 50, 45, 5, 2, "рыжая", 10),
        new Rabbit("Солнышко", 50, 45, 5, 1, "серый", 20),
        new Dog("Даг", 50, 46, 5, 1, "в полоску", "голубой"),
        new Cat("Мелисса", 50, 45, 5, 3, "лысая", 10),
        new Rabbit("Фырк", 50, 45, 5, 3, "черный", 10),
        new Dog("Лиана", 50, 46, 5, 2, "в полоску", "карие"),
        new Cat("Егор", 50, 45, 5, 3, "серая", 10),
        new Rabbit("Чипс", 50, 45, 5, 4, "белый", 15)
        };

        Console.WriteLine("Приютили животных!<3");

        shelters[0].Add(homeless_animals[..5]);
        shelters[1].Add(homeless_animals[5..10]);
        shelters[2].Add(homeless_animals[10..15]);
        homeless_animals = homeless_animals[15..];

        string path = @"C:\Users\ADM\Desktop";
        string folderName = "Shelters_info";
        path = Path.Combine(path, folderName);
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
        string fileName1 = "raw_data.json";
        fileName1 = Path.Combine(path, fileName1);

        MyJsonSerializer f = new MyJsonSerializer();
        if (!File.Exists(fileName1))
        {
            f.Write(shelters, fileName1);
        }
        else
        {
            Shelter[] t1 = f.Read(fileName1);
            foreach (Shelter t2 in t1)
            {
                Console.WriteLine(t2);
            }
        }
        Console.WriteLine("О! Приютили еще парочку");

        shelters[0].Add(homeless_animals[..5]);
        shelters[1].Add(homeless_animals[5..10]);
        shelters[2].Add(homeless_animals[10..]);

        string fileName2 = "data.json";
        fileName2 = Path.Combine(path, fileName2);
        if (!File.Exists(fileName2))
        {
            f.Write(shelters, fileName2);
        }
        else
        {
            Shelter[] t1 = f.Read(fileName2);
            foreach (Shelter t2 in t1)
            {
                Console.WriteLine(t2);
            }
        }

        Console.WriteLine("Некоторые нашли новый дом!");

        shelters[0].Remove(shelters[0].Animals[0]);
        shelters[1].Remove(shelters[1].Animals[0]);
        shelters[2].Remove(shelters[2].Animals[0]);

        string fileName3 = "new_data.json";
        fileName3 = Path.Combine(path, fileName3);
        if (!File.Exists(fileName3))
        {
            f.Write(shelters, fileName3);
        }
        else
        {
            Shelter[] t1 = f.Read(fileName3);
            foreach (Shelter t2 in t1)
            {
                Console.WriteLine(t2);
            }
        }

        //ДОПОЛНИТЕЛЬНАЯ ЧАСТЬ 
        MyXmlSerializer x = new MyXmlSerializer();

        Console.WriteLine("Забрали по 3 самых старших!");
        shelters[0].Sort_animals();
        shelters[1].Sort_animals();
        shelters[2].Sort_animals();

        for (int i = 0; i < 3; i++)
        {
            shelters[0].Remove(shelters[0].Animals[i]);
            shelters[1].Remove(shelters[1].Animals[i]);
            shelters[2].Remove(shelters[2].Animals[i]);
        }

        string fileName4 = "raw_data.xml";
        fileName4 = Path.Combine(path, fileName4);
        if (!File.Exists(fileName4))
        {
            x.Write(shelters, fileName4);
        }
        else
        {
            Shelter[] t3 = x.Read(fileName4);
            foreach (Shelter t2 in t3)
            {
                Console.WriteLine(t2);
            }
        }

        Console.WriteLine("Ура! первый приют приютил по 5 животных каждого вида");
        Animal[] cats = new Animal[5]
        {
            new Cat("Кот1", 50, 45, 5, 1, "серый", 10),
            new Cat("Кот2", 50, 45, 5, 3, "белый", 10),
            new Cat("Кот3", 50, 45, 5, 5, "рыжий", 10),
            new Cat("Кот4", 50, 45, 5, 6, "черный", 10, true),
            new Cat("Кот5", 50, 45, 5, 9, "лиловый", 10)
        };
        Animal[] dogs = new Animal[5]
        {
            new Dog("Собака", 50, 46, 5, 3, "в горошек", "черный"),
            new Dog("Пес", 50, 46, 5, 6, "в полоску", "голубой"),
            new Dog("Щенок", 50, 46, 5, 10, "длинная", "карие"),
            new Dog("Собачка", 50, 46, 5, 4, "однотонная", "синие", true),
            new Dog("Собакен", 50, 46, 5, 1, "в полоску", "голубой")
        };
        Animal[] rabbits = new Animal[5] 
        {
            new Rabbit("Заяц1", 50, 45, 5, 1, "серый", 20, true),
            new Rabbit("Зайка", 50, 45, 5, 3, "белый", 20),
            new Rabbit("Зайчонок", 50, 45, 5, 6, "черный", 20, true),
            new Rabbit("Зайчушка", 50, 45, 5, 7, "серый", 20),
            new Rabbit("Заинька", 50, 45, 5, 2, "черный", 20)
        };

        shelters[0].Add(cats);
        shelters[0].Add(dogs);
        shelters[0].Add(rabbits);

        Animal[] remove_rebbits = shelters[0].Remove_animals_older_than_int("Rabbit", 2);
        Animal[] remove_cat = shelters[0].Remove_animals_older_than_int("Cat", 4);
        Animal[] remove_dog = shelters[0].Remove_animals_older_than_int("Dog", 6);
        shelters[0].Remove(remove_rebbits);
        shelters[0].Remove(remove_cat);
        shelters[0].Remove(remove_dog);

        string fileName5 = "data.xml";
        fileName5 = Path.Combine(path, fileName5);
        if (!File.Exists(fileName5))
        {
            x.Write(shelters, fileName5);
        }
        else
        {
            Shelter[] t4 = x.Read(fileName5);
            foreach (Shelter t2 in t4)
            {
                Console.WriteLine(t2);
            }
        }

    }
}