using ApiRotas_ONGG.Model;
using ApiRotas_ONGG.Utils;
using MongoDB.Driver;
using System.Collections.Generic;

namespace ApiRotas_ONGG.Services
{
    public class CachorroServices
    {
        private readonly IMongoCollection<Cachorro> _dogs;

        public CachorroServices(IDataBaseSettings settings)
        {
            var dogs = new MongoClient(settings.ConnectionString);
            var DataBase = dogs.GetDatabase(settings.DatabaseName);
            _dogs = DataBase.GetCollection<Cachorro>(settings.CachorroCollectionName);

        }

        public List<Cachorro> GetDog() => _dogs.Find(dogs => true).ToList();

        public Cachorro GetDogName(string nome) => _dogs.Find<Cachorro>(dogs => dogs.Nome == nome).FirstOrDefault();

        public Cachorro AdicionaDog(Cachorro dogs)
        {
            _dogs.InsertOne(dogs);
            return dogs;
        }

        


    }
}
