using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;

using ToDoAppCommon.Items;
using ToDoApp.Repository;

namespace ToDoServices.Items
{
    public class ItemService : IItemService
    {
        IItempRepository _rep;

        public ItemService(IItempRepository rep)
        {
            _rep = rep;
        }

        public IList<Item> GetAllItems()
        {
            return _rep.GetAllItems();
        }

        public Item GetItem(int id)
        {
            return _rep.GetItem(id);
        }

        public HttpResponseMessage AddItem(Item itm)
        {
            var response = new HttpResponseMessage() { StatusCode = System.Net.HttpStatusCode.OK };
            try
            {
                _rep.AddItem(itm);
            }
            catch (Exception ex)
            {
                response.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                response.Content = new StringContent(ex.ToString());
            }

            return response;
        }

        public HttpResponseMessage DeleteItem(int id)
        {
            var response = new HttpResponseMessage() { StatusCode = System.Net.HttpStatusCode.OK };
            try
            {
                _rep.DeleteItem(id);
            }
            catch (Exception ex)
            {
                response.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                response.Content = new StringContent(ex.ToString());
            }

            return response;
        }

        public HttpResponseMessage UpdateItem(Item itm)
        {
            var response = new HttpResponseMessage() { StatusCode = System.Net.HttpStatusCode.OK };
            try
            {
                _rep.UpdateItem(itm);
            }
            catch (Exception ex)
            {
                response.StatusCode = System.Net.HttpStatusCode.InternalServerError;
                response.Content = new StringContent(ex.ToString());
            }

            return response;
        }
    }
}
