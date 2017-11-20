using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace webapi.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        public string[] Get()
        {
            return new string[]
            {
                "Hello",
                "World"
            };
        }
    }
}