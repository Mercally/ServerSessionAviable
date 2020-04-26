using System;
using System.Collections.Generic;
using System.Text;

namespace SSAApp.Models
{
    public enum MenuItemType
    {
        Browse,
        About,
        SSAAPP
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
