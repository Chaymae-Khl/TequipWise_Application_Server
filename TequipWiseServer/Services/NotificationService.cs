using Microsoft.AspNetCore.SignalR;
using TequipWiseServer.Models.Notification;

namespace TequipWiseServer.Services
{
    public class NotificationService
    {
        private readonly IHubContext<NotificationHub> _hubContext;

        public NotificationService(IHubContext<NotificationHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task SendNotificationAsync(string userId, string message)
        {
            Console.WriteLine($"Sending notification to user: {userId}, message: {message}"); // Debug log
            await _hubContext.Clients.User(userId).SendAsync("ReceiveNotification", message);
        }

    }
}
