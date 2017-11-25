using System;
using System.Collections.Generic;
using System.Linq;
using licenseItExternal.Models.AppModel;
using licenseItExternal.Models.DataBaseModel;
using licenseItExternal.Repositories.Interfaces;

namespace licenseItExternal.Repositories
{
   
    public class LogsRepository : Repository<Logs>, ILogsRepository
    {
        private readonly DataBaseContext _context;

        public LogsRepository(DataBaseContext context) : base(context)
        {
            _context = context;
        }
    }
}
