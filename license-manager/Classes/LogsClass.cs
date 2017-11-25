using System;
using licenseItExternal.Models.AppModel;
using licenseItExternal.Models.DataBaseModel;
using licenseItExternal.Repositories;
using licenseItExternal.Repositories.Interfaces;

namespace licenseItExternal.Classes
{
    public class LogsClass
    {
        private readonly ILogsRepository _logsRepository = new LogsRepository(new DataBaseContext());

        private Logs Logs { get; set; }

        public LogsClass(Logs logs)
        {
            Logs = logs;
        }


        public bool SetLogs()
        {
            try
            {
                return Logs != null && _logsRepository.Insert(Logs);
            }
            catch (Exception)
            {
                // ignore
            }
            return false;
        }
    }
}
