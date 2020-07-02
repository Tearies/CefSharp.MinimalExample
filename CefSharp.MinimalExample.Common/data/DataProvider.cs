using CefSharp.MinimalExample.Common.args;

namespace CefSharp.MinimalExample.Common.data
{
    public class DataProvider
    {
        static DataProvider()
        {
            CallBackObject = new GanttBoundObject();
        }

        public static string MainPage => "http://www.baidu.com";

        public static GanttBoundObject CallBackObject { get; private set; }

        public static string BuildLocalUrl(string localhtml)
        {
            return FileHelper.GetPhysicalPath(localhtml);
        }

        public static string ProvideData()
        {
            return string.Empty;
        }
    }
}