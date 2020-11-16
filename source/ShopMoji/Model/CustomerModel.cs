using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Model
{
    public class CustomerModel
    {
        public CustomerModel() { }
        public int CustomID { get; set; }
        public string Username { get; set; }
        public string CustomName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Location { get; set; }
        public string Pass { get; set; }
        public bool Statu { get; set; }
        public Nullable<int> TotalPrice { get; set; }
        public string MemID { get; set; }
    }
}
