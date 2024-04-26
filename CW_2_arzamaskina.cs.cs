using System;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

abstract class Task
{
    protected string text;
    public string Text
    {
        get => text;
        protected set => text = value;
    }
    public Task(string text)
    {
        this.text = text;
    }
    protected abstract void ParseText();
}

class Task1 : Task
{
    private string answer = "Сделали какие-то буквы больше, а другие меньше:" + "\n";
    public string Ans1
    {
        get => answer;
        protected set => answer = value;
    }
    [JsonConstructor]
    public Task1(string text) : base(text)
    {
        ParseText();
    }
    protected override void ParseText()
    {
        bool f = true; //нечетное
        for (int i = 0; i < text.Length; i++)
        {
            if (Char.IsLetter(text[i]) && f)
            {
                answer += char.ToLower(text[i]);
                f = false;
            }
            else if (Char.IsLetter(text[i]) && !f)
            {
                answer += char.ToUpper(text[i]);
                f = true;
            }
            else if (!Char.IsLetter(text[i]))
            {
                answer += text[i];
            }
        }
    }
    public override string ToString()
    {
        return answer;
    }
}

class Task2 : Task
{
    private string answer = "";
    public string Ans2
    {
        get => answer;
        protected set => answer = value;
    }
    [JsonConstructor]
    public Task2(string text) : base(text)
    {
        ParseText();
    }
    protected override void ParseText()
    {
        string dob = text;
        string[] symb = new string[] {".","!","?"};
        for (int i=0; i<symb.Length; i++)
        {
            dob = dob.Replace(symb[i], "$");
        }
        dob += " ";
        string[] predl = dob.Split("$ ");
        for (int j=0; j < predl.Length; j++)
        {
            string[] now_words = predl[j].Split(" ");
            for (int i = 0; i < now_words.Length / 2; i++)
            {
                string tmp = now_words[i];
                now_words[i] = now_words[now_words.Length - i - 1];
                now_words[now_words.Length - i - 1] = tmp;
            }
            string reverse_predl = String.Join(" ", now_words);
            if (j != predl.Length - 1)
            {
                reverse_predl += text[reverse_predl.Length + answer.Length] + " ";
            }
            answer += reverse_predl;
        }
    }
    public override string ToString()
    {
        return "Перевернули все предложния:" + "\n" + answer;
    }
}

class JsonText
{
    public static void Write<T>(T obj, string filePath)
    {
        using (FileStream f = new FileStream(filePath, FileMode.OpenOrCreate))
        {
            JsonSerializer.Serialize(f, obj);
        }
    }
    public static T Read<T>(string filePath)
    {
        using (FileStream f = new FileStream(filePath, FileMode.OpenOrCreate))
        {
            return JsonSerializer.Deserialize<T>(f);
        }
        return default(T);
    }
}

class Program
{
    static void Main()
    {
        Task1 text1 = new Task1("Буквы считаются с первой, сделай кого-то заглавной! Улулу АЙ-ай 45.");
        Console.WriteLine(text1);
        Task2 text2 = new Task2("Первернешь мое предложение? Хочу автоматом 5. Я очень стараюсь. Меня переверни!");
        Console.WriteLine(text2);
        Console.WriteLine();

        Task[] task12 = new Task[] { text1, text2 };

        string path = @"C:\Users\m2304640\Documents";
        string folder = "Control work";
        path = Path.Combine(path, folder);

        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }

        string f1 = "task_1.json";
        string f2 = "task_2.json";

        f1 = Path.Combine(path, f1);
        f2 = Path.Combine(path, f2);

        if (!File.Exists(f1))
        {
            JsonText.Write<Task1>(task12[0] as Task1, f1);
        }
        else
        {
            var fread1 = JsonText.Read<Task1>(f1);
            Console.WriteLine(fread1);
        }

        if (!File.Exists(f2))
        {
            JsonText.Write<Task2>(task12[1] as Task2, f2);
        }
        else
        {
            var fread2 = JsonText.Read<Task2>(f2);
            Console.WriteLine(fread2);
        }
    }
}
