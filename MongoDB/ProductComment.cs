using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace MongoDB
{
    public class ProductComment
    {
        public ProductComment(string content)
        {
            if (content == null)
            {
                throw new ArgumentNullException("content");
            }
            Id = ObjectId.GenerateNewId();
            Content = content;
            CheckState = true;
            CreateTime = DateTime.Now;
        }

        /// <summary>
        /// 评论ID
        /// </summary>
        [BsonElement(elementName: "_id")]
        public ObjectId Id { get; set; }

        /// <summary>
        /// 评论内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 评论审核状态
        /// </summary>
        public bool CheckState { get; set; }

        /// <summary>
        /// 添加时间
        /// </summary>
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime? ModifyTime { get; set; }

        public override string ToString()
        {
            return $"评论信息:{Content},审核状态:{CheckState}";
        }
    }
}
