using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace WKEU_BESR.Services.Cache
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}
