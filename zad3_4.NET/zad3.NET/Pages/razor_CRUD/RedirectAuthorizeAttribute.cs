using System;

namespace zad3.NET.Pages.razor_CRUD
{
    internal class RedirectAuthorizeAttribute : Attribute
    {
        public string Users { get; set; }
    }
}