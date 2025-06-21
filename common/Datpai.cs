using System.Globalization;
using System.Text;
using Dapper;
using egourmetAPI.Model;
using FirebirdSql.Data.FirebirdClient;

namespace IzyLav.common
{
    public static class Datpai
    {
        public static string RemoveAccents(this string text)
        {
            StringBuilder sbReturn = new StringBuilder();
            var arrayText = text.Normalize(NormalizationForm.FormD).ToCharArray();
            foreach (char letter in arrayText)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(letter) != UnicodeCategory.NonSpacingMark)
                    sbReturn.Append(letter);
            }
            
            return sbReturn.ToString().ToUpper();
        }

        public static IdLanc GerarIdLanc(int empCodigo, FbConnection con1, string query)
        {
            try
            {
                IdLanc id;
                id = con1.Query<IdLanc>(query, new { empresa = empCodigo }).FirstOrDefault();
                if (id.idLanc == 0)
                {
                    id.idLanc = 1;
                }
                return id;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


    }
}
