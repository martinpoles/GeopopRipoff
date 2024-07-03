using GeopopRipoff.Models;

namespace GeopopRipoff.Repository
{
    public class ArticlesRepository
    {
        public ArgumentsPageModel GetModelForArgumentPage(string oid_argument)
        {
            ArgumentsPageModel model = new ArgumentsPageModel();

            string qry = "select Argomenti.Id_Argomento, Argomenti.Ds_Argomenti, " +
                            "Articoli.Id_articolo, Articoli.Id_Path " +
                            "Autori.Id_Autore " +
                            "FROM Argomenti" +
                            "JOIN Articoli" +
                            "JOIN Autori" +
                            $"WHERE Argomenti.oid = {oid_argument}";

            return model;

        }
    }
}
