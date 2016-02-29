namespace OneSystemsChat.Models
{
    /// <summary>
    /// Represents a model for the JSON response. 
    /// Use this model in controllers to send some information to the client side.
    /// </summary>
    public sealed class ResponseModel
    {
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
    }
}