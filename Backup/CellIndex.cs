using System;
using System.Collections.Generic;
using System.Text;

namespace ExportToExcel
{
   public class CellIndex
   {

       public int Row;
       public int Col;
       public CellIndex(int row, int col)
       {
           this.Row = row;
           this.Col = col;
       }
   };
    public class MergeRow
    {
        public int Row;
        public string  StartColumnName;
        public string  EndColumnName;
        public MergeRow(int row, string startcolumnName, string endcolumnName)
        {
            this.Row = row;
            this.StartColumnName = startcolumnName;
            this.EndColumnName = endcolumnName;
        }
        public static int IndexOf_(int row,List<MergeRow>lstC)
        {
            if (lstC == null || lstC.Count == 0) return -1;
            int i = 0; bool temp = false;
            while (i < lstC.Count && !temp)
            {
                if (lstC[i].Row == row) temp = true;
                else i++;
            }
            if(temp)        return i;
            return -1;
        }
    }
}
