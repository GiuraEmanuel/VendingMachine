﻿using System;
using System.Collections.Generic;
using System.Linq;
using iQuest.VendingMachine.Interfaces;


namespace iQuest.VendingMachine.PresentationLayer
{
    internal class CommandSelectorControl : DisplayBase
    {
        public IEnumerable<IUseCase> UseCases { get; set; }

        public IUseCase Display()
        {
            DisplayUseCases();
            return SelectUseCase();
        }

        private void DisplayUseCases()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Available commands:");
            Console.WriteLine();

            foreach (IUseCase useCase in UseCases)
                DisplayUseCase(useCase);
        }

        private static void DisplayUseCase(IUseCase useCase)
        {
            ConsoleColor oldColor = Console.ForegroundColor;

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(useCase.Name);

            Console.ForegroundColor = oldColor;

            Console.WriteLine(" - " + useCase.Description);
        }

        private IUseCase SelectUseCase()
        {
            while (true)
            {
                string rawValue = ReadCommandName();
                IUseCase selectedUseCase = FindUseCase(rawValue);

                if (selectedUseCase != null)
                    return selectedUseCase;

                DisplayLine("Invalid command. Please try again.", ConsoleColor.Red);
            }
        }

        private IUseCase FindUseCase(string rawValue) => UseCases.FirstOrDefault(u => u.Name == rawValue);

        private string ReadCommandName()
        {
            Console.WriteLine();
            Display("Choose command: ", ConsoleColor.Cyan);
            string rawValue = Console.ReadLine();
            Console.WriteLine();

            return rawValue;
        }
    }
}