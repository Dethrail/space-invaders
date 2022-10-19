namespace Common
{
    public interface ITimeService
    {
        float DeltaTime();
        float RealtimeSinceStartup();
    }
}