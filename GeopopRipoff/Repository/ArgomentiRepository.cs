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

        public IEnumerable<Argomento> GetAllActiveDocument()
        {

            string qry = "SELECT id_argomento FROM argomenti";

            return _genericRepository.Query<Argomento>(qry);
        }
        public IEnumerable<string> GetArgumentDescriptionByIdArgument(string id_argomento)
        {

            string qry = "SELECT argomenti.ds_argomento FROM argomenti" +
                            $" WHERE argomenti.id_argomento = '{id_argomento}'";

            return _genericRepository.Query<string>(qry);
        }
    }
}
