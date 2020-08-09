using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConverterANSII
{
    class MyConverterANSII
    {
        /// <summary>
        /// разряды числа (целого, int32)
        /// </summary>
        private List<byte> numbers = new List<byte> { };

        /// <summary>
        /// Переводит число в код ANSII (от 0 до 9) 
        /// </summary>
        /// <param name="number">Число от 0 до 9</param>
        /// <returns>Код числа</returns>
        private byte ConversionNumber(byte number)
        {
            if (number >= 0 && number <= 9) return number += 48;    // 48 = 0 в таблице ANSII

            return 255;
        }

        /// <summary>
        /// Переводит строку в число (целое)
        /// </summary>
        /// <param name="number">Введенная строка</param>
        /// <returns>Числовое значение строки</returns>
        private int ConversionString(string number)
        {
            int temp = -1;
            try
            {
                temp = Convert.ToInt32(number);
            }
            catch (OverflowException)
            {
                Console.WriteLine("{0} is outside the range of the Int32 type.", number);
            }
            catch (FormatException) 
            {
                Console.WriteLine("The {0} value '{1}' is not in a recognizable format.", number.GetType().Name, number);
            }
            return temp;
        }

        /// <summary>
        /// Разбивает десятичное число (целое) на разряды
        /// </summary>
        /// <param name="number">Целое число</param>
        private void SplitNumber(int number)
        {
            byte temp;
            numbers.Clear();

            while (number > 0)
            {
                temp = (byte)(number % 10);
                numbers.Add(temp);
                number /= 10;
            }

            numbers.Reverse();
        }
       
        /// <summary>
        /// Получает строку, содежащую целое число и конвертирует разряды числа в коды ANSII 
        /// </summary>
        /// <param name="number">Входная строка</param>
        public List<byte> SetNumberString(string number)
        {
           SplitNumber(ConversionString(number));

            var sizeList = numbers.Count;

            for (int i = 0; i < sizeList; i++)
            {
                var temp = ConversionNumber(numbers[i]);
                numbers.RemoveAt(i);
                numbers.Insert(i, temp);
            }

            return numbers;
        }
    }
}
