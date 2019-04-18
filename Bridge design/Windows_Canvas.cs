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
    public class Windows_Canvas
    {
        //宽度方向的跨中的中梁的外轮廓线的坐标数组
        public static float[] b_kz_zl_out = new float[19];
        //高度方向的跨中的中梁的外轮廓线的坐标数组
        public static float[] h_kz_zl_out = new float[19];
        //宽度方向的跨中的中梁的内轮廓线的坐标数组
        public static float[] b_kz_zl_in = new float[9];
        //高度方向的跨中的中梁的内轮廓线的坐标数组
        public static float[] h_kz_zl_in = new float[9];

        //宽度方向的跨中的边梁的外轮廓线的坐标数组
        public static float[] b_kz_bl_out = new float[15];
        //高度方向的跨中的边梁的外轮廓线的坐标数组
        public static float[] h_kz_bl_out = new float[15];
        //宽度方向的跨中的边梁的外轮廓线的坐标数组
        public static float[] b_kz_bl_in = new float[9];
        //高度方向的跨中的边梁的外轮廓线的坐标数组
        public static float[] h_kz_bl_in = new float[9];

        //宽度方向的支点的中梁的外轮廓线的坐标数组
        public static float[] b_zd_zl_out = new float[19];
        //高度方向的支点的中梁的外轮廓线的坐标数组
        public static float[] h_zd_zl_out = new float[19];
        //宽度方向的支点的中梁的内轮廓线的坐标数组
        public static float[] b_zd_zl_in = new float[9];
        //高度方向的支点的中梁的内轮廓线的坐标数组
        public static float[] h_zd_zl_in = new float[9];

        //宽度方向的支点的边梁的外轮廓线的坐标数组
        public static float[] b_zd_bl_out = new float[15];
        //高度方向的支点的边梁的外轮廓线的坐标数组
        public static float[] h_zd_bl_out = new float[15];
        //宽度方向的支点的边梁的外轮廓线的坐标数组
        public static float[] b_zd_bl_in = new float[9];
        //高度方向的支点的边梁的外轮廓线的坐标数组
        public static float[] h_zd_bl_in = new float[9];

        /// <summary>
        /// 在Windows_Canvas画布canvas上绘制一条直线，起点坐标（x1,y1），终点坐标（x2，y2）
        /// </summary>
        /// <param name="canvas"></param>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        public void WindowsDrawing(float x,float y,Canvas canvas, float x1, float y1,float x2, float y2)
        {
            LineGeometry myLineGeometry = new LineGeometry();
            myLineGeometry.StartPoint = new System.Windows.Point(x + x1, y + y1);
            myLineGeometry.EndPoint = new System.Windows.Point(x + x2, y + y2);

            Path myPath = new Path();
            myPath.Stroke = System.Windows.Media.Brushes.Black;
            myPath.StrokeThickness = 1;
            myPath.Data = myLineGeometry;

            canvas.Children.Add(myPath);
        }

        /// <summary>
        /// 跨中截面中梁绘图
        /// </summary>
        /// <param name="canvas"></param>
        public void CanvasMidspan_zl(Canvas canvas)
        {
            int i;
            //此处大概有错误
            for (i = 0; i < b_kz_zl_out.Length - 4; i++)
            {
                WindowsDrawing(0, 0, canvas, b_kz_zl_out[i], h_kz_zl_out[i], b_kz_zl_out[i + 1], h_kz_zl_out[i + 1]);
            }
            for (i = 0; i < b_kz_zl_in.Length - 1; i++)
            {
                WindowsDrawing(0, 0, canvas, b_kz_zl_in[i], h_kz_zl_in[i], b_kz_zl_in[i + 1], h_kz_zl_in[i + 1]);
            }
            WindowsDrawing(0, 0, canvas, b_kz_zl_out[14], h_kz_zl_out[14], b_kz_zl_out[1], h_kz_zl_out[1]);
            WindowsDrawing(0, 0, canvas, b_kz_zl_out[16], h_kz_zl_out[16], b_kz_zl_out[18], h_kz_zl_out[18]);
            WindowsDrawing(0, 0, canvas, b_kz_zl_out[18], h_kz_zl_out[18], b_kz_zl_out[3], h_kz_zl_out[3]);
            WindowsDrawing(0, 0, canvas, b_kz_zl_out[17], h_kz_zl_out[17], b_kz_zl_out[2], h_kz_zl_out[2]);
        }

        /// <summary>
        /// 跨中截面边梁绘图
        /// </summary>
        /// <param name="canvas"></param>
        public void CanvasMidspan_bl(Canvas canvas)
        {
            int i;
            
            for (i = 0; i < b_kz_bl_out.Length - 2; i++)
            {
                WindowsDrawing(0, 0, canvas, b_kz_bl_out[i], h_kz_bl_out[i], b_kz_bl_out[i + 1], h_kz_bl_out[i + 1]);
            }
            for (i = 0; i < b_zd_bl_in.Length - 1; i++)
            {
                WindowsDrawing(0, 0, canvas, b_kz_bl_in[i], h_kz_bl_in[i], b_kz_bl_in[i + 1], h_kz_bl_in[i + 1]);
            }
            WindowsDrawing(0, 0, canvas, b_kz_bl_out[13], h_kz_bl_out[13], b_kz_bl_out[1], h_kz_bl_out[1]);
        }

        /// <summary>
        /// 支点截面中梁绘图
        /// </summary>
        /// <param name="canvas"></param>
        public void CanvasFulcrum_zl(Canvas canvas)
        {
            int i;
            
            for (i = 0; i < b_zd_zl_out.Length - 4; i++)
            {
                WindowsDrawing(0, 0, canvas, b_zd_zl_out[i], h_zd_zl_out[i], b_zd_zl_out[i + 1], h_zd_zl_out[i + 1]);
            }
            for (i = 0; i < b_zd_zl_in.Length - 1; i++)
            {
                WindowsDrawing(0, 0, canvas, b_zd_zl_in[i], h_zd_zl_in[i], b_zd_zl_in[i + 1], h_zd_zl_in[i + 1]);
            }
            WindowsDrawing(0, 0, canvas, b_zd_zl_out[14], h_zd_zl_out[14], b_zd_zl_out[1], h_zd_zl_out[1]);
            WindowsDrawing(0, 0, canvas, b_zd_zl_out[16], h_zd_zl_out[16], b_zd_zl_out[18], h_zd_zl_out[18]);
            WindowsDrawing(0, 0, canvas, b_zd_zl_out[18], h_zd_zl_out[18], b_zd_zl_out[3], h_zd_zl_out[3]);
            WindowsDrawing(0, 0, canvas, b_zd_zl_out[17], h_zd_zl_out[17], b_zd_zl_out[2], h_zd_zl_out[2]);

        }

        /// <summary>
        /// 支点截面边梁绘图
        /// </summary>
        /// <param name="canvas"></param>
        public void CanvasFulcrum_bl(Canvas canvas)
        {
            int i;
            
            for (i = 0; i < b_zd_bl_out.Length - 2; i++)
            {
                WindowsDrawing(0, 0, canvas, b_zd_bl_out[i], h_zd_bl_out[i], b_zd_bl_out[i + 1], h_zd_bl_out[i + 1]);
            }
            for (i = 0; i < b_zd_bl_in.Length - 1; i++)
            {
                WindowsDrawing(0, 0, canvas, b_zd_bl_in[i], h_zd_bl_in[i], b_zd_bl_in[i + 1], h_zd_bl_in[i + 1]);
            }
            WindowsDrawing(0, 0, canvas, b_zd_bl_out[13], h_zd_bl_out[13], b_zd_bl_out[1], h_zd_bl_out[1]);
        }
    }
}
