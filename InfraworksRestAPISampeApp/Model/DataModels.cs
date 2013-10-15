using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InfraworksRestAPISampeApp.Model
{
    public class InfraworksService
    {
        public string name { get; set; }
        public string href { get; set; }
        public string description { get; set; }
    }

    public class Model
    {
        public string id { get; set; }
        public string name { get; set; }
        public string href { get; set; }
    }

//    public class RootObject
//{
//    public string name { get; set; }
//    public string id { get; set; }
//    public string model_type { get; set; }
//    public string parent { get; set; }
//    public List<Class> classes { get; set; }
//}


}
