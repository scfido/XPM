using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Xunmei.ProductRegister.Site.Models
{
    /// <summary>
    /// 分页显示的数据页码信息。
    /// 页码是从1开始的正整数。
    /// </summary>
    public class PagingInfo
    {
        public PagingInfo(int currentPage, int pageSize, int totalCount, int pagingCount = 10)
        {
            if (pagingCount < 1)
                pagingCount = 10;
            PagingCount = pagingCount;

            if (totalCount < 0)
                totalCount = 0;

            if (pageSize <= 0)
                pageSize = 10;
            PageSize = pageSize;

            FirstPage = 1;
            int result;
            LastPage = Math.DivRem(totalCount, pageSize, out result);
            if (result > 0)
                LastPage += 1;

            if (currentPage < 1 || currentPage > LastPage)
                CurrentPage = 1;
            else
                CurrentPage = currentPage;

            int ret = currentPage % pagingCount;
            if (ret > 0)
                BeginPage = currentPage - ret + 1;
            else
                BeginPage = currentPage - pagingCount + 1;

            if (BeginPage <1)
                BeginPage = 1;

            EndPage = BeginPage + PagingCount - 1;
            if (EndPage > LastPage)
                EndPage = LastPage;
        }

        /// <summary>
        /// 第一页页码，总是1。
        /// </summary>
        public int FirstPage { get; private set; }

        /// <summary>
        /// 最后一页页码。
        /// </summary>
        public int LastPage { get; private set; }

        /// <summary>
        /// 当前翻页范围开始页码，例如11。
        /// </summary>
        public int BeginPage { get; private set; }

        /// <summary>
        /// 当前翻页范围结束页码，例如20。
        /// </summary>
        public int EndPage { get; private set; }

        /// <summary>
        /// 翻页范围，默认显示当前页前后共10页。
        /// </summary>
        public int PagingCount { get; private set; }

        public int PageSize { get; private set; }

        /// <summary>
        /// 当前页。
        /// </summary>
        public int CurrentPage { get; private set; }

        public bool FirstEnabled
        {
            get { return CurrentPage+PagingCount <LastPage; }
        }

        public bool LastEnabled
        {
            get { return CurrentPage != LastPage; }
        }

        public bool PageEnabled(int number)
        {
            return number > BeginPage && number <= EndPage;
        }

        public bool IsCurrentPage(int number)
        {
            return number == CurrentPage;
        }
    }
}
