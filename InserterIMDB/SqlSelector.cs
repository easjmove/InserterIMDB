using InserterIMDB.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InserterIMDB
{
    class SqlSelector
    {
        public List<TitleBasic> SelectAllTitles(SqlConnection sqlConn)
        {
            List<TitleBasic> allTitles = new List<TitleBasic>();

            SqlCommand sqlComm = new SqlCommand("SELECT TOP (1000) [Tconst],[TitleType],[PrimaryTitle],[OriginalTitle] " +
                                                ",[IsAdult],[StartYear],[EndYear],[RuntimeMinutes] " +
                                                "FROM [IMDB].[dbo].[TitlesBasic] WHERE IsAdult = 0", sqlConn);
            SqlDataReader sqlReader = sqlComm.ExecuteReader();
            while (sqlReader.Read())
            {
                allTitles.Add(new TitleBasic(sqlReader));
            }
            sqlReader.Close();

            return allTitles;
        }
    }
}
