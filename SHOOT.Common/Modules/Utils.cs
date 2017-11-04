using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHOOT.Common.Modules
{
    public class Utils
    {
        private static readonly object olock = new object();

        /// <summary>
        /// 创建GUID
        /// </summary>
        /// <returns></returns>
        public static string CreateGUID()
        {
            return Guid.NewGuid().ToString("D");
        }

        public static DateTime GetDefaultDateTime()
        {
            DateTime ret = DateTime.Now;
            DateTime.TryParse("1900/01/01 00:00:01", out ret);
            return ret;
        }

        public static String GetCoupon(long MemberID = 1000)
        {
            long tick = DateTime.Now.Ticks;
            int oid = (int)MemberID;
            int tik = (int)tick;
            oid = oid - 10000 * (oid / 10000);
            tik = tik - 1000000 * (tik / 1000000);
            int Seed = oid * 1000000 + tik;
            Random ran = new Random(Seed);
            return GetRandomCode() + ran.Next(1, 1000000000).ToString().PadLeft(9, '0');
        }

        #region 随机生成四位数字
        public static string GetRandomNum()
        {
            int Seed = (int)DateTime.Now.Ticks;
            Random rand = new Random(Seed);
            string strRandomNum = string.Empty;
            lock (olock)
            {
                strRandomNum = string.Format(@"{0}{1}", DateTime.Now.ToString("MMddHHmmssfff"), rand.Next(999));
            }
            return strRandomNum;
        }
        /// <summary> 
        /// 随机生成四位数字
        /// </summary>
        /// <returns></returns>
        public static string GetRandomNum(int length = 4)
        {
            Random newRm = new Random(); //建立一个随机
            int[] Data = new int[length];     //建立一个length维数组保存数据

            int i;
            i = 0;
            Data[i] = newRm.Next(0, 9); //取得第一个随机数 (0至9之间)

            int x;
            while (i < length)   //循环,取够length位为止
            {
                Data[i] = newRm.Next(0, 9);//取得下一位随机数
                for (x = 0; x < i; x++)// 循环判断
                {
                    if (Data[i] == Data[x])//如果以前取得的重复了,
                    {
                        i = i - 1;  //重新取随机数
                    }
                }
                i++; //不重复.取下一位
            }
            string strNum = Data[0].ToString() + Data[1].ToString() + Data[2].ToString() + Data[3].ToString();
            return strNum;
        }
        #endregion
        #region 随机生成四位字母
        /// <summary>
        /// 从字符串里随机得到，规定个数的字符串.随机生成4个字母
        /// </summary>
        /// <returns></returns>
        private static string GetRandomCode()
        {
            string allChar = "A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z";
            string[] allCharArray = allChar.Split(',');
            string RandomCode = "";
            int temp = -1;
            Random rand = new Random();
            for (int i = 0; i < 4; i++)
            {
                if (temp != -1)
                {
                    rand = new Random(temp * i * ((int)DateTime.Now.Ticks));
                }

                int t = rand.Next(allCharArray.Length - 1);

                while (temp == t)
                {
                    t = rand.Next(allCharArray.Length - 1);
                }

                temp = t;
                RandomCode += allCharArray[t];
            }
            return RandomCode;
        }
        #endregion
    }
}
