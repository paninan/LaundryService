using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaundryService
{
    class CustomerProfile
    {
        private PromotionBuy promoBuy;
        private Customer customer;
        private Order order;

        public PromotionBuy PromoBuy
        {
            get { return promoBuy; }
            set { promoBuy = value; }
        }

        public Customer Customer
        {
            get { return customer; }
            set { customer = value; }
        }

        public Order Order
        {
            get { return order; }
            set { order = value; }
        }
    }




    class PromotionBuy
    {

    }

    class Customer
    {

    }

    class Order
    {

    }
}
