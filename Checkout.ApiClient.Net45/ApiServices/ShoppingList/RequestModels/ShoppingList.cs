using System.Collections.Generic;

namespace Checkout.ApiServices.ShoppingList.RequestModels
{
    public class ShoppingListRequest
    {
        public List<ShoppingListItemRequest> ShoppingItems = new List<ShoppingListItemRequest>();
    }
}
