using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.UI.Events;
using Autodesk.Revit.DB.Events;
using Autodesk.Revit;
using System.Windows.Media.Imaging;

namespace Bridge_design
{
    public class Icon : IExternalApplication
    {
        /// <summary>
        /// 将Bridge_design以具体的图标显示出来，OnStartup为在Revit运行时的同时也同时开始运行，OnShutdown为在Revit关闭时也同时关闭
        /// </summary>
        /// <param name="application"></param>
        /// <returns></returns>
        public Result OnStartup(UIControlledApplication application)
        {
            RibbonPanel ribbonPanel = application.CreateRibbonPanel("Bridge_design");

            //在Revit中创建一个新的按钮，并且依次给它：区块名，按钮名，dll文件地址，要运行的类名
            PushButtonData buttonData = new PushButtonData("Bridge_design", "尺寸输入及建模", @"E:\Bridge_design\Bridge design\bin\Debug\Bridge design.dll", "Bridge_design.Revit_Interface");
            PushButton pushButton = ribbonPanel.AddItem(buttonData) as PushButton;

            //给按钮添加一个图片，并且说明图片的地址
            Uri uriImage = new Uri(@"E:\Bridge_design\Bridge design\GJX.jpg");
            BitmapImage largeImage = new BitmapImage(uriImage);
            pushButton.LargeImage = largeImage;
            pushButton.ToolTip = "欢迎来到Revit";
            return Result.Succeeded;
        }

        /// <summary>
        /// 将Bridge_design以具体的图标显示出来，OnStartup为在Revit运行时的同时也同时开始运行，OnShutdown为在Revit关闭时也同时关闭
        /// </summary>
        /// <param name="application"></param>
        /// <returns></returns>
        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }
    }

    [TransactionAttribute(TransactionMode.Manual)]
    [RegenerationAttribute(RegenerationOption.Manual)]

    public class Revit_Interface:IExternalCommand
    {
        public Application m_revit;
        public Document m_familyDocument;

        /// <summary>
        /// Revit的接口主程序，调用并运行Cross_section_size窗体及其xaml.cs文件
        /// </summary>
        /// <param name="revit"></param>
        /// <param name="message"></param>
        /// <param name="elements"></param>
        /// <returns></returns>
        public Result Execute(ExternalCommandData revit, ref string message, ElementSet elements)
        {
            Cross_section_size cross = new Cross_section_size(revit);
            cross.ShowDialog();
            //返回值，这句话必须有，没有运行不了
            return Result.Succeeded;
        }
    }
}
