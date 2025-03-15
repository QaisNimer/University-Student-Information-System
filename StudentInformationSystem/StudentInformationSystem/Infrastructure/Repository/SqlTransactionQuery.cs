using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using StudentInformationSystem.Infrastructure.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformationSystem.Infrastructure.Repository
{
    public class SqlTransactionQuery : ISqlTransactionQuery
    {
        private readonly IConfiguration _configuration;
       
        public SqlTransactionQuery(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<DataSet> ExecuteSp(string SpName, Dictionary<string, dynamic> param)
        {
            DataSet dataSet = new DataSet();

            try
            {
                using (SqlConnection connection = new SqlConnection(_configuration.GetSection("ConnectionStrings:DefaultConnection").Value))
                {
                    await connection.OpenAsync();

                    using (SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandText = SpName;
                        command.CommandType = CommandType.StoredProcedure;

                        foreach (var item in param)
                        {
                            if (item.Value == null)
                            {
                                command.Parameters.AddWithValue(item.Key, DBNull.Value);
                            }
                            else
                            {
                                command.Parameters.AddWithValue(item.Key, item.Value);
                            }
                        }

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(dataSet);
                            await connection.CloseAsync();
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                // Serilog need to be applied here
                Console.WriteLine("An error occurred: " + ex.Message);
            }

            return dataSet;
        }

    }
}
