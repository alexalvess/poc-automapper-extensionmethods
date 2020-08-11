using AutoMapper;
using poc_automapper_extensionmethod.Case01;
using poc_automapper_extensionmethod.Case01.Entities;
using poc_automapper_extensionmethod.Case01.Models;
using System;
using System.Diagnostics;

namespace poc_automapper_extensionmethod
{
    class Program
    {
        static void Main(string[] args)
        {
            RunCase01();
        }

        private static void RunCase01()
        {
            Console.WriteLine("AutoMapper with an object");
            Case01.Run.RunWithMapper();

            Console.WriteLine("\nAutoMapper with a list");
            Case01.Run.RunWithListMapper();

            Console.WriteLine("\nWithout AutoMapper with an object");
            Case01.Run.RunWithoutMapper();

            Console.WriteLine("\nWithout AutoMapper with a list");
            Case01.Run.RunWithoutMapperList();
        }
    }
}
