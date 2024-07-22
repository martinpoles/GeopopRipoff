using GeopopRipoff.Models;
using GeopopRipoff.Models.Argument;
using GeopopRipoff.Models.Home;
using Microsoft.Data.SqlClient;
using System.Security.Cryptography;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace GeopopRipoff.Repository
{
    public class ArticlesRepository
    {
        private readonly GenericRepository _genericRepository;

        public ArticlesRepository(GenericRepository genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public IEnumerable<Contenuto> GetArticleByArgomento(string id_argomento)
        {

            string qry = "SELECT distinct contenuti.id_contenuto, contenuti.dt_pubblicazione"
                         + " FROM contenuti"
                         + " JOIN contenuti_argomenti ON contenuti.oid = contenuti_argomenti.oid_contenuto"
                         + " JOIN contenuti_formati ON contenuti.oid = contenuti_formati.oid_contenuto"
                         + " JOIN argomenti ON contenuti_argomenti.oid_argomento = argomenti.oid"
                         + " JOIN formati ON contenuti_formati.oid_formato = formati.oid"
                         + " WHERE argomenti.id_argomento = @IdArgomento"
                         + " AND formati.id_formato = 'Articolo'"
                         + " ORDER BY contenuti.dt_pubblicazione DESC";

            //using (SqlCommand command = new SqlCommand(qry))
            //{
            //    command.Parameters.AddWithValue("@IdArgomento", id_argomento);
            //}
            var parameters = new { IdArgomento = id_argomento };

            return _genericRepository.Query<Contenuto>(qry, parameters);
        }

        public DbDataArticle GetArticleByIdArticle(string id_contenuto)
        {


            string qry = "SELECT contenuti.id_contenuto, autori.id_autore, contenuti.dt_pubblicazione"
                            + " FROM contenuti"
                            + " join contenuti_autori on contenuti.oid = contenuti_autori.oid_contenuto"
                            + " join autori on contenuti_autori.oid_autore = autori.oid"
                            + " WHERE contenuti.id_contenuto = @IdContenuto";
            
            var parameters = new { IdContenuto = id_contenuto };

            return _genericRepository.Query<DbDataArticle>(qry, parameters).FirstOrDefault();
        }

        public List<IdContenutoArgomento> GetLast2WeekStories()
        {

            string qry = " SELECT top 9 contenuti.id_contenuto, argomenti.id_argomento"
                        + " FROM contenuti"
                        + " JOIN contenuti_argomenti ON contenuti.oid = contenuti_argomenti.oid_contenuto"
                        + " JOIN contenuti_formati ON contenuti.oid = contenuti_formati.oid_contenuto"
                        + " JOIN argomenti ON contenuti_argomenti.oid_argomento = argomenti.oid"
                        + " JOIN formati ON contenuti_formati.oid_formato = formati.oid"
                        + " WHERE Dt_Pubblicazione >= DATEADD(WEEK, -4, GETDATE())" 
                        + " AND formati.id_formato = 'Articolo'"
                        + " ORDER BY Argomenti.Id_Argomento DESC";


            List<IdContenutoArgomento> list = _genericRepository.Query<IdContenutoArgomento>(qry).ToList();

            return list;
        }


        public List<Content> GetLast5Reels()
        {

            string qry = " SELECT top 5 contenuti.id_contenuto, argomenti.id_argomento"
                        + " FROM contenuti"
                        + " JOIN contenuti_argomenti ON contenuti.oid = contenuti_argomenti.oid_contenuto"
                        + " JOIN contenuti_formati ON contenuti.oid = contenuti_formati.oid_contenuto"
                        + " JOIN argomenti ON contenuti_argomenti.oid_argomento = argomenti.oid"
                        + " JOIN formati ON contenuti_formati.oid_formato = formati.oid"
                        + " WHERE formati.id_formato = 'Reels'"
                        + " ORDER BY contenuti.dt_pubblicazione DESC";


            List<Content> list = _genericRepository.Query<Content>(qry).ToList();

            return list;
        }




        
    }
}
