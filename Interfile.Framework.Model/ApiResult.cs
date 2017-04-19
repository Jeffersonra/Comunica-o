using Interfile.Framework.Model.Enum;

namespace Interfile.Framework.Model
{
    public class ApiResult
    {
        public string SuccessMessage { get; set; }
        public string ErrorMessage { get; set; }
        public dynamic Data { get; set; }
        public ApiReturnStatus Status { get; set; }
    }
}
