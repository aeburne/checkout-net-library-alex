using Checkout.ApiServices.ShoppingList.RequestModels;
using Checkout.ApiServices.ShoppingList.ResponseModels;
using Checkout.ApiServices.SharedModels;
using System.Collections.Generic;

namespace Checkout.ApiServices.Cards
{
    public class ShoppingListService
    {

        public HttpResponse<ResponseModel> CreateListItem(ShoppingListItemRequest requestModel)
        {
            var createCardUri = ApiUrls.ShoppingList + "post";
            return new ApiHttpClient().PostRequest<ResponseModel>(createCardUri, AppSettings.SecretKey, requestModel);
        }

        public HttpResponse<QuantityModel> GetQuantitybyName(string name)
        {
           
            var getCardListUri = ApiUrls.ShoppingList + string.Format("GetQuantity/{0}", name);
            return new ApiHttpClient().GetRequest<QuantityModel>(getCardListUri, AppSettings.SecretKey);
        }

        public HttpResponse<ShoppingListRequest> GetShoppingList()
        {
            var getCardListUri = ApiUrls.ShoppingList + "Get";
            return new ApiHttpClient().GetRequest<ShoppingListRequest>(getCardListUri, AppSettings.SecretKey);
        }

        public HttpResponse<ShoppingListItemResponse> GetItemById(int id)
        {
            var getCardListUri = ApiUrls.ShoppingList + string.Format("Get/{0}", id);
            return new ApiHttpClient().GetRequest<ShoppingListItemResponse>(getCardListUri, AppSettings.SecretKey);
        }

        public HttpResponse<ResponseModel> DeleteItem(int id)
        {
            var getCardListUri = ApiUrls.ShoppingList + string.Format("Delete/{0}", id);
            return new ApiHttpClient().DeleteRequest<ResponseModel>(getCardListUri, AppSettings.SecretKey);
        }

        public HttpResponse<ResponseModel> DeleteItem(string name)
        {
            var getCardListUri = ApiUrls.ShoppingList + string.Format("DeleteByName/{0}", name);
            return new ApiHttpClient().DeleteRequest<ResponseModel>(getCardListUri, AppSettings.SecretKey);
        }

        public HttpResponse<ResponseModel> PutItem(ShoppingListItemResponse model)
        {
            var getCardListUri = ApiUrls.ShoppingList + "put";
            return new ApiHttpClient().PutRequest<ResponseModel>(getCardListUri, AppSettings.SecretKey, model);
        }

    }
}