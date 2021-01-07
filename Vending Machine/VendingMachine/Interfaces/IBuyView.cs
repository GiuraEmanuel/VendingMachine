using System;
using System.Collections.Generic;
using System.Text;

namespace iQuest.VendingMachine.Interfaces
{
    internal interface IBuyView
    {
        Product RequestProduct(int columnId);
        int AskForColumnId();
        public void ShowError(string errorMessage);
    }
}
