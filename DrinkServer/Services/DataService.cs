namespace DrinkServer.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using DrinkServer.Model;
    using DrinkServer.Utils;

    /// <summary>
    /// Service for accessing persisted Drinks data.
    /// </summary>
    public class DataService
    {
        private readonly IDictionary<string, Drink> drinks;

        public DataService()
        {
            drinks = new Dictionary<string, Drink>();
        }

        /// <summary>
        /// Adds or updates the drink. Drink may not be null.
        /// </summary>
        /// <exception cref="ArgumentNullException">drink</exception>
        public void AddOrUpdate(Drink drink)
        {
            Precond.IsNotNull(drink?.Name);

            drinks[drink.Name] = drink;
        }

        /// <summary>
        /// Indicates whether the given drink is present.
        /// </summary>
        public bool Contains(string name)
        {
            if (name == null) return false;

            return drinks.ContainsKey(name);
        }

        /// <summary>
        /// Removes the drink with the given name.
        /// </summary>
        public bool Remove(string name)
        {
            if (name == null) return false;

            return drinks.Remove(name);
        }

        /// <summary>
        /// Gets the drink with the given name. Null if there is no such drink.
        /// </summary>
        public Drink GetByName(string name)
        {
            Drink val = null;

            if (name != null)
            {
                drinks.TryGetValue(name, out val);
            }

            return val;
        }
        
        /// <summary>
        /// Gets all drinks with the given quantity. Sorts by name.
        /// </summary>
        public IReadOnlyCollection<Drink> GetByQuantity(int quantity)
            => drinks.Values.Where(x => x.Quantity == quantity)
                            .OrderBy(x => x.Name).ToArray();

        /// <summary>
        /// Gets all drinks. Sorts by quantity (largest first).
        /// </summary>
        public IReadOnlyCollection<Drink> GetAll() 
            => drinks.Values.OrderByDescending(x => x.Quantity).ToArray();
    }
}
