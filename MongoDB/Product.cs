using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace MongoDB
{
    public class Product
    {
        public Product()
        {
        }

        public Product(string name, int price) : this()
        {
            Id = ObjectId.GenerateNewId();
            Name = name;
            Price = price;
            CreateTime = DateTime.Now;
        }

        /// <summary>
        /// 商品ID
        /// </summary>
        [BsonElement(elementName: "_id")]
        public ObjectId Id { get; set; }

        /// <summary>
        /// 商品名字
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 价格
        /// </summary>
        public int Price { get; set; }



        /// <summary>
        /// 添加时间
        /// </summary>
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime? ModifyTime { get; set; }

        /// <summary>
        /// 商品评论
        /// </summary>
        public List<ProductComment> Comments { get; set; }

        public override string ToString()
        {
            return $"{Id}:{Name},价格{Price}元";
        }

        public void ShowComments()
        {
            if (Comments != null)
            {
                foreach (var item in Comments)
                {
                    Console.WriteLine(item.ToString());
                }
            }

        }

        public void Comment(string content)
        {
            if (Comments == null)
            {
                Comments = new List<ProductComment>();
            }
            Comments.Add(new ProductComment(content));
        }
    }
}
