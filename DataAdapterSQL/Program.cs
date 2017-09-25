using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAdapterSQL
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
                //string sql = "select * from T_News";
                //SqlDataAdapter myda = new SqlDataAdapter(sql, myCon);
                //DataSet myds = new DataSet();
                //myda.Fill(myds, "T_News");
                //Console.WriteLine("填充成功");
                //OutValue(myds);

                //更改数据源文件
                string updatesql = "update T_News set Title='测试用的标题' where Id=1";
                SqlDataAdapter myda = new SqlDataAdapter("select * from T_News", myCon);
                myda.UpdateCommand = new SqlCommand(updatesql,myCon);
                DataSet myds = new DataSet();
                myda.Fill(myds, "T_News");
                Console.WriteLine("原dataset");
                OutValue(myds);
                DataRow row = myds.Tables[0].Rows[0];
                row["Title"] = "测试用的标题";
                myda.Update(myds, "T_News");
                Console.WriteLine("更新后的对象内容");
                OutValue(myds);
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

        public static void OutValue(DataSet ds)
        {
            foreach (DataTable dt in ds.Tables)
            {
                Console.WriteLine("表名：" + dt.TableName);
                foreach (DataRow row in dt.Rows)
                {
                    foreach (DataColumn col in dt.Columns)
                    {
                        Console.Write(row[col]+"\t");
                    }
                    Console.WriteLine();
                }
            }
        }

    }
}
