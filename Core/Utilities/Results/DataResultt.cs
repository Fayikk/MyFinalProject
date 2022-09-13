using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class DataResultt<T> : Result,IDataResult<T> 
    {
        public DataResultt(T data,bool success,string message):base(success,message)
        {
            Data = data;//Set etme işlemidir
        }

        public DataResultt(T data,bool success):base(success)
        {
           Data=data; //Set etme işlemi uygulanmıştır.
        }

        public T Data { get; }
    }
}
