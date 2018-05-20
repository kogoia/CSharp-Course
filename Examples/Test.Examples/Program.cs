using System;
using System.Collections.Generic;
using System.Linq;

namespace A
{
    class Program
    {
        public static void Main()
        {
            Output(
                Filter(
                    item => item > 3,
                    new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }
                )
             );

            Output(
                Map(
                    item => item * item,
                    new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }
                )
             );

            Output(
                Fold(
                    (prev, next) => prev + next,
                    0,
                    new[] { 1, 2, 3 }
                )
            );

            Output(
                Count(
                    new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }
                )
            );
        }

        static int Sum(int a, int b) => a + b;
        static int Min(int a, int b) => ((a + b) - Math.Abs(a - b)) / 2;
        static int Max(int a, int b) => a > b ? a : b;


        static int[] Map(Func<int, int> mapper, int[] arr)
            => Fold((prev, next) => Concat(prev, mapper(next)), new int[0], arr);

        static int[] Filter(Func<int, bool> pred, int[] arr) => Fold((prev, next) => pred(next) ? Concat(prev, next) : prev, new int[0], arr);

        static int[] Map(int[] arr, Func<int, int> fn)
            => IsEmpty(arr) ?
            arr :
            Concat(
                fn(
                    Head(arr)
                ),
                Map(
                    Tail(arr),
                    fn
                )
            );

        static T Fold<T>(Func<T, int, T> fn, T seed, int[] arr) => IsEmpty(arr) ? seed : Fold(fn, fn(seed, Head(arr)), Tail(arr));
        static int Count(int[] arr) => IsEmpty(arr) ? 0 : 1 + Count(Tail(arr));



        static bool IsEmpty(int[] arr) => arr.Length == 0;
        static int[] Concat(int a, int[] arr) => new List<int>() { a }.Concat(arr.ToList()).ToArray();
        static int[] Concat(int[] arr1, int a) => arr1.ToList().Concat(new List<int>() { a }).ToArray();
        static int Head(int[] arr) => arr[0];
        static int[] Tail(int[] arr) => arr.Length == 0 ? arr : arr.ToList().Skip(1).ToArray();
        static void Output(int[] arr)
        {
            arr.ToList().ForEach(item => Console.WriteLine(item));
            Console.WriteLine();
        }
        static void Output(int number) => Console.WriteLine(number);
    }
}

namespace B
{
    class Program
    {
        public static int Sum(int a, int b) => a + b;
    }
}