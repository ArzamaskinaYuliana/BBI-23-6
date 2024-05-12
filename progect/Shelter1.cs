using System.Text.Json.Serialization;
using System.Xml.Serialization;

[Serializable]
[XmlInclude(typeof(Animal))]
[XmlInclude(typeof(Cat))]
[XmlInclude(typeof(Dog))]
[XmlInclude(typeof(Rabbit))]
public partial class Shelter : ICountable
{
    [XmlAttribute]
    private string name;
    [XmlAttribute]
    private int maxCount;
    [XmlAttribute]
    private bool isOutdoorNursery;
    [XmlAttribute]
    private List<Animal> animals;

    public Shelter(string name, int maxCount, bool isOut)
    {
        this.name = name;
        this.maxCount = maxCount;
        isOutdoorNursery = isOut;
        animals = new List<Animal>(maxCount);
    }

    [JsonConstructor]
    public Shelter(string name, int maxCount, bool isOutdoorNursery, List<Animal> animals)
    {
        this.name = name;
        this.maxCount = maxCount;
        this.isOutdoorNursery = isOutdoorNursery;
        this.animals = animals;
        Check_animals();
    }

    public Shelter() { }

    public override string ToString()
    {
        return $"Информация о питомнике: Название - {Name}; Максимальное кол-во мест - {MaxCount}; Мест занято - {animals.Count}; На воздухе или нет - {IsOutdoorNursery}";
    }

    public List<Animal> Animals
    {
        get => animals;
        set => animals = value;
    }
    public string Name
    {
        get => name;
        set => name = value;
    }
    public int MaxCount
    {
        get => maxCount;
        set => maxCount = value;
    }
    public bool IsOutdoorNursery
    {
        get => isOutdoorNursery;
        set => isOutdoorNursery = value;
    }

    public void Add(Animal new_animal)
    {
        if (!new_animal.Claustrophobia || (new_animal.Claustrophobia && isOutdoorNursery))
        {
            animals.Add(new_animal);
        }
    }

    public void Add(Animal[] new_animals)
    {
        for (int i = 0; i < new_animals.Length; i++)
        {
            if (!new_animals[i].Claustrophobia || (new_animals[i].Claustrophobia && isOutdoorNursery))
            {
                animals.Add(new_animals[i]);
            }
        }
    }

    public void Remove(Animal remove_animal)
    {
        for (int i = 0; i < animals.Count; i++)
        {
            if (animals[i] == remove_animal)
            {
                animals.RemoveAt(i);
                break;
            }
        }
    }

    public void Remove(Animal[] remove_animals)
    {
        for (int i = 0; i < remove_animals.Length; i++)
        {
            animals.Remove(remove_animals[i]);
        }
    }

    public int Count()
    {
        return animals.Count;
    }

    public int Count(string type)
    {
        int kolvo = 0;
        for (int i = 0; i < animals.Count; i++)
        {
            if (type == "Cat" && animals[i] is Cat)
            {
                kolvo++;
            }
            if (type == "Dog" && animals[i] is Dog)
            {
                kolvo++;
            }
            if (type == "Rabbit" && animals[i] is Rabbit)
            {
                kolvo++;
            }
        }
        return kolvo;
    }

    public int Percentage(string type)
    {
        int k = Count(type);
        int all = Count();
        return k * 100 / all;
    }
}

