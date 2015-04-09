using System.Linq;

namespace HearthStone.Hub
{
    public class GameHub : Microsoft.AspNet.SignalR.Hub
    {
        public void Send(string name, string message)
        {
            // Call the broadcastMessage method to update clients.
            Clients.All.broadcastMessage(name, message);
        }

        public void PlayCard(string playerName, string cardUrl)
        {
            var cardName = cardUrl.Split('/').Last().Split('.').First();

            Clients.All.broadcastMessage("Player " + playerName + ": ", "Played " + cardName);

            Clients.All.CardPlayed(playerName, cardUrl);
        }
    }
}