namespace iQuest.VendingMachine
{
    internal class Product
    {
        public string Name { get; private set; }
        private decimal Price { get;}
        public int ColumnId { get;}
        public int Quantity { get; private set; }

        public Product()
        {

        }

        public Product(int columnId, string name, int quantity, decimal price)
        {
            ColumnId = columnId;
            Name = name;
            Quantity = quantity;
            Price = price;
        }

        public Product(int columnId)
        {
            ColumnId = columnId;
        }

        public override string ToString()
        {
            return $"{Name} - Quantity: {Quantity} - Price per item: {Price}$"; 
        }

        public void DecrementQuantity()
        {
            Quantity--;
        }

        public virtual void SetQuantity(int quantity)
        {
            Quantity = quantity;
        }

    }
}
