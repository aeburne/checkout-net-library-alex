using Checkout.ApiServices.ShoppingList.RequestModels;
using Checkout.ApiServices.ShoppingList.ResponseModels;
using FluentAssertions;
using NUnit.Framework;
using System.Net;

namespace Tests
{
    [TestFixture(Category = "ListApi")]
    public class ShoppingListTests : BaseServiceTests
    {
        [Test]
        public void CreateListItem()
        {
            // can use a helper but I want to use the item i create later to test below as its in memory.
            // var shopitem = TestHelper.GetShoppingListItem(101);
            var response = CheckoutClient.ShoppingListService.CreateListItem(CreateItem1());

            response.Model.successfull.Should().Be(true);

            response.HttpStatusCode.Should().Be(HttpStatusCode.OK);

            // Remove when done not ideal but means test can run any order
            var response2 = CheckoutClient.ShoppingListService.DeleteItem(CreateItem1().Description);
        }

        [Test]
        
        public void CreateListItem2()
        {
            // can use a helper but I want to use the item i create later to test below as its in memory.
            // var shopitem = TestHelper.GetShoppingListItem(101);
            var response = CheckoutClient.ShoppingListService.CreateListItem(CreateItem2());

            response.Model.successfull.Should().Be(true);

            response.HttpStatusCode.Should().Be(HttpStatusCode.OK);

            var response2 = CheckoutClient.ShoppingListService.DeleteItem(CreateItem2().Description);
        }

        [Test]
        public void UpdateItem1()
        {
            // can use a helper but I want to use the item i create later to test below as its in memory.
            // var shopitem = TestHelper.GetShoppingListItem(101);
            var modelToUpdate = new ShoppingListItemResponse();
            modelToUpdate.Description = "Coke";
            modelToUpdate.Quantity = 1000;
            modelToUpdate.ItemId = 1;

            var response = CheckoutClient.ShoppingListService.CreateListItem(CreateItem1());
            var response2 = CheckoutClient.ShoppingListService.PutItem(modelToUpdate);

            response2.HttpStatusCode.Should().Be(HttpStatusCode.OK);
            response2.Model.successfull.Should().Be(true);

            var response3 = CheckoutClient.ShoppingListService.DeleteItem(CreateItem1().Description);
        }


        [Test]
        public void GetItemById()
        {
            // Make sure item 1 is there
            var response1 = CheckoutClient.ShoppingListService.CreateListItem(CreateItem1());

            int id = 1;
            var response2 = CheckoutClient.ShoppingListService.GetItemById(id);
            response2.Should().NotBeNull();
            response2.HttpStatusCode.Should().Be(HttpStatusCode.OK);
            response2.Model.Description.Should().Be("Coke");

            var response3 = CheckoutClient.ShoppingListService.DeleteItem(CreateItem1().Description);
        }


        [Test]
        public void GetItemQuantityByName()
        {
            // Make sure item 1 is there
            var response1 = CheckoutClient.ShoppingListService.CreateListItem(CreateItem1());

            string name = "Coke";

            var response = CheckoutClient.ShoppingListService.GetQuantitybyName(name);
            response.Should().NotBeNull();
            response.HttpStatusCode.Should().Be(HttpStatusCode.OK);
            response.Model.Quantity.Should().Be(102);


            var response3 = CheckoutClient.ShoppingListService.DeleteItem(CreateItem1().Description);
        }

        [Test]
        [Ignore]
        public void GetShoppingList()
        {
            var response = CheckoutClient.ShoppingListService.GetShoppingList();
            response.Should().NotBeNull();
            response.HttpStatusCode.Should().Be(HttpStatusCode.OK);

        }


        [Test]
        public void DeleteItem()
        {

            var response1 = CheckoutClient.ShoppingListService.CreateListItem(CreateItem1());

            int id = 1;
            var response = CheckoutClient.ShoppingListService.DeleteItem(id);
            response.Model.successfull.Should().Be(true);
            response.HttpStatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Test]
        public void DeleteItem2()
        {
            // Not item needed as it doesnt exist
            int id = 12;
            var response = CheckoutClient.ShoppingListService.DeleteItem(id);
            response.Model.successfull.Should().Be(false);
            response.HttpStatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Test]
        public void DeleteItem3()
        {

            var response1 = CheckoutClient.ShoppingListService.CreateListItem(CreateItem2());

            string name = "Pepsi";
            var response = CheckoutClient.ShoppingListService.DeleteItem(name);
            response.Model.successfull.Should().Be(true);
            response.HttpStatusCode.Should().Be(HttpStatusCode.OK);
        }

        private ShoppingListItemRequest CreateItem1()
        {
            var shopitem = new ShoppingListItemRequest();
            shopitem.Description = "Coke";
            shopitem.Quantity = 102;

            return shopitem;
        }

        private ShoppingListItemRequest CreateItem2()
        {
            var shopitem = new ShoppingListItemRequest();
            shopitem.Description = "Pepsi";
            shopitem.Quantity = 22;

            return shopitem;
        }
    }
}