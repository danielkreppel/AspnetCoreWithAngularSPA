using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Contract
{
    public interface IConnectionFactory
    {
        IDbConnection GetConnection();
    }
}
