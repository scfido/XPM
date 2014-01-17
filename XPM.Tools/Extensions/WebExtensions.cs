using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Xunmei.ProductRegister.Tools
{
    public static class WebExtensions
    {

        public static MvcHtmlString Test(this String s)
        {
           return new MvcHtmlString("是");
        }

        public static MvcHtmlString ThenBy(this HtmlHelper html, Func<bool> predicate, string trueValue, string falseValue)
        {
            //ThenBy(null, () => true, "是", "否");
            bool ret = predicate.Invoke();
            if (ret)
                return new MvcHtmlString(trueValue);
            else
                return new MvcHtmlString(falseValue);
        }

        /// <summary>
        /// 使用最适合的K、M、G、T为单位表示容量。
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        public static MvcHtmlString GetOptimumSize(this int size)
        {
            return GetOptimumSize((long)size);
        }

        /// <summary>
        /// 使用最适合的K、M、G、T为单位表示容量。
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        public static MvcHtmlString GetOptimumSize(this long size)
        {
            const long K = 1024;
            const long M = 1024 * K;
            const long G = 1024 * M;
            const long T = 1024 * G;

            if (size < K)
                return new MvcHtmlString(size.ToString());
            else if (size < M)
                return new MvcHtmlString((size / K).ToString() + "K");
            else if (size < G)
                return new MvcHtmlString((size / M).ToString() + "M");
            else if (size < T)
                return new MvcHtmlString((size / G).ToString() + "G");
            else
                return new MvcHtmlString((size / T).ToString() + "T");
        }
    }
}