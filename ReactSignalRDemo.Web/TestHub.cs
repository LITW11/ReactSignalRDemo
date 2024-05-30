using Microsoft.AspNetCore.SignalR;
using ReactSignalRDemo.Web.Models;

namespace ReactSignalRDemo.Web
{
    public class TestHub : Hub
    {
        private static List<ChatMessage> _allMessages = new();

        //public TestHub(IConfiguration configuration)
        //{
        //    string conSstr = configuration.GetConnectionString("ConStr");
        //}

        public void Foobar()
        {
            //Console.WriteLine("Inside of hub!!!");
            Clients.All.SendAsync("newMessage", new { value = Guid.NewGuid() });
        }

        public void NewChatMessage(ChatMessage message)
        {
            _allMessages.Add(message);
            Clients.All.SendAsync("newChatReceived", message);
        }

        public void NewUser()
        {
            //Context.User.Identity.Name -- this will get the currently logged in users email

            Clients.Caller.SendAsync("allMessages", _allMessages);
        }
    }
}
