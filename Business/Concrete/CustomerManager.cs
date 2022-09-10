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
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _ICustomerDal;

        public CustomerManager(ICustomerDal ıCustomerDal)
        {
            _ICustomerDal = ıCustomerDal;
        }

        public List<Customer> GetById(string customerId)
        {
            return _ICustomerDal.GetAll(i => i.CustomerId == customerId);
        }

        public List<Customer> GetAll()
        {
            return _ICustomerDal.GetAll();  
        }
    }
}
