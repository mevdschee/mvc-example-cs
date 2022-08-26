﻿using System;
using System.Collections;
using System.Dynamic;
using Maussoft.Mvc;

namespace Acme.Example.Controllers
{
    public class Todo
    {
        public void Add(WebContext<Session> context)
        {
            if (context.Method == "POST")
            {
                context.Data.Values = new ViewData(context.Post);
                context.Data.Errors = new ViewData();
                if (context.Data.Values.Item.Length == 0)
                {
                    context.Data.Errors.Item = "Field is mandatory";
                }
                if (context.Data.Errors.Empty())
                {
                    context.Session.Items.Add(context.Data.Values.Item);
                    context.Redirect("/Todo");
                    return;
                }
            }
            else
            {
                context.Data.Values = new ViewData();
                context.Data.Values.Item = "";
            }

            context.Data.Title = "Todo app";
        }

        public void Index(WebContext<Session> context)
        {
            context.Data.Title = "Todo app";
        }

    }

}