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
    class ThreeD_Building
    {
        z_coordinate_transformation zz_Coordinate_Transformation = new z_coordinate_transformation();
        public static double l1;
        public static double l2;
        public static double l3;
        public static double l0;
        public static double t;

        public void Middle_beam_left_building(ExternalCommandData commandData)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Autodesk.Revit.DB.Document Rdoc = uidoc.Document;
            //族样板路径
            String filePath = @"C:\ProgramData\Autodesk\RVT 2018\Family Templates\Chinese\公制常规模型.rft";
            UIApplication uiapp = commandData.Application;
            Autodesk.Revit.ApplicationServices.Application app = uiapp.Application;

            //创建族文档
            Autodesk.Revit.DB.Document familyDoc = app.NewFamilyDocument(filePath);
            zz_Coordinate_Transformation.Z_coordinate_transformation();
            Transaction familyTrans = new Transaction(familyDoc, "family");
            //familyDoc.FamilyManager.NewType("1");

            #region 定义主梁轮廓线与轮廓线连接
            //定义部分1左半边轮廓线与轮廓线连接
            CurveArrArray bubufen1_z = app.Create.NewCurveArrArray();
            CurveArray bufen1_z = app.Create.NewCurveArray();

            //定义部分1右半边轮廓线与轮廓线连接
            CurveArrArray bubufen1_y = app.Create.NewCurveArrArray();
            CurveArray bufen1_y = app.Create.NewCurveArray();

            //定义部分2左半边近心点轮廓线与轮廓线连接
            CurveArrArray bubufen2_jz = app.Create.NewCurveArrArray();
            CurveArray bufen2_jz = app.Create.NewCurveArray();

            //定义部分2右半边近心点轮廓线与轮廓线连接
            CurveArrArray bubufen2_jy = app.Create.NewCurveArrArray();
            CurveArray bufen2_jy = app.Create.NewCurveArray();

            //定义部分2左半边上部分内侧轮廓线与轮廓线连接
            CurveArrArray bubufen2_z = app.Create.NewCurveArrArray();
            CurveArray bufen2_z = app.Create.NewCurveArray();

            //定义部分2右半边轮廓线与轮廓线连接
            CurveArrArray bubufen2_y = app.Create.NewCurveArrArray();
            CurveArray bufen2_y = app.Create.NewCurveArray();
            #endregion

            #region 创建坐标点
            #region//创建三维轮廓线坐标点,用于部分1与部分5的拉伸
            XYZ pzz0 = new XYZ(0, 0, 400);
            XYZ pzz1 = new XYZ(Windows_Canvas.b_zd_zl_out[0], 0, z_coordinate_transformation.z_zd_zl_out[0] + 400);
            XYZ pzz2 = new XYZ(Windows_Canvas.b_zd_zl_out[11], 0, z_coordinate_transformation.z_zd_zl_out[11] + 400);
            XYZ pzz3 = new XYZ(Windows_Canvas.b_zd_zl_out[10], 0, z_coordinate_transformation.z_zd_zl_out[10] + 400);
            XYZ pzz4 = new XYZ(Windows_Canvas.b_zd_zl_out[9], 0, z_coordinate_transformation.z_zd_zl_out[9] + 400);
            XYZ pzz5 = new XYZ(Windows_Canvas.b_zd_zl_out[8], 0, z_coordinate_transformation.z_zd_zl_out[8] + 400);
            XYZ pzz6 = new XYZ(0, 0, z_coordinate_transformation.z_zd_zl_out[8] + 400);
            XYZ pzz7 = new XYZ(0, 0, z_coordinate_transformation.z_zd_zl_in[4] + 400);
            XYZ pzz8 = new XYZ(Windows_Canvas.b_zd_zl_in[4], 0, z_coordinate_transformation.z_zd_zl_in[4] + 400);
            XYZ pzz9 = new XYZ(Windows_Canvas.b_zd_zl_in[5], 0, z_coordinate_transformation.z_zd_zl_in[5] + 400);
            XYZ pzz10 = new XYZ(Windows_Canvas.b_zd_zl_in[6], 0, z_coordinate_transformation.z_zd_zl_in[6] + 400);
            XYZ pzz11 = new XYZ(Windows_Canvas.b_zd_zl_in[7], 0, z_coordinate_transformation.z_zd_zl_in[7] + 400);
            XYZ pzz12 = new XYZ(0, 0, z_coordinate_transformation.z_zd_zl_in[7] + 400);
            #endregion

            #region//创建三维轮廓线坐标点,用于2部分的融合(左半边的)
            XYZ pjz0 = new XYZ(0, l1, 400);
            XYZ pjz1 = new XYZ(Windows_Canvas.b_zd_zl_out[0], l1, z_coordinate_transformation.z_zd_zl_out[0] + 400);
            XYZ pjz2 = new XYZ(Windows_Canvas.b_zd_zl_out[11], l1, z_coordinate_transformation.z_zd_zl_out[11] + 400);
            XYZ pjz3 = new XYZ(Windows_Canvas.b_zd_zl_out[10], l1, z_coordinate_transformation.z_zd_zl_out[10] + 400);
            XYZ pjz4 = new XYZ(Windows_Canvas.b_zd_zl_out[9], l1, z_coordinate_transformation.z_zd_zl_out[9] + 400);
            XYZ pjz5 = new XYZ(Windows_Canvas.b_zd_zl_out[8], l1, z_coordinate_transformation.z_zd_zl_out[8] + 400);
            XYZ pjz6 = new XYZ(0, l1, z_coordinate_transformation.z_zd_zl_out[8] + 400);
            XYZ pjz7 = new XYZ(0, l1, z_coordinate_transformation.z_zd_zl_in[4] + 400);
            XYZ pjz8 = new XYZ(Windows_Canvas.b_zd_zl_in[4], l1, z_coordinate_transformation.z_zd_zl_in[4] + 400);
            XYZ pjz9 = new XYZ(Windows_Canvas.b_zd_zl_in[5], l1, z_coordinate_transformation.z_zd_zl_in[5] + 400);
            XYZ pjz10 = new XYZ(Windows_Canvas.b_zd_zl_in[6], l1, z_coordinate_transformation.z_zd_zl_in[6] + 400);
            XYZ pjz11 = new XYZ(Windows_Canvas.b_zd_zl_in[7], l1, z_coordinate_transformation.z_zd_zl_in[7] + 400);
            XYZ pjz12 = new XYZ(0, l1, z_coordinate_transformation.z_zd_zl_in[7] + 400);
            #endregion

            #region//创建三维轮廓线坐标点,用于2部分的融合(右半边的)
            XYZ pjy0 = new XYZ(0, l1, 400);
            XYZ pjy1 = new XYZ(-Windows_Canvas.b_zd_zl_out[0], l1, z_coordinate_transformation.z_zd_zl_out[0] + 400);
            XYZ pjy2 = new XYZ(-Windows_Canvas.b_zd_zl_out[11], l1, z_coordinate_transformation.z_zd_zl_out[11] + 400);
            XYZ pjy3 = new XYZ(-Windows_Canvas.b_zd_zl_out[10], l1, z_coordinate_transformation.z_zd_zl_out[10] + 400);
            XYZ pjy4 = new XYZ(-Windows_Canvas.b_zd_zl_out[9], l1, z_coordinate_transformation.z_zd_zl_out[9] + 400);
            XYZ pjy5 = new XYZ(-Windows_Canvas.b_zd_zl_out[8], l1, z_coordinate_transformation.z_zd_zl_out[8] + 400);
            XYZ pjy6 = new XYZ(0, l1, z_coordinate_transformation.z_zd_zl_out[8] + 400);
            XYZ pjy7 = new XYZ(0, l1, z_coordinate_transformation.z_zd_zl_in[4] + 400);
            XYZ pjy8 = new XYZ(-Windows_Canvas.b_zd_zl_in[4], l1, z_coordinate_transformation.z_zd_zl_in[4] + 400);
            XYZ pjy9 = new XYZ(-Windows_Canvas.b_zd_zl_in[5], l1, z_coordinate_transformation.z_zd_zl_in[5] + 400);
            XYZ pjy10 = new XYZ(-Windows_Canvas.b_zd_zl_in[6], l1, z_coordinate_transformation.z_zd_zl_in[6] + 400);
            XYZ pjy11 = new XYZ(-Windows_Canvas.b_zd_zl_in[7], l1, z_coordinate_transformation.z_zd_zl_in[7] + 400);
            XYZ pjy12 = new XYZ(0, l1, z_coordinate_transformation.z_zd_zl_in[7] + 400);
            #endregion

            #region//创建三维轮廓线坐标点,用于部分3的拉伸,2部分的融合(左半边的)
            XYZ pkz0 = new XYZ(0, l1 + l2, 400);
            XYZ pkz1 = new XYZ(Windows_Canvas.b_kz_zl_out[0], l1 + l2, z_coordinate_transformation.z_kz_zl_out[0] + 400);
            XYZ pkz2 = new XYZ(Windows_Canvas.b_kz_zl_out[11], l1 + l2, z_coordinate_transformation.z_kz_zl_out[11] + 400);
            XYZ pkz3 = new XYZ(Windows_Canvas.b_kz_zl_out[10], l1 + l2, z_coordinate_transformation.z_kz_zl_out[10] + 400);
            XYZ pkz4 = new XYZ(Windows_Canvas.b_kz_zl_out[9], l1 + l2, z_coordinate_transformation.z_kz_zl_out[9] + 400);
            XYZ pkz5 = new XYZ(Windows_Canvas.b_kz_zl_out[8], l1 + l2, z_coordinate_transformation.z_kz_zl_out[8] + 400);
            XYZ pkz6 = new XYZ(0, l1 + l2, z_coordinate_transformation.z_kz_zl_out[8] + 400);
            XYZ pkz7 = new XYZ(0, l1 + l2, z_coordinate_transformation.z_kz_zl_in[4] + 400);
            XYZ pkz8 = new XYZ(Windows_Canvas.b_kz_zl_in[4], l1 + l2, z_coordinate_transformation.z_kz_zl_in[4] + 400);
            XYZ pkz9 = new XYZ(Windows_Canvas.b_kz_zl_in[5], l1 + l2, z_coordinate_transformation.z_kz_zl_in[5] + 400);
            XYZ pkz10 = new XYZ(Windows_Canvas.b_kz_zl_in[6], l1 + l2, z_coordinate_transformation.z_kz_zl_in[6] + 400);
            XYZ pkz11 = new XYZ(Windows_Canvas.b_kz_zl_in[7], l1 + l2, z_coordinate_transformation.z_kz_zl_in[7] + 400);
            XYZ pkz12 = new XYZ(0, l1 + l2, z_coordinate_transformation.z_zd_zl_in[7] + 400);
            #endregion

            #region//创建三维轮廓线坐标点,用于部分1与部分5的拉伸，2部分与4部分的融合(右半边的)
            XYZ pzy0 = new XYZ(0, 0, 400);
            XYZ pzy1 = new XYZ(-Windows_Canvas.b_zd_zl_out[0], 0, z_coordinate_transformation.z_zd_zl_out[0] + 400);
            XYZ pzy2 = new XYZ(-Windows_Canvas.b_zd_zl_out[11], 0, z_coordinate_transformation.z_zd_zl_out[11] + 400);
            XYZ pzy3 = new XYZ(-Windows_Canvas.b_zd_zl_out[10], 0, z_coordinate_transformation.z_zd_zl_out[10] + 400);
            XYZ pzy4 = new XYZ(-Windows_Canvas.b_zd_zl_out[9], 0, z_coordinate_transformation.z_zd_zl_out[9] + 400);
            XYZ pzy5 = new XYZ(-Windows_Canvas.b_zd_zl_out[8], 0, z_coordinate_transformation.z_zd_zl_out[8] + 400);
            XYZ pzy6 = new XYZ(0, 0, z_coordinate_transformation.z_zd_zl_out[8] + 400);
            XYZ pzy7 = new XYZ(0, 0, z_coordinate_transformation.z_zd_zl_in[4] + 400);
            XYZ pzy8 = new XYZ(-Windows_Canvas.b_zd_zl_in[4], 0, z_coordinate_transformation.z_zd_zl_in[4] + 400);
            XYZ pzy9 = new XYZ(-Windows_Canvas.b_zd_zl_in[5], 0, z_coordinate_transformation.z_zd_zl_in[5] + 400);
            XYZ pzy10 = new XYZ(-Windows_Canvas.b_zd_zl_in[6], 0, z_coordinate_transformation.z_zd_zl_in[6] + 400);
            XYZ pzy11 = new XYZ(-Windows_Canvas.b_zd_zl_in[7], 0, z_coordinate_transformation.z_zd_zl_in[7] + 400);
            XYZ pzy12 = new XYZ(0, 0, z_coordinate_transformation.z_zd_zl_in[7] + 400);
            #endregion

            #region//创建三维轮廓线坐标点,用于部分3的拉伸,2部分的融合(左半边的)
            XYZ pky0 = new XYZ(0, l1 + l2, 400);
            XYZ pky1 = new XYZ(-Windows_Canvas.b_kz_zl_out[0], l1 + l2, z_coordinate_transformation.z_kz_zl_out[0] + 400);
            XYZ pky2 = new XYZ(-Windows_Canvas.b_kz_zl_out[11], l1 + l2, z_coordinate_transformation.z_kz_zl_out[11] + 400);
            XYZ pky3 = new XYZ(-Windows_Canvas.b_kz_zl_out[10], l1 + l2, z_coordinate_transformation.z_kz_zl_out[10] + 400);
            XYZ pky4 = new XYZ(-Windows_Canvas.b_kz_zl_out[9], l1 + l2, z_coordinate_transformation.z_kz_zl_out[9] + 400);
            XYZ pky5 = new XYZ(-Windows_Canvas.b_kz_zl_out[8], l1 + l2, z_coordinate_transformation.z_kz_zl_out[8] + 400);
            XYZ pky6 = new XYZ(0, l1 + l2, z_coordinate_transformation.z_kz_zl_out[8] + 400);
            XYZ pky7 = new XYZ(0, l1 + l2, z_coordinate_transformation.z_kz_zl_in[4] + 400);
            XYZ pky8 = new XYZ(-Windows_Canvas.b_kz_zl_in[4], l1 + l2, z_coordinate_transformation.z_kz_zl_in[4] + 400);
            XYZ pky9 = new XYZ(-Windows_Canvas.b_kz_zl_in[5], l1 + l2, z_coordinate_transformation.z_kz_zl_in[5] + 400);
            XYZ pky10 = new XYZ(-Windows_Canvas.b_kz_zl_in[6], l1 + l2, z_coordinate_transformation.z_kz_zl_in[6] + 400);
            XYZ pky11 = new XYZ(-Windows_Canvas.b_kz_zl_in[7], l1 + l2, z_coordinate_transformation.z_kz_zl_in[7] + 400);
            XYZ pky12 = new XYZ(0, l1 + l2, z_coordinate_transformation.z_zd_zl_in[7] + 400);
            #endregion
            #endregion

            #region 创建轮廓线
            #region//创建部分1左半边轮廓线
            Curve bf1_outline_z_1 = Autodesk.Revit.DB.Line.CreateBound(pzz0,pzz1);
            Curve bf1_outline_z_2 = Autodesk.Revit.DB.Line.CreateBound(pzz1,pzz2);
            Curve bf1_outline_z_3 = Autodesk.Revit.DB.Line.CreateBound(pzz2,pzz3);
            Curve bf1_outline_z_4 = Autodesk.Revit.DB.Line.CreateBound(pzz3,pzz4);
            Curve bf1_outline_z_5 = Autodesk.Revit.DB.Line.CreateBound(pzz4,pzz5);
            Curve bf1_outline_z_6 = Autodesk.Revit.DB.Line.CreateBound(pzz5,pzz6);
            Curve bf1_outline_z_7 = Autodesk.Revit.DB.Line.CreateBound(pzz6,pzz7);
            Curve bf1_outline_z_8 = Autodesk.Revit.DB.Line.CreateBound(pzz7,pzz8);
            Curve bf1_outline_z_9 = Autodesk.Revit.DB.Line.CreateBound(pzz8,pzz9);
            Curve bf1_outline_z_10 = Autodesk.Revit.DB.Line.CreateBound(pzz9,pzz10);
            Curve bf1_outline_z_11 = Autodesk.Revit.DB.Line.CreateBound(pzz10,pzz11);
            Curve bf1_outline_z_12 = Autodesk.Revit.DB.Line.CreateBound(pzz11,pzz12);
            Curve bf1_outline_z_13 = Autodesk.Revit.DB.Line.CreateBound(pzz12,pzz0);
            #endregion

            #region//创建部分2左半边近心点轮廓线
            Curve bf2_outline_jz_1 = Autodesk.Revit.DB.Line.CreateBound(pjz0, pjz1);
            Curve bf2_outline_jz_2 = Autodesk.Revit.DB.Line.CreateBound(pjz1, pjz2);
            Curve bf2_outline_jz_3 = Autodesk.Revit.DB.Line.CreateBound(pjz2, pjz3);
            Curve bf2_outline_jz_4 = Autodesk.Revit.DB.Line.CreateBound(pjz3, pjz4);
            Curve bf2_outline_jz_5 = Autodesk.Revit.DB.Line.CreateBound(pjz4, pjz5);
            Curve bf2_outline_jz_6 = Autodesk.Revit.DB.Line.CreateBound(pjz5, pjz6);
            Curve bf2_outline_jz_7 = Autodesk.Revit.DB.Line.CreateBound(pjz6, pjz7);
            Curve bf2_outline_jz_8 = Autodesk.Revit.DB.Line.CreateBound(pjz7, pjz8);
            Curve bf2_outline_jz_9 = Autodesk.Revit.DB.Line.CreateBound(pjz8, pjz9);
            Curve bf2_outline_jz_10 = Autodesk.Revit.DB.Line.CreateBound(pjz9, pjz10);
            Curve bf2_outline_jz_11 = Autodesk.Revit.DB.Line.CreateBound(pjz10, pjz11);
            Curve bf2_outline_jz_12 = Autodesk.Revit.DB.Line.CreateBound(pjz11, pjz12);
            Curve bf2_outline_jz_13 = Autodesk.Revit.DB.Line.CreateBound(pjz12, pjz0);
            #endregion

            #region//创建部分2右半边近心点轮廓线
            Curve bf2_outline_jy_1 = Autodesk.Revit.DB.Line.CreateBound(pjy0, pjy1);
            Curve bf2_outline_jy_2 = Autodesk.Revit.DB.Line.CreateBound(pjy1, pjy2);
            Curve bf2_outline_jy_3 = Autodesk.Revit.DB.Line.CreateBound(pjy2, pjy3);
            Curve bf2_outline_jy_4 = Autodesk.Revit.DB.Line.CreateBound(pjy3, pjy4);
            Curve bf2_outline_jy_5 = Autodesk.Revit.DB.Line.CreateBound(pjy4, pjy5);
            Curve bf2_outline_jy_6 = Autodesk.Revit.DB.Line.CreateBound(pjy5, pjy6);
            Curve bf2_outline_jy_7 = Autodesk.Revit.DB.Line.CreateBound(pjy6, pjy7);
            Curve bf2_outline_jy_8 = Autodesk.Revit.DB.Line.CreateBound(pjy7, pjy8);
            Curve bf2_outline_jy_9 = Autodesk.Revit.DB.Line.CreateBound(pjy8, pjy9);
            Curve bf2_outline_jy_10 = Autodesk.Revit.DB.Line.CreateBound(pjy9, pjy10);
            Curve bf2_outline_jy_11 = Autodesk.Revit.DB.Line.CreateBound(pjy10, pjy11);
            Curve bf2_outline_jy_12 = Autodesk.Revit.DB.Line.CreateBound(pjy11, pjy12);
            Curve bf2_outline_jy_13 = Autodesk.Revit.DB.Line.CreateBound(pjy12, pjy0);
            #endregion

            #region//创建部分1右半边轮廓线
            Curve bf1_outline_y_1 = Autodesk.Revit.DB.Line.CreateBound(pzy0, pzy12);
            Curve bf1_outline_y_2 = Autodesk.Revit.DB.Line.CreateBound(pzy12, pzy11);
            Curve bf1_outline_y_3 = Autodesk.Revit.DB.Line.CreateBound(pzy11, pzy10);
            Curve bf1_outline_y_4 = Autodesk.Revit.DB.Line.CreateBound(pzy10, pzy9);
            Curve bf1_outline_y_5 = Autodesk.Revit.DB.Line.CreateBound(pzy9, pzy8);
            Curve bf1_outline_y_6 = Autodesk.Revit.DB.Line.CreateBound(pzy8, pzy7);
            Curve bf1_outline_y_7 = Autodesk.Revit.DB.Line.CreateBound(pzy7, pzy6);
            Curve bf1_outline_y_8 = Autodesk.Revit.DB.Line.CreateBound(pzy6, pzy5);
            Curve bf1_outline_y_9 = Autodesk.Revit.DB.Line.CreateBound(pzy5, pzy4);
            Curve bf1_outline_y_10 = Autodesk.Revit.DB.Line.CreateBound(pzy4, pzy3);
            Curve bf1_outline_y_11 = Autodesk.Revit.DB.Line.CreateBound(pzy3, pzy2);
            Curve bf1_outline_y_12 = Autodesk.Revit.DB.Line.CreateBound(pzy2, pzy1);
            Curve bf1_outline_y_13 = Autodesk.Revit.DB.Line.CreateBound(pzy1, pzy0);
            #endregion

            #region//创建部分2远心点部分左半边轮廓线
            Curve bf2_outline_z_1 = Autodesk.Revit.DB.Line.CreateBound(pkz0, pkz1);
            Curve bf2_outline_z_2 = Autodesk.Revit.DB.Line.CreateBound(pkz1, pkz2);
            Curve bf2_outline_z_3 = Autodesk.Revit.DB.Line.CreateBound(pkz2, pkz3);
            Curve bf2_outline_z_4 = Autodesk.Revit.DB.Line.CreateBound(pkz3, pkz4);
            Curve bf2_outline_z_5 = Autodesk.Revit.DB.Line.CreateBound(pkz4, pkz5);
            Curve bf2_outline_z_6 = Autodesk.Revit.DB.Line.CreateBound(pkz5, pkz6);
            Curve bf2_outline_z_7 = Autodesk.Revit.DB.Line.CreateBound(pkz6, pkz7);
            Curve bf2_outline_z_8 = Autodesk.Revit.DB.Line.CreateBound(pkz7, pkz8);
            Curve bf2_outline_z_9 = Autodesk.Revit.DB.Line.CreateBound(pkz8, pkz9);
            Curve bf2_outline_z_10 = Autodesk.Revit.DB.Line.CreateBound(pkz9, pkz10);
            Curve bf2_outline_z_11 = Autodesk.Revit.DB.Line.CreateBound(pkz10, pkz11);
            Curve bf2_outline_z_12 = Autodesk.Revit.DB.Line.CreateBound(pkz11, pkz12);
            Curve bf2_outline_z_13 = Autodesk.Revit.DB.Line.CreateBound(pkz12, pkz0);
            #endregion

            #region//创建部分2远心点部分右半边轮廓线
            Curve bf2_outline_y_1 = Autodesk.Revit.DB.Line.CreateBound(pky0, pky1);
            Curve bf2_outline_y_2 = Autodesk.Revit.DB.Line.CreateBound(pky1, pky2);
            Curve bf2_outline_y_3 = Autodesk.Revit.DB.Line.CreateBound(pky2, pky3);
            Curve bf2_outline_y_4 = Autodesk.Revit.DB.Line.CreateBound(pky3, pky4);
            Curve bf2_outline_y_5 = Autodesk.Revit.DB.Line.CreateBound(pky4, pky5);
            Curve bf2_outline_y_6 = Autodesk.Revit.DB.Line.CreateBound(pky5, pky6);
            Curve bf2_outline_y_7 = Autodesk.Revit.DB.Line.CreateBound(pky6, pky7);
            Curve bf2_outline_y_8 = Autodesk.Revit.DB.Line.CreateBound(pky7, pky8);
            Curve bf2_outline_y_9 = Autodesk.Revit.DB.Line.CreateBound(pky8, pky9);
            Curve bf2_outline_y_10 = Autodesk.Revit.DB.Line.CreateBound(pky9, pky10);
            Curve bf2_outline_y_11 = Autodesk.Revit.DB.Line.CreateBound(pky10, pky11);
            Curve bf2_outline_y_12 = Autodesk.Revit.DB.Line.CreateBound(pky11, pky12);
            Curve bf2_outline_y_13 = Autodesk.Revit.DB.Line.CreateBound(pky12, pky0);
            #endregion
            #endregion

            #region 连接轮廓线
            #region//连接部分1左半边轮廓线
            bufen1_z.Append(bf1_outline_z_1);
            bufen1_z.Append(bf1_outline_z_2);
            bufen1_z.Append(bf1_outline_z_3);
            bufen1_z.Append(bf1_outline_z_4);
            bufen1_z.Append(bf1_outline_z_5);
            bufen1_z.Append(bf1_outline_z_6);
            bufen1_z.Append(bf1_outline_z_7);
            bufen1_z.Append(bf1_outline_z_8);
            bufen1_z.Append(bf1_outline_z_9);
            bufen1_z.Append(bf1_outline_z_10);
            bufen1_z.Append(bf1_outline_z_11);
            bufen1_z.Append(bf1_outline_z_12);
            bufen1_z.Append(bf1_outline_z_13);
            bubufen1_z.Append(bufen1_z);
            #endregion

            #region//连接部分2近心点左半边轮廓线
            bufen2_jz.Append(bf2_outline_jz_1);
            bufen2_jz.Append(bf2_outline_jz_2);
            bufen2_jz.Append(bf2_outline_jz_3);
            bufen2_jz.Append(bf2_outline_jz_4);
            bufen2_jz.Append(bf2_outline_jz_5);
            bufen2_jz.Append(bf2_outline_jz_6);
            bufen2_jz.Append(bf2_outline_jz_7);
            bufen2_jz.Append(bf2_outline_jz_8);
            bufen2_jz.Append(bf2_outline_jz_9);
            bufen2_jz.Append(bf2_outline_jz_10);
            bufen2_jz.Append(bf2_outline_jz_11);
            bufen2_jz.Append(bf2_outline_jz_12);
            bufen2_jz.Append(bf2_outline_jz_13);
            bubufen2_jz.Append(bufen2_jz);
            #endregion

            #region//连接部分2近心点右半边轮廓线
            bufen2_jy.Append(bf2_outline_jy_1);
            bufen2_jy.Append(bf2_outline_jy_2);
            bufen2_jy.Append(bf2_outline_jy_3);
            bufen2_jy.Append(bf2_outline_jy_4);
            bufen2_jy.Append(bf2_outline_jy_5);
            bufen2_jy.Append(bf2_outline_jy_6);
            bufen2_jy.Append(bf2_outline_jy_7);
            bufen2_jy.Append(bf2_outline_jy_8);
            bufen2_jy.Append(bf2_outline_jy_9);
            bufen2_jy.Append(bf2_outline_jy_10);
            bufen2_jy.Append(bf2_outline_jy_11);
            bufen2_jy.Append(bf2_outline_jy_12);
            bufen2_jy.Append(bf2_outline_jy_13);
            bubufen2_jy.Append(bufen2_jy);
            #endregion

            #region//连接部分1右半边轮廓线
            bufen1_y.Append(bf1_outline_y_1);
            bufen1_y.Append(bf1_outline_y_2);
            bufen1_y.Append(bf1_outline_y_3);
            bufen1_y.Append(bf1_outline_y_4);
            bufen1_y.Append(bf1_outline_y_5);
            bufen1_y.Append(bf1_outline_y_6);
            bufen1_y.Append(bf1_outline_y_7);
            bufen1_y.Append(bf1_outline_y_8);
            bufen1_y.Append(bf1_outline_y_9);
            bufen1_y.Append(bf1_outline_y_10);
            bufen1_y.Append(bf1_outline_y_11);
            bufen1_y.Append(bf1_outline_y_12);
            bufen1_y.Append(bf1_outline_y_13);
            bubufen1_y.Append(bufen1_y);
            #endregion

            #region//连接部分2左半边轮廓线
            bufen2_z.Append(bf2_outline_z_1);
            bufen2_z.Append(bf2_outline_z_2);
            bufen2_z.Append(bf2_outline_z_3);
            bufen2_z.Append(bf2_outline_z_4);
            bufen2_z.Append(bf2_outline_z_5);
            bufen2_z.Append(bf2_outline_z_6);
            bufen2_z.Append(bf2_outline_z_7);
            bufen2_z.Append(bf2_outline_z_8);
            bufen2_z.Append(bf2_outline_z_9);
            bufen2_z.Append(bf2_outline_z_10);
            bufen2_z.Append(bf2_outline_z_11);
            bufen2_z.Append(bf2_outline_z_12);
            bufen2_z.Append(bf2_outline_z_13);
            bubufen2_z.Append(bufen2_z);
            #endregion

            #region//连接部分2右半边轮廓线
            bufen2_y.Append(bf2_outline_y_1);
            bufen2_y.Append(bf2_outline_y_2);
            bufen2_y.Append(bf2_outline_y_3);
            bufen2_y.Append(bf2_outline_y_4);
            bufen2_y.Append(bf2_outline_y_5);
            bufen2_y.Append(bf2_outline_y_6);
            bufen2_y.Append(bf2_outline_y_7);
            bufen2_y.Append(bf2_outline_y_8);
            bufen2_y.Append(bf2_outline_y_9);
            bufen2_y.Append(bf2_outline_y_10);
            bufen2_y.Append(bf2_outline_y_11);
            bufen2_y.Append(bf2_outline_y_12);
            bufen2_y.Append(bf2_outline_y_13);
            bubufen2_y.Append(bufen2_y);
            #endregion
            #endregion

            #region 定义各部分元素名称
            Element Middlebeam1_z = null;
            Element Middlebeam1_y = null;
            Element Middlebeam2_z = null;
            Element Middlebeam2_y = null;
            Element Middlebeam3_z = null;
            Element Middlebeam3_y = null;
            Element Middlebeam4_z = null;
            Element Middlebeam4_y = null;
            Element Middlebeam5_z = null;
            Element Middlebeam5_y = null;
            #endregion

            #region 主梁的拉伸和融合
            //新建事务，创建主梁部分拉伸体
            using (Transaction Mainbeam_stretching = new Transaction(familyDoc))
            {
                if (Mainbeam_stretching.Start("主梁拉伸") == TransactionStatus.Started)
                Middlebeam1_z = familyDoc.FamilyCreate.NewExtrusion(true, bubufen1_z, SketchPlane.Create(familyDoc, Plane.CreateByNormalAndOrigin(XYZ.BasisY, XYZ.Zero)), l1);
                Middlebeam1_y = familyDoc.FamilyCreate.NewExtrusion(true, bubufen1_y, SketchPlane.Create(familyDoc, Plane.CreateByNormalAndOrigin(XYZ.BasisY, XYZ.Zero)), l1);
                Middlebeam3_z = familyDoc.FamilyCreate.NewExtrusion(true, bubufen2_z, SketchPlane.Create(familyDoc, Plane.CreateByNormalAndOrigin(XYZ.BasisY, XYZ.Zero)), l3);
                Middlebeam3_y = familyDoc.FamilyCreate.NewExtrusion(true, bubufen2_y, SketchPlane.Create(familyDoc, Plane.CreateByNormalAndOrigin(XYZ.BasisY, XYZ.Zero)), l3);
                Middlebeam5_z = familyDoc.FamilyCreate.NewExtrusion(true, bubufen1_z, SketchPlane.Create(familyDoc, Plane.CreateByNormalAndOrigin(XYZ.BasisY, XYZ.Zero)), l1);
                Middlebeam5_y = familyDoc.FamilyCreate.NewExtrusion(true, bubufen1_y, SketchPlane.Create(familyDoc, Plane.CreateByNormalAndOrigin(XYZ.BasisY, XYZ.Zero)), l1);

                //移动部分5到正确位置
                XYZ transPointModel5 = new XYZ(0, l1 + 2 * l2 + l3, 0);
                ElementTransformUtils.MoveElement(familyDoc, Middlebeam5_z.Id, transPointModel5);
                ElementTransformUtils.MoveElement(familyDoc, Middlebeam5_y.Id, transPointModel5);
                Mainbeam_stretching.Commit();
            }

            //新建事务，创造主梁部分融合体
            using (Transaction Mainbeam_lofting = new Transaction(familyDoc))
            {
                if (Mainbeam_lofting.Start("主梁融合") == TransactionStatus.Started)
                Middlebeam2_z = familyDoc.FamilyCreate.NewBlend(true, bufen2_jz, bufen2_z, SketchPlane.Create(familyDoc, Plane.CreateByNormalAndOrigin(new XYZ(0, -1, 0), XYZ.Zero)));
                Middlebeam2_y = familyDoc.FamilyCreate.NewBlend(true, bufen2_jy, bufen2_y, SketchPlane.Create(familyDoc, Plane.CreateByNormalAndOrigin(new XYZ(0, 1, 0), XYZ.Zero)));
                Middlebeam4_z = familyDoc.FamilyCreate.NewBlend(true, bufen2_jz, bufen2_z, SketchPlane.Create(familyDoc, Plane.CreateByNormalAndOrigin(new XYZ(0, -1, 0), XYZ.Zero)));
                Middlebeam4_y = familyDoc.FamilyCreate.NewBlend(true, bufen2_jy, bufen2_y, SketchPlane.Create(familyDoc, Plane.CreateByNormalAndOrigin(new XYZ(0, 1, 0), XYZ.Zero)));

                //移动部分4到正确的位置
                XYZ transPointModel4 = new XYZ(0, l2 + l3, 0);
                ElementTransformUtils.MoveElement(familyDoc, Middlebeam4_z.Id, transPointModel4);
                ElementTransformUtils.MoveElement(familyDoc, Middlebeam4_y.Id, transPointModel4);
                Mainbeam_lofting.Commit();
            }
            #endregion

            //using (Transaction transaction3 = new Transaction(familyDoc))
            //{
            //    if (transaction3.Start("连接") == TransactionStatus.Started)
            //        JoinGeometryUtils.JoinGeometry(familyDoc, Model1_z, Model1_y);
            //    transaction3.Commit();
            //}

            #region 横隔梁部分建模
            //左侧横隔梁坐标点
            XYZ hz1 = new XYZ(Windows_Canvas.b_zd_zl_out[11], 0, z_coordinate_transformation.z_zd_zl_out[11] + 400);
            XYZ hz2 = new XYZ(Windows_Canvas.b_zd_zl_out[13], 0, z_coordinate_transformation.z_zd_zl_out[13] + 400);
            XYZ hz3 = new XYZ(Windows_Canvas.b_zd_zl_out[15], 0, z_coordinate_transformation.z_zd_zl_out[15] + 400);
            XYZ hz4 = new XYZ(Windows_Canvas.b_zd_zl_out[9], 0, z_coordinate_transformation.z_zd_zl_out[9] + 400);
            XYZ hz5 = new XYZ(Windows_Canvas.b_zd_zl_out[10], 0, z_coordinate_transformation.z_zd_zl_out[10] + 400);

            //右侧横隔梁坐标点
            XYZ hy1 = new XYZ(Windows_Canvas.b_zd_zl_out[4], 0, z_coordinate_transformation.z_zd_zl_out[4] + 400);
            XYZ hy2 = new XYZ(Windows_Canvas.b_zd_zl_out[5], 0, z_coordinate_transformation.z_zd_zl_out[5] + 400);
            XYZ hy3 = new XYZ(Windows_Canvas.b_zd_zl_out[6], 0, z_coordinate_transformation.z_zd_zl_out[6] + 400);
            XYZ hy4 = new XYZ(Windows_Canvas.b_zd_zl_out[16], 0, z_coordinate_transformation.z_zd_zl_out[16] + 400);
            XYZ hy5 = new XYZ(Windows_Canvas.b_zd_zl_out[18], 0, z_coordinate_transformation.z_zd_zl_out[18] + 400);

            //定义左侧横隔梁
            CurveArrArray Transversebeam_z = app.Create.NewCurveArrArray();
            CurveArray Transverse_z = app.Create.NewCurveArray();

            //定义右侧横隔梁
            CurveArrArray Transversebeam_y = app.Create.NewCurveArrArray();
            CurveArray Transverse_y = app.Create.NewCurveArray();

            //左侧横隔梁轮廓线
            Curve Tb_outline_z1 = Autodesk.Revit.DB.Line.CreateBound(hz1, hz2);
            Curve Tb_outline_z2 = Autodesk.Revit.DB.Line.CreateBound(hz2, hz3);
            Curve Tb_outline_z3 = Autodesk.Revit.DB.Line.CreateBound(hz3, hz4);
            Curve Tb_outline_z4 = Autodesk.Revit.DB.Line.CreateBound(hz4, hz5);
            Curve Tb_outline_z5 = Autodesk.Revit.DB.Line.CreateBound(hz5, hz1);

            //右侧横隔梁轮廓线
            Curve Tb_outline_y1 = Autodesk.Revit.DB.Line.CreateBound(hy1, hy2);
            Curve Tb_outline_y2 = Autodesk.Revit.DB.Line.CreateBound(hy2, hy3);
            Curve Tb_outline_y3 = Autodesk.Revit.DB.Line.CreateBound(hy3, hy4);
            Curve Tb_outline_y4 = Autodesk.Revit.DB.Line.CreateBound(hy4, hy5);
            Curve Tb_outline_y5 = Autodesk.Revit.DB.Line.CreateBound(hy5, hy1);

            //连接左侧横隔梁轮廓线
            Transverse_z.Append(Tb_outline_z1);
            Transverse_z.Append(Tb_outline_z2);
            Transverse_z.Append(Tb_outline_z3);
            Transverse_z.Append(Tb_outline_z4);
            Transverse_z.Append(Tb_outline_z5);
            Transversebeam_z.Append(Transverse_z);

            //连接右侧横隔梁轮廓线
            Transverse_y.Append(Tb_outline_y1);
            Transverse_y.Append(Tb_outline_y2);
            Transverse_y.Append(Tb_outline_y3);
            Transverse_y.Append(Tb_outline_y4);
            Transverse_y.Append(Tb_outline_y5);
            Transversebeam_y.Append(Transverse_y);

            #region 横隔梁位置信息处理
            double x1 = l0;
            double x3 = (2 * l1 + 2 * l2 + l3) / 2 - (t / 2);
            double x5 = 2 * l1 + 2 * l2 + l3 - l0 - t;
            double x2 = (x1 + x3) / 2;
            double x4 = (x3 + x5) / 2;
            #endregion

            #region  定义横隔梁部分元素名称
            Element Transversebeam1_z = null;
            Element Transversebeam1_y = null;
            Element Transversebeam2_z = null;
            Element Transversebeam2_y = null;
            Element Transversebeam3_z = null;
            Element Transversebeam3_y = null;
            Element Transversebeam4_z = null;
            Element Transversebeam4_y = null;
            Element Transversebeam5_z = null;
            Element Transversebeam5_y = null;
            #endregion

            using (Transaction Transversebeam_stretching = new Transaction(familyDoc))
            {
                if (Transversebeam_stretching.Start("横隔梁拉伸") == TransactionStatus.Started)
                //左边的横隔梁拉伸
                Transversebeam1_z = familyDoc.FamilyCreate.NewExtrusion(true, Transversebeam_z, SketchPlane.Create(familyDoc, Plane.CreateByNormalAndOrigin(XYZ.BasisY, XYZ.Zero)), t);
                Transversebeam2_z = familyDoc.FamilyCreate.NewExtrusion(true, Transversebeam_z, SketchPlane.Create(familyDoc, Plane.CreateByNormalAndOrigin(XYZ.BasisY, XYZ.Zero)), t);
                Transversebeam3_z = familyDoc.FamilyCreate.NewExtrusion(true, Transversebeam_z, SketchPlane.Create(familyDoc, Plane.CreateByNormalAndOrigin(XYZ.BasisY, XYZ.Zero)), t);
                Transversebeam4_z = familyDoc.FamilyCreate.NewExtrusion(true, Transversebeam_z, SketchPlane.Create(familyDoc, Plane.CreateByNormalAndOrigin(XYZ.BasisY, XYZ.Zero)), t);
                Transversebeam5_z = familyDoc.FamilyCreate.NewExtrusion(true, Transversebeam_z, SketchPlane.Create(familyDoc, Plane.CreateByNormalAndOrigin(XYZ.BasisY, XYZ.Zero)), t);
                Transversebeam1_y = familyDoc.FamilyCreate.NewExtrusion(true, Transversebeam_y, SketchPlane.Create(familyDoc, Plane.CreateByNormalAndOrigin(XYZ.BasisY, XYZ.Zero)), t);
                Transversebeam2_y = familyDoc.FamilyCreate.NewExtrusion(true, Transversebeam_y, SketchPlane.Create(familyDoc, Plane.CreateByNormalAndOrigin(XYZ.BasisY, XYZ.Zero)), t);
                Transversebeam3_y = familyDoc.FamilyCreate.NewExtrusion(true, Transversebeam_y, SketchPlane.Create(familyDoc, Plane.CreateByNormalAndOrigin(XYZ.BasisY, XYZ.Zero)), t);
                Transversebeam4_y = familyDoc.FamilyCreate.NewExtrusion(true, Transversebeam_y, SketchPlane.Create(familyDoc, Plane.CreateByNormalAndOrigin(XYZ.BasisY, XYZ.Zero)), t);
                Transversebeam5_y = familyDoc.FamilyCreate.NewExtrusion(true, Transversebeam_y, SketchPlane.Create(familyDoc, Plane.CreateByNormalAndOrigin(XYZ.BasisY, XYZ.Zero)), t);


                //移动到正确的位置
                ElementTransformUtils.MoveElement(familyDoc, Transversebeam1_z.Id, new XYZ(0, x1, 0));
                ElementTransformUtils.MoveElement(familyDoc, Transversebeam2_z.Id, new XYZ(0, x2, 0));
                ElementTransformUtils.MoveElement(familyDoc, Transversebeam3_z.Id, new XYZ(0, x3, 0));
                ElementTransformUtils.MoveElement(familyDoc, Transversebeam4_z.Id, new XYZ(0, x4, 0));
                ElementTransformUtils.MoveElement(familyDoc, Transversebeam5_z.Id, new XYZ(0, x5, 0));
                ElementTransformUtils.MoveElement(familyDoc, Transversebeam1_y.Id, new XYZ(0, x1, 0));
                ElementTransformUtils.MoveElement(familyDoc, Transversebeam2_y.Id, new XYZ(0, x2, 0));
                ElementTransformUtils.MoveElement(familyDoc, Transversebeam3_y.Id, new XYZ(0, x3, 0));
                ElementTransformUtils.MoveElement(familyDoc, Transversebeam4_y.Id, new XYZ(0, x4, 0));
                ElementTransformUtils.MoveElement(familyDoc, Transversebeam5_y.Id, new XYZ(0, x5, 0));
                Transversebeam_stretching.Commit();
            }
            #endregion

            Family family = familyDoc.LoadFamily(Rdoc);
        }
    }
}

