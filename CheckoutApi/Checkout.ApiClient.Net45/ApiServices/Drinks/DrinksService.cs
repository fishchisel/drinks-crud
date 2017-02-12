namespace Checkout.ApiServices.Drinks
{
    using System.Collections.Generic;
    using Checkout.ApiServices.Drinks.ResponseModels;
    using Checkout.ApiServices.SharedModels;

    public class DrinksService
    {
        public HttpResponse<Drink> CreateDrink(string name, int quantity)
        {
            var uri = string.Format(ApiUrls.Drinks, "");
            var drink = new Drink { Name = name, Quantity = quantity };

            return new ApiHttpClient().PostRequest<Drink>(uri, AppSettings.SecretKey, drink);
        }

        public HttpResponse<Drink> GetDrink(string name)
        {
            var uri = string.Format(ApiUrls.Drinks, name);
            return new ApiHttpClient().GetRequest<Drink>(uri, AppSettings.SecretKey);
        }

        public HttpResponse<Drink> UpdateDrink(string name, int quantity)
        {
            var uri = string.Format(ApiUrls.Drinks, "");
            var drink = new Drink { Name = name, Quantity = quantity };

            return new ApiHttpClient().PutRequest<Drink>(uri, AppSettings.SecretKey, drink);
        }

        public HttpResponse<OkResponse> DeleteDrink(string name)
        {
            var uri = string.Format(ApiUrls.Drinks, name);
            return new ApiHttpClient().DeleteRequest<OkResponse>(uri, AppSettings.SecretKey);
        }

        public HttpResponse<ICollection<Drink>> GetDrinkList()
        {
            var uri = string.Format(ApiUrls.Drinks, "");
            return new ApiHttpClient().GetRequest<ICollection<Drink>>(uri, AppSettings.SecretKey);
        }
    }
}
