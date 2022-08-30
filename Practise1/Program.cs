using System;

namespace Practise1
{
    /// <summary>
    /// Main Program.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Starts the App.
        /// </summary>
        /// <param name="args">console call params.</param>
        public static void Main(string[] args)
        {
            if (args is null)
            {
                throw new ArgumentNullException(nameof(args));
            }

            var inputedString = Console.ReadLine();
            if (inputedString == null)
            {
                Console.WriteLine("Недопустимое значение строки");
            }
            else
            {
                var editedArray = new char[inputedString.Length];

                for (var i = 0; i < inputedString.Length; i++)
                {
                    bool digit = char.IsDigit(inputedString[i]);
                    switch (digit)
                    {
                        case false:
                            inputedString.CopyTo(i, editedArray, i, 1);
                            break;
                    }
                }

                Console.WriteLine("Исходная строка: " + inputedString);

                string newString = new string(editedArray);
                Console.WriteLine("Новая строка: " + newString);

                var upperString = newString.ToUpper();
                var spWords = upperString.Split(" ");
                var replacesString = spWords;
                for (int i = 0; i < spWords.Length; i++)
                {
                    var startsWith = spWords[i].StartsWith("P");
                    if (startsWith == true)
                    {
                        replacesString[i] = spWords[i].Replace("P", "S");
                    }

                    var endsWith = spWords[i].EndsWith("N");
                    if (endsWith == true)
                    {
                        replacesString[i] = spWords[i].Replace("N", "O");
                    }
                }

                var jointRepString = string.Join(" ", replacesString);
                var lowString = jointRepString.ToLower();
                var lastString = lowString;
                var lastWords = lowString.Split(" ");

                for (int i = 0; i < lastWords.Length; i++)
                {
                    if (lastWords[i].Length > 1)
                    {
                        lastWords[i] = $"{lastWords[i][..1].ToUpper()}{lastWords[i][1..].ToLower()}";
                    }
                    else
                    {
                        lastWords[i] = lastWords[i].ToUpper();
                    }

                    lastString = string.Join(" ", lastWords);
                }

                var words = lastString.Split(" ");

                string[] reverseString = new string[newString.Length];

                int count = 1;
                for (int i = 0; i < words.Length; i++)
                {
                    var word = words[i];
                    if (count % 2 == 0)
                    {
                        for (int k = 0; k < word.Length; k++)
                        {
                            reverseString[i] += word[word.Length - 1 - k];
                        }
                    }
                    else
                    {
                        reverseString[i] = word;
                    }

                    count++;
                }

                var result = string.Join(" ", reverseString);
                Console.Write("Финальная строка: " + result);
            }
        }
    }
}