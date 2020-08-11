using AutoMapper;
using Bogus;
using poc_automapper_extensionmethod.Case01.Entities;
using poc_automapper_extensionmethod.Case01.Models;
using poc_automapper_extensionmethod.Case01.UseCases;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace poc_automapper_extensionmethod.Case01
{
    public static class Run
    {
        public static void Start()
        {
            Console.WriteLine("CASE 01");

            AutoMapperOperation.Start();
            ExtensionMethod.Start();
            CreateMethod.Start();
        }
    }
}
