using GeopopRipoff.Models;
using GeopopRipoff.Models.Menu;
using Microsoft.Data.SqlClient;

namespace GeopopRipoff.Repository
{
    public class ReelsRepository
    {
        private readonly GenericRepository _genericRepository;

        public ReelsRepository(GenericRepository genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public bool CheckLikeOnReel(string oid_utente, string id_contenuto)
        {
            string qry = "SELECT contenuti_like.fl_like "
                            + " FROM contenuti_like"
                            + " JOIN contenuti ON contenuti_like.oid_contenuto = contenuti.oid"
                            + " WHERE contenuti_like.oid = @OidContenuto AND contenuti.id_contenuto = @IdContenuto";

            var parameters = new { OidContenuto = oid_utente, 
                                    IdContenuto = id_contenuto};

            return _genericRepository.Query<bool>(qry, parameters).First();
        }

        public int InsertLike(string oid_utente, string id_contenuto)
        {
            int newOid = -1;
            string qry = "INSERT INTO contenuti_like"
                            + " (oid_contenuto, oid_utente, data_pubblicazione, fl_like)"
                            + " VALUES ("
                               + " (select oid from contenuto where id_contenuto = @IdContenuto),"
                               + " @OidUtente,"
                               + " GETDATE(),"
                               + " 1)";

            using (SqlConnection connection = new SqlConnection(_genericRepository.returnConnectionString()))
            {

                using (SqlCommand command = new SqlCommand(qry, connection))
                {
                    command.Parameters.AddWithValue("@IdContenuto", id_contenuto);
                    command.Parameters.AddWithValue("@OidUtente", oid_utente);

                    connection.Open();
                    newOid = (int)command.ExecuteScalar();
                }
            }

            return newOid;

        }

        public void UpdateLikeStatus(string oid_utente, string id_contenuto)
        {
            string qry = "UPDATE contenuti_like " 
                           + " SET fl_like = 1 - fl_like"
                           + " WHERE oid_contenuto = (SELECT oid FROM contenuto WHERE id_contenuto = @IdContenuto)"
                           + " AND oid_utente = @OidContenuto";

            var parameters = new
            {
                OidContenuto = oid_utente,
                IdContenuto = id_contenuto
            };

            _genericRepository.Query<int>(qry, parameters).First();
        }
    }
}
