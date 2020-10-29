﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;
using Tillascope.Domain.Entities;

namespace Tillascope.WebUI.Infrastructure.Binders
{
    public class CartModelBinder : IModelBinder
    {
        private const string sessionKey = "Cart";

        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            // get the Cart from the session

            Cart cart = null;
            if (controllerContext.HttpContext.Session != null)
            {
                cart = (Cart)controllerContext.HttpContext.Session[sessionKey];
            }
            //create the Cart if there wasnt one in the session data

            if (cart == null)
            {
                cart = new Cart();
                if (controllerContext.HttpContext.Session!= null)
                {
                    controllerContext.HttpContext.Session[sessionKey] = cart;
                }
            }

        // return the cart
        return cart;
        }
    }
}