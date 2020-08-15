using AutoMapper;
using Bogus;
using poc_automapper_extensionmethod.Case02.Entities;
using poc_automapper_extensionmethod.Case02.Enum;
using poc_automapper_extensionmethod.Case02.Models;
using poc_automapper_extensionmethod.Case02.UseCases;
using poc_automapper_extensionmethod.Shared;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace poc_automapper_extensionmethod.Case02
{
    public static class Run
    {
        public static void Start()
        {
            Console.WriteLine("CASE 02");

            AutoMapperOperation.Start();
            ExtensionMethod.Start();
            CreateMethod.Start();
        }
    }
}
