namespace Forum.Server.GraphQl.Common
{
    public class Base(ILogger<Base> log)
    {
        protected void LogError(Exception ex, string message)
        {
            log.LogError(ex,$"An error has occured: {message}");
        }
    }
}
