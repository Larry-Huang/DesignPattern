using System;
using Demo.Clip01;
using Demo.Clip02;
using Demo.Clip03;
using Demo.Clip04;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            new Clip01Demo().Run();
            new Clip02Demo().Run();
            new Clip03Demo().Run();
            new Clip04Demo().Run();

            Console.Write("Press ENTER to exit. . . ");
            Console.ReadLine();
        }
    }
}
