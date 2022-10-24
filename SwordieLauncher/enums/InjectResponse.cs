using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Master.enums
{
    public enum InjectResponse
    {
        FAILED_GET_PROCESS_ID = 1,
        FAILED_LOADING_KERNEL_LoadLibraryA=2,
        FAILED_OPENPROCESS =3,
        FAILED_ALLOCATING_MEMORY_FOR_DLL=4,
        FAILED_WRITTING_PROCESS_MEMORY=5,
        FAILED_CREATEREMOTETHREAD=6,
        SUCCESS=0

    }
}
