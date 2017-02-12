namespace DrinkServer.Model
{
    public class Drink
    {
        public Drink(string name, int quantity)
        {
            this.Name = name;
            this.Quantity = quantity;
        }

        /// <summary>
        /// Name of the drink. Should not be null.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Quanity of drinks. Should be positive.
        /// </summary>
        public int Quantity { get; }

        public bool IsValid()
        {
            return this.Name != null && this.Quantity >= 0;
        }
    }
}
