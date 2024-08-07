﻿using GeopopRipoff.Models;
using Microsoft.Data.SqlClient;
using System.Security.Cryptography;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

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
        public List<Argomento> GetArgumentDescriptionByIdArgument(string id_argomento)
        {

            string qry = "SELECT argomenti.ds_argomento FROM argomenti" +
                            $" WHERE argomenti.id_argomento = @IdArgomento";

            var parameters = new { IdArgomento = id_argomento };

            return _genericRepository.Query<Argomento>(qry, parameters).ToList();
        }
    }
}
