namespace MusicAPI.Exceptions
{
    public class InvalidArtistException : Exception
    {
        public InvalidArtistException()
        {
        }

        public InvalidArtistException(string? message) : base(message)
        {
        }
    }
}
