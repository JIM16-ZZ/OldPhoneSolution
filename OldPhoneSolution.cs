using System;

namespace OldPhone
{
    class OldPhoneSolution
    {
        /// <summary>
        ///The starting point of the program. It takes what the user types and changes it into letters using an old-style phone keypad.
        /// </summary>
        static void Main(string[] args)
        {
            Console.Write("Enter String Inputs: ");
            string userInput = Console.ReadLine();

            string result = PhonePad.TranslateInput(userInput);
            Console.WriteLine("Output: " + result);
            Console.WriteLine("\nPress any keys to Exit!");
            Console.ReadKey();
        }
    }

    public static class PhonePad
    {
        /// <summary>
        /// Translates a sequence of key presses from an old phone keypad into readable text.
        /// </summary>
        public static string TranslateInput(string input)
        {
            string result = "";
            string currentSequence = "";
            char previousKey = '\0';

            foreach (char ch in input)
            {
                if (ch == '#')
                {
                    result += ConvertKeySequence(currentSequence);
                    break;
                }
                else if (ch == '*')
                {
                    result += ConvertKeySequence(currentSequence);
                    if (result.Length > 0)
                        result = result.Substring(0, result.Length - 1);
                    currentSequence = "";
                    previousKey = '\0';
                }
                else if (ch == ' ')
                {
                    result += ConvertKeySequence(currentSequence);
                    currentSequence = "";
                    previousKey = '\0';
                }
                else if (char.IsDigit(ch))
                {
                    if (ch == previousKey || previousKey == '\0')
                    {
                        currentSequence += ch;
                    }
                    else
                    {
                        result += ConvertKeySequence(currentSequence);
                        currentSequence = ch.ToString();
                    }
                    previousKey = ch;
                }
            }
            // Fallback in case input doesn't end with #
            result += ConvertKeySequence(currentSequence);
            return result;
        }
        /// <summary>
        /// Matches a series of number key presses to the correct letters, like on old mobile phone keypads.
        /// </summary>
        private static string MapKeySequence(string sequence)
        {
           if (string.IsNullOrEmpty(sequence))
                return "";

            char key = sequence[0];
            int count = sequence.Length;

            int position = 0;

            switch (key)
            {
                case '2':
                    position = (count - 1) % 3;
                    return "ABC"[position].ToString();
                case '3':
                    position = (count - 1) % 3;
                    return "DEF"[position].ToString();
                case '4':
                    position = (count - 1) % 3;
                    return "GHI"[position].ToString();
                case '5':
                    position = (count - 1) % 3;
                    return "JKL"[position].ToString();
                case '6':
                    position = (count - 1) % 3;
                    return "MNO"[position].ToString();
                case '7':
                    position = (count - 1) % 4;
                    return "PQRS"[position].ToString();
                case '8':
                    position = (count - 1) % 3;
                    return "TUV"[position].ToString();
                case '9':
                    position = (count - 1) % 4;
                    return "WXYZ"[position].ToString();
                case '0':
                    return " ";
                default:
                    return "";
            }
        }
    }
}
