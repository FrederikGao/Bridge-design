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

using MSWord = Microsoft.Office.Interop.Word;
using System.IO;
using System.Reflection;


namespace Bridge_design
{
    /// <summary>
    /// Cross_section_size.xaml 的交互逻辑
    /// </summary>
    public partial class Cross_section_size : System.Windows.Window
    {
        Windows_Canvas xyz = new Windows_Canvas();
        public Autodesk.Revit.ApplicationServices.Application n_revit;
        public Document m_familyDocument;
        ExternalCommandData m_revit;
        
        /// <summary>
        /// Cross_section_size.xaml的窗体主程序
        /// 起到的作用是赋给TextBox的Text值，实施绘图修改。。。。。。（待添加）
        /// </summary>
        /// <param name="revit"></param>
        public Cross_section_size(ExternalCommandData revit)
        {
            //下两句是与revit对接
            InitializeComponent();
            m_revit = revit;
            //下两句是有关于赋值、添加事件与实时修改绘图的方法，在Cross_section_size.xaml.cs里可以查到
            InitTextboxMidspan();
            InitTextboxFulcrum();
            InitTextboxBeamlength();
            //three_dimensional();
            //下两句是关于当Cross_section_size.xaml窗体在Revit刚开始运行时就能看到的绘出的截面图形的方法
            FirstDrawing();
        }

        /// <summary>
        /// 第一次绘图
        /// </summary>
        public void FirstDrawing()
        {
            //跨中截面第一次绘图,处理梁截面坐标数据，并将其转换为全局通用的，数组形式的坐标
            add_XYZMidspan();
            //跨中截面中梁绘图
            xyz.CanvasMidspan_zl(mainPane1);
            //跨中截面边梁绘图
            xyz.CanvasMidspan_bl(mainPane2);
            //支点截面第一次绘图,处理梁截面坐标数据，并将其转换为全局通用的，数组形式的坐标
            add_XYZFulcrum();
            //支点截面中梁绘图
            xyz.CanvasFulcrum_zl(mainPane3);
            //支点截面边梁绘图
            xyz.CanvasFulcrum_bl(mainPane4);
            //支点截面第一次绘图,处理梁长坐标数据，并将其转换为全局静态变量
            add_XYZBeamlength();
        }

        /// <summary>
        /// 给Cross_section_size.xaml窗体中的跨中截面尺寸拟定部分的TextBox赋Text值
        /// 并让跨中截面尺寸尺寸拟定部分的所有TextBox都等于一个TextChanged，以做到实施修改绘图
        /// </summary>
        private void InitTextboxMidspan()
        {
            this.aa1.Text = 17.5.ToString();
            this.aa2.Text = 19.2.ToString();
            this.aa3.Text = 33.ToString();
            this.aa4.Text = 15.ToString();
            this.aa5.Text = 113.ToString();
            this.aa6.Text = 67.ToString();
            this.aa7.Text = 28.ToString();
            this.aa8.Text = 16.ToString();
            this.aa9.Text = 31.4.ToString();
            this.aa10.Text = 31.4.ToString();
            this.aa11.Text = 50.ToString();
            this.aa12.Text = 17.ToString();
            this.bb1.Text = 15.ToString();
            this.bb2.Text = 6.5.ToString();
            this.bb3.Text = 110.ToString();
            this.bb4.Text = 9.5.ToString();
            this.bb5.Text = 18.ToString();
            this.bb6.Text = 7.ToString();
            this.bb7.Text = 13.9.ToString();
            this.bb8.Text = 15.ToString();
            //添加一个新的事件，让多个TextBox的TextChanged都等于一个TextChanged事件
            this.aa1.TextChanged += txtMidspan_TextChanged;
            this.aa2.TextChanged += txtMidspan_TextChanged;
            this.aa3.TextChanged += txtMidspan_TextChanged;
            this.aa4.TextChanged += txtMidspan_TextChanged;
            this.aa5.TextChanged += txtMidspan_TextChanged;
            this.aa6.TextChanged += txtMidspan_TextChanged;
            this.aa7.TextChanged += txtMidspan_TextChanged;
            this.aa8.TextChanged += txtMidspan_TextChanged;
            this.aa9.TextChanged += txtMidspan_TextChanged;
            this.aa10.TextChanged += txtMidspan_TextChanged;
            this.aa11.TextChanged += txtMidspan_TextChanged;
            this.aa12.TextChanged += txtMidspan_TextChanged;
            this.bb1.TextChanged += txtMidspan_TextChanged;
            this.bb2.TextChanged += txtMidspan_TextChanged;
            this.bb3.TextChanged += txtMidspan_TextChanged;
            this.bb4.TextChanged += txtMidspan_TextChanged;
            this.bb5.TextChanged += txtMidspan_TextChanged;
            this.bb6.TextChanged += txtMidspan_TextChanged;
            this.bb7.TextChanged += txtMidspan_TextChanged;
            this.bb8.TextChanged += txtMidspan_TextChanged;
        }

        /// <summary>
        /// 给Cross_section_size.xaml窗体中的支点截面尺寸拟定部分的TextBox赋Text值
        /// 并让支点截面尺寸尺寸拟定部分的所有TextBox都等于一个TextChanged，以做到实施修改绘图
        /// </summary>
        private void InitTextboxFulcrum()
        {
            this.aaa1.Text = 17.5.ToString();
            this.aaa2.Text = 19.2.ToString();
            this.aaa3.Text = 33.ToString();
            this.aaa4.Text = 15.ToString();
            this.aaa5.Text = 113.ToString();
            this.aaa6.Text = 67.ToString();
            this.aaa7.Text = 28.ToString();
            this.aaa8.Text = 16.ToString();
            this.aaa9.Text = 31.4.ToString();
            this.aaa10.Text = 31.4.ToString();
            this.aaa11.Text = 50.ToString();
            this.aaa12.Text = 17.ToString();
            this.bbb1.Text = 15.ToString();
            this.bbb2.Text = 6.5.ToString();
            this.bbb3.Text = 110.ToString();
            this.bbb4.Text = 9.5.ToString();
            this.bbb5.Text = 18.ToString();
            this.bbb6.Text = 7.ToString();
            this.bbb7.Text = 13.9.ToString();
            this.bbb8.Text = 15.ToString();
            //添加一个新的事件，让多个TextBox的TextChanged都等于一个TextChanged事件
            this.aaa1.TextChanged += txtFulcrum_TextChanged;
            this.aaa2.TextChanged += txtFulcrum_TextChanged;
            this.aaa3.TextChanged += txtFulcrum_TextChanged;
            this.aaa4.TextChanged += txtFulcrum_TextChanged;
            this.aaa5.TextChanged += txtFulcrum_TextChanged;
            this.aaa6.TextChanged += txtFulcrum_TextChanged;
            this.aaa7.TextChanged += txtFulcrum_TextChanged;
            this.aaa8.TextChanged += txtFulcrum_TextChanged;
            this.aaa9.TextChanged += txtFulcrum_TextChanged;
            this.aaa10.TextChanged += txtFulcrum_TextChanged;
            this.aaa11.TextChanged += txtFulcrum_TextChanged;
            this.aaa12.TextChanged += txtFulcrum_TextChanged;
            this.bbb1.TextChanged += txtFulcrum_TextChanged;
            this.bbb2.TextChanged += txtFulcrum_TextChanged;
            this.bbb3.TextChanged += txtFulcrum_TextChanged;
            this.bbb4.TextChanged += txtFulcrum_TextChanged;
            this.bbb5.TextChanged += txtFulcrum_TextChanged;
            this.bbb6.TextChanged += txtFulcrum_TextChanged;
            this.bbb7.TextChanged += txtFulcrum_TextChanged;
            this.bbb8.TextChanged += txtFulcrum_TextChanged;
        }

        /// <summary>
        /// 给Cross_section_size.xaml窗体中的梁长尺寸拟定部分的TextBox赋Text值
        /// </summary>
        private void InitTextboxBeamlength()
        {
            this.l1.Text = 50.ToString();
            this.l2.Text = 150.ToString();
            this.l3.Text = 2600.ToString();
            this.l0.Text = 30.ToString();
            this.t.Text = 20.ToString();
        }

        /// <summary>
        /// 将跨中截面的边梁以及中梁坐标转换成坐标数组中储存，并转换成全局通用的坐标数组。
        /// </summary>
        public void add_XYZMidspan()
        {
            //将TextBox的各段长度存入数组
            float[] x = new float[12];
            float[] y = new float[8];
            #region 判断TextBox是否为空，若为空，则给TextBox赋0，若存在值就将TextBox的值读出来
            if (aa1.Text == "")
            {
                aa1.Text = "0";
                x[0] = 0;
            }
            else
            {
                x[0] = Convert.ToSingle(aa1.Text);
            }
            if (aa2.Text == "")
            {
                aa2.Text = "0";
                x[1] = 0;
            }
            else
            {
                x[1] = Convert.ToSingle(aa2.Text);
            }
            if (aa3.Text == "")
            {
                aa3.Text = "0";
                x[2] = 0;
            }
            else
            {
                x[2] = Convert.ToSingle(aa3.Text);
            }
            if (aa4.Text == "")
            {
                aa4.Text = "0";
                x[3] = 0;
            }
            else
            {
                x[3] = Convert.ToSingle(aa4.Text);
            }
            if (aa5.Text == "")
            {
                aa5.Text = "0";
                x[4] = 0;
            }
            else
            {
                x[4] = Convert.ToSingle(aa5.Text);
            }
            if (aa6.Text == "")
            {
                aa6.Text = "0";
                x[5] = 0;
            }
            else
            {
                x[5] = Convert.ToSingle(aa6.Text);
            }
            if (aa7.Text == "")
            {
                aa7.Text = "0";
                x[6] = 0;
            }
            else
            {
                x[6] = Convert.ToSingle(aa7.Text);
            }
            if (aa8.Text == "")
            {
                aa8.Text = "0";
                x[7] = 0;
            }
            else
            {
                x[7] = Convert.ToSingle(aa8.Text);
            }
            if (aa8.Text == "")
            {
                aa8.Text = "0";
                x[7] = 0;
            }
            else
            {
                x[7] = Convert.ToSingle(aa8.Text);
            }
            if (aa9.Text == "")
            {
                aa9.Text = "0";
                x[8] = 0;
            }
            else
            {
                x[8] = Convert.ToSingle(aa9.Text);
            }
            if (aa10.Text == "")
            {
                aa10.Text = "0";
                x[9] = 0;
            }
            else
            {
                x[9] = Convert.ToSingle(aa10.Text);
            }
            if (aa11.Text == "")
            {
                aa11.Text = "0";
                x[10] = 0;
            }
            else
            {
                x[10] = Convert.ToSingle(aa11.Text);
            }
            if (aa12.Text == "")
            {
                aa12.Text = "0";
                x[11] = 0;
            }
            else
            {
                x[11] = Convert.ToSingle(aa12.Text);
            }
            if (bb1.Text == "")
            {
                bb1.Text = "0";
                y[0] = 0;
            }
            else
            {
                y[0] = Convert.ToSingle(bb1.Text);
            }
            if (bb2.Text == "")
            {
                bb2.Text = "0";
                y[1] = 0;
            }
            else
            {
                y[1] = Convert.ToSingle(bb2.Text);
            }
            if (bb3.Text == "")
            {
                bb3.Text = "0";
                y[2] = 0;
            }
            else
            {
                y[2] = Convert.ToSingle(bb3.Text);
            }
            if (bb4.Text == "")
            {
                bb4.Text = "0";
                y[3] = 0;
            }
            else
            {
                y[3] = Convert.ToSingle(bb4.Text);
            }
            if (bb5.Text == "")
            {
                bb5.Text = "0";
                y[4] = 0;
            }
            else
            {
                y[4] = Convert.ToSingle(bb5.Text);
            }
            if (bb6.Text == "")
            {
                bb6.Text = "0";
                y[5] = 0;
            }
            else
            {
                y[5] = Convert.ToSingle(bb6.Text);
            }
            if (bb7.Text == "")
            {
                bb7.Text = "0";
                y[6] = 0;
            }
            else
            {
                y[6] = Convert.ToSingle(bb7.Text);
            }
            if (bb8.Text == "")
            {
                bb8.Text = "0";
                y[7] = 0;
            }
            else
            {
                y[7] = Convert.ToSingle(bb8.Text);
            }
            #endregion
            #region 将跨中的边梁的外轮廓线的坐标建立为数组
            Windows_Canvas.b_kz_bl_out[0] = -(x[4] / 2) - x[2] - x[1] - x[0] - x[11];
            Windows_Canvas.h_kz_bl_out[0] = 0;
            Windows_Canvas.b_kz_bl_out[1] = -(x[4] / 2) - x[2] - x[1] - x[0];
            Windows_Canvas.h_kz_bl_out[1] = 0;
            Windows_Canvas.b_kz_bl_out[2] = (x[4] / 2) + x[2] + x[10];
            Windows_Canvas.h_kz_bl_out[2] = 0;
            Windows_Canvas.b_kz_bl_out[3] = (x[4] / 2) + x[2] + x[10];
            Windows_Canvas.h_kz_bl_out[3] = y[0];
            Windows_Canvas.b_kz_bl_out[4] = (x[4] / 2) + x[2];
            Windows_Canvas.h_kz_bl_out[4] = y[0] + y[1];
            Windows_Canvas.b_kz_bl_out[5] = x[9] + x[6];
            Windows_Canvas.h_kz_bl_out[5] = y[0] + y[1] + y[2] + y[3] + y[4];
            Windows_Canvas.b_kz_bl_out[6] = -x[8] - x[6];
            Windows_Canvas.h_kz_bl_out[6] = y[0] + y[1] + y[2] + y[3] + y[4];
            Windows_Canvas.b_kz_bl_out[7] = -(x[4] / 2) - x[2];
            Windows_Canvas.h_kz_bl_out[7] = y[0] + y[1];
            Windows_Canvas.b_kz_bl_out[8] = -(x[4] / 2) - x[2] - x[1];
            Windows_Canvas.h_kz_bl_out[8] = y[0];
            Windows_Canvas.b_kz_bl_out[9] = -(x[4] / 2) - x[2] - x[1] - x[0] - x[11];
            Windows_Canvas.h_kz_bl_out[9] = y[0];
            Windows_Canvas.b_kz_bl_out[10] = -(x[4] / 2) - x[2] - x[1] - x[0] - x[11];
            Windows_Canvas.h_kz_bl_out[10] = 0;
            Windows_Canvas.b_kz_bl_out[11] = -(x[4] / 2) - x[2] - x[1] - x[0] - x[11];
            Windows_Canvas.h_kz_bl_out[11] = y[0] + y[1] + y[2] + y[3] + y[4] - y[6];
            Windows_Canvas.b_kz_bl_out[12] = -(x[5] - ((x[5] - x[0] - x[1]) / (x[2] + x[3] + x[4])) * x[6]);
            Windows_Canvas.h_kz_bl_out[12] = y[0] + y[1] + y[2] + y[3] + y[4] - y[6];
            Windows_Canvas.b_kz_bl_out[13] = -(x[4] / 2) - x[2] - x[1] - x[0];
            Windows_Canvas.h_kz_bl_out[13] = y[0] + y[1] + y[2] + y[3] + y[4] - y[6];
            #endregion
            #region 将跨中的边梁的内轮廓线的坐标建立为数组
            Windows_Canvas.b_kz_bl_in[0] = x[4] / 2;
            Windows_Canvas.h_kz_bl_in[0] = y[7];
            Windows_Canvas.b_kz_bl_in[1] = x[4] / 2 + x[3];
            Windows_Canvas.h_kz_bl_in[1] = y[5] + y[7];
            Windows_Canvas.b_kz_bl_in[2] = x[7] + x[9];
            Windows_Canvas.h_kz_bl_in[2] = y[0] + y[1] + y[2];
            Windows_Canvas.b_kz_bl_in[3] = x[9];
            Windows_Canvas.h_kz_bl_in[3] = y[0] + y[1] + y[2] + y[3];
            Windows_Canvas.b_kz_bl_in[4] = -x[8];
            Windows_Canvas.h_kz_bl_in[4] = y[0] + y[1] + y[2] + y[3];
            Windows_Canvas.b_kz_bl_in[5] = -(x[7] + x[8]);
            Windows_Canvas.h_kz_bl_in[5] = y[0] + y[1] + y[2];
            Windows_Canvas.b_kz_bl_in[6] = -(x[4] / 2 + x[3]);
            Windows_Canvas.h_kz_bl_in[6] = y[5] + y[7];
            Windows_Canvas.b_kz_bl_in[7] = -x[4] / 2;
            Windows_Canvas.h_kz_bl_in[7] = y[7];
            Windows_Canvas.b_kz_bl_in[8] = x[4] / 2;
            Windows_Canvas.h_kz_bl_in[8] = y[7];
            #endregion
            #region 将跨中的中梁的外轮廓线的坐标建立为数组
            Windows_Canvas.b_kz_zl_out[0] = Windows_Canvas.b_kz_bl_out[0];
            Windows_Canvas.h_kz_zl_out[0] = Windows_Canvas.h_kz_bl_out[0];
            Windows_Canvas.b_kz_zl_out[1] = Windows_Canvas.b_kz_bl_out[1];
            Windows_Canvas.h_kz_zl_out[1] = Windows_Canvas.h_kz_bl_out[1];
            Windows_Canvas.b_kz_zl_out[2] = -Windows_Canvas.b_kz_bl_out[1];
            Windows_Canvas.h_kz_zl_out[2] = Windows_Canvas.h_kz_bl_out[1];
            Windows_Canvas.b_kz_zl_out[3] = -Windows_Canvas.b_kz_bl_out[0];
            Windows_Canvas.h_kz_zl_out[3] = Windows_Canvas.h_kz_bl_out[0];
            Windows_Canvas.b_kz_zl_out[4] = -Windows_Canvas.b_kz_bl_out[0];
            Windows_Canvas.h_kz_zl_out[4] = Windows_Canvas.h_kz_bl_out[3];
            Windows_Canvas.b_kz_zl_out[5] = -Windows_Canvas.b_kz_bl_out[8];
            Windows_Canvas.h_kz_zl_out[5] = Windows_Canvas.h_kz_bl_out[8];
            Windows_Canvas.b_kz_zl_out[6] = Windows_Canvas.b_kz_bl_out[4];
            Windows_Canvas.h_kz_zl_out[6] = Windows_Canvas.h_kz_bl_out[4];
            Windows_Canvas.b_kz_zl_out[7] = x[6] + x[8];
            Windows_Canvas.h_kz_zl_out[7] = Windows_Canvas.h_kz_bl_out[5];
            Windows_Canvas.b_kz_zl_out[8] = Windows_Canvas.b_kz_bl_out[6];
            Windows_Canvas.h_kz_zl_out[8] = Windows_Canvas.h_kz_bl_out[6];
            Windows_Canvas.b_kz_zl_out[9] = Windows_Canvas.b_kz_bl_out[7];
            Windows_Canvas.h_kz_zl_out[9] = Windows_Canvas.h_kz_bl_out[7];
            Windows_Canvas.b_kz_zl_out[10] = Windows_Canvas.b_kz_bl_out[8];
            Windows_Canvas.h_kz_zl_out[10] = Windows_Canvas.h_kz_bl_out[8];
            Windows_Canvas.b_kz_zl_out[11] = Windows_Canvas.b_kz_bl_out[9];
            Windows_Canvas.h_kz_zl_out[11] = Windows_Canvas.h_kz_bl_out[9];
            Windows_Canvas.b_kz_zl_out[12] = Windows_Canvas.b_kz_bl_out[0];
            Windows_Canvas.h_kz_zl_out[12] = Windows_Canvas.h_kz_bl_out[0];
            Windows_Canvas.b_kz_zl_out[13] = Windows_Canvas.b_kz_bl_out[11];
            Windows_Canvas.h_kz_zl_out[13] = Windows_Canvas.h_kz_bl_out[11];
            Windows_Canvas.b_kz_zl_out[14] = Windows_Canvas.b_kz_bl_out[13];
            Windows_Canvas.h_kz_zl_out[14] = Windows_Canvas.h_kz_bl_out[13];
            Windows_Canvas.b_kz_zl_out[15] = Windows_Canvas.b_kz_bl_out[12];
            Windows_Canvas.h_kz_zl_out[15] = Windows_Canvas.h_kz_bl_out[12];
            Windows_Canvas.b_kz_zl_out[16] = -Windows_Canvas.b_kz_bl_out[12];
            Windows_Canvas.h_kz_zl_out[16] = Windows_Canvas.h_kz_bl_out[12];
            Windows_Canvas.b_kz_zl_out[17] = -Windows_Canvas.b_kz_bl_out[13];
            Windows_Canvas.h_kz_zl_out[17] = Windows_Canvas.h_kz_bl_out[12];
            Windows_Canvas.b_kz_zl_out[18] = -Windows_Canvas.b_kz_bl_out[11];
            Windows_Canvas.h_kz_zl_out[18] = Windows_Canvas.h_kz_bl_out[13];
            #endregion
            #region 将跨中的中梁的内轮廓线的坐标建立为数组
            Windows_Canvas.b_kz_zl_in[0] = x[4] / 2;
            Windows_Canvas.h_kz_zl_in[0] = y[7];
            Windows_Canvas.b_kz_zl_in[1] = x[4] / 2 + x[3];
            Windows_Canvas.h_kz_zl_in[1] = y[5] + y[7];
            Windows_Canvas.b_kz_zl_in[2] = x[7] + x[8];
            Windows_Canvas.h_kz_zl_in[2] = y[0] + y[1] + y[2];
            Windows_Canvas.b_kz_zl_in[3] = x[8];
            Windows_Canvas.h_kz_zl_in[3] = y[0] + y[1] + y[2] + y[3];
            Windows_Canvas.b_kz_zl_in[4] = -x[8];
            Windows_Canvas.h_kz_zl_in[4] = y[0] + y[1] + y[2] + y[3];
            Windows_Canvas.b_kz_zl_in[5] =- x[7] - x[8];
            Windows_Canvas.h_kz_zl_in[5] = y[0] + y[1] + y[2];
            Windows_Canvas.b_kz_zl_in[6] = -(x[4] / 2 + x[3]);
            Windows_Canvas.h_kz_zl_in[6] = y[5] + y[7];
            Windows_Canvas.b_kz_zl_in[7] = -x[4] / 2;
            Windows_Canvas.h_kz_zl_in[7] = y[7];
            Windows_Canvas.b_kz_zl_in[8] = x[4] / 2;
            Windows_Canvas.h_kz_zl_in[8] = y[7];
            #endregion
        }

        /// <summary>
        /// 将支点截面的边梁以及中梁坐标转换成坐标数组中储存，并转换成全局通用的坐标数组。
        /// </summary>
        public void add_XYZFulcrum()
        {
            //将TextBox的各段长度存入数组
            float[] x = new float[12];
            float[] y = new float[8];
            #region 判断TextBox是否为空，若为空，则给TextBox赋0，若存在值就将TextBox的值读出来
            if (aaa1.Text == "")
            {
                aaa1.Text = "0";
                x[0] = 0;
            }
            else
            {
                x[0] = Convert.ToSingle(aaa1.Text);
            }
            if (aaa2.Text == "")
            {
                aaa2.Text = "0";
                x[1] = 0;
            }
            else
            {
                x[1] = Convert.ToSingle(aaa2.Text);
            }
            if (aaa3.Text == "")
            {
                aaa3.Text = "0";
                x[2] = 0;
            }
            else
            {
                x[2] = Convert.ToSingle(aaa3.Text);
            }
            if (aaa4.Text == "")
            {
                aaa4.Text = "0";
                x[3] = 0;
            }
            else
            {
                x[3] = Convert.ToSingle(aaa4.Text);
            }
            if (aaa5.Text == "")
            {
                aaa5.Text = "0";
                x[4] = 0;
            }
            else
            {
                x[4] = Convert.ToSingle(aaa5.Text);
            }
            if (aaa6.Text == "")
            {
                aaa6.Text = "0";
                x[5] = 0;
            }
            else
            {
                x[5] = Convert.ToSingle(aaa6.Text);
            }
            if (aaa7.Text == "")
            {
                aaa7.Text = "0";
                x[6] = 0;
            }
            else
            {
                x[6] = Convert.ToSingle(aaa7.Text);
            }
            if (aaa8.Text == "")
            {
                aaa8.Text = "0";
                x[7] = 0;
            }
            else
            {
                x[7] = Convert.ToSingle(aaa8.Text);
            }
            if (aaa8.Text == "")
            {
                aaa8.Text = "0";
                x[7] = 0;
            }
            else
            {
                x[7] = Convert.ToSingle(aaa8.Text);
            }
            if (aaa9.Text == "")
            {
                aaa9.Text = "0";
                x[8] = 0;
            }
            else
            {
                x[8] = Convert.ToSingle(aaa9.Text);
            }
            if (aaa10.Text == "")
            {
                aaa10.Text = "0";
                x[9] = 0;
            }
            else
            {
                x[9] = Convert.ToSingle(aaa10.Text);
            }
            if (aaa11.Text == "")
            {
                aaa11.Text = "0";
                x[10] = 0;
            }
            else
            {
                x[10] = Convert.ToSingle(aaa11.Text);
            }
            if (aaa12.Text == "")
            {
                aaa12.Text = "0";
                x[11] = 0;
            }
            else
            {
                x[11] = Convert.ToSingle(aaa12.Text);
            }
            if (bbb1.Text == "")
            {
                bbb1.Text = "0";
                y[0] = 0;
            }
            else
            {
                y[0] = Convert.ToSingle(bbb1.Text);
            }
            if (bbb2.Text == "")
            {
                bbb2.Text = "0";
                y[1] = 0;
            }
            else
            {
                y[1] = Convert.ToSingle(bbb2.Text);
            }
            if (bbb3.Text == "")
            {
                bbb3.Text = "0";
                y[2] = 0;
            }
            else
            {
                y[2] = Convert.ToSingle(bbb3.Text);
            }
            if (bbb4.Text == "")
            {
                bbb4.Text = "0";
                y[3] = 0;
            }
            else
            {
                y[3] = Convert.ToSingle(bbb4.Text);
            }
            if (bbb5.Text == "")
            {
                bbb5.Text = "0";
                y[4] = 0;
            }
            else
            {
                y[4] = Convert.ToSingle(bbb5.Text);
            }
            if (bbb6.Text == "")
            {
                bbb6.Text = "0";
                y[5] = 0;
            }
            else
            {
                y[5] = Convert.ToSingle(bbb6.Text);
            }
            if (bbb7.Text == "")
            {
                bbb7.Text = "0";
                y[6] = 0;
            }
            else
            {
                y[6] = Convert.ToSingle(bbb7.Text);
            }
            if (bbb8.Text == "")
            {
                bbb8.Text = "0";
                y[7] = 0;
            }
            else
            {
                y[7] = Convert.ToSingle(bbb8.Text);
            }
            #endregion
            #region 将跨中的边梁的外轮廓线的坐标建立为数组
            Windows_Canvas.b_zd_bl_out[0] = -(x[4] / 2) - x[2] - x[1] - x[0] - x[11];
            Windows_Canvas.h_zd_bl_out[0] = 0;
            Windows_Canvas.b_zd_bl_out[1] = -(x[4] / 2) - x[2] - x[1] - x[0];
            Windows_Canvas.h_zd_bl_out[1] = 0;
            Windows_Canvas.b_zd_bl_out[2] = (x[4] / 2) + x[2] + x[10];
            Windows_Canvas.h_zd_bl_out[2] = 0;
            Windows_Canvas.b_zd_bl_out[3] = (x[4] / 2) + x[2] + x[10];
            Windows_Canvas.h_zd_bl_out[3] = y[0];
            Windows_Canvas.b_zd_bl_out[4] = (x[4] / 2) + x[2];
            Windows_Canvas.h_zd_bl_out[4] = y[0] + y[1];
            Windows_Canvas.b_zd_bl_out[5] = x[9] + x[6];
            Windows_Canvas.h_zd_bl_out[5] = y[0] + y[1] + y[2] + y[3] + y[4];
            Windows_Canvas.b_zd_bl_out[6] = -x[8] - x[6];
            Windows_Canvas.h_zd_bl_out[6] = y[0] + y[1] + y[2] + y[3] + y[4];
            Windows_Canvas.b_zd_bl_out[7] = -(x[4] / 2) - x[2];
            Windows_Canvas.h_zd_bl_out[7] = y[0] + y[1];
            Windows_Canvas.b_zd_bl_out[8] = -(x[4] / 2) - x[2] - x[1];
            Windows_Canvas.h_zd_bl_out[8] = y[0];
            Windows_Canvas.b_zd_bl_out[9] = -(x[4] / 2) - x[2] - x[1] - x[0] - x[11];
            Windows_Canvas.h_zd_bl_out[9] = y[0];
            Windows_Canvas.b_zd_bl_out[10] = -(x[4] / 2) - x[2] - x[1] - x[0] - x[11];
            Windows_Canvas.h_zd_bl_out[10] = 0;
            Windows_Canvas.b_zd_bl_out[11] = -(x[4] / 2) - x[2] - x[1] - x[0] - x[11];
            Windows_Canvas.h_zd_bl_out[11] = y[0] + y[1] + y[2] + y[3] + y[4] - y[6];
            Windows_Canvas.b_zd_bl_out[12] = -(x[5] - ((x[5] - x[0] - x[1]) / (x[2] + x[3] + x[4])) * x[6]);
            Windows_Canvas.h_zd_bl_out[12] = y[0] + y[1] + y[2] + y[3] + y[4] - y[6];
            Windows_Canvas.b_zd_bl_out[13] = -(x[4] / 2) - x[2] - x[1] - x[0];
            Windows_Canvas.h_zd_bl_out[13] = y[0] + y[1] + y[2] + y[3] + y[4] - y[6];
            #endregion
            #region 将跨中的边梁的内轮廓线的坐标建立为数组
            Windows_Canvas.b_zd_bl_in[0] = x[4] / 2;
            Windows_Canvas.h_zd_bl_in[0] = y[7];
            Windows_Canvas.b_zd_bl_in[1] = x[4] / 2 + x[3];
            Windows_Canvas.h_zd_bl_in[1] = y[5] + y[7];
            Windows_Canvas.b_zd_bl_in[2] = x[7] + x[9];
            Windows_Canvas.h_zd_bl_in[2] = y[0] + y[1] + y[2];
            Windows_Canvas.b_zd_bl_in[3] = x[9];
            Windows_Canvas.h_zd_bl_in[3] = y[0] + y[1] + y[2] + y[3];
            Windows_Canvas.b_zd_bl_in[4] = -x[8];
            Windows_Canvas.h_zd_bl_in[4] = y[0] + y[1] + y[2] + y[3];
            Windows_Canvas.b_zd_bl_in[5] = -(x[7] + x[9]);
            Windows_Canvas.h_zd_bl_in[5] = y[0] + y[1] + y[2];
            Windows_Canvas.b_zd_bl_in[6] = -(x[4] / 2 + x[3]);
            Windows_Canvas.h_zd_bl_in[6] = y[5] + y[7];
            Windows_Canvas.b_zd_bl_in[7] = -x[4] / 2;
            Windows_Canvas.h_zd_bl_in[7] = y[7];
            Windows_Canvas.b_zd_bl_in[8] = x[4] / 2;
            Windows_Canvas.h_zd_bl_in[8] = y[7];
            #endregion
            #region 将跨中的中梁的外轮廓线的坐标建立为数组
            Windows_Canvas.b_zd_zl_out[0] = Windows_Canvas.b_kz_bl_out[0];
            Windows_Canvas.h_zd_zl_out[0] = Windows_Canvas.h_kz_bl_out[0];
            Windows_Canvas.b_zd_zl_out[1] = Windows_Canvas.b_kz_bl_out[1];
            Windows_Canvas.h_zd_zl_out[1] = Windows_Canvas.h_kz_bl_out[1];
            Windows_Canvas.b_zd_zl_out[2] = -Windows_Canvas.b_kz_bl_out[1];
            Windows_Canvas.h_zd_zl_out[2] = Windows_Canvas.h_kz_bl_out[1];
            Windows_Canvas.b_zd_zl_out[3] = -Windows_Canvas.b_kz_bl_out[0];
            Windows_Canvas.h_zd_zl_out[3] = Windows_Canvas.h_kz_bl_out[0];
            Windows_Canvas.b_zd_zl_out[4] = -Windows_Canvas.b_kz_bl_out[0];
            Windows_Canvas.h_zd_zl_out[4] = Windows_Canvas.h_kz_bl_out[3];
            Windows_Canvas.b_zd_zl_out[5] = -Windows_Canvas.b_kz_bl_out[8];
            Windows_Canvas.h_zd_zl_out[5] = Windows_Canvas.h_kz_bl_out[8];
            Windows_Canvas.b_zd_zl_out[6] = Windows_Canvas.b_kz_bl_out[4];
            Windows_Canvas.h_zd_zl_out[6] = Windows_Canvas.h_kz_bl_out[4];
            Windows_Canvas.b_zd_zl_out[7] = x[6] + x[8];
            Windows_Canvas.h_zd_zl_out[7] = Windows_Canvas.h_kz_bl_out[5];
            Windows_Canvas.b_zd_zl_out[8] = Windows_Canvas.b_kz_bl_out[6];
            Windows_Canvas.h_zd_zl_out[8] = Windows_Canvas.h_kz_bl_out[6];
            Windows_Canvas.b_zd_zl_out[9] = Windows_Canvas.b_kz_bl_out[7];
            Windows_Canvas.h_zd_zl_out[9] = Windows_Canvas.h_kz_bl_out[7];
            Windows_Canvas.b_zd_zl_out[10] = Windows_Canvas.b_kz_bl_out[8];
            Windows_Canvas.h_zd_zl_out[10] = Windows_Canvas.h_kz_bl_out[8];
            Windows_Canvas.b_zd_zl_out[11] = Windows_Canvas.b_kz_bl_out[9];
            Windows_Canvas.h_zd_zl_out[11] = Windows_Canvas.h_kz_bl_out[9];
            Windows_Canvas.b_zd_zl_out[12] = Windows_Canvas.b_kz_bl_out[0];
            Windows_Canvas.h_zd_zl_out[12] = Windows_Canvas.h_kz_bl_out[0];
            Windows_Canvas.b_zd_zl_out[13] = Windows_Canvas.b_kz_bl_out[11];
            Windows_Canvas.h_zd_zl_out[13] = Windows_Canvas.h_kz_bl_out[11];
            Windows_Canvas.b_zd_zl_out[14] = Windows_Canvas.b_kz_bl_out[13];
            Windows_Canvas.h_zd_zl_out[14] = Windows_Canvas.h_kz_bl_out[13];
            Windows_Canvas.b_zd_zl_out[15] = Windows_Canvas.b_kz_bl_out[12];
            Windows_Canvas.h_zd_zl_out[15] = Windows_Canvas.h_kz_bl_out[12];
            Windows_Canvas.b_zd_zl_out[16] = -Windows_Canvas.b_kz_bl_out[12];
            Windows_Canvas.h_zd_zl_out[16] = Windows_Canvas.h_kz_bl_out[12];
            Windows_Canvas.b_zd_zl_out[17] = -Windows_Canvas.b_kz_bl_out[13];
            Windows_Canvas.h_zd_zl_out[17] = Windows_Canvas.h_kz_bl_out[12];
            Windows_Canvas.b_zd_zl_out[18] = -Windows_Canvas.b_kz_bl_out[11];
            Windows_Canvas.h_zd_zl_out[18] = Windows_Canvas.h_kz_bl_out[13];
            #endregion
            #region 将跨中的中梁的内轮廓线的坐标建立为数组
            Windows_Canvas.b_zd_zl_in[0] = x[4] / 2;
            Windows_Canvas.h_zd_zl_in[0] = y[7];
            Windows_Canvas.b_zd_zl_in[1] = x[4] / 2 + x[3];
            Windows_Canvas.h_zd_zl_in[1] = y[5] + y[7];
            Windows_Canvas.b_zd_zl_in[2] = x[7] + x[8];
            Windows_Canvas.h_zd_zl_in[2] = y[0] + y[1] + y[2];
            Windows_Canvas.b_zd_zl_in[3] = x[8];
            Windows_Canvas.h_zd_zl_in[3] = y[0] + y[1] + y[2] + y[3];
            Windows_Canvas.b_zd_zl_in[4] = -x[8];
            Windows_Canvas.h_zd_zl_in[4] = y[0] + y[1] + y[2] + y[3];
            Windows_Canvas.b_zd_zl_in[5] = -(x[8] + x[7]);
            Windows_Canvas.h_zd_zl_in[5] = y[0] + y[1] + y[2];
            Windows_Canvas.b_zd_zl_in[6] = -(x[4] / 2 + x[3]);
            Windows_Canvas.h_zd_zl_in[6] = y[5] + y[7];
            Windows_Canvas.b_zd_zl_in[7] = -x[4] / 2;
            Windows_Canvas.h_zd_zl_in[7] = y[7];
            Windows_Canvas.b_zd_zl_in[8] = x[4] / 2;
            Windows_Canvas.h_zd_zl_in[8] = y[7];
            #endregion
        }

        /// <summary>
        /// 将梁长数据转换为全局静态变量，并转换成用于拉伸和融合的长度
        /// </summary>
        public void add_XYZBeamlength()
        {
            if (l1.Text == "")
            {
                l1.Text = "0";
                ThreeD_Building.l1 = 0;
            }
            else
            {
                ThreeD_Building.l1 = Convert.ToSingle(l1.Text);
            }
            if (l2.Text == "")
            {
                l2.Text = "0";
                ThreeD_Building.l2 = 0;
            }
            else
            {
                ThreeD_Building.l2 = Convert.ToSingle(l2.Text);
            }
            if (l3.Text == "")
            {
                l3.Text = "0";
                ThreeD_Building.l3 = 0;
            }
            else
            {
                ThreeD_Building.l3 = Convert.ToSingle(l3.Text);
            }
            if (l0.Text == "")
            {
                l0.Text = "0";
                ThreeD_Building.l0 = 0;
            }
            else
            {
                ThreeD_Building.l0 = Convert.ToSingle(l0.Text);
            }
            if (t.Text == "")
            {
                t.Text = "0";
                ThreeD_Building.t = 0;
            }
            else
            {
                ThreeD_Building.t = Convert.ToSingle(t.Text);
            }
        }

        //private void three_dimensional()
        //{
        //    this.Bridge_modeling.Click += Bridge_modeling_Click;
        //}

        //下面这个代码折叠起来的地方是批量性的给坐标及系数变量赋值，作为全局变量，这样在哪都能用
        #region 批量性的给坐标和系数变量赋值
        public double x1;
        public double x2;
        public double x3;
        public double x4;
        public double x5;
        public double x6;
        public double x7;
        public double x8;
        public double x9;
        public double x10;
        public double y1;
        public double y2;
        public double y3;
        public double y4;
        public double y5;
        public double y6;
        public double y7;
        public double xx1;
        public double xx2;
        public double xx3;
        public double xx4;
        public double xx5;
        public double xx6;
        public double xx7;
        public double xx8;
        public double xx9;
        public double xx10;
        public double yy1;
        public double yy2;
        public double yy3;
        public double yy4;
        public double yy5;
        public double yy6;
        public double yy7;
        public double i;
        #endregion

        /// <summary>
        /// 对于跨中截面尺寸改变时，所触发的实时修改绘图事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void txtMidspan_TextChanged(object sender, TextChangedEventArgs args)
        {
            mainPane1.Children.Clear();
            mainPane2.Children.Clear();
            System.Windows.Controls.TextBox textBox = sender as System.Windows.Controls.TextBox;
            //跨中截面尺寸改变时处理梁截面坐标数据，并将其转换为全局通用的，数组形式的坐标
            add_XYZMidspan();
            //跨中截面中梁绘图
            xyz.CanvasMidspan_zl(mainPane1);
            //跨中截面边梁绘图
            xyz.CanvasMidspan_bl(mainPane2);
        }

        /// <summary>
        /// 对于支点截面尺寸改变时，所触发的实时修改绘图事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void txtFulcrum_TextChanged(object sender, TextChangedEventArgs args)
        {
            mainPane3.Children.Clear();
            mainPane4.Children.Clear();
            System.Windows.Controls.TextBox textBox = sender as System.Windows.Controls.TextBox;
            //支点截面尺寸改变时处理梁截面坐标数据，并将其转换为全局通用的，数组形式的坐标
            add_XYZFulcrum();
            //支点截面中梁绘图
            xyz.CanvasFulcrum_zl(mainPane3);
            //支点截面边梁绘图
            xyz.CanvasFulcrum_bl(mainPane4);
        }

        /// <summary>
        /// 建模按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Bridge_modeling_Click(object sender, RoutedEventArgs e)
        {
            ThreeD_Building threeD_Building = new ThreeD_Building();
            threeD_Building.Middle_beam_left_building(m_revit);
            //output_word word = new output_word();
            //word.AddWordText();
            //string path = @"D:\myWord.doc"; //测试一个word文档
            //System.Diagnostics.Process.Start(path); //打开此文件。 
        }
    }
}
