namespace OneSystemsChat.Hubs.HubModels
{
    /// <summary>
    /// Represents a user model that should be used in the Hubs only.
    /// </summary>
    public sealed class UserHubModel
    {
        public string ConnectionId { get; set; }
        public string Login { get; set; }
        public int UserId { get; set; }
        public bool HasMessage { get; set; }
    }
}