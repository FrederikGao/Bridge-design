using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.UI.Events;
using Autodesk.Revit.DB.Events;
using Autodesk.Revit;
using System.Drawing;

namespace Bridge_design
{
    /// <summary>
    /// 将长度数据转换为数组坐标的工具类
    /// </summary>
    class XYZ_Transformation
    {/*
        
        //定义比例系数，这个比例是窗体绘图的时候用来自适应窗体的
        public float j;
        /// <summary>
        /// 对于输入失误或者截面较大时做出的自适应调整，进行比例缩放
        /// </summary>
        public void xyz_Limit()
        {
            int i;
            //确定一个高和宽的上限，限定边为上侧宽度，下测宽度以及高度，首先分析高度小于或者等于170，上侧或者下侧宽度超限的情况。
            if ((b_kz_bl_out[6] - b_kz_bl_out[7]) > 270 || (b_kz_zl_out[2] - b_kz_zl_out[0]) > 270 && h_kz_zl_out[8] <= 170)
            {
                if ((b_kz_bl_out[6] - b_kz_bl_out[7]) > 270 && (b_kz_zl_out[2] - b_kz_zl_out[0]) <= 270)
                {
                    j = 270 / (b_kz_bl_out[6] - b_kz_bl_out[7]);
                }
                else if ((b_kz_bl_out[6] - b_kz_bl_out[7]) <= 270 && (b_kz_zl_out[2] - b_kz_zl_out[0]) > 270)
                {
                    j = 270 / (b_kz_zl_out[2] - b_kz_zl_out[0]);
                }
                else if ((b_kz_bl_out[6] - b_kz_bl_out[7]) > 270 && (b_kz_zl_out[2] - b_kz_zl_out[0]) > 270)
                {
                    if (270 / (b_kz_bl_out[6] - b_kz_bl_out[7]) >= 270 / (b_kz_zl_out[2] - b_kz_zl_out[0]))
                    {
                        j = 270 / (b_kz_zl_out[2] - b_kz_zl_out[0]);
                    }
                    else
                    {
                        j = 270 / (b_kz_bl_out[6] - b_kz_bl_out[7]);
                    }
                }
                for (i = 0; i < b_kz_zl_out.Length; i++)
                {
                    b_kz_zl_out[i] = b_kz_zl_out[i] * j;
                    h_kz_zl_out[i] = h_kz_zl_out[i] * j;
                    b_kz_zl_in[i] = b_kz_zl_in[i] * j;
                    h_kz_zl_in[i] = b_kz_zl_in[i] * j;
                }
            }
            //再考虑上侧与下侧宽度均小于270，但是高度超限的情况
            else if ((b_kz_bl_out[6] - b_kz_bl_out[7]) <= 270 && (b_kz_zl_out[2] - b_kz_zl_out[0]) <= 270 && h_kz_zl_out[8] > 170)
            {
                //j=
                for (i = 0; i < b_kz_zl_out.Length; i++)
                {
                    b_kz_zl_out[i] = b_kz_zl_out[i] / 170;
                    h_kz_zl_out[i] = h_kz_zl_out[i] / 170;
                    b_kz_zl_in[i] = b_kz_zl_in[i] / 170;
                    h_kz_zl_in[i] = b_kz_zl_in[i] / 170;
                }
            }
            //在考虑上侧或下册宽度与高度均超限的情况，这样的情况话就先进行比较，看看那个超的多，比例就用哪个
            else if ((b_kz_bl_out[6] - b_kz_bl_out[7]) > 270 || (b_kz_zl_out[2] - b_kz_zl_out[0]) > 270 && h_kz_zl_out[8] > 170)
            {
                if ((b_kz_bl_out[6] - b_kz_bl_out[7]) / 270 > (h_kz_zl_out[8]) / 170 || (b_kz_zl_out[2] - b_kz_zl_out[0]) / 270 > (h_kz_zl_out[8]) / 170)
                {
                    for (i = 0; i < b_kz_zl_out.Length; i++)
                    {
                        b_kz_zl_out[i] = b_kz_zl_out[i] / 270;
                        h_kz_zl_out[i] = h_kz_zl_out[i] / 270;
                        b_kz_zl_in[i] = b_kz_zl_in[i] / 270;
                        h_kz_zl_in[i] = b_kz_zl_in[i] / 270;
                    }
                }
                else
                {
                    for (i = 0; i < b_kz_zl_out.Length; i++)
                    {
                        b_kz_zl_out[i] = b_kz_zl_out[i] / 170;
                        h_kz_zl_out[i] = h_kz_zl_out[i] / 170;
                        b_kz_zl_in[i] = b_kz_zl_in[i] / 170;
                        h_kz_zl_in[i] = b_kz_zl_in[i] / 170;
                    }
                }
            }
        }

    */}
}
