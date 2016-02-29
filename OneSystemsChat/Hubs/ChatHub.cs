using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using OneSystemsChat.Hubs.HubModels;

namespace OneSystemsChat.Hubs
{
    /// <summary>
    /// Represents a Hub for the chat's onlinesynchronization
    /// </summary>
    public class ChatHub : Hub
    {
        private static List<UserHubModel> _users;

        public ChatHub()
        {
            if (_users == null)
            {
                _users = new List<UserHubModel>();
            }
        }

        /// <summary>
        /// Represents a handler for the connected users.
        /// The client-side should have 2 callbaks implemented: 
        ///     - getActiveUsers(activeUsers)
        ///     - onNewUserConnected(userHubModel)
        /// </summary>
        /// <param name="login">Connected user's login</param>
        /// <param name="userId">Connected user's ID</param>
        public void Connected(string login, int userId)
        {
            string connectionId = Context.ConnectionId;

            _users.Add(new UserHubModel { ConnectionId = connectionId, Login = login, UserId = userId });

            Clients.Others.onNewUserConnected(new UserHubModel { Login = login, UserId = userId });

            var activeUsers = _users.Where(u => u.ConnectionId != Context.ConnectionId)
                .Select(u => new UserHubModel() { Login = u.Login, UserId = u.UserId })
                .ToList();

            Clients.Client(Context.ConnectionId).getActiveUsers(activeUsers);
        }

        /// <summary>
        /// A handler for the OnDisconnected event.
        /// On the client side this method has onUserDisconnected(users) callback.
        /// </summary>
        public override Task OnDisconnected(bool stopCalled)
        {
            UserHubModel userToDelete = _users.FirstOrDefault(u => u.ConnectionId == Context.ConnectionId);
            if (userToDelete != null)
            {
                _users.Remove(userToDelete);
                Clients.All.onUserDisconnected(_users);
            }

            return base.OnDisconnected(stopCalled);
        }

        /// <summary>
        /// Sends new message to the clients.
        /// On the client side, it has addMessage(login, message, messageDate) callback.
        /// </summary>
        /// <param name="login">Sender's login</param>
        /// <param name="message">The message's content that has been sent.</param>
        /// <param name="messageDate">A date when the message was sent.</param>
        public void Send(string login, string message, DateTime messageDate)
        {
            Clients.Others.addMessage(login, message, messageDate);
        }

        /// <summary>
        /// Sends notification about incoming message to the recipient.
        /// On the client side has updateNotifications(senderId, recipientId) callback.
        /// </summary>
        /// <param name="senderId">An ID of the user that sent the message.</param>
        /// <param name="recipientId">An ID of the recipient user.</param>
        public void SendNotificationToUser(int senderId, int recipientId)
        {
            Clients.Others.updateNotifications(senderId, recipientId);
        }
    }
}