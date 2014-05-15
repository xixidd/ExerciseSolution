using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SaoLeiAPP
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {

        private bool isFirst = true;
        private GameLevelClass gameLevel = new GameLevelClass();
        public MainWindow()
        {
            InitializeComponent();
            InitGameCanvas();
        }

        private void InitGameCanvas()
        {
            GameWrapPanel.ItemHeight = 50;
            GameWrapPanel.ItemWidth = 50;
            int x = 9;
            int y = 9;
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    Button btn = new Button();
                    btn.Background = Brushes.Black;
                    btn.FontWeight = FontWeights.Medium;
                    btn.FontSize = 32;
                    btn.Tag = new AreaClass(i * 9 + j + 1);//tag 
                    btn.PreviewMouseLeftButtonDown += new MouseButtonEventHandler(btn_PreviewMouseLeftButtonDown);
                    //btn.MouseRightButtonDown += new MouseButtonEventHandler(btn_MouseRightButtonDown);
                    GameWrapPanel.Children.Add(btn);

                }
            }
        }
        private int[] leiIndex;
        void btn_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Button btn = (Button)sender;
            AreaClass ac = (AreaClass)btn.Tag;
            int a = ac.AreaNO;
            if (isFirst)
            {
                isFirst = false;
                //加载地雷
                Random random = new Random();
                leiIndex = new int[10];
                for (int i = 0; i < 10; i++)
                {
                    int randomNumber = random.Next(1, 81 + 1);
                    if (leiIndex.Contains(randomNumber))
                    {
                        i = i - 1;
                    }
                    else
                    {
                        leiIndex[i] = randomNumber;
                    }
                }
            }
            else
            {

            }
            if (leiIndex.Contains(a))
            {
                foreach (Button item in GameWrapPanel.Children)
                {
                    if (leiIndex.Contains(((AreaClass)item.Tag).AreaNO))
                    {
                        item.Background = Brushes.White;
                        item.Content = "*";
                    }
                }
            }
            else
            {
                //btn.Background = Brushes.White;
                //int fujin = 0;
                //fujin = leiIndex.Contains(a + 1) == true ? +1 : +0;
                //fujin = leiIndex.Contains(a - 1) == true ? +1 : +0;
                //fujin = leiIndex.Contains(a - 9) == true ? +1 : +0;
                //fujin = leiIndex.Contains(a - 9 + 1) == true ? +1 : +0;
                //fujin = leiIndex.Contains(a - 9 - 1) == true ? +1 : +0;
                //fujin = leiIndex.Contains(a + 9) == true ? +1 : +0;
                //fujin = leiIndex.Contains(a + 9 + 1) == true ? +1 : +0;
                //fujin = leiIndex.Contains(a + 9 - 1) == true ? +1 : +0;
                //while (fujin == 0)
                //{
                //    //GameWrapPanel.Children[]
                //}

                //btn.Content = fujin.ToString();
                CheckArea(btn);
            }
        }

        private void CheckArea(Button btn)
        {
            AreaClass area = (AreaClass)btn.Tag;
            if (area.IsCheck == false)
            {
                area.IsCheck = true;
                //btn.Tag = area;
                btn.Background = Brushes.White;

                int fujin = 0;

                if (area.AreaNO >= 1 && area.AreaNO <= 81)
                {
                    fujin += leiIndex.Contains(area.AreaNO - 9) == true ? 1 : 0;
                    fujin += leiIndex.Contains(area.AreaNO + 9) == true ? 1 : 0;
                    if (area.AreaNO % 9 != 1)
                    {
                        fujin += leiIndex.Contains(area.AreaNO - 1) == true ? 1 : 0;
                        fujin += leiIndex.Contains(area.AreaNO - 9 - 1) == true ? 1 : 0;
                        fujin += leiIndex.Contains(area.AreaNO + 9 - 1) == true ? 1 : 0;
                    }
                    if (area.AreaNO % 9 != 0)
                    {
                        fujin += leiIndex.Contains(area.AreaNO + 1) == true ? 1 : 0;
                        fujin += leiIndex.Contains(area.AreaNO - 9 + 1) == true ? 1 : 0;
                        fujin += leiIndex.Contains(area.AreaNO + 9 + 1) == true ? 1 : 0;
                    }


                }
                if (fujin == 0)
                {
                    if ((area.AreaNO - 9) >= 1 && (area.AreaNO - 9) <= 81)
                    {
                        Button NeedCheckbtn_T = ((Button)GameWrapPanel.Children[area.AreaNO - 9 - 1]);
                        CheckArea(NeedCheckbtn_T);
                    }
                    if ((area.AreaNO + 9) >= 1 && (area.AreaNO + 9) <= 81)
                    {
                        Button NeedCheckbtn_D = ((Button)GameWrapPanel.Children[area.AreaNO + 9 - 1]);
                        CheckArea(NeedCheckbtn_D);
                    }
                    if (area.AreaNO % 9 != 1)
                    {
                        if ((area.AreaNO - 1) >= 1 && (area.AreaNO - 1) <= 81)
                        {
                            Button NeedCheckbtn_L = ((Button)GameWrapPanel.Children[area.AreaNO - 1 - 1]);
                            CheckArea(NeedCheckbtn_L);
                        }
                        if ((area.AreaNO + 9 - 1) >= 1 && (area.AreaNO + 9 - 1) <= 81)
                        {
                            Button NeedCheckbtn_DL = ((Button)GameWrapPanel.Children[area.AreaNO + 9 - 1 - 1]);
                            CheckArea(NeedCheckbtn_DL);
                        }

                        if ((area.AreaNO - 9 - 1) >= 1 && (area.AreaNO - 9 - 1) <= 81)
                        {
                            Button NeedCheckbtn_TL = ((Button)GameWrapPanel.Children[area.AreaNO - 9 - 1 - 1]);
                            CheckArea(NeedCheckbtn_TL);
                        }
                    }
                    if (area.AreaNO % 9 != 0)
                    {
                        if ((area.AreaNO + 1) >= 1 && (area.AreaNO + 1) <= 81)
                        {
                            Button NeedCheckbtn_R = ((Button)GameWrapPanel.Children[area.AreaNO + 1 - 1]);
                            CheckArea(NeedCheckbtn_R);
                        }

                        if ((area.AreaNO + 9 + 1) >= 1 && (area.AreaNO + 9 + 1) <= 81)
                        {
                            Button NeedCheckbtn_DR = ((Button)GameWrapPanel.Children[area.AreaNO + 9 + 1 - 1]);
                            CheckArea(NeedCheckbtn_DR);
                        }
                        if ((area.AreaNO - 9 + 1) >= 1 && (area.AreaNO - 9 + 1) <= 81)
                        {
                            Button NeedCheckbtn_TR = ((Button)GameWrapPanel.Children[area.AreaNO - 9 + 1 - 1]);
                            CheckArea(NeedCheckbtn_TR);
                        }
                    }

                }
                else
                {
                    area.IsCheck = true;
                    btn.Tag = area;
                    btn.Background = Brushes.White;
                    btn.Content = fujin.ToString();
                    BrushConverter bc = new BrushConverter();
                    switch (fujin)
                    {
                        case 1:
                            btn.Foreground = (Brush)bc.ConvertFrom("#02A4F8");
                            break;
                        case 2:
                            btn.Foreground = (Brush)bc.ConvertFrom("#B0E400");
                            break;
                        case 3:
                            break;
                        case 4:
                            break;
                        case 5:
                            break;
                        case 6:
                            break;
                        case 7:
                            break;
                        case 8:
                            break;
                        default:
                            break;
                    }
                }
            }
            else
            {
            }

        }

        void btn_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void InitLei()
        {
            //9*9 10
            //16*16 40


        }

    }
}
