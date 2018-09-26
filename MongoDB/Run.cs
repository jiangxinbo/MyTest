using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;

namespace MongoDB
{
    public class Run
    {
        private static string _MongoDbConnectionStr = "mongodb://127.0.0.1/test";
        private static IMongoCollection<Product> db;
        static Run()
        {
            db= GetCollection<Product>();
        }

        public static void addinfo()
        {
            //添加一个待审核的商品
            Product product = new Product("橡胶", 5);
            db.InsertOne(product);

            Product product1 = new Product("香蕉", 10);
            db.InsertOne(product1);

            Product product2 = new Product("苹果", 12);
            db.InsertOne(product2);

            Product product3 = new Product("苹果1", 13);
            db.InsertOne(product3);
        }

        public static List<Product> find()
        {
            var productList = db.Find(new BsonDocument("Name", "苹果")).ToList();
            foreach (var item in productList)
            {
                Console.WriteLine(item.ToString());
            }
            return productList;
        }

        public static void findLinqLike()
        {
            var productList = db.Find(x=>x.Name.Contains("苹果")).ToList();
            foreach (var item in productList)
            {
                Console.WriteLine(item.ToString());
            }
        }

        public static void findLinqLikeStart()
        {
            var productList = db.Find(x => x.Name.StartsWith("苹果")&&x.Price>2).ToList();

            foreach (var item in productList)
            {
                Console.WriteLine(item.ToString());
            }
        }

        public static void findLinq()
        {
            var productList = db.Find(x=>x.Name=="苹果").ToList();
            foreach (var item in productList)
            {
                Console.WriteLine(item.ToString());
            }
        }

        public static void update()
        {
            var updateFilter=Builders<Product>.Update.Set(m => m.ModifyTime, DateTime.Now).Set(m => m.Name, "aaa");
            var updateResult=db.UpdateOne(m => m.Name == "苹果", updateFilter);
            if (updateResult.IsModifiedCountAvailable)
            {
                Console.WriteLine("更新销售状态成功=====");
            }
            else
            {
                Console.WriteLine("更新失败=====");
            }
        }

        public static void delete()
        {
            db.DeleteOne(x => x.Name == "苹果");
            
        }

        public static void findPage()
        {
            FilterDefinition<Product> filter = new BsonDocument();
            long productAllCount = db.Count(filter);
            var productList = db.Find(filter).Skip(0).Limit(20).ToList();
            foreach (var item in productList)
            {
                Console.WriteLine(item.ToString());
            }
        }

        public static void findOther()
        {
          
            var productList = db.Find(x=>x.Comments.Where(p=>p.CheckState==true).Any()).ToEnumerable();
            foreach (var item in productList)
            {
                Console.WriteLine(item.ToString());
            }
        }

        //分组查询  
        public static void findGroup()
        {
            var productList = db.Aggregate().Group(x =>x.Name,g=>new {Name=g.Key, Count =g.Count(), TotalMinutes = g.Sum(x => x.Price) }).ToList();
            foreach (var item in productList)
            {
                Console.WriteLine(item.ToString());
            }
        }

        



        public static void init()
        {




            addinfo();
            var productList = db.Find(new BsonDocument()).ToList();
            foreach(var product in productList)
            {
                new ObjectId();
                var id = product.Id;
                Console.WriteLine(id.ToString());
            }

            



        }





        private static IMongoCollection<T> GetCollection<T>(string collectionName = null)
        {
            MongoUrl mongoUrl = new MongoUrl(_MongoDbConnectionStr);
            var mongoClient = new MongoClient(mongoUrl);
            
            var database = mongoClient.GetDatabase(mongoUrl.DatabaseName);
            return database.GetCollection<T>(collectionName ?? typeof(T).Name);
        }
    }
}
