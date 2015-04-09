namespace HearthStone.Hub
{
    public class GameHub : Microsoft.AspNet.SignalR.Hub
    {
        public void Send(string name, string message)
        {
            // Call the broadcastMessage method to update clients.
            Clients.All.broadcastMessage(name, message);
        }
    }
}