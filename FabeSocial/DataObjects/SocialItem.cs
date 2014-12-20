using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Mobile.Service;

namespace FabeSocial.DataObjects
{
    public class SocialItem : EntityData
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MobilePhone { get; set; }
        public string EmailAddr { get; set; }
        public string TwitterHandle { get; set; }
        public string IGName { get; set; }
        public string FBName { get; set; }
    }
}
