using GeopopRipoff.Models;
using System.Security.Cryptography;

namespace GeopopRipoff.Repository
{
    public class ArgomentiRepository
    {
        private readonly GenericRepository _genericRepository;

        public ArgomentiRepository(GenericRepository genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public IEnumerable<Argomenti> GetAllActiveDocument(string id_argomento)
        {

            string qry = "SELECT id_argomento FROM argomenti" +
                            " WHERE argomenti.fl_attivo = 1";

            return _genericRepository.Query<Argomenti>(qry);
        }
    }
}
