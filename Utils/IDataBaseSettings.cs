namespace ApiRotas_ONGG.Utils
{
    public interface IDataBaseSettings
    {
        string DatabaseName { get; set; }
        string ConnectionString { get; set; }
        string CachorroCollectionName { get; set; }
    }
}
