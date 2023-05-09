using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR7_CSH
{
    class SubjectStatus
    {
        public Subject SubjectToChange { get; set; }
        public string InnitialSub { get; set; }
        public string FormattedSub { get; set; }
        public SubjectStatus(Subject sub, string initstat = "", string changedstat = "")
        {
            InnitialSub = initstat;
            FormattedSub = changedstat;
            SubjectToChange = sub;
        }
    }
}
