using System.Text.Json.Serialization;
using System.Xml.Serialization;

[Serializable]
public class Animal
{
    [XmlAttribute]
    protected string name;
    [XmlAttribute]
    protected int length;
    [XmlAttribute]
    protected int height;
    [XmlAttribute]
    protected int weight;
    [XmlAttribute]
    protected int age;
    [XmlAttribute]
    protected bool claustrophobia;
    public bool Claustrophobia
    {
        get => claustrophobia;
        set => claustrophobia = value;
    }

    public string Name
    {
        get => name;
        set => name = value;
    }

    public int Length
    {
        get => length;
        set => length = value;
    }

    public int Height
    {
        get => height;
        set => height = value;
    }
    public int Weight
    {
        get => weight;
        set => weight = value;
    }
    public int Age
    {
        get => age;
        set => age = value;
    }

    [JsonConstructor]
    public Animal(string name, int length, int height, int weight, int age)
    {
        this.name = name;
        this.length = length;
        this.height = height;
        this.weight = weight;
        this.age = age;
    }
    public Animal() { }
    public virtual string ToString()
    {
        return "Информация о животном:" + "\n" + $"Имя - {name}" + "\n" + $"Длина - {length}" + "\n" + $"Высота - {height}" + "\n" + $"Вес - {weight}" + "\n" + $"Возраст - {age}" + "\n";
    }
}

[Serializable]
public class Cat : Animal
{
    [XmlAttribute]
    private string coloring;
    [XmlAttribute]
    private int tail_length;

    public string Coloring
    {
        get => coloring;
        set => coloring = value;
    }

    public int Tail_length
    {
        get => tail_length;
        set => tail_length = value;
    }


    [JsonConstructor]
    public Cat(string name, int length, int height, int weight, int age, string coloring, int tail_length) : base(name, length, height, weight, age)
    {
        this.coloring = coloring;
        this.tail_length = tail_length;
    }

    public Cat(string name, int length, int height, int weight, int age, string coloring, int tail_length, bool claustrophobia) : base(name, length, height, weight, age)
    {
        this.coloring = coloring;
        this.tail_length = tail_length;
        this.claustrophobia = claustrophobia;
    }

    public Cat() { }

    public override string ToString()
    {
        return "Информация о котике:" + "\n" + $"Имя - {name}" + "\n" + $"Длина - {length}" + "\n" + $"Высота - {height}" + "\n" + $"Вес - {weight}" + "\n" + $"Возраст - {age}" + "\n" + $"Окраска - {coloring}" + "\n" + $"Длина хвоста - {tail_length}" + "\n";
    }
}
[Serializable]
public class Dog : Animal
{
    [XmlAttribute]
    private string breed;
    [XmlAttribute]
    private string eye_color;

    public string Breed
    {
        get => breed;
        set => breed = value;
    }

    public string Eye_color
    {
        get => eye_color;
        set => eye_color = value;
    }


    [JsonConstructor]
    public Dog(string name, int length, int height, int weight, int age, string breed, string eye_color) : base(name, length, height, weight, age)
    {
        this.breed = breed;
        this.eye_color = eye_color;
    }
    public Dog(string name, int length, int height, int weight, int age, string breed, string eye_color, bool claustrophobia) : base(name, length, height, weight, age)
    {
        this.breed = breed;
        this.eye_color = eye_color;
        this.claustrophobia = claustrophobia;
    }
    public Dog() { }
    
    public override string ToString()
    {
        return "Информация о песике:" + "\n" + $"Имя - {name}" + "\n" + $"Длина - {length}" + "\n" + $"Высота - {height}" + "\n" + $"Вес - {weight}" + "\n" + $"Возраст - {age}" + "\n" + $"Порода - {breed}" + "\n" + $"Цвет глаз - {eye_color}" + "\n";
    }
}
[Serializable]
public class Rabbit : Animal
{
    [XmlAttribute]
    private string color;
    [XmlAttribute]
    private int ear_length;

    public string Color
    {
        get => color;
        set => color = value;
    }

    public int Ear_length
    {
        get => ear_length;
        set => ear_length = value;
    }


    [JsonConstructor]
    public Rabbit(string name, int length, int height, int weight, int age, string color, int tail_length) : base(name, length, height, weight, age)
    {
        this.color = color;
        this.ear_length = tail_length;
    }

    public Rabbit(string name, int length, int height, int weight, int age, string color, int tail_length, bool claustrophobia) : base(name, length, height, weight, age)
    {
        this.color = color;
        this.ear_length = tail_length;
        this.claustrophobia = claustrophobia;
    }
    public Rabbit() { }
    
    public override string ToString()
    {
        return "Информация о зайчике:" + "\n" + $"Имя - {name}" + "\n" + $"Длина - {length}" + "\n" + $"Высота - {height}" + "\n" + $"Вес - {weight}" + "\n" + $"Возраст - {age}" + "\n" + $"Цвет - {color}" + "\n" + $"Длина уха - {ear_length}" + "\n";
    }
}

interface ICountable
{
    int Count();
    int Count(string t);
    int Percentage(string t);
}