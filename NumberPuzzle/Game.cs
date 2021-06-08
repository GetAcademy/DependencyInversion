using System;

namespace NumberPuzzle
{
    public class Game
    {
        private char[] _numbers = "1234567 8".ToCharArray();
        private IProgram _program;
        //private object _program;

        public Game(IProgram program)
        {
            _program = program;
        }

        public void Show()
        {
            Console.Clear();
            var numbersStr = new string(_numbers);
            Console.WriteLine(numbersStr.Substring(0, 3));
            Console.WriteLine(numbersStr.Substring(3, 3));
            Console.WriteLine(numbersStr.Substring(6, 3));
        }

        public void Play()
        {
            var consoleKeyInfo = Console.ReadKey();
            if (consoleKeyInfo.Key == ConsoleKey.LeftArrow) Move(1);
            if (consoleKeyInfo.Key == ConsoleKey.RightArrow) Move(-1);
            if (consoleKeyInfo.Key == ConsoleKey.DownArrow) Move(-3);
            if (consoleKeyInfo.Key == ConsoleKey.UpArrow) Move(3);
            if (IsSolved())
            {
                _program.OnSolved();
            }
        }

        private bool IsSolved()
        {
            return new string(_numbers) == "12345678 ";
        }

        private void Move(int changeInIndex)
        {
            var blankIndex = Array.FindIndex(_numbers, c => c == ' ');
            var otherIndex = blankIndex + changeInIndex;
            _numbers[blankIndex] = _numbers[otherIndex];
            _numbers[otherIndex] = ' ';
        }

        public void Run()
        {
            while (true)
            {
                if (!IsSolved()) Show();
                Play();
            }
        }
    }
}
