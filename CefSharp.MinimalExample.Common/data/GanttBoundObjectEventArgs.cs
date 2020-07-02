using System;

namespace CefSharp.MinimalExample.Common.data
{
    public class GanttBoundObjectEventArgs : EventArgs
    {
        /// <summary>Initializes a new instance of the <see cref="T:System.EventArgs" /> class.</summary>
        public GanttBoundObjectEventArgs(GanttCallBackNames ganttCallBackName, string data)
        {
            GanttCallBackName = ganttCallBackName;
            Data = data;
        }

        public GanttCallBackNames GanttCallBackName { get; set; }
        public string Data { get; set; }
    }
}