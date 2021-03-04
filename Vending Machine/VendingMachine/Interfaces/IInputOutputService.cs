using System;

namespace iQuest.VendingMachine.Interfaces
{
    public interface IInputOutputService
    {
        public string ReadLine();
        void WriteLine(string message, ConsoleColor color = ConsoleColor.Gray);
        void Write(string message, ConsoleColor color = ConsoleColor.Gray);
    }
}
