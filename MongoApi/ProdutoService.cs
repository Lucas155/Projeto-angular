using MongoApi.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoApi
{
    public class ProdutoService
    {
        private readonly IMongoCollection<Produtos> _produtos;

        public ProdutoService(IProdutostoreDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _produtos = database.GetCollection<Produtos>(settings.ProdutosCollectionName);
        }

        public List<Produtos> Get() =>
           _produtos.Find(produtos => true).ToList();

        public Produtos Get(string id) =>
            _produtos.Find<Produtos>(produtos => produtos._id == id).FirstOrDefault();

        public Produtos Create(Produtos produtos)
        {
            _produtos.InsertOne(produtos);
            return produtos;
        }

        public void Update(string id, Produtos produtosIn) =>
            _produtos.ReplaceOne(produtos => produtos._id == id, produtosIn);
            

        public void Remove(Produtos produtosIn) =>
            _produtos.DeleteOne(produtos => produtos._id == produtosIn._id);

        public void Remove(string id) =>
            _produtos.DeleteOne(produtos => produtos._id == id);

    }
}


