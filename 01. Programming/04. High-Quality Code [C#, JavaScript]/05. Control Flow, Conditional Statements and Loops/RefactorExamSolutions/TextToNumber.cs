namespace RefactorExamSolutions
{
    using System;

    public class TextToNumber
    {
        private const int LowerCaseLetterMinimumValue = 97;
        private const int LowerCaseLetterMaximumValue = 122;
        private const int UpperCaseLetterMinimumValue = 65;
        private const int UpperCaseLetterMaximumValue = 90;

        public static void Main()
        {
            string textParser = Console.ReadLine();
            long textParserAsNumber = long.Parse(textParser);

            string text = Console.ReadLine();
            long finalResult = 0;

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == '@')
                {
                    Console.WriteLine(finalResult);
                    return;
                }
                else if (char.IsDigit(text[i]))
                {
                    finalResult *= text[i] - '0';
                }
                else if ((text[i] >= UpperCaseLetterMinimumValue && text[i] <= UpperCaseLetterMaximumValue) || 
                        (text[i] >= LowerCaseLetterMinimumValue && text[i] <= LowerCaseLetterMaximumValue))
                {
                    if (text[i] >= UpperCaseLetterMinimumValue && text[i] <= UpperCaseLetterMaximumValue)
                    {
                        finalResult += text[i] - UpperCaseLetterMinimumValue;
                    }
                    else if (text[i] >= LowerCaseLetterMinimumValue && text[i] <= LowerCaseLetterMaximumValue)
                    {
                        finalResult += text[i] - LowerCaseLetterMinimumValue;
                    }
                }
                else
                {
                    finalResult %= textParserAsNumber;
                }
            }

            Console.WriteLine(finalResult);
        }
    }
}
