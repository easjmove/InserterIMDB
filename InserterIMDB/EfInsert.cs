using InserterIMDB.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InserterIMDB
{
    class EfInsert : IInsert
    {
        public void InsertData(SqlConnection sqlConn, List<TitleBasic> allTitles)
        {
            IMDBContext context = new IMDBContext();

            foreach (TitleBasic title in allTitles)
            {
                context.TitlesBasics.Add(title);
            }
            context.SaveChanges();
        }
    }
}
