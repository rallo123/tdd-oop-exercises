using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture_7_Solutions
{
    public static class ArrayHelper
    {
        public static T Min<T>(T[] array) where T : IComparable
        {
            if (array == null)
                throw new ArgumentNullException();
            if (array.Length == 0)
                return default(T);

            T lowestValue = array[0];

            for(int i = 1; i < array.Length; i++)
            {
                if (array[i].CompareTo(lowestValue) < 0)
                    lowestValue = array[i];
            }

            return lowestValue;
        }

        public static T Max<T>(T[] array) where T : IComparable
        {
            if (array == null)
                throw new ArgumentNullException();
            if (array.Length == 0)
                return default(T);

            T highestValue = array[0];

            for (int i = 1; i < array.Length; i++)
            {
                if (array[i].CompareTo(highestValue) > 0)
                    highestValue = array[i];
            }

            return highestValue;
        }

        public static T[] Copy<T>(T[] array)
        {
            if (array == null)
                throw new ArgumentNullException();

            T[] copyOfArray = new T[array.Length];

            for (int i = 0; i < array.Length; i++)
                copyOfArray[i] = array[i];

            return copyOfArray;
        }

        public static void Shuffle<T>(T[] array)
        {
            if (array == null)
                throw new ArgumentNullException();

            Random random = new Random();

            for (int i = 0; i < array.Length; i++)
            {
                int j = random.Next(0, array.Length - 1);

                T temp = array[i];
                array[i] = array[j];
                array[j] = temp;
            }
        }
    }
}
