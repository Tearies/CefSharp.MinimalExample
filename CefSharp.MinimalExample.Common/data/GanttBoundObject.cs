namespace CefSharp.MinimalExample.Common.data
{
    public class GanttBoundObject : GenericControlToJsObject<GanttBoundObjectEventArgs>
    {
        public void OnSelectedItemChanged(string taskId)
        {
            base.OnWebBrowserCallBack(new GanttBoundObjectEventArgs(GanttCallBackNames.SelectedItemChanged, taskId));
        }
    }
}