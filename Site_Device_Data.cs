using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Azure_RestAPI
{
    class Site_Device_Data
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]

        public string Id { get; set; }
        public string name { get; set; }
        public string location { get; set; }
        public string site_id{ get; set; }


        public string device_id { get; set; }

        public string alarm { get; set; }



        public string Trouble_count { get; set; }



       public string Description { get; set; }


        public string Maintenance_alert { get; set; }

        public string RAM_Usage{ get; set; }

    }
}
