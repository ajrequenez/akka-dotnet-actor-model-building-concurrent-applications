namespace MovieStreaming.Common.Messages
{
    public sealed class StopMovieMessage
    {
        public int UserId { get; private set; }

        public StopMovieMessage(int userId)
        {  
            UserId = userId; 
        }

    }
}
