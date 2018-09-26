using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using Model.SystemModel;

namespace Data.SystemData
{
    public class LogData
    {
        public void AddLog(DataProvider dp, System_Log log)
        {
            dp.System_Log.Add(log);
        }

        public void GetLogList(DataProvider dp, LogFilter filter)
        {

        }
    }
}
