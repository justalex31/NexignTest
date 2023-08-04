using Microsoft.AspNetCore.Mvc;

namespace NexignTest.Models.Game
{
    public class JoinModel : StatModel
    {
        [FromRoute(Name = "userName2")]
        public string UserName { get; set; }
    }
}
