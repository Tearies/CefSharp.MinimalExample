// Copyright © 2010-2015 The CefSharp Authors. All rights reserved.
//
// Use of this source code is governed by a BSD-style license that can be found in the LICENSE file.

using CefSharp.WinForms;
using System;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using CefSharp.MinimalExample.Common.browser;

namespace CefSharp.MinimalExample.WinForms
{
    public class Program
    {
        [STAThread]
        public static int Main(string[] args)
        {
            ChromiumManager.Initialize();
            var browser = new BrowserForm();
            Application.Run(browser);

            return 0;
        }
    }
}
