namespace DrinksClient
{
    using System;
    using Checkout;

    class Program
    {
        enum RequestType { Invalid, Get, GetList, Create, Update, Delete }

        // C#7 soon...
        struct UserInput
        {
            public RequestType Request;
            public string Name;
            public int Quantity;
        }

        static void Main(string[] args)
        {

            var client = new APIClient("unused", Checkout.Helpers.Environment.LocalTesting, true, 20);
            AppSettings.BaseApiUri = "http://localhost:63866";

            var drinkService = client.DrinksService;

            Console.WriteLine("Give input in the format:");
            Console.WriteLine("RequestType[,Name[,Quantity]]");
            Console.WriteLine("Example:\tCreate,Coke,10");
            Console.WriteLine("Valid RequestTypes: {0}\n\n", 
                string.Join(",", (RequestType[])Enum.GetValues(typeof(RequestType))));

            while (true)
            {
                var input = Parse(Console.ReadLine());
                switch (input.Request)
                {
                    case RequestType.Create:
                        drinkService.CreateDrink(input.Name, input.Quantity);
                        break;
                    case RequestType.Update:
                        drinkService.UpdateDrink(input.Name, input.Quantity);
                        break;
                    case RequestType.Delete:
                        drinkService.DeleteDrink(input.Name);
                        break;
                    case RequestType.Get:
                        drinkService.GetDrink(input.Name);
                        break;
                    case RequestType.GetList:
                        drinkService.GetDrinkList();
                        break;
                    default:
                        Console.WriteLine("Invalid Input");
                        break;
                }
            }
        }

        static UserInput Parse(string line)
        {
            var parts = line?.Split(',');

            RequestType req = RequestType.Invalid;
            string name = null;
            int quantity = 0;

            if (parts?.Length > 0) Enum.TryParse(parts[0], out req);
            if (parts?.Length > 1) name = parts[1]?.Trim();
            if (parts?.Length > 2) int.TryParse(parts[2], out quantity);

            return new UserInput
            {
                Request = req,
                Name = name,
                Quantity = quantity
            };
        }
    }
}
