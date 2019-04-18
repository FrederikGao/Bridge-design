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
    class z_coordinate_transformation
    {
        //高度方向的跨中的中梁的外轮廓线的坐标数组
        public static float[] z_kz_zl_out = new float[19];
        //宽度方向的跨中的中梁的内轮廓线的坐标数组
        public static float[] z_kz_zl_in = new float[9];
        //高度方向的跨中的边梁的外轮廓线的坐标数组
        public static float[] z_kz_bl_out = new float[15];
        //高度方向的跨中的边梁的外轮廓线的坐标数组
        public static float[] z_kz_bl_in = new float[9];
        //高度方向的支点的中梁的外轮廓线的坐标数组
        public static float[] z_zd_zl_out = new float[19];
        //高度方向的支点的中梁的内轮廓线的坐标数组
        public static float[] z_zd_zl_in = new float[9];
        //高度方向的支点的边梁的外轮廓线的坐标数组
        public static float[] z_zd_bl_out = new float[15];
        //高度方向的支点的边梁的外轮廓线的坐标数组
        public static float[] z_zd_bl_in = new float[9];    
        public int i;
        /// <summary>
        /// 画布中的h方向坐标转换为REVIT中z方向的坐标
        /// </summary>
        public void Z_coordinate_transformation()
        {
            //高度方向的跨中的中梁的外轮廓线的坐标数组倒过来
            for (i = 0; i < z_kz_bl_out.Length; i++)
            {
                z_kz_zl_out[i] = -Windows_Canvas.h_kz_zl_out[i];
            }
            //宽度方向的跨中的中梁的内轮廓线的坐标数组倒过来
            for (i = 0; i < z_kz_zl_in.Length; i++)
            {
                z_kz_zl_in[i] = -Windows_Canvas.h_kz_zl_in[i];
            }
            //高度方向的跨中的边梁的外轮廓线的坐标数组倒过来
            for (i = 0; i < z_kz_bl_out.Length; i++)
            {
                z_kz_bl_out[i] = -Windows_Canvas.h_kz_bl_out[i];
            }
            //高度方向的跨中的边梁的外轮廓线的坐标数组倒过来
            for (i = 0; i < z_kz_bl_in.Length; i++)
            {
                z_kz_bl_in[i] = -Windows_Canvas.h_kz_bl_in[i];
            }
            //高度方向的支点的中梁的外轮廓线的坐标数组倒过来
            for (i = 0; i < z_zd_zl_out.Length; i++)
            {
                z_zd_zl_out[i] = -Windows_Canvas.h_zd_zl_out[i];
            }
            //高度方向的支点的中梁的内轮廓线的坐标数组倒过来
            for (i = 0; i < z_zd_zl_in.Length; i++)
            {
                z_zd_zl_in[i] = -Windows_Canvas.h_zd_zl_in[i];
            }
            //高度方向的支点的边梁的外轮廓线的坐标数组倒过来
            for (i = 0; i < z_zd_bl_out.Length; i++)
            {
                z_zd_bl_out[i] = -Windows_Canvas.h_zd_bl_out[i];
            }
            //高度方向的支点的边梁的外轮廓线的坐标数组倒过来
            for (i = 0; i < z_zd_bl_in.Length; i++)
            {
                z_zd_bl_in[i] = -Windows_Canvas.h_zd_bl_in[i];
            }
        }
    }
}