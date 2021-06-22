using System;
using System.Collections.Generic;
using System.Text;

namespace Azure_RestAPI
{
   public class MultiDeviceData
    {
        public List<sites> Sites { get; set; }
    }
    public class sites
    {
        /*public sites()
        {
        }
        */

       /* public sites(string site_id, string device_id, string alarm, string trouble_count, string description, string maintainence_alert, string rAM_Usage)
        {
          /*  this.site_id = site_id;
            this.device_id = device_id;
            this.alarm = alarm;
            this.Trouble_count = trouble_count;
            this.Description = description;
            this.Maintainence_alert = maintainence_alert;
            this.RAM_Usage = rAM_Usage;
          
        }
       
     */
        public string name { get; set; }
        public string location { get; set; }
        public string site_id { get; set; }

        public string device_id { get; set; }

        public string alarm { get; set; }

        public string Trouble_count { get; set; }

        public string Description { get; set; }

        public string Maintainence_alert { get; set; }

        public string RAM_Usage { get; set; }
    }
}
