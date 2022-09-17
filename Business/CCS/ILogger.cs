using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.CCS
{
    public interface ILogger//Farklı loglama operasynlarını sisteme entegre edebiliyor olacağım.
    {
        void Log();
    }
}
