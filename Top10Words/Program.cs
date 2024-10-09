using System.Diagnostics;

namespace Top10Words
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            string filePath = @"C:\Users\nisso\Desktop\Text1.txt";
            string text = File.ReadAllText(filePath);
            string[] words = text.Split(new char[] { ' ', '\n', '.', '–', '*' }, StringSplitOptions.RemoveEmptyEntries);


            var wordFrequency = new Dictionary<string, int>();
            foreach (string word in words)
            {
                if (wordFrequency.ContainsKey(word))
                    wordFrequency[word]++;
                else
                    wordFrequency[word] = 1;
            }

            var top10Words = wordFrequency.OrderByDescending(pair => pair.Value)
                .Take(10)
                .ToList();

            Console.WriteLine("Это список слов, которые чаще всего встречались в указанном тексте:");
            for (int i = 0; i < top10Words.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {top10Words[i].Key}: {top10Words[i].Value} раз");
            }
        }
    }
}