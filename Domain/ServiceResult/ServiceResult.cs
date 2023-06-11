using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ServiceResult
{
    public class ServiceResult<T>
    {
        public T Result { get; set; }
        public bool IsSuccees { get; set; }
        public string Message { get; set; }
        public ServiceResult() { }
        public ServiceResult(string massage)
        {
            Message= massage;
        }
    }
}
