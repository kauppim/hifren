using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

using Hifren.Client;

namespace Hifren.Tests
{
    class TestProgram
    {
        static void Main(string[] args)
        {
            Console.WriteLine("START Chat server instance...");
            Console.WriteLine("=============================");
            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                Hifrend.MsgServer("Monkey");
            }).Start();


            var demo1 = new Blabla();
            var demo2 = new Blabla();


            Console.WriteLine("START Chat client demo 1...");
            Console.WriteLine("=============================");
            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                demo1.ChatClient("tcp://127.0.0.1:5555", "Demo1", "Hello");
            }).Start();


            Console.WriteLine("START Chat client demo 2...");
            Console.WriteLine("=============================");
            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                demo2.ChatClient("tcp://127.0.0.1:5555", "Demo2", "Bye");
            }).Start();


            Thread.Sleep(2000);
            Console.WriteLine("=============================> Ready.");
            Console.ReadLine();

        }
    }
}
