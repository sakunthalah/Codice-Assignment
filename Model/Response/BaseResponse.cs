using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Response
{
    public class BaseResponse<T> : InitialResponse
    {
        public string Message { get; set; }
        public T? Data { get; set; }
    }
    public class InitialResponse
    {
        public bool Success { get; set; } = false;
    }


}
