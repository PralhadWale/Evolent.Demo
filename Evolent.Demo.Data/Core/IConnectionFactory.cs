using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Evolent.Demo.Data.Core
{
    public interface IConnectionFactory
    {
        IDbConnection GetConnection();
    }
}
