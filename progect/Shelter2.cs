using System.Collections.Generic;
using System.Text.Json.Serialization;

public partial class Shelter : ICountable
{
    public void Sort_animals()
    {
        for (int i = 0; i < animals.Count; i++)
        {
            for (int j = i; j < animals.Count; j++)
                if (animals[i].Age < animals[j].Age)
                {
                    Animal person_now = animals[j];
                    animals[j] = animals[i];
                    animals[i] = person_now;
                }
        }
    }
    public void Print_animals_age(int age)
    {
        for (int i = 0; i < animals.Count; i++)
        {
            if (animals[i].Age > age)
            {
                Console.WriteLine(animals[i]);
            }
        }
    }

    public Animal[] Remove_animals_older_than_int(string type, int age)
    {
        Animal[] remove_list = new Animal[animals.Count];
        int j = 0;
        for (int i = 0; i < animals.Count; i++)
        {
            if (animals[i].Age > age) {
                if (type == "Cat" && animals[i] is Cat)
                {
                    remove_list[j] = animals[i];
                    j++;
                }
                else if (type == "Dog" && animals[i] is Dog)
                {
                    remove_list[j] = animals[i];
                    j++;
                }
                else if (type == "Rabbit" && animals[i] is Rabbit)
                {
                    remove_list[j] = animals[i];
                    j++;
                } 
            }
        }
        remove_list = remove_list[..j];
        return remove_list;
    }
}

