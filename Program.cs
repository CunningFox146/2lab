using System;
using System.Collections.Immutable;
using System.Globalization;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Text;

#nullable enable

namespace lab2
{
    class Task1
    {
        private static void Types()
        {
            bool Bool = false;
            byte Byte = 0;
            sbyte SmallByte = 0;
            char Char = 'a';
            decimal Dec = 3.1m;
            double Double = 1.0;
            float Float = 3.2f;
            int Int = -1;
            uint UnsignedInt = 1;
            long Long = -1;
            ulong UnsignedLong = 55;
            short Short = -1;
            ushort UnsignedShort = 55;
            object Obj = Bool; // Упаковка
            string Str = "Hello world";
            dynamic Dyn = 5;
            Dyn = 'a';

            Console.WriteLine($"Bool: {Bool}");
            Console.WriteLine($"Byte: {Byte}");
            Console.WriteLine($"SmallByte: {SmallByte}");
            Console.WriteLine($"Char: {Char}");
            Console.WriteLine($"Dec: {Dec}");
            Console.WriteLine($"Double: {Double}");
            Console.WriteLine($"Float: {Float}");
            Console.WriteLine($"Int: {Int}");
            Console.WriteLine($"UnsignedInt: {UnsignedInt}");
            Console.WriteLine($"Long: {Long}");
            Console.WriteLine($"UnsignedLong: {UnsignedLong}");
            Console.WriteLine($"Short: {Short}");
            Console.WriteLine($"UnsignedShort: {UnsignedShort}");
            Console.WriteLine($"Obj: {Obj}");
            Console.WriteLine($"Str: {Str}");
            Console.WriteLine($"Dyn: {Dyn}");

            Console.WriteLine("\nНеявные преобразования:");
            Console.WriteLine($"Byte -> Double: {Byte + Double}");
            Console.WriteLine($"Char -> Float: {Char + Float}");
            Console.WriteLine($"Float -> String: {Float + Str}");
            Console.WriteLine($"Dyn -> String: {Dyn + Str}");
            Console.WriteLine($"Obj (bool) -> String: {Obj + Str}");

            Console.WriteLine("\nЯвные преобразования:");
            Console.WriteLine($"Double -> Byte: {(byte)Double}");
            Console.WriteLine($"Float -> Char: {(char)Float}");
            Console.WriteLine($"Char -> Dyn: {(dynamic)Char}");
            Console.WriteLine($"Float -> Int: {(int)Float}");
            Console.WriteLine($"Uint -> Int: {(uint)Int}");
        }

        private static void Pack()
        {
            byte ToPack = 0;
            object Packed = ToPack;
            byte Unpacked = (byte)Packed;
            Console.WriteLine($"Unpacked: {Unpacked}");
        }

        private static void Dynamic()
        {
            dynamic Dyn = 0;
            Dyn = "test";
            Dyn = 0.1f;
            Console.WriteLine($"Dyn: {Dyn}");
        }

        private static void Nullable()
        {
            int? test = 1;
            test = null;
            Console.WriteLine($"Nullable: {test}");
            test = 1;
            Console.WriteLine($"Nullable: {test}");
        }

        public Task1()
        {
            Types();
            Pack();
            Dynamic();
            Nullable();
        }
    }

    class StringsTasks
    {
        private static void Task1()
        {
            string str1 = "Hello";
            string str2 = "World";
            Console.WriteLine("Comparison: {0}", str1 == str2);
        }

        private static void Task2()
        {
            string str1 = "str1";
            string str2 = "str2";
            string str3 = "str 3 str 2";

            string con = str1 + str2;
            string copy = new string(str1); // String.Copy(str1) is outdated

            string sub = str2.Substring(0, 3);

            string[] split = str3.Split(' ');

            Console.WriteLine($"Concat: {con}");
            Console.WriteLine($"Copy: {copy}");
            Console.WriteLine($"Sub: {sub}");
            Console.WriteLine($"Sub: {sub}");

            Console.WriteLine("Split:");
            for (byte i = 0; i < split.Length; i++)
            {
                Console.WriteLine(split[i]);
            }

            string NullStr1 = "";
            string? NullStr2 = null;
            Console.WriteLine($"Null str: {String.IsNullOrEmpty(NullStr1)}, Null: {String.IsNullOrEmpty(NullStr2)}");

            string insert = str1.Insert(2, str2);
            Console.WriteLine($"Insert: {insert}");

            string replace = str1.Replace("str", "new");
            Console.WriteLine($"Replace: {replace}");
        }

        public static void Builder()
        {
            StringBuilder stringBuilder = new StringBuilder("test");
            stringBuilder.Append("!");
            stringBuilder.Insert(0, "!");
            stringBuilder.Remove(1, 2);
            Console.WriteLine($"String: {stringBuilder.ToString()}, Size {stringBuilder.Capacity}");
        }

        public StringsTasks()
        {
            Console.WriteLine("\nStrings:");
            Task1();
            Task2();
            Builder();
        }
    }

    class Arrays
    {
        private static void Task1()
        {
            int[,] arr = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 }, { 10, 11, 12 } };

            int rows = arr.GetUpperBound(0) + 1;
            int columns = arr.Length / rows;

            for (byte i = 0; i < columns; i++)
            {
                for (byte j = 0; j < rows; j++)
                {
                    Console.Write($"{arr[j, i]} \t");
                }
                Console.WriteLine();
            }
        }

        private static void Task2()
        {
            string[] text = { "Hello", "World", "!" };
            int idx = Convert.ToInt32(Console.ReadLine());

            try
            {
                text[idx] = (string)Console.ReadLine();
            }
            catch {
                Console.WriteLine("Wrong index!");
            }

            Console.WriteLine();
            foreach (string word in text)
            {
                Console.WriteLine(word);
            }
        }

        private static void Task3()
        {
            int[][] arr = new int[3][];

            byte size = 2;
            for (byte i = 0; i < arr.Length; i++)
            {
                arr[i] = new int[size];
                size += 2;

                for (byte j = 0; j < arr[i].Length; j++)
                {
                    Console.WriteLine($"Input element #{j + 1} for row #{i + 1}");
                    arr[i][j] = Convert.ToInt32(Console.ReadLine());
                }
            }

            Console.WriteLine();
            foreach (int[] k in arr)
            {
                foreach (int v in k)
                {
                    Console.Write($"{v}\t");
                }
                Console.WriteLine();
            }
        }

        private static void Task4()
        {
            dynamic[] arr =
            {
                "test",
                1,
                '!',
                0.1f
            };
            Console.WriteLine();
            foreach (dynamic val in arr)
            {
                Console.WriteLine($"{val} : {val.GetType().ToString()}");
            }
        }

        public Arrays()
        {
            Task1();
            //Task2();
            //Task3();
            Task4();
        }
    }

    class Tuples
    {
        public Tuples()
        {
            (int, string, char, string, ulong) t1 = (1, "test", 'a', "!!!", 5555);
            (int, string, char, string, ulong) t = (1, "test", 'a', "!!!", 555);
            Console.WriteLine(t);
            Console.WriteLine($"{t.Item1}, {t.Item4}");

            var (test, kek, _, _, _) = t;
            Console.WriteLine($"{test}, {kek}");
            Console.WriteLine(t == t1);
        }
    }

    class Program
    {
        static void Main()
        {
            (int, int, int, char) Task5(int[] arr, string str)
            {
                Array.Sort(arr);

                int sum = 0;
                foreach (int val in arr) { sum += val; };

                return (arr[0], arr[arr.Length - 1], sum, str[0]);
            }

            Task1 task1 = new Task1();
            StringsTasks task2 = new StringsTasks();
            Arrays task3 = new Arrays();
            Tuples task4 = new Tuples();

            int[] arr = { 1, 5, 10, 20 };
            Console.WriteLine(Task5(arr, "Hello World"));

            void Checked()
            {
                int a = unchecked(2147483647);
            };

            void Unchecked()
            {
                int a = checked(2147483647);
            };
            Checked();
            Unchecked();
        }
    }
}
