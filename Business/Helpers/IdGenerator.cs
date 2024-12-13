namespace Business.Helpers;

public static class IdGenerator
{

    public static string UniqueIdGenerator() => Guid.NewGuid().ToString();

}
