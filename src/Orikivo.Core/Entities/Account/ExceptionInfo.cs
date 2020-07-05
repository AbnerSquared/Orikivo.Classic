using System;
using System.Collections;

namespace Orikivo
{
    public class ExceptionInfo
    {
        public ExceptionInfo(Exception ex)
        {
            Data = ex.Data;
            Message = ex.Message ?? "";
            StackTrace = ex.StackTrace;
        }

        public ICollection Data { get; set; }
        public string Message { get; set; }
        public string StackTrace { get; set; }
    }
}
