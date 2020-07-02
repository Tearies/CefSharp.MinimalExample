namespace CefSharp.MinimalExample.Common.args
{
    public enum UseAge
    {
        /// <summary>
        /// 应用于所有场景
        /// </summary>
        None = 0b01,
        /// <summary>
        /// 只用于调试模式
        /// </summary>
        Debug = None| 0b10
    }

    public enum Target
    {
        None = 0b000,
        Common = 0b001,
        WPF = Common | 0b01,
        Winform = Common | 0b10,
    }
}