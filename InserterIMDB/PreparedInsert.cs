using InserterIMDB.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InserterIMDB
{
    class PreparedInsert : IInsert
    {
        public void InsertData(SqlConnection sqlConn, List<TitleBasic> allTitles)
        {
            SqlCommand sqlComm = new SqlCommand("INSERT INTO [dbo].[TitlesBasic] " +
           "([Tconst],[TitleType],[PrimaryTitle],[OriginalTitle] " +
           ",[IsAdult],[StartYear],[EndYear],[RuntimeMinutes]) " +
            "VALUES " +
           "(@Tconst,@TitleType,@PrimaryTitle,@OriginalTitle" +
           ",@IsAdult,@StartYear,@EndYear,@RuntimeMinutes)", sqlConn);

            SqlParameter TconstPar = new SqlParameter("@Tconst", SqlDbType.VarChar,50);
            SqlParameter TitleTypePar = new SqlParameter("@TitleType", SqlDbType.VarChar, 50);
            SqlParameter PrimaryTitlePar = new SqlParameter("@PrimaryTitle", SqlDbType.VarChar, 8000);
            SqlParameter OriginalTitlePar = new SqlParameter("@OriginalTitle", SqlDbType.VarChar, 8000);
            SqlParameter IsAdultPar = new SqlParameter("@IsAdult", SqlDbType.Bit);
            SqlParameter StartYearPar = new SqlParameter("@StartYear", SqlDbType.Int);
            SqlParameter EndYearPar = new SqlParameter("@EndYear", SqlDbType.Int);
            SqlParameter RuntimeMinutesPar = new SqlParameter("@RuntimeMinutes", SqlDbType.Int);

            sqlComm.Parameters.Add(TconstPar);
            sqlComm.Parameters.Add(TitleTypePar);
            sqlComm.Parameters.Add(PrimaryTitlePar);
            sqlComm.Parameters.Add(OriginalTitlePar);
            sqlComm.Parameters.Add(IsAdultPar);
            sqlComm.Parameters.Add(StartYearPar);
            sqlComm.Parameters.Add(EndYearPar);
            sqlComm.Parameters.Add(RuntimeMinutesPar);

            sqlComm.Prepare();

            foreach (TitleBasic title in allTitles)
            {
                TconstPar.Value = title.tconst;
                TitleTypePar.Value = title.titleType;
                PrimaryTitlePar.Value = title.primaryTitle;
                OriginalTitlePar.Value = title.originalTitle;
                IsAdultPar.Value = title.isAdult;
                SetParameterValue(title.startYear, StartYearPar);
                SetParameterValue(title.endYear, EndYearPar);
                SetParameterValue(title.runTimeMinutes, RuntimeMinutesPar);

                sqlComm.ExecuteNonQuery();
            }
        }

        public void SetParameterValue(int? input, SqlParameter parameter)
        {
            if (input == null)
            {
                parameter.Value = DBNull.Value;
            } else
            {
                parameter.Value = input;
            }

        }
    }
}
