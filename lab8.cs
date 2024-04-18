//using System;
//using System.Threading.Tasks;
//using System.Xml.Linq;
//using static System.Net.Mime.MediaTypeNames;

//abstract class Task
//{
//    protected string text;

//    public Task(string text)
//    {
//        this.text = text;
//    }
//    protected abstract void ParseText(string text);
//    protected abstract string Print(string text);

//    protected void Sort_para(string[] list_word, int[] list_count)
//    {
//        for (int i = 0; i < list_count.Length; i++)
//        {
//            for (int j2 = i; j2 < list_count.Length; j2++)
//                if (list_count[i] < list_count[j2])
//                {
//                    int old = list_count[j2];
//                    list_count[j2] = list_count[i];
//                    list_count[i] = old;
//                    string p = list_word[j2];
//                    list_word[j2] = list_word[i];
//                    list_word[i] = p;
//                }
//        }
//    }

//    protected string Replace_Para(string text, string[,] kode)
//    {
//        for (int i = 0; i < 5; i++)
//        {
//            text = text.Replace(kode[0, i], kode[1, i]);
//        }
//        return text;
//    }

//    protected string Reverse_Para(string text, string[,] kode)
//    {
//        for (int i = 0; i < 5; i++)
//        {
//            text = text.Replace(kode[1, i], kode[0, i]);
//        }
//        return text;
//    }

//    protected string Delete_symb(string text)
//    {
//        string[] t = new string[] { ",", ".", "?", "!", "-" };
//        for (int i = 0; i < t.Length; i++)
//        {
//            text = text.Replace(t[i], "");
//        }
//        return text;
//    }

//}

//class Task_8 : Task
//{
//    public Task_8(string text) : base(text)
//    {
//        ParseText(text);
//    }
//    protected override string Print(string text)
//    {
//        return "Ура! Текст разделен на строки по 50 символов:" + "\n" + "\n" + text;
//    }
//    public override string ToString()
//    {
//        return text;
//    }

//    private string Stroki_fifty_symb(string text)
//    {
//        string res = "";
//        string[] lines = text.Split(' ');

//        int PositionWordNow = 0;

//        while (PositionWordNow < lines.Length)
//        {
//            string line = lines[PositionWordNow];
//            int i = PositionWordNow + 1;
//            while (line.Length < 50 && i < lines.Length)
//            {
//                line = line + " " + lines[i];
//                i++;
//            }
//            if (line.Length > 50)
//            {
//                line = line.Substring(0, line.Length - lines[i - 1].Length);
//                PositionWordNow = i - 1;
//            }
//            if (line.Length < 50)
//            {
//                while (line.Length < 50)
//                {
//                    line = line + ' ';
//                }
//                PositionWordNow = i;
//            }
//            if (line.Length == 50)
//            {
//                PositionWordNow = i;
//            }
//            res += line + "\n";
//        }
//        return res;
//    }

//    protected override void ParseText(string text)
//    {
//        text = Stroki_fifty_symb(text);
//        this.text = Print(text);
//    }
//}

//class Task_9 : Task
//{

//    private string[] para;
//    private int[] count_kolvo_para;
//    private string[,] kode;

//    public string[,] Kode { get { return kode; } }

//    public Task_9(string text) : base(text)
//    {
//        ParseText(text);
//    }
//    protected override string Print(string text)
//    {
//        string s = "Ура! Текст сжат!" + "\n" + "Таблица кодов:";
//        for (int i = 0; i < 5; i++)
//        {
//            s += "\n" + $"{kode[0, i]} - {kode[1, i]}";
//        }
//        s += "\n" + "Пары и их количество:";

//        for (int i = 0; i < count_kolvo_para.Length; i++)
//        {
//            s += "\n" + $"пара {para[i]} количество {count_kolvo_para[i]}";
//        }
//        s += "\n" + "Сжатый текст:" + "\n" + text;
//        return s;
//    }

//    public override string ToString()
//    {
//        return text;
//    }

//    private void Find_Para(string text)
//    {
//        para = new string[text.Length - 1];
//        count_kolvo_para = new int[text.Length - 1];

//        int j = 0;
//        for (int i = 0; i < text.Length - 1; i++)
//        {
//            bool flag = false;
//            string new_para = text.Substring(i, 2);
//            for (int j2 = 0; j2 < para.Length; j2++)
//            {
//                if (para[j2] == new_para)
//                {
//                    count_kolvo_para[j2] += 1;
//                    flag = true;
//                    break;
//                }
//            }
//            if (flag == false)
//            {
//                para[j] = new_para;
//                count_kolvo_para[j] = 1;
//                j++;
//            }
//        }
//        para = para[0..j];
//        count_kolvo_para = count_kolvo_para[0..j];
//    }



//    protected override void ParseText(string text)
//    {
//        Find_Para(text);
//        Sort_para(para, count_kolvo_para);
//        kode = new string[2, 5] { { para[0], para[1], para[2], para[3], para[4] }, { "$", "@", "%", "#", "~" } };
//        text = Replace_Para(text, kode);
//        this.text = Print(text);
//    }
//}

//class Task_10 : Task
//{
//    private string[,] kode;
//    public Task_10(string old_text, string text) : base(text)
//    {
//        Task_9 ForCode = new Task_9(old_text);
//        kode = ForCode.Kode;
//        ParseText(text);
//    }

//    protected override string Print(string text)
//    {
//        return "Текст разжат!" + "\n" + "Текст:" + "\n" + text;
//    }

//    public override string ToString()
//    {
//        return text;
//    }

//    protected override void ParseText(string text)
//    {
//        text = Reverse_Para(text, kode);
//        this.text = Print(text);
//    }
//}

//class Task_12 : Task
//{
//    private string[] words;
//    private string[] wordss;
//    private int[] count_kolvo_words;
//    private string[,] kode;
//    private string copy_text;
//    public Task_12(string text) : base(text)
//    {

//        copy_text = text;
//        Make_table();
//        ParseText(copy_text);
//    }

//    private string[] Make_words_list()
//    {
//        text = Delete_symb(text);
//        string[] words = text.Split(" ");
//        return words;
//    }

//    private void Count_words()
//    {
//        int j = 0;
//        for (int i = 0; i < words.Length; i++)
//        {
//            bool flag = false;
//            string new_words = words[i];
//            for (int j2 = 0; j2 < wordss.Length; j2++)
//            {
//                if (wordss[j2] == new_words)
//                {
//                    count_kolvo_words[j2] += 1;
//                    flag = true;
//                    break;
//                }
//            }
//            if (flag == false)
//            {
//                wordss[j] = new_words;
//                count_kolvo_words[j] = 1;
//                j++;
//            }
//        }
//        wordss = wordss[0..j];
//        count_kolvo_words = count_kolvo_words[0..j];
//    }

//    protected override string Print(string text)
//    {
//        string s = "Ура! Текст расшифрован!" + "\n" + "Таблица кодов:";
//        for (int i = 0; i < 5; i++)
//        {
//            s += "\n" + $"{kode[0, i]} - {kode[1, i]}";
//        }
//        s += "\n" + "Пары и их количество:";

//        for (int i = 0; i < count_kolvo_words.Length; i++)
//        {
//            s += "\n" + $"пара {wordss[i]} количество {count_kolvo_words[i]}";
//        }
//        s += "\n" + "Tекст измененный:" + "\n" + text;
//        return s;
//    }
//    public override string ToString()
//    {
//        return text;
//    }

//    private void Make_table()
//    {
//        this.words = Make_words_list();
//        wordss = new string[words.Length];
//        count_kolvo_words = new int[words.Length];
//        Count_words();
//        Sort_para(wordss, count_kolvo_words);
//        kode = new string[2, 5] { { wordss[0], wordss[1], wordss[2], wordss[3], wordss[4] }, { "$", "@", "%", "#", "~" } };
//    }


//    protected override void ParseText(string copy_text)
//    {
//        copy_text = Replace_Para(copy_text, kode); // <-будто нам дали его изначально
//        copy_text = Reverse_Para(copy_text, kode);
//        this.text = Print(copy_text);
//    }
//}

//class Task_13 : Task
//{
//    private string[] words;
//    private char[] chars;
//    private int[] count_kolvo_word;

//    public Task_13(string text) : base(text)
//    {
//        words = text.Split(" ");
//        chars = new char[words.Length];
//        count_kolvo_word = new int[words.Length];
//        ParseText(text);
//    }

//    protected override string Print(string text)
//    {
//        string s = "Доля в процентах слов, начинающихся на различные буквы" + "\n" + "Процент:  Буква:" + "\n" + "\n";
//        for (int i = 0; i < chars.Length; i++)
//        {
//            s += $"{Persent(i)} - {chars[i]}" + "\n";
//        }
//        return s;
//    }
//    public override string ToString()
//    {
//        return text;
//    }

//    private void Count_Char()
//    {
//        int j = 0;
//        for (int i = 0; i < words.Length; i++)
//        {
//            bool flag = false;
//            char new_char = char.ToLower(words[i][0]);
//            for (int j2 = 0; j2 < chars.Length; j2++)
//            {

//                if (chars[j2] == new_char)
//                {
//                    count_kolvo_word[j2] += 1;
//                    flag = true;
//                    break;
//                }
//            }
//            if (flag == false)
//            {
//                chars[j] = new_char;
//                count_kolvo_word[j] = 1;
//                j++;
//            }
//        }
//        chars = chars[0..j];
//        count_kolvo_word = count_kolvo_word[0..j];
//    }

//    private int Persent(int i)
//    {
//        return 100 * count_kolvo_word[i] / words.Length;
//    }
//    protected override void ParseText(string text)
//    {
//        Count_Char();
//        this.text = Print(text);
//    }
//}

//class Task_15 : Task
//{
//    public Task_15(string text) : base(text)
//    {
//        ParseText(text);
//    }

//    protected override string Print(string sum)
//    {
//        return "Сумма чисел, найденных в тексте: " + sum;
//    }
//    public override string ToString()
//    {
//        return text;
//    }

//    private int Count_sum(string[] words)
//    {
//        int s = 0;
//        foreach (string word in words)
//        {
//            if (int.TryParse(word, out int number))
//            {
//                s += number;
//            }
//        }
//        return s;
//    }
//    protected override void ParseText(string text)
//    {
//        text = Delete_symb(text);
//        string[] words = text.Split(" ");
//        int sum = Count_sum(words);
//        this.text = Print($"{sum}");
//    }
//}

//class Program
//{
//    public static void Main()
//    {
//        Task_8 task8 = new Task_8("После многолетних исследований ученые обнаружили тревожную тенденцию в вырубке лесов Амазонии. Анализ данных показал, что основной участник разрушения лесного покрова – человеческая деятельность. За последние десятилетия рост объема вырубки достиг критических показателей. Главными факторами, способствующими этому, являются промышленные рубки, производство древесины, расширение сельскохозяйственных угодий и незаконная добыча древесины. Это приводит к серьезным экологическим последствиям, таким как потеря биоразнообразия, ухудшение климата и угроза вымирания многих видов животных и растений");
//        Console.WriteLine(task8);
//        Task_9 task9 = new Task_9("abcabddffeb");
//        Console.WriteLine(task9);
//        Task_10 task10 = new Task_10("abcabddffeb", "$c$~ffeb");
//        Console.WriteLine(task10);
//        Task_12 task12 = new Task_12("привет я юлиана мне 18 лет. привет, я прикол, я, я, я. ");
//        Console.WriteLine(task12);
//        Task_13 task13 = new Task_13("привет я юлиана мне 18 лет. привет, я прикол, я, я, я.");
//        Console.WriteLine(task13);
//        Task_15 task15 = new Task_15("посчитай 1 и 2 и еще 100 и даже 52.");
//        Console.WriteLine(task15);
//    }
//}

