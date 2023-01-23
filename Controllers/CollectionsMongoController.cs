using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;

namespace ApiCollections.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]

    public class CollectionsMongoController : ControllerBase
    {
    [HttpGet]
        public CollectionsMongoClasses Get()
        {
            CollectionsMongoClasses conectar = new CollectionsMongoClasses();
            MongoClient dbClient = new MongoClient("mongodb://localhost:27017");
            var dbName = dbClient.GetDatabase("6846433ef36b141080740094ce6e3852");
            var collist = dbName.GetCollection<BsonDocument>("LogConversation");

            var result = collist.Find(_=>true).FirstOrDefault();

            //return Ok(result.ToString());
            //CollectionsMongoClasses conectar = new CollectionsMongoClasses();
            conectar.collections = result;

            return conectar;
        }
    }
}
