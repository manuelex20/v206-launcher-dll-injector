using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Master.enums
{
    public enum CreateResponse
    {

        SUCCESS = 0,
        NAME_TAKEN = 1,
        IP_ALREADY_CREATED = 2,
        UNKNOWN_ERROR = 3,

    }
}
