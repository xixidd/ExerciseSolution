using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SaoLeiAPP
{
    /// <summary>
    /// 游戏难度
    /// </summary>
    public class GameLevelClass
    {
        /// <summary>
        /// 游戏难度 默认9*9(10颗地雷)sadasd
        /// </summary>
        public GameLevelClass()
        {
            width = 9;
            height = 9;
            mineCount = 10;


        }

        private int width;
        /// <summary>
        /// 地图宽度dsadsa
        /// </summary>
        public int Width
        {
            get { return width; }
            set { width = value; }
        }
        private int height;
        /// <summary>
        /// 地图高度
        /// </summary>
        public int Height
        {
            get { return height; }
            set { height = value; }
        }
        private int mineCount;
        /// <summary>
        /// 地雷数量
        /// </summary>
        public int MineCount
        {
            get { return mineCount; }
            set { mineCount = value; }
        }
    }
}
