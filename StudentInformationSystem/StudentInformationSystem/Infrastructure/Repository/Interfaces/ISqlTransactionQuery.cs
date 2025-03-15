using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformationSystem.Infrastructure.Repository.Interfaces
{
    public interface ISqlTransactionQuery
    {
        Task<DataSet> ExecuteSp(string SpName, Dictionary<string, dynamic> param);
    }
}
