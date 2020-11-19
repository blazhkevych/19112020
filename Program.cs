// Колекції, generic
using System;
using System.Collections;

namespace _19112020
{
    public static class ShowCollections
    {
        public static void Print(this ArrayList list, string title = null)
        {
            if (title != null) Console.WriteLine(title + ":");
            foreach (var item in list)
                Console.Write($"{item}\t");
            Console.WriteLine();
        }
        public static void Print(this Hashtable table, string title = null)
        {
            if (title != null) Console.WriteLine(title + ":");
            //foreach (DictionaryEntry item in table)
            //    Console.WriteLine($"{item.Key}\t{item.Value}");
            foreach (var key in table.Keys)
                Console.WriteLine($"{key}\t{table[key]}  {key.GetHashCode()}");
            Console.WriteLine();
        }
    }
    class CMP_int : IComparer
    {
        public int Compare(object x, object y)
        {
            if (x is Int32 X && y is Int32 Y)
                return -X.CompareTo(Y);
            throw new InvalidCastException();
        }
    }
    // class Point<T> where T: struct
    // class Point<T> where T: class
    // class Point<T> where T: new()
    // class Point<T> where T: BaseClass
    //  class Point<T> where T: ImyIterface
    class Point<T, U> where T : struct where U : class, new()
    {
    }
    class Point<T>
    {
        public static T Position;
        private T x;
        public T X
        {
            set { x = value; }
            get { return x; }
        }
        public T Y { set; get; }
        public Point()
        {
            this.x = default;
            Y = default(T);
        }
        public Point(T x, T y)
        {
            this.x = x;
            Y = y;
        }
        public void Reset()
        {
            this.x = default;
            Y = default(T);
        }
        public override string ToString()
        {
            return $"({X};{Y}) Position={Position}";
        }
    }
    class Circle : Point<int>
    {
        public int R { get; set; }
        public Circle()
        {
            R = 0;
        }
        public Circle(int r, int x, int y) : base(x, y)
        {
            R = r;
        }
        public override string ToString()
        {
            return $"{base.ToString()} R={R}";
        }
    }
    class Kolo<K>
    {
        public class Point<T>
        {
            public static T Position;
            private T x;
            public T X
            {
                set { x = value; }
                get { return x; }
            }
            public T Y { set; get; }
            public Point()
            {
                this.x = default;
                Y = default(T);
            }
            public Point(T x, T y)
            {
                this.x = x;
                Y = y;
            }
            public void Reset()
            {
                this.x = default;
                Y = default(T);
            }
            public override string ToString()
            {
                return $"({X};{Y}) Position={Position}";
            }
        }

        private Point<K> center;
        public K R { get; set; }
        public Kolo()
        {
            R = default;
            center = new Point<K>();
        }
        public Kolo(K r, K x, K y)
        {
            R = r;
            center = new Point<K>(x, y);
        }
        public override string ToString()
        {
            return $"{center} R={R}";
        }

    }
    class Circle<T> : Point<T> //where T:struct
    {
        public T R { get; set; }
        public Circle()
        {
            R = default;
        }
        public Circle(T r, T x, T y) : base(x, y)
        {
            R = r;
        }
        public override string ToString()
        {
            return $"{base.ToString()} R={R}";
        }

    }
    class Program
    {
        static void TestArrayListO()
        {
            ArrayList list = new ArrayList();
            list.Add(10);
            list.Add(20.96);
            list.Add(-30);
            list.Add("It Step");
            list.AddRange(new string[]
                {"It"," Step","Zhytomyr"});
            list.Print("list");
            list.Insert(1, 999);
            list.Print("list");
            Console.WriteLine();
            // for (int i = 0; i < 100; i++)
            // {
            //     list.Add(i);
            //     Console.WriteLine("Count = " + list.Count);
            //     Console.WriteLine("Capacity = " + list.Capacity);
            //  }
            list.Remove(20.96);
            list.RemoveRange(3, 4);
            list.Print("list");
            //list[0] = 88.8;
            list[0] = 888;
            list.Print("list");
            if (list.Contains(888))
                Console.WriteLine("Yes");
            else
                Console.WriteLine("No");
            Console.WriteLine(list.IndexOf(-30));
            list.Sort();
            list.Print("sort list");
            double s = 0;
            foreach (var item in list)
            {
                if (item is Int32 i)
                    s += i;
                else if (item is Double d)
                    s += d;
            }
            //list.Reverse();
            list.AddRange(new int[]
                {10,-10,20,55,-30});
            list.Sort(new CMP_int());
            list.Print("sort list");
            Console.Write($"s={s}\t");
        }
        static void TestStackO() { }
        static void TestQueueO() { }
        static void TestHashTableO()
        {
            Hashtable table = new Hashtable
            {
                {1,"Petro" },
                {2.6,"Sitro" },
                {"Ira","Retro" },
                {4,"Metro" },
            };
            table.Print();
            table.Add(10, "Ivan");
            table[555] = "Stepan";
            // table.Add(555, "Maks");
            table[555] = "Maks";
            table.Print();
            //  if (table.Contains(10))
            if (table.ContainsKey(10))
                Console.WriteLine("Yes key");
            else
                Console.WriteLine("No key");

        }
        static void TestGen()
        {
            Point<int>.Position = 10;
            Point<string>.Position = "XYZ";

            Point<int> pintd = new Point<int>();
            Console.WriteLine(pintd);
            Point<int> pint = new Point<int>(5, 10);
            Console.WriteLine(pint);
            pint.Reset();
            Console.WriteLine(pint);
            Point<string> pstring = new Point<string>("It", "Step");
            Console.WriteLine(pstring);
            pstring.Reset();
            Console.WriteLine(pstring);
            Circle circle = new Circle(10, 20, 30);
            Console.WriteLine(circle);
            Circle<String> cir = new Circle<string>(x: "x", y: "y", r: "R");
            Console.WriteLine(cir);
            Kolo<double> kolo = new Kolo<double>(9.99, 5.69, 3.21);
            Console.WriteLine(kolo);
            Kolo<int>.Point<string> tt = new Kolo<int>.Point<string>("www", "ttt");
            var tt2 = new Kolo<int>.Point<string>("www", "ttt");
            Console.WriteLine(tt);
            Console.WriteLine(tt2);

        }

        static void swap<T>(ref T a, ref T b)
        {
            T t = a;
            a = b;
            b = t;
        }
        static T Max<T>(T[] mas) where T : IComparable<T>
        {
            T max = mas[0];
            foreach (var item in mas)
            {
                if (item.CompareTo(max) > 0)
                    max = item;
            }
            return max;
        }


        static void Main(string[] args)
        {
            // TestArrayListO();
            // TestHashTableO();
            //TestGen();
            int a = 10;
            int b = 20;
            swap(ref a, ref b);
            Console.WriteLine($"a={a} b={b}");
            double a1 = 10.10;
            double b1 = 20.20;
            swap(ref a1, ref b1);
            Console.WriteLine($"a1={a1} b1={b1}");
            int[] masint = { 10, 30, -90, 3, 66, 5, 59, 63 };
            double[] masdouble = { 10.25, 30.25, -90.52, 3.25, 66.25, 5.52, 5.9, 6.3 };
            Console.WriteLine($"masint={Max(masint)}");
            Console.WriteLine($"masdouble={Max(masdouble)}");
        }
    }
}