using GeopopRipoff.Models;
using GeopopRipoff.Models.Menu;
using Microsoft.Data.SqlClient;

namespace GeopopRipoff.Repository
{
    public class LogSignInOutRepository
    {
        private readonly GenericRepository _genericRepository;

        public LogSignInOutRepository(GenericRepository genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public int InsertUtente(string id_username, string id_nome, string id_cognome, string id_email)
        {
            int newOid = -1;

            string qry = "INSERT INTO Utenti (id_username, id_nome, id_cognome, id_email) "
                         + "OUTPUT INSERTED.oid "
                         + $" VALUES (@IdUsername, @IdNome, @IdCognome, @IdEmail)";
            
            
            using (SqlConnection connection = new SqlConnection(_genericRepository.returnConnectionString()))
            {

                using (SqlCommand command = new SqlCommand(qry, connection))
                {
                    command.Parameters.AddWithValue("@IdUsername", id_username);
                    command.Parameters.AddWithValue("@IdNome", id_nome);
                    command.Parameters.AddWithValue("@IdCognome", id_cognome);
                    command.Parameters.AddWithValue("@IdEmail", id_email);

                    connection.Open();
                    newOid = (int)command.ExecuteScalar();
                }
            }

            return newOid;
        }

        public Utente GetUtenteByOid(string oid)
        {

            string qry = "SELECT id_username, id_nome, id_cognome, id_email FROM utenti"
                            + $" WHERE utenti.oid = {oid}";

            return _genericRepository.Query<Utente>(qry).FirstOrDefault();
        }

    }
}
