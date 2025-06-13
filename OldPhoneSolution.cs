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
            string output = "";
            string buffer = "";
            char previousChar = '\0';

            foreach (char currentChar in input)
            {
                switch (currentChar)
                {
                    case '#':
                        output += MapKeySequence(buffer);
                        return output;

                    case '*':
                        output += MapKeySequence(buffer);
                        if (output.Length > 0)
                            output = output.Substring(0, output.Length - 1);
                        buffer = "";
                        previousChar = '\0';
                        break;

                    case ' ':
                        output += MapKeySequence(buffer);
                        buffer = "";
                        previousChar = '\0';
                        break;

                    default:
                        if (char.IsDigit(currentChar))
                        {
                            if (currentChar == previousChar || buffer == "")
                            {
                                buffer += currentChar;
                            }
                            else
                            {
                                output += MapKeySequence(buffer);
                                buffer = currentChar.ToString();
                            }
                            previousChar = currentChar;
                        }
                        break;
                }
            }

            output += MapKeySequence(buffer);
            return output;
        }
        /// <summary>
        /// Matches a series of number key presses to the correct letters, like on old mobile phone keypads.
        /// </summary>
        private static string MapKeySequence(string sequence)
        {
            if (string.IsNullOrEmpty(sequence))
                return "";

            char key = sequence[0];
            int presses = sequence.Length;

            int Wrap(int count, int max) => (count - 1) % max;

            switch (key)
            {
                case '2': return "ABC"[Wrap(presses, 3)].ToString();
                case '3': return "DEF"[Wrap(presses, 3)].ToString();
                case '4': return "GHI"[Wrap(presses, 3)].ToString();
                case '5': return "JKL"[Wrap(presses, 3)].ToString();
                case '6': return "MNO"[Wrap(presses, 3)].ToString();
                case '7': return "PQRS"[Wrap(presses, 4)].ToString();
                case '8': return "TUV"[Wrap(presses, 3)].ToString();
                case '9': return "WXYZ"[Wrap(presses, 4)].ToString();
                case '0': return " ";//spacing
                default: return "";
            }
        }
    }
}
