namespace Vending_Machine
{
    public class Item
    {
        public string Name { get; }
        public int Price { get; }

        public Item(string name, int price)
        {
            Name = name;
            Price = price;
        }
    }
}