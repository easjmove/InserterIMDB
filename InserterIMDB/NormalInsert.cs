using InserterIMDB.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InserterIMDB
{
    class NormalInsert
    {
        public void InsertData(SqlConnection sqlConn, List<TitleBasic> allTitles)
        {
            //p4SSw0rd

            foreach (TitleBasic myTitle in allTitles)
            {
                SqlCommand sqlComm = new SqlCommand("INSERT INTO [dbo].[TitlesBasic] " +
           "([Tconst],[TitleType],[PrimaryTitle],[OriginalTitle] " +
           ",[IsAdult],[StartYear],[EndYear],[RuntimeMinutes]) " +
            "VALUES " +
           "('" + myTitle.tconst + "'" +
           ",'" + myTitle.titleType + "' " +
          " ,'" + myTitle.primaryTitle + "' " +
           ",'" + myTitle.originalTitle + "' " +
           ", " + (myTitle.isAdult ? 1 : 0) +
           "," + CheckForNull(myTitle.startYear) +
           "," + CheckForNull(myTitle.endYear) +
           "," + CheckForNull(myTitle.runTimeMinutes) + ")", sqlConn);

                try
                {
                    sqlComm.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(sqlComm.CommandText);
                    throw ex;
                }

            }

        }
        private string CheckForNull(int? input)
        {
            if (input == null)
            {
                return "NULL";
            }
            return "" + input;
        }
    }
}
