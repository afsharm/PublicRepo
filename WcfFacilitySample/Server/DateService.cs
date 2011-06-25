using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using Common;

namespace Server
{
    [ServiceBehavior]
    public class DateService : IDateService
    {
        public string SaySomething(string first)
        {
            return string.Format("come on {0} go back", first);
        }
    }
}
