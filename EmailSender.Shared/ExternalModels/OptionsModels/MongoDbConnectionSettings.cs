namespace EmailSender.Core.ExternalModels.OptionsModels
{
    public class MongoDbConnectionSettings
    {
        public const string MongoDB = "MongoDB";
        public string ConnectionURI { get; set; }
        public string DatabaseName { get; set; }
    }
}
