using System;
using System.Collections.Generic;
using System.Text;

namespace Azure_RestAPI
{
   public  class DeviceSiteData
    {
            public string sitelocation { get; set; }

            public string devicevalue { get; set; }
            public List<S> s121 { get; set; }
            public List<S> s122 { get; set; }

            public List<S> s123 { get; set; }
    }
        public class S
        {

            public string site_id { get; set; }

            public string device_id { get; set; }

            public string alarm { get; set; }

            public string Trouble_count { get; set; }

            public string Description { get; set; }

            public string Maintainence_alert { get; set; }

            public string RAM_Usage { get; set; }

        }
        /*  public class s122
          {
              public string site_id { get; set; }

              public string device_id { get; set; }

              public string alarm { get; set; }

              public string Trouble_count { get; set; }

              public string Description { get; set; }

              public string Maintainence_alert { get; set; }

              public string RAM_Usage { get; set; }

          }
        */
 }

