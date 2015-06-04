using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TurtleEazyCheckout.Classes
{
    internal class BwArguments
    {
        internal JobType Type { get; set; }
        internal string ID { get; set; }
        internal string Message { get; set; }

        internal BwArguments(JobType type, string id)
        {            
            this.Type = type;
            this.ID = id;
        }
    }

    internal enum JobType
    {
        JIRA,
        LCS
    }
}
