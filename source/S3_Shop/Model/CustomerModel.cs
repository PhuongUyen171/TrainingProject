using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class CustomerModel
    {
        public CustomerModel() { }
        public int CustomID { get; set; }
        public string CustomName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Location { get; set; }
        public string Pass { get; set; }
        public bool? Statu
        {
            get 
            { 
                if (this.Statu != null)
                    return this.Statu;
                return true;
            }
            set { this.Statu = value; }
        }
        public int? TotalPrice 
        {
            get
            {
                if (this.TotalPrice != null)
                    return this.TotalPrice;
                return 0;
            }
            set { this.TotalPrice = value; }
        }
        public string MemID { get; set; }
    }
}
