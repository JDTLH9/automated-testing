namespace TestApi
{
    public interface IDatabaseSettings
    {
        string Name { get; set; }
    }

    public class DatabaseSettings : IDatabaseSettings
    {
        public string Name { get; set; }
    }
}
