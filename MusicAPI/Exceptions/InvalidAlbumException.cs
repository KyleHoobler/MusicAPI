namespace MusicAPI.Exceptions
{
    public class InvalidAlbumException : Exception
    {
        public InvalidAlbumException()
        {
        }

        public InvalidAlbumException(string? message) : base(message)
        {
        }
    }
}
