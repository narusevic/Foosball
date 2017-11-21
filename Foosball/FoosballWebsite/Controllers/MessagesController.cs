using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR.Infrastructure;
using FoosballWebsite.Hubs;
using FoosballWebsite.Models;

namespace FoosballWebsite.Controllers
{
    [Route("api/[controller]")]
    public class MessagesController : ApiHubController<Broadcaster>
    {
        public MessagesController(
            IConnectionManager signalRConnectionManager)
        : base(signalRConnectionManager)
        {

        }

        // POST api/messages
        [HttpPost]
        public void Post([FromBody]ChatMessage message)
        {
            this.Clients.Group(message.MatchId.ToString()).AddChatMessage(message);
        }
    }
}
