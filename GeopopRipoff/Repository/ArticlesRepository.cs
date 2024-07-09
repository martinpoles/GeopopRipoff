using GeopopRipoff.Models;
using GeopopRipoff.Models.Home;
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

        public IEnumerable<Contenuto> Get9ArticleByArgomento(string id_argomento)
        {

            string qry = "SELECT top 9 contenuti.id_contenuto" 
                            + " FROM contenuti"
                            + " JOIN contenuti_argomenti ON contenuti.oid = contenuti_argomenti.oid_contenuto"
                            + " JOIN contenuti_formati ON contenuti.oid = contenuti_formati.oid_contenuto"
                            + " JOIN argomenti ON contenuti_argomenti.oid_argomento = argomenti.oid"
                            + " JOIN formati ON contenuti_formati.oid_formato = formati.oid"
                            + $" WHERE argomenti.id_argomento = '{id_argomento}'"
                            + " AND formati.id_formato = 'Articolo'";

            return _genericRepository.Query<Contenuto>(qry);
        }

        public Content GetArticleByIdArticle(string id_contenuto)
        {

            string qry = "SELECT contenuti.id_contenuto"
                            + " FROM contenuti"
                            + $" WHERE contenuti.id_contenuto = '{id_contenuto}'";

            return _genericRepository.Query<Content>(qry).FirstOrDefault();
        }

        public List<IdContenutoArgomento> GetLast2WeekStories()
        {

            string qry = " SELECT contenuti.id_contenuto, argomenti.id_argomento"
                        + " FROM contenuti"
                        + " JOIN contenuti_argomenti ON contenuti.oid = contenuti_argomenti.oid_contenuto"
                        + " JOIN contenuti_formati ON contenuti.oid = contenuti_formati.oid_contenuto"
                        + " JOIN argomenti ON contenuti_argomenti.oid_argomento = argomenti.oid"
                        + " JOIN formati ON contenuti_formati.oid_formato = formati.oid"
                        + " WHERE Dt_Pubblicazione >= DATEADD(WEEK, -2, GETDATE())" 
                        + " AND formati.id_formato = 'Articolo'"
                        + " ORDER BY Argomenti.Id_Argomento DESC";


            List<IdContenutoArgomento> list = _genericRepository.Query<IdContenutoArgomento>(qry).ToList();

            return list;
        }

    }
}
