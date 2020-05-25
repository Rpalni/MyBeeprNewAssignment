using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalTestAssignment.Module.Interface
{
    public interface IWorkingDays
    {
        int GetWorkingDays(DateTime from, DateTime to);
    }
}
