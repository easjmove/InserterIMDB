using InserterIMDB.Models;
using System.Data.SqlClient;

namespace InserterIMDB
{
    interface IInsert
    {
        void InsertData(SqlConnection sqlConn, System.Collections.Generic.List<TitleBasic> allTitles);
    }
}