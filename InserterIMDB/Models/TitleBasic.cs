﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InserterIMDB.Models
{
    public class TitleBasic
    {
        public string tconst { get; set; }
        public string titleType { get; set; }
        public string primaryTitle { get; set; }
        public string originalTitle { get; set; }
        public bool isAdult { get; set; }
        public int? startYear { get; set; }
        public int? endYear { get; set; }
        public int? runTimeMinutes { get; set; }

        public TitleBasic()
        {
        }

        public TitleBasic(string[] splitLine)
        {
            tconst = splitLine[0];
            titleType = splitLine[1];
            primaryTitle = splitLine[2];
            originalTitle = splitLine[3];
            isAdult =  splitLine[4] == "1";
            startYear = CheckIntForNull(splitLine[5]);
            endYear = CheckIntForNull(splitLine[6]);
            runTimeMinutes = CheckIntForNull(splitLine[7]);
        }

        private static int? CheckIntForNull(string input)
        {
            if (input == "\\N")
            {
                return null;
            }
            return int.Parse(input);
        }
    }
}
