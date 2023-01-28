namespace ProductAPI.DateTime
{
    public interface IDateTimeContext
    {
        DateTimeOffset GetDateTime() => DateTimeOffset.UtcNow;
    }
}
