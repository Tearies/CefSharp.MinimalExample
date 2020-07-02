using System;

namespace CefSharp.MinimalExample.Common.data
{
    public abstract class GenericControlToJsObject<T> where T : EventArgs
    {
        private EventHandler<T> callBackEventHandler;
        public event EventHandler<T> WebBrowserCallBack
        {
            add { callBackEventHandler += value; }
            remove { callBackEventHandler -= value; }
        }

        protected virtual void OnWebBrowserCallBack(T e)
        {
            callBackEventHandler?.Invoke(this, e);
        }
    }
}