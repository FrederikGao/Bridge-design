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
    class output_word
    {
        //private MSWord.Application m_word;
        //private MSWord.Document m_doc;

        public void AddWordText()
        {
            object path;//文件路径
            string strContent;//文件内容
            MSWord.Application wordApp;//Word应用程序变量
            MSWord.Document wordDoc;//Word文档变量
            path = "d:\\myWord.doc";//保存为Word2003文档
                                    // path = "d:\\myWord.doc";//保存为Word2007文档
            wordApp = new MSWord.ApplicationClass();//初始化
            if (File.Exists((string)path))
            {
                File.Delete((string)path);
            }
            Object Nothing = Missing.Value;
            wordDoc = wordApp.Documents.Add(ref Nothing, ref Nothing, ref Nothing, ref Nothing);
            wordApp.Selection.ParagraphFormat.LineSpacing = 35f;//设置文档的行间距
                                                                //写入普通文本
            wordApp.Selection.ParagraphFormat.FirstLineIndent = 30;//首行缩进的长度
            strContent = "c#向Word写入文本 普通文本:\n";
            wordDoc.Paragraphs.Last.Range.Text = strContent;
            //将文档的前三个字替换成"asdfasdf"，并将其颜色设为蓝色
            object start = 0;
            object end = 3;
            Microsoft.Office.Interop.Word.Range rang = wordDoc.Range(ref start, ref end);
            rang.Font.Color = Microsoft.Office.Interop.Word.WdColor.wdColorBrightGreen;
            rang.Text = "我是替换文字";
            wordDoc.Range(ref start, ref end);

            //写入黑体文本
            object unite = Microsoft.Office.Interop.Word.WdUnits.wdStory;
            wordApp.Selection.EndKey(ref unite, ref Nothing);
            wordApp.Selection.ParagraphFormat.FirstLineIndent = 0;//取消首行缩进的长度
            strContent = "黑体文本\n ";//在文本中使用'\n'换行
            wordDoc.Paragraphs.Last.Range.Font.Name = "黑体";
            wordDoc.Paragraphs.Last.Range.Text = strContent;
            // wordApp.Selection.Text = strContent;
            //写入加粗文本
            strContent = "加粗文本\n ";
            wordApp.Selection.EndKey(ref unite, ref Nothing);
            wordDoc.Paragraphs.Last.Range.Font.Bold = 1;//Bold=0为不加粗
            wordDoc.Paragraphs.Last.Range.Text = strContent;
            // wordApp.Selection.Text = strContent;
            //写入15号字体文本
            strContent = "15号字体文本\n ";
            wordApp.Selection.EndKey(ref unite, ref Nothing);

            wordDoc.Paragraphs.Last.Range.Font.Size = 15;
            wordDoc.Paragraphs.Last.Range.Text = strContent;
            //写入斜体文本
            strContent = "斜体文本\n ";
            wordApp.Selection.EndKey(ref unite, ref Nothing);
            wordDoc.Paragraphs.Last.Range.Font.Italic = 1;
            wordDoc.Paragraphs.Last.Range.Text = strContent;
            //写入蓝色文本
            strContent = "蓝色文本\n ";
            wordApp.Selection.EndKey(ref unite, ref Nothing);
            wordDoc.Paragraphs.Last.Range.Font.Color = MSWord.WdColor.wdColorBlue;
            wordDoc.Paragraphs.Last.Range.Text = strContent;
            //写入下划线文本
            strContent = "下划线文本\n ";
            wordApp.Selection.EndKey(ref unite, ref Nothing);
            wordDoc.Paragraphs.Last.Range.Font.Underline = MSWord.WdUnderline.wdUnderlineThick;
            wordDoc.Paragraphs.Last.Range.Text = strContent;
            object format = MSWord.WdSaveFormat.wdFormatDocument;
            wordDoc.SaveAs(ref path, ref format, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing);
            wordDoc.Close(ref Nothing, ref Nothing, ref Nothing);
            wordApp.Quit(ref Nothing, ref Nothing, ref Nothing);
            //Response.Write("<script> alert('" + path + ": Word文档写入文本完毕!');</script>");
        }
    }
}