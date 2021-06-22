using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Azure_RestAPI
{
    class DeviceData
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Device_value { get; set; }
    }
}
