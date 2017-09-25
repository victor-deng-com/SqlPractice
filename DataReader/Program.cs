using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataReader
{
    class Program
    {
        static void Main(string[] args)
        {
            string constr = "Server=.;user=sa;pwd=123456;database=ItcastDb";
            SqlConnection myCon = new SqlConnection(constr);
            try
            {
                myCon.Open();
                string sql = "select * from T_News";
                SqlCommand myCom = new SqlCommand(sql, myCon);
                //声明SqlDataReader
                SqlDataReader mydr;
                mydr = myCom.ExecuteReader();
                if (mydr.HasRows)
                {
                    Console.WriteLine("存在数据");
                }
                else
                {
                    Console.WriteLine("没有数据");
                }
                //Console.WriteLine(mydr.FieldCount);
                //Console.WriteLine(mydr.IsClosed);
                //Console.WriteLine(mydr.GetDataTypeName(1));
                //Console.WriteLine(mydr.GetName(1));//1表示从索引1列得到数据，索引从0开始
                //Console.WriteLine(mydr.GetOrdinal("Title"));//获取字段名对应的索引
                //if (mydr.Read())
                //    Console.WriteLine(mydr.GetValue(1));

                //object[] myobj = new object[mydr.FieldCount];
                //while (mydr.Read())
                //{
                //    mydr.GetValues(myobj);
                //    foreach (object outobj in myobj)
                //    {
                //        Console.Write(outobj + "\t");
                //    }
                //    Console.WriteLine();
                //}

                while (mydr.Read())
                {
                    Console.WriteLine(mydr[0].ToString() + ",");
                    Console.WriteLine(mydr["Title"].ToString() + ",");
                    Console.WriteLine(mydr[3].ToString() + ",");//使用索引值要比使用字段名快很多
                    Console.WriteLine();
                }

                mydr.Close();
                //Console.WriteLine(mydr.IsClosed);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
            finally
            {
                myCon.Close();
            }
            Console.ReadKey();
        }
    }
}
