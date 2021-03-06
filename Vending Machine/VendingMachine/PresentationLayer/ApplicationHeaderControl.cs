﻿using iQuest.VendingMachine.Interfaces;
using System;
using System.Reflection;

namespace iQuest.VendingMachine.PresentationLayer
{
    public class ApplicationHeaderControl
    {
        private readonly string applicationName;
        private readonly Version applicationVersion;
        private readonly IInputOutputService ioService;

        public ApplicationHeaderControl(IInputOutputService inputOutputService)
        {
            ioService = inputOutputService;
            Assembly assembly = Assembly.GetEntryAssembly();

            AssemblyProductAttribute assemblyProductAttribute = assembly.GetCustomAttribute<AssemblyProductAttribute>();
            applicationName = assemblyProductAttribute.Product;

            AssemblyName assemblyName = assembly.GetName();
            applicationVersion = assemblyName.Version;
        }

        public void Display()
        {
            Console.WriteLine("{0} {1}", applicationName, applicationVersion.ToString(2));
            Console.WriteLine(new string('=', 79));
        }
    }
}