using Dapper;
using GeopopRipoff.Repository;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
public class GenericRepository
{
    private readonly AppDbContext _context;

    public GenericRepository(AppDbContext context)
    {
        _context = context;
    }

    private IDbConnection Connection => _context.Database.GetDbConnection();

    public IEnumerable<T> Query<T>(string sql, object parameters = null)
    {

        var connection = _context.Database.GetDbConnection();
        if (connection.State == ConnectionState.Closed)
            connection.Open();

        return connection.Query<T>(sql, parameters);

    }

    public object Execute(string sql, object parameters = null)
    {
        using (var connection = Connection)
        {
            if (connection.State == ConnectionState.Closed)
                connection.Open();

            return connection.Execute(sql, parameters);
        }
    }

    public string returnConnectionString()
    {
        return Connection.ConnectionString;
    }
}