﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace melakify.UI.BackDrop
{
    static class BackDropCoWorker
    {
        public static class Parameter
        {
            [Flags]
            enum DWM_SYSTEMBACKDROP_TYPE
            {
                DWMSBT_MAINWINDOW = 2, // Mica
                DWMSBT_TRANSIENTWINDOW = 3, // Acrylic
                DWMSBT_TABBEDWINDOW = 4 // Tabbed
            }


            [Flags]
            public enum DWMWINDOWATTRIBUTE
            {
                DWMWA_USE_IMMERSIVE_DARK_MODE = 20,
                DWMWA_SYSTEMBACKDROP_TYPE = 38,
                DWMWA_MICA_EFFECT = 1029
            }

            [StructLayout(LayoutKind.Sequential)]
            public struct MARGINS
            {
                public int cxLeftWidth;      // width of left border that retains its size
                public int cxRightWidth;     // width of right border that retains its size
                public int cyTopHeight;      // height of top border that retains its size
                public int cyBottomHeight;   // height of bottom border that retains its size
            };
        }

        public static class Method
        {
            [DllImport("dwmApi.dll")]
            static extern int DwmExtendFrameIntoClientArea(
                IntPtr hwnd,
                ref Parameter.MARGINS pMarInset);

            [DllImport("dwmapi.dll")]
            static extern int DwmSetWindowAttribute(IntPtr hwnd, Parameter.DWMWINDOWATTRIBUTE dwAttribute, ref int pvAttribute, int cbAttribute);

            public static int ExtendFrame(IntPtr hwnd, Parameter.MARGINS margins)
                => DwmExtendFrameIntoClientArea(hwnd, ref margins);

            public static int SetWindowAttribute(IntPtr hwnd, Parameter.DWMWINDOWATTRIBUTE attribute, int parameter)
                => DwmSetWindowAttribute(hwnd, attribute, ref parameter, Marshal.SizeOf<int>());
        }
    }
}
