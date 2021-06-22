using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Azure_RestAPI
{
    class SiteLocation
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }


        
        public Int32 site_id { get; set; }


        public string Name { get; set; }



        public string Location { get; set; }



        public Int32 Devices { get; set; }


        public string LastServicedDate { get; set; }

        public string ServiceDueDate { get; set; }


        public string Contact { get; set; }
    }
}
