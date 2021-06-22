using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Azure_RestAPI
{
    class Class3
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]

        public string Id { get; set; }

        public string site_id { get; set; }
    }
}
