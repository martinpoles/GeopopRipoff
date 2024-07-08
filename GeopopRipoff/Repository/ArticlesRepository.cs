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

        public IEnumerable<TempTemp> GetLast2WeekStories()
        {

            string qry = " SELECT Articoli.Id_Articolo, Argomenti.id_argomento"
                        + " FROM Articoli"
                        + " JOIN Argomenti_articoli ON Articoli.oid = Argomenti_articoli.oid_articolo"
                        + " JOIN Argomenti ON Argomenti_articoli.oid_argomenti = Argomenti.oid"
                        + " WHERE Dt_Pubblicazione >= DATEADD(WEEK, -2, GETDATE())"
                        + " ORDER BY Argomenti.Id_Argomento DESC";

            return _genericRepository.Query<TempTemp>(qry);
        }

    }
}
