using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace Data.SystemData
{
    public class LogData
    {
        public void AddLog(DataProvider dp, System_Log log)
        {
            dp.System_Log.Add(log);
        }
    }
}
