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



        public IEnumerable<TempClass> GetAllCustomers(string id_argomento)
        {

            string qry = "SELECT top 9 articoli.id_articolo, argomenti.ds_argomento" 
                            + " FROM Argomenti"
                            + " JOIN Argomenti_Articoli ON Argomenti.Oid = Argomenti_Articoli.Oid_argomenti"
                            + " JOIN Articoli ON Argomenti_Articoli.Oid_articolo = articoli.Oid"
                            +$" WHERE argomenti.Id_Argomento = '{id_argomento}'";

            return _genericRepository.Query<TempClass>(qry);
        }

        public TempClass GetArticleByIdArticle(string id_articolo)
        {

            string qry = "SELECT articoli.id_articolo"
                            + " FROM articoli"
                            + $" WHERE articoli.id_articolo = '{id_articolo}'";

            return _genericRepository.Query<TempClass>(qry).FirstOrDefault();
        }

    }
}
