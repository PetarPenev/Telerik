namespace _12.StackImplementation
{
    using System;

    public class StackTest
    {
        public static void Main()
        {
            NewStack<int> stack = new NewStack<int>(4);

            Console.WriteLine("Testing adding:");
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            Console.WriteLine(stack);
            Console.WriteLine();

            Console.WriteLine("Testing resizing:");
            stack.Push(4);
            stack.Push(5);
            Console.WriteLine(stack);
            Console.WriteLine();

            Console.WriteLine("Testing peeking:");
            Console.WriteLine(stack.Peek());
            Console.WriteLine(stack.Peek());
            Console.WriteLine();

            Console.WriteLine("Testing popping:");
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack);
            Console.WriteLine();

            Console.WriteLine("Testing contains:");
            Console.WriteLine("The stack contains 2: {0}", stack.Contains(2));
            Console.WriteLine("The stack contains 164: {0}", stack.Contains(164));
            Console.WriteLine();

            Console.WriteLine("Testing clearing:");
            stack.Clear();
            Console.WriteLine(stack);
        }
    }
}
