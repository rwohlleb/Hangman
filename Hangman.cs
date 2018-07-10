using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Hangman
{
    class Hangman
    {
        static void Main(string[] args)
        {
            Hangman hangman = new Hangman();
            List<String> dictionary = hangman.FillDictionary();
            int numberOfGuesses = 10;
            Boolean isPlaying = true;
            Boolean win = false;
            Char guess;
            Char play;
            String guessedLetters = "";

            while (isPlaying == true)
            {
                String word = hangman.SelectWord(dictionary);
                word = word.ToUpper();
                String temp = "";
                Boolean isFound = false;

                for (int i = 0; i < word.Count(); i++)
                {
                    if (word.ElementAt(i) != ' ')
                    {
                        temp = temp + "_";
                    }
                    else
                        temp = temp + " ";
                }

                for (int i = 0; i < numberOfGuesses; i++)
                {
                    isFound = false;
                    Console.Clear();
                    for (int z = 0; z < temp.Length; z++)
                    {
                        Console.Write(" " + temp[z]);
                    }
                    Console.WriteLine();
                    Console.WriteLine("You have " + (numberOfGuesses - i) + " guesses left.");
                    Console.WriteLine();
                    Console.WriteLine("Previous guesses:");
                    Console.WriteLine(guessedLetters);
                    Console.WriteLine();
                    Console.WriteLine("Enter Guess: ");
                    


                    guess = Convert.ToChar(Console.ReadLine().ToUpperInvariant()[0]);
                    Console.WriteLine(guess);
                    guessedLetters += guess.ToString() + " ";
                    

                    for (int k = 0; k < word.Length; k++)
                    {
                        if (word[k] == guess)
                        {
                            temp = ReplaceAt(temp, k, guess);
                            isFound = true;
                        }

                    }

                    if (isFound)
                    {
                        i--;
                    }

                    if (!temp.Contains('_'))
                    {
                        i = numberOfGuesses;
                        win = true;
                    }
                }

                Console.Clear();
                Console.WriteLine("Your word was : " + word);

                if (win)
                {
                    
                    Console.WriteLine("You win!");
                }
                else
                {
                    Console.WriteLine("You lose!");
                }

                Console.WriteLine("Would you like to continue playing? Y/N");
                play = Convert.ToChar(Console.ReadLine().ToUpperInvariant());
                if (play == 'Y')
                {
                    isPlaying = true;
                }
                else
                {
                    isPlaying = false;
                }
            }
        }

        private List<String> FillDictionary()
        {
            try
            {
                StreamReader readingMachine = new StreamReader(@"ENTER WORDS.TXT PATH HERE");
                List<String> myList = new List<String>();
                String str = "";
                while ((str = readingMachine.ReadLine()) != null)
                {
                    myList.Add(str);
                }
                return myList;
            }
            catch (IOException e)
            {
                return null;
            }
        }

        private String SelectWord(List<String> dictionary)
        {
            Random rand = new Random();
            int index = rand.Next(dictionary.Count());
            return dictionary[index];
        }

        public static string ReplaceAt(string input, int index, char newChar)
        {
            char[] chars = input.ToCharArray();
            chars[index] = newChar;
            return new string(chars);
        }
    }
}