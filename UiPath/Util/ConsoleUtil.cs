using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUiPath.Util
{
    public static class ConsoleUtil
    {
        #region PrintLoadingString

        private static string[] DefaultPattern = new string[]
        {
            " ●    ",
            "  ●   ",
            "   ●  ",
            "    ● ",
            "     ●",
            "    ● ",
            "   ●  ",
            "  ●   ",
            " ●    ",
            "●     "
        };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="task"></param>
        /// <param name="pattern"></param>
        public static void PrintLoadingString<T>(Task<T> task, string[] pattern = null) where T : class
        {
            pattern = pattern ?? DefaultPattern;

            while (!task.IsCompleted)
            {
                Console.CursorVisible = false;

                foreach (var item in pattern)
                {
                    Console.Write(item);
                    Console.SetCursorPosition(0, Console.CursorTop);
                    System.Threading.Thread.Sleep(100);
                }
                Console.Write(new string(' ', pattern.Max().Length));
                Console.SetCursorPosition(0, Console.CursorTop);
                Console.CursorVisible = true;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="task"></param>
        /// <param name="pattern"></param>
        public static void PrintLoadingString(Task task, string[] pattern = null)
        {
            pattern = pattern ?? DefaultPattern;

            while (!task.IsCompleted)
            {
                Console.CursorVisible = false;

                foreach (var item in pattern)
                {
                    Console.Write(item);
                    Console.SetCursorPosition(0, Console.CursorTop);
                    System.Threading.Thread.Sleep(100);
                }
                Console.Write(new string(' ', pattern.Max().Length));
                Console.SetCursorPosition(0, Console.CursorTop);
                Console.CursorVisible = true;
            }
        }

        #endregion

        #region PrintTable

        public static void PrintTable<T>(List<T> models, List<string> displayHeaderList) where T : class
        {
            if (models == null || models.Count == 0 || displayHeaderList == null || displayHeaderList.Count == 0)
            {
                Console.WriteLine("対象のデータは存在しません。");
                return;
            }

            var table = ConsoleUtil.PrintTableCore<T>(models, displayHeaderList);
            Console.WriteLine(table);
        }

        private static string PrintTableCore<T>(List<T> models, List<string> displayHeaderList) where T : class
        {
            //テーブルソースの作成
            var tableSource = new Dictionary<string, List<string>>();
            for (int i = 0; i < displayHeaderList.Count; i++)
            {
                var colList = new List<string>();
                foreach (var model in models)
                {
                    foreach (var prop in model.GetType().GetProperties())
                    {
                        if (prop.Name.Equals(displayHeaderList[i]))
                        {
                            colList.Add(prop.GetValue(model) == null ?
                                        string.Empty : prop.GetValue(model).ToString());
                        }
                    }
                }
                tableSource.Add(displayHeaderList[i].ToString(), colList);
            }

            //フォーマットの作成
            int tableWidth = 2 + (displayHeaderList.Count - 1);
            List<int> colWidthList = new List<int>();
            foreach (var dicItem in tableSource)
            {

                var length = dicItem.Value.OrderByDescending(item => item.Length).First().Length + 1;
                if (length < dicItem.Key.Length)
                {
                    //if header name is longger than body value, use header name length.
                    length = dicItem.Key.Length + 1;
                }
                colWidthList.Add(length);
                tableWidth += length;
            }
            string tableTop = new string('=', tableWidth);
            var rowFormatBuilder = new StringBuilder();
            string tableBetweenRowAndRow = new string('-', tableWidth);
            string tableBotom = new string('=', tableWidth);

            var table = new StringBuilder();
            table.AppendLine(tableTop);

            //create header
            for (int col = 0; col < displayHeaderList.Count; col++)
            {
                var emmpyZone = new string(' ', Math.Abs(colWidthList[col] - displayHeaderList[col].Count()));
                table.Append($"|{displayHeaderList[col]}{emmpyZone}");
            }
            table.Append("|\r\n");

            //create table body
            table.AppendLine(tableBetweenRowAndRow);
            for (int row = 0; row < models.Count; row++)
            {
                for (int col = 0; col < displayHeaderList.Count; col++)
                {
                    var colValueTemp = models[row].GetType().GetProperty(displayHeaderList[col]).GetValue(models[row]);
                    var colValue = colValueTemp == null ? string.Empty : colValueTemp.ToString();

                    var emmpyZone = new string(' ', Math.Abs(colWidthList[col] - colValue.Count()));
                    table.Append($"|{colValue}{emmpyZone}");
                }
                table.Append("|\r\n");
            }
            table.AppendLine(tableBotom);
            return table.ToString();
        }

        #endregion
    }
}




