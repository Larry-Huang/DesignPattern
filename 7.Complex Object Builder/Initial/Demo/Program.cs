using System;
using Demo.Clip01;
using Demo.Clip03;
using Demo.Clip05;
using Demo.Clip06;
using Demo.Clip07;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            new Clip01Demo().Run();
            new Clip03Demo().Run();
            new Clip05Demo().Run();
            new Clip06Demo().Run();
            new Clip07Demo().Run();

            Console.WriteLine();
            Console.Write("Press ENTER to continue . . . ");
            Console.ReadLine();
        }
    }
}
