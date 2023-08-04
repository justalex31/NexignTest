using Microsoft.AspNetCore.Mvc;

namespace NexignTest.Models.Game
{
    public class CreateModel
    {
        [FromQuery(Name = "userName1")]
        public string UserName { get; set; }
    }
}
