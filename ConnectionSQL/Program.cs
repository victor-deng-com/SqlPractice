using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectionSQL
{
    class Program
    {
        static void Main(string[] args)
        {
            //数据库的连接分为两种方式:

            //1.Windows身份验证
            //string constr = "Server=.;integrated security=SSPI;Initial Catalog=ItcastDb";
            //2.SQL Server数据库账号密码
            string constr = "Server=.;user=sa;pwd=123456;database=ItcastDb";
            SqlConnection mySqlCon = new SqlConnection(constr);
            
            //mySqlCon.Open();
            //Console.WriteLine("数据库成功打开");

            //及时释放数据库的方法：
            //方法1：
            //mySqlCon.Close();
            //Console.WriteLine("数据库成功关闭");
            //方法2：通过using语句实现数据库的关闭
            //using (mySqlCon)
            //{
            //    mySqlCon.Open();
            //    Console.WriteLine("数据库成功打开");
            //}
            //方法3：通过try...catch...finally实现数据库的实时关闭
            try
            {
                mySqlCon.Open();
                Console.WriteLine("数据库成功打开");
            }
            catch { }
            finally
            {
                mySqlCon.Close();
                Console.WriteLine("数据库成功关闭");
            }
            //方法4：通过using语句与try...catch...finally结合使用，using语句放到try括号内
            //双重保险，确保数据库被及时关闭

            Console.ReadKey();
        }
    }
}
