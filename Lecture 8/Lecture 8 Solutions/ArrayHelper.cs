using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture_8_Solutions
{
    public static class ArrayHelper
    {
        public static T[] Filter<T>(T[] array, Predicate<T> predicate)
        {
            List<T> output = new List<T>();

            foreach(T elem in array)
            {
                if (predicate(elem))
                    output.Add(elem);
            }
            return output.ToArray();
        }

        public static T2[] Map<T1, T2>(T1[] array, Func<T1, T2> mappingFunc)
        {
            T2[] output = new T2[array.Length];

            for (int i = 0; i < array.Length; i++)
                output[i] = mappingFunc(array[i]);

            return output;
        }

        public static void Sort<T>(T[] array, Func<T, T, int> comparerFunc)
        {
            // bubble sort
            for(int i = 0; i < array.Length - 1; i++)
            {
                for(int j = 0; j < array.Length - i - 1; j++)
                {
                    if(comparerFunc(array[j], array[j + 1]) < 0)
                    {
                        T temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            } 
        }

        public static T Find<T>(T[] array, Predicate<T> predicate)
        {
            foreach(T elem in array)
            {
                if (predicate(elem))
                    return elem;
            }
            return default(T);
        }

        public static bool Contains<T>(T[] array, Predicate<T> predicate)
        {
            foreach(T elem in array)
            {
                if (predicate(elem))
                    return true;
            }
            return false;
        }
    }
}
