public partial class Shelter
{
    public bool Claustrophobia(Animal animal)
    {
        if (animal.Claustrophobia)
        {
            return true;
        }
        else return false;
    }

    public void Check_animals() //запускаем при создании закрытого питомника, чтобы убрать животных с клаустрофобией
    {
        if (!isOutdoorNursery)
        {
            for (int i = 0; i < animals.Count; i++)
            {
                if (Claustrophobia(animals[i]))
                {
                    animals.Remove(animals[i]);
                }
            }
        }
    }
}