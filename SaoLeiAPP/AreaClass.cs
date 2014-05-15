using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SaoLeiAPP
{
    /// <summary>
    /// 区域
    /// </summary>
    public class AreaClass
    {
        public AreaClass(int areaNO)
        {
            AreaNO = areaNO;
            isCheck = false;
            isMark = false;
        }

        private int areaNO;
        /// <summary>
        /// 区域编号9*9（1-81）
        /// </summary>
        public int AreaNO
        {
            get { return areaNO; }
            set { areaNO = value; }
        }

        private bool isCheck;
        /// <summary>
        /// 是否已查看
        /// </summary>
        public bool IsCheck
        {
            get { return isCheck; }
            set { isCheck = value; }
        }

        private int nearbyMineCount;
        /// <summary>
        /// 附近地雷数量
        /// </summary>
        public int NearbyMineCount
        {
            get { return nearbyMineCount; }
            set { nearbyMineCount = value; }
        }

        private bool isMark;
        /// <summary>
        /// 是否已标记（插旗）
        /// </summary>
        public bool IsMark
        {
            get { return isMark; }
            set { isMark = value; }
        }
    }
}
