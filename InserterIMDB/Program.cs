using InserterIMDB.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;

namespace InserterIMDB
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection sqlConn = new SqlConnection("server=localhost;database=IMDB;user id=IMDB_inserter;password=p4SSw0rd");
            sqlConn.Open();

            List<TitleBasic> allTitles = ReadAllTitles(@"C:\Users\zealand\Downloads\DB Elective\title.basics.tsv\data.tsv", 50000);
            Console.WriteLine("Has read all lines");

            //DateTime beforeTime = DateTime.Now;
            //IInsert myInserter = new NormalInsert();
            //IInsert myInserter = new PreparedInsert();
            //IInsert myInserter = new EfInsert();
            //IInsert myInserter = new BulkInsert();
            //myInserter.InsertData(sqlConn, allTitles);
            //DateTime afterTime = DateTime.Now;

            //Console.WriteLine("It took: " + afterTime.Subtract(beforeTime).TotalSeconds + " seconds");

            SqlSelector mySelector = new SqlSelector();
            foreach (TitleBasic title in mySelector.SelectAllTitles(sqlConn))
            {
                Console.WriteLine(title.originalTitle);
            }

            sqlConn.Close();
        }

        public static List<TitleBasic> ReadAllTitles(string filePath, int maxRows)
        {
            List<TitleBasic> allTitles = new List<TitleBasic>();

            int counter = 0;
            foreach (string line in File.ReadLines(filePath))
            {
                if (counter != 0)
                {
                    string[] splitLine = line.Split("\t");
                    if (splitLine.Length == 9)
                    {
                        allTitles.Add(new TitleBasic(splitLine));
                    }
                }
                counter++;

                if (counter >= maxRows)
                {
                    break;
                }
            }

            return allTitles;
        }
    }
}
