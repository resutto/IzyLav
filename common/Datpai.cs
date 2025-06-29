using System.Globalization;
using System.Text;
using Dapper;
using egourmetAPI.Model;
using FirebirdSql.Data.FirebirdClient;
using System.Security.Cryptography;

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
                if (empCodigo == -1) //Não tem Filtro Por Empresa
                {
                    id = con1.Query<IdLanc>(query).FirstOrDefault();
                }
                else {
                    id = con1.Query<IdLanc>(query, new { empresa = empCodigo }).FirstOrDefault();
                }

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

        public static string HashMD5(string input)
        {
            using (System.Security.Cryptography.MD5 md5Hash = System.Security.Cryptography.MD5.Create())
            {
                // Convert the valor string to a byte array and compute the hash.
                byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

                // Create a new Stringbuilder to collect the bytes
                // and create a string.
                StringBuilder sBuilder = new StringBuilder();

                // Loop through each byte of the hashed data 
                // and format each one as a hexadecimal string.
                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }

                // Return the hexadecimal string.
                return sBuilder.ToString();
            }
        }

    }
}
