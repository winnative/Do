﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Interop;
using System.Windows;
using System.Windows.Media;
using static melakify.UI.BackDrop.BackDropCoWorker.Method;
using static melakify.UI.BackDrop.BackDropCoWorker.Parameter;
using Microsoft.VisualBasic;

namespace melakify.UI.BackDrop
{
    static class BackDrop
    {
        static void RefreshFrame(Window window)
        {
            IntPtr mainWindowPtr = new WindowInteropHelper(window).Handle;
            HwndSource mainWindowSrc = HwndSource.FromHwnd(mainWindowPtr);
            mainWindowSrc.CompositionTarget.BackgroundColor = System.Windows.Media.Color.FromArgb(0, 0, 0, 0);

            MARGINS margins = new MARGINS();
            margins.cxLeftWidth = -1;
            margins.cxRightWidth = -1;
            margins.cyTopHeight = -1;
            margins.cyBottomHeight = -1;

            ExtendFrame(mainWindowSrc.Handle, margins);
        }

        public static void UseAcrylic(Window window, bool isDark = false)
        {
            RefreshFrame(window);

            if (isDark)
            {
                SetWindowAttribute(
                new WindowInteropHelper(window).Handle,
                DWMWINDOWATTRIBUTE.DWMWA_USE_IMMERSIVE_DARK_MODE,
                3);
            }
            else
            {
                SetWindowAttribute(
                new WindowInteropHelper(window).Handle,
                DWMWINDOWATTRIBUTE.DWMWA_SYSTEMBACKDROP_TYPE,
                3);
            }
        }

        public static void UseMica(Window window, bool isDark = false)
        {
            RefreshFrame(window);

            if (isDark)
            {
                SetWindowAttribute(
                new WindowInteropHelper(window).Handle,
                DWMWINDOWATTRIBUTE.DWMWA_USE_IMMERSIVE_DARK_MODE,
                2);
            }
            else
            {
                SetWindowAttribute(
                new WindowInteropHelper(window).Handle,
                DWMWINDOWATTRIBUTE.DWMWA_SYSTEMBACKDROP_TYPE,
                2);
            }
        }
        public static bool IsWindows11_22523_OrGreater { get; } = new Version(10, 0, 22523) <= Environment.OSVersion.Version;
        public static void UseNewMica(Window window, bool isDark = false)
        {
            RefreshFrame(window);

            if (isDark)
            {
                SetWindowAttribute(
                    new WindowInteropHelper(window).Handle,
                    DWMWINDOWATTRIBUTE.DWMWA_USE_IMMERSIVE_DARK_MODE,
                    0x01);
            }
            else
            {
                SetWindowAttribute(
                    new WindowInteropHelper(window).Handle,
                    DWMWINDOWATTRIBUTE.DWMWA_USE_IMMERSIVE_DARK_MODE,
                    0x00);
            }

            if (IsWindows11_22523_OrGreater)
            {
                SetWindowAttribute(
                new WindowInteropHelper(window).Handle,
                DWMWINDOWATTRIBUTE.DWMWA_SYSTEMBACKDROP_TYPE,
                4);
            }
            else
            {
                SetWindowAttribute(
                new WindowInteropHelper(window).Handle,
                DWMWINDOWATTRIBUTE.DWMWA_MICA_EFFECT,
                0x01);
            }
        }

        public static void Auto(Window window, bool isDark = false)
        {
            RefreshFrame(window);

            if (isDark)
            {
                SetWindowAttribute(
                new WindowInteropHelper(window).Handle,
                DWMWINDOWATTRIBUTE.DWMWA_USE_IMMERSIVE_DARK_MODE,
                0);
            }
            else
            {
                SetWindowAttribute(
                new WindowInteropHelper(window).Handle,
                DWMWINDOWATTRIBUTE.DWMWA_SYSTEMBACKDROP_TYPE,
                0);
            }
        }

        public static void Disable(Window window, bool isDark = false)
        {
            RefreshFrame(window);

            if (isDark)
            {
                SetWindowAttribute(
                new WindowInteropHelper(window).Handle,
                DWMWINDOWATTRIBUTE.DWMWA_USE_IMMERSIVE_DARK_MODE,
                1);
            }
            else
            {
                SetWindowAttribute(
                new WindowInteropHelper(window).Handle,
                DWMWINDOWATTRIBUTE.DWMWA_SYSTEMBACKDROP_TYPE,
                1);
            }
        }
    }
}
