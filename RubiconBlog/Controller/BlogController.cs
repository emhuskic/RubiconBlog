using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RubiconBlog.Controller
{
    public class BlogController : ApiController
    {
        public string Get()
        {
            return "Hello World";
        }
    }
}
