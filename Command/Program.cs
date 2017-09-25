using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Command
{
    class Program
    {
        static void Main(string[] args)
        {
            string constr = "Server=.;user=sa;pwd=123456;database=ItcastDb";
            SqlConnection myCon = new SqlConnection(constr);
            try
            {
                ////创建command对象过程
                //myCon.Open();
                //string sql = "select * from T_News";
                //SqlCommand myCom = new SqlCommand(sql, myCon);
                //myCom.CommandTimeout = 2;
                //Console.WriteLine("创建对象成功");

                ////新增、修改、删除数据ExcuteNonQuery()
                //myCon.Open();
                //string sql = "insert T_News(Title,Msg,SubDateTime,Author,ImagePath)values('插入数据','内容测试','2017-09-16 12:18:00.777','Victor','Imgs/test.jpg')";
                //SqlCommand myCom = new SqlCommand(sql,myCon);
                //myCom.ExecuteNonQuery();
                //Console.WriteLine("数据更改完成");

                //ExecuteScalar
                myCon.Open();
                string sql = "select max(Id) from T_News";
                SqlCommand myCom=new SqlCommand(sql,myCon);
                int t = 0;
                t = (int)myCom.ExecuteScalar();
                Console.WriteLine("最大的ID是"+t);
            }
            catch(Exception ex)
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
