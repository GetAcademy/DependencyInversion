using System;
using System.IO;
using NumberPuzzle;

namespace DependencyInversion
{
    class Program : IProgram
    {
        static void Main(string[] args)
        {
            var filename = @"C:\Users\Terje\source\repos\DependencyInversion\DependencyInversion\Program.cs";

            // v3:
            var myFileReader = new MyFileReader();
            var lineCounter = new LineCounter(myFileReader);
            Console.WriteLine(lineCounter.CountV3(filename));

            // v2:
            // var lines = File.ReadAllLines(filename);
            // var count = LineCounter.CountV2(lines);
            // Console.WriteLine(count);

            // v1:
            // Console.WriteLine(LineCounter.CountV1(filename));
        }
        static void Main1(string[] args)
        {
            var program = new Program();
            program.Run();
        }

        private void Run()
        {
            var game = new Game(this);
            game.Run();
        }

        public void OnSolved()
        {
            Console.WriteLine("*** Hurra! ***");
        }

        static void EnSlagsUnitTest(string[] args)
        {
            var dummyFileReader = new DummyFileReader(
                new string[]
                    {
                        "ljkhgjhg",
                        "ljkhgjhg",
                        "ljkhgjhg",
                        "ljkhgjhg",
                    });

            var lineCounter = new LineCounter(dummyFileReader);

            var count = lineCounter.CountV3("dummy");
            if (count == 4) Console.WriteLine("OK");
            else Console.WriteLine("Failed, expected 4 - was: " + count);
        }
    }
}
