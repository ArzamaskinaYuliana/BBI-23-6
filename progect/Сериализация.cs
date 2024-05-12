using ProtoBuf.Serializers;
using System.Text.Json;
using System.Xml.Serialization;

abstract class MySerializer
{
    public abstract void Write(Shelter[] animals, string fileName);
    public abstract Shelter[] Read(string fileName);
}
class MyJsonSerializer : MySerializer
{
    public override void Write(Shelter[] animals, string filePath)
    {
        using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
        {
            JsonSerializer.Serialize(fs, animals);
        }
    }
    public override Shelter[] Read(string fileName)
    {
        using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
        {
            return JsonSerializer.Deserialize<Shelter[]>(fs);
        }
    }
}

class MyXmlSerializer: MySerializer
{
    public override void Write(Shelter[] animals, string fileName)
    {
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(Shelter[]));
        using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
        {
            xmlSerializer.Serialize(fs, animals);
        }
    }
    public override Shelter[] Read(string fileName)
    {
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(Shelter[]));
        using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
        {
            Shelter[] t = (Shelter[])xmlSerializer.Deserialize(fs);
            return t;
        }
    }
}

