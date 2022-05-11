using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace NPOIExportTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Fuck Wayne");

            var sw = new Stopwatch();
            sw.Start();

            Test();

            sw.Stop();

            Console.WriteLine($"Ok,{sw.ElapsedMilliseconds}ms");

            Console.ReadKey();
        }

        static void Test()
        {
            /*
             *  1、声明XSSFWorkbook实例。

                2、利用声明并实例化的工作簿创建其工作表。

                3、写入Excel表头和表数据

                4、将实例化的工作簿写入流文件中。
             */

            using (FileStream fs = new FileStream("test.xlsx", FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                XSSFWorkbook workbook = new XSSFWorkbook();
                ISheet sheet = workbook.CreateSheet("Sheet1");

                string[] excelHeader = new string[] { "点名称", "编号", "时间", "埋深(m)", "水深(m)", "测试01", "测试02", "测试03", "测试04", "测试05", "测试06", "测试06", "测试07", "测试08", "测试09" };
                IRow headerRow = sheet.CreateRow(0);
                for (int i = 0; i < excelHeader.Length; i++)
                {
                    headerRow.CreateCell(i).SetCellValue(excelHeader[i]);
                }

                int count = 40000;
                for (int i = 0; i < count; i++)
                {
                    IRow row = sheet.CreateRow(i + 1);

                    for (int j = 0; j < excelHeader.Length; j++)
                    {
                        row.CreateCell(j).SetCellValue(excelHeader[j] + i);
                    }
                }

                // 写入到Excel中          
                workbook.Write(fs);
            }
        }
    }
}
