using Newtonsoft.Json;

namespace VirtualMind.Core.Exceptions
{
    public class ErrorHandlerModel
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
