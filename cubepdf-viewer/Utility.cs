﻿/* ------------------------------------------------------------------------- */
/*
 *  Utility.cs
 *
 *  Copyright (c) 2010 CubeSoft Inc. All rights reserved.
 *
 *  This program is free software: you can redistribute it and/or modify
 *  it under the terms of the GNU General Public License as published by
 *  the Free Software Foundation, either version 3 of the License, or
 *  (at your option) any later version.
 *
 *  This program is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *  GNU General Public License for more details.
 *
 *  You should have received a copy of the GNU General Public License
 *  along with this program.  If not, see < http://www.gnu.org/licenses/ >.
 *
 *  Last-modified: Mon 02 Aug 2010 22:59:00 JST
 */
/* ------------------------------------------------------------------------- */
using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;

namespace Cube {
    /* --------------------------------------------------------------------- */
    /// Utility
    /* --------------------------------------------------------------------- */
    public abstract class Utility {
        /* ----------------------------------------------------------------- */
        /// SetupLog
        /* ----------------------------------------------------------------- */
        public static void SetupLog(string src) {
            if (System.IO.File.Exists(src)) System.IO.File.Delete(src);
            Trace.Listeners.Remove("Default");
            Trace.Listeners.Add(new TextWriterTraceListener(src));
            Trace.AutoFlush = true;
        }

        /* ----------------------------------------------------------------- */
        /// ErrorLog
        /* ----------------------------------------------------------------- */
        public static void ErrorLog(Exception err) {
            Trace.WriteLine(DateTime.Now.ToString() + ": TYPE: " + err.GetType().ToString());
            Trace.WriteLine(DateTime.Now.ToString() + ": SOURCE: " + err.Source);
            Trace.WriteLine(DateTime.Now.ToString() + ": MESSAGE: " + err.Message);
            Trace.WriteLine(DateTime.Now.ToString() + ": STACKTRACE: " + err.StackTrace);
        }

        /* ----------------------------------------------------------------- */
        /// GetIcon
        /* ----------------------------------------------------------------- */
        public static Icon GetIcon(string path) {
            var info = new SHFILEINFO();
            var status = SHGetFileInfo(path, 0, ref info, (uint)Marshal.SizeOf(info), SHGFI_ICON | SHGFI_LARGEICON);
            return (status != IntPtr.Zero) ? Icon.FromHandle(info.hIcon) : null;
        }

        /* ----------------------------------------------------------------- */
        /// TempPath
        /* ----------------------------------------------------------------- */
        public static string TempPath() {
            var dir = System.Environment.GetEnvironmentVariable("tmp");
            if (dir == null) dir = System.Environment.GetEnvironmentVariable("temp");
            if (dir == null) {
                var exec = System.Reflection.Assembly.GetEntryAssembly();
                dir = System.IO.Path.GetDirectoryName(exec.Location);
            }
            var dest = dir + '\\' + System.IO.Path.GetRandomFileName();
            return dest;
        }

        /* ----------------------------------------------------------------- */
        /// IsPSPrinter
        /* ----------------------------------------------------------------- */
        public static bool IsPSPrinter(string name) {
            IntPtr hdc = CreateDC(IntPtr.Zero, name, IntPtr.Zero, IntPtr.Zero);
	        uint code = POSTSCRIPT_PASSTHROUGH;
	        if(ExtEscape(hdc, QUERYESCSUPPORT, sizeof(int), BitConverter.GetBytes(code), 0, IntPtr.Zero) > 0) return true;
	        return false;
        }

        /* ----------------------------------------------------------------- */
        //  GetIcon() の為の Win32 API
        /* ----------------------------------------------------------------- */
        #region Win32 API for GetIcon().
        [DllImport("shell32.dll")]
        private static extern IntPtr SHGetFileInfo(string pszPath, uint dwFileAttributes, ref SHFILEINFO psfi, uint cbSizeFileInfo, uint uFlags);

        [DllImport("gdi32.dll")]
        static extern int ExtEscape(IntPtr hdc, uint nEscape, uint cbInput, byte[] lpszInData, int cbOutput, IntPtr lpszOutData);

        [DllImport("gdi32.dll")]
        static extern IntPtr CreateDC(IntPtr lpszDriver, string lpszDevice, IntPtr lpszOutput, IntPtr lpInitData);

        private const uint SHGFI_ICON = 0x100;      // アイコン・リソースの取得
        private const uint SHGFI_LARGEICON = 0x0;   // 大きいアイコン
        private const uint SHGFI_SMALLICON = 0x1;   // 小さいアイコン
        private const uint POSTSCRIPT_PASSTHROUGH = 4115;
        private const uint QUERYESCSUPPORT = 8;

        private struct SHFILEINFO {
            public IntPtr hIcon;
            public IntPtr iIcon;
            public uint dwAttributes;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
            public string szDisplayName;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
            public string szTypeName;
        };
        #endregion
    }
}
