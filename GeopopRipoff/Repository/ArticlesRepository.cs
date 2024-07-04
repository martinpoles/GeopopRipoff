using GeopopRipoff.Models;
using System.Security.Cryptography;

namespace GeopopRipoff.Repository
{
    public class ArticlesRepository
    {
        private readonly GenericRepository _genericRepository;

        public ArticlesRepository(GenericRepository genericRepository)
        {
            _genericRepository = genericRepository;
        }

        //public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
        //{
        //    var sql = "SELECT * FROM Customers";
        //    return await _genericRepository.QueryAsync<Customer>(sql);
        //}

        //public async Task<Customer> GetCustomerByIdAsync(int id)
        //{
        //    var sql = "SELECT * FROM Customers WHERE Id = @Id";
        //    var customers = await _genericRepository.QueryAsync<Customer>(sql, new { Id = id });
        //    return customers.FirstOrDefault();
        //}



        public async Task<IEnumerable<object>> GetAllCustomersAsync(string oid_argument)
        {

            string qry = "SELECT autori.id_autore, articoli.id_articolo from Argomenti "
                            + "join Argomenti_Articoli on Argomenti.Oid = Argomenti_Articoli.Oid_argomenti "
                            + "join Articoli on Argomenti_Articoli.Oid_articolo = articoli.Oid "
                            + "join Articoli_Autori on Articoli.Oid = Articoli_Autori.Oid_articolo "
                            + "join Autori on Articoli_Autori.Oid_autore = autori.Oid "
                            + "where argomenti.Id_Argomento = 'SCIENZE'" ;

            return _genericRepository.Query<object>(qry);
        }
    }
}
