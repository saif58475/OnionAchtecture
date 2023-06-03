using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.service.Contract
{
    public interface IResponse<T> where T : class
    {
        public string Message { get; set; }

        public int MessageCode { get; set; }

        public T Data { get; set; }
        bool Success { get; set; }
    }
}
