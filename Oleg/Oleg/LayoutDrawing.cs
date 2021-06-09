using System;
using System.Collections.Generic;
using System.Text;

namespace Oleg
{
    public static class LayoutDrawing
    {
        static int tableWidth = 90;

        public static void PrintLine()
        {
            Console.WriteLine(new string('-', tableWidth));
        }

        public static void PrintRow(params string[] columns)
        {
            int width = (tableWidth - columns.Length) / columns.Length;
            string row = "|";


            for (int i = 0; i < columns.Length; i++)
            {
                row += AlignCentre(columns[i], width);
            }

            //foreach (string column in columns)
            //{
            //    if (columns.GetEnumerator().MoveNext())
            //    {
            //        row += AlignCentre(column, width) + "|";
            //    }
            //    else
            //    {
            //        row += AlignCentre(column, width);
            //    }
            //}

            Console.WriteLine(row);
        }

        static string AlignCentre(string text, int width)
        {
            //text = text.Length > width ? /*text.Substring(0, width - 3)*/ + "..." : text;

            if (string.IsNullOrEmpty(text))
            {
                return new string(' ', width);
            }
            else
            {
                return text.PadRight(width - (width - text.Length) / 2).PadLeft(width);
            }
        }
    }
}
