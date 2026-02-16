using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Infrastucture.Interfaces
{
    public interface IDbConnectionFactory
    {
        DbConnection CreateConnection();
    }
}
