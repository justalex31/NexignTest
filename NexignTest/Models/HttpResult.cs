using NexignTest.Enums;

namespace NexignTest.Models
{
    public class HttpResult
    {
        public ECode Code { get; set; } = ECode.OK;
        public string Message { get; set; }
        public string Description { get; set; }
    }
}
