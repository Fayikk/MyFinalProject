using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class OrderManager : IOrderService
    {
        IOrderDal _IOrderDal;
        public OrderManager(IOrderDal ıOrderDal)
        {
            _IOrderDal = ıOrderDal; 
        }

        public List<Order> GetAll()
        {
            return _IOrderDal.GetAll(); 
        }

        public List<Order> GetAll(int orderId)
        {
            return _IOrderDal.GetAll(o=>o.OrderId==orderId);
        }
    }
}
