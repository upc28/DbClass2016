using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace DbClass
{
    public class CheckSQL
    {
        
        #region 特殊字符  
        /// <summary>  
        /// 检测是否有Sql危险字符  
        /// </summary>  
        /// <param name="str">要判断字符串</param>  
        /// <returns>判断结果</returns>  
        public static bool IsSafeSqlString(string str)
        {
            try
            {
                return !Regex.IsMatch(str, @"[-|;|,|/|(|)|[|]|}|{|%|@|*|!|']");
            }
            catch
            {
                return true;
            }
        }

        /// <summary>  
        /// 删除SQL注入特殊字符  
        /// 解然 20070622加入对输入参数sql为Null的判断  
        /// </summary>  
        public static string StripSQLInjection(string sql)
        {
            if (!string.IsNullOrEmpty(sql))
            {
                //过滤 ' --  
                string pattern1 = @"(%27)|(')|(--)";

                //防止执行 ' or  
                string pattern2 = @"((%27)|('))s*((%6F)|o|(%4F))((%72)|r|(%52))";

                //防止执行sql server 内部存储过程或扩展存储过程  
                string pattern3 = @"s+exec(s|+)+(s|x)pw+";

                sql = Regex.Replace(sql, pattern1, string.Empty, RegexOptions.IgnoreCase);
                sql = Regex.Replace(sql, pattern2, string.Empty, RegexOptions.IgnoreCase);
                sql = Regex.Replace(sql, pattern3, string.Empty, RegexOptions.IgnoreCase);
            }
            return sql;
        }      
        
        #endregion
    }
}