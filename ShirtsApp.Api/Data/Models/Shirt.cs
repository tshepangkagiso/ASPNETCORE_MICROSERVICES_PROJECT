namespace ShirtsApp.Api.Data.Models
{
    public class Shirt
    {
        public int ShirtID { get; set; }

        public string Brand { get; set; }
        public string Color { get; set; }
        public int Size { get; set; }

        public Shirt(string brand, string color, int size)
        {
            Brand = brand;
            Color = color;
            Size = size;
        }

        public Shirt() { }
    }
}
