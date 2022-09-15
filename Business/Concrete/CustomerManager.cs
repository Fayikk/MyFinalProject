using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
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

        public IDataResult<List<Customer>> GetById(string customerId)
        {
            return new DataResultt<List<Customer>>(_ICustomerDal.GetAll(i => i.CustomerId == customerId), true, Messages.Success);



        }

        public IDataResult<List<Customer>> GetAll()
        {
            return new DataResultt<List<Customer>>(_ICustomerDal.GetAll(),true,Messages.Success);  
        }
    }
}
