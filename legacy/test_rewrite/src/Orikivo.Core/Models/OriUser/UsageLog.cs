using System.Collections.Generic;

namespace Orikivo
{
    public class UsageLog
    {
        public ulong UsageCount {get; set;}
        public ulong ErrorCount {get; set;}
        public List<CommandLog> Commands {get; set;}
        public double SuccessRate {get; set;} // the success rate of commands executed.
    }
}