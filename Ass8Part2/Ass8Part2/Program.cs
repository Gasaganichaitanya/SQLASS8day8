using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Ass8Part2
{
    internal class Program
    {
        private static string pid;

        static DataTable Create()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("PId", typeof(string));
            dt.Columns.Add("PName", typeof(string));            
            dt.Columns.Add("Price", typeof(int));
            dt.Columns.Add("MnfDate", typeof(DateTime));
            dt.Columns.Add("ExpDate", typeof(DateTime));
            dt.PrimaryKey = new DataColumn[] { dt.Columns["PId"] };
            return dt;
        }

        static void insert(DataTable dt, string pid, string pname,  int price, DateTime mnfdate, DateTime expdate)
        {
            DataRow dr = dt.NewRow();
            dr["PId"] = pid;
            dr["PName"] = pname;
            dr["Price"] = price;
            dr["MnfDate"] = mnfdate;
            dr["ExpDate"] = expdate;
            dt.Rows.Add(dr);
            Console.WriteLine($"Record inserted for ID {pid}");
        }
        static void Update(DataTable dt, string pid, string pname, int price, DateTime mnfdate, DateTime expdate)
        {
            DataRow updateRow = dt.Rows.Find(pid);
            if (updateRow != null)
            {
                updateRow["PName"] = pname;
                updateRow["Price"] = price;
                updateRow["MnfDate"] = mnfdate;
                updateRow["ExpDate"] = expdate;
            }
            else
            {
                Console.WriteLine($"No such ID {pid} exsist");
            }
        }

        static void Delete(DataTable dt, string pid)
        {
            DataRow delRow = dt.Rows.Find(pid);
            if (delRow == null)
            {
                Console.WriteLine($"No such ID {pid} exsist");
            }
            else
            {
                dt.Rows.Remove(delRow);
                Console.WriteLine($"Record with ID {pid} deleted from Table");
            }
        }

        static void Search(DataTable dt, string pid)
        {
            DataRow foundRow = dt.Rows.Find(pid);
            if (foundRow == null)
            {
                Console.WriteLine($"No such ID{pid} exsist");
            }
            else
            {
                Console.WriteLine("Record Fond Details as follows");
                Console.WriteLine($"PID : {foundRow["PId"]}");
                Console.WriteLine($"PName : {foundRow["PName"]}");
                Console.WriteLine($"Price : {foundRow["Price"]}");
                Console.WriteLine($"MnfDate : {foundRow["MnfDate"]}");
                Console.WriteLine($"ExpDate : {foundRow["ExpDate"]}");
            }
        }

        static void Display(DataTable dt)
        {
            Console.WriteLine("Stored Current Data in Table");
            foreach (DataRow row in dt.Rows)
            {
                Console.WriteLine("PID:" + row["PId"]);
                Console.WriteLine("PName:" + row["PName"]);
                Console.WriteLine("Price:" + row["Price"]);
                Console.WriteLine("MnfDate:" + row["MnfDate"]);
                Console.WriteLine("ExpDate :" + row["ExpDate"]);
                Console.WriteLine("*****************");
            }
        }
        static void Main(string[] args)
        {
            //insert
            DataTable dt = Create();
            insert(dt, "P00010", "Inventor",  25000, new DateTime(day: 20, month: 06, year: 2020), new DateTime(day: 21, month: 07, year: 2029));
            insert(dt, "P00012", "Lays", 150, new DateTime(day: 05, month: 11, year: 2022), new DateTime(day: 26, month: 09, year: 2024));
            insert(dt, "P00014", "Sprite", 250, new DateTime(day: 22, month: 08, year: 2023), new DateTime(day: 25, month: 11, year: 2024));
            Display(dt);

            //update
            Console.WriteLine("Enter PID to update the Data Row");
            string pId = Console.ReadLine();
            Console.WriteLine("Enter New Product Name");
            string newPname = Console.ReadLine();
            Console.WriteLine("Enter New Price");
            int newprice = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter new manufacture date");
            DateTime newmfdate = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Enter new expiry date");
            DateTime newexpdate = DateTime.Parse(Console.ReadLine());
            Update(dt, pId, newPname, newprice, newmfdate, newexpdate);
            Console.WriteLine("***After Update Method***");
            Display(dt);
            //delete
            Console.WriteLine("Enter Product Id to delete");
            string DelpId = Console.ReadLine();
            Delete(dt, DelpId);
            Console.WriteLine("After Delete Method Call Table");
            Display(dt);
            //search
            Console.WriteLine("Enter Product Id to Search the Data Row");
            pid = Console.ReadLine();
            Search(dt, pid);
            Console.ReadKey();
        }
    }
}
