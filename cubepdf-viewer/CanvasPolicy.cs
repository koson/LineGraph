/* ------------------------------------------------------------------------- */
/*
 *  CanvasPolicy.cs
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
 *  Last-modified: Mon 18 Oct 2010 13:40:00 JST
 */
/* ------------------------------------------------------------------------- */
using System;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using System.ComponentModel;
using System.Text.RegularExpressions;
using Container = System.Collections.Generic;
using Canvas = System.Windows.Forms.PictureBox;
using PDF = PDFLibNet.PDFWrapper;

namespace Cube
{
    /* --------------------------------------------------------------------- */
    /// FitCondition
    /* --------------------------------------------------------------------- */
    public enum FitCondition
    {
        None = 0x00, Width = 0x01, Height = 0x02
    }

    /* --------------------------------------------------------------------- */
    ///
    /// CanvasEngine
    /// 
    /// <summary>
    /// PDF の内容を表示・操作するために必要な各種情報を保持するための
    /// クラス．通常は，Canvas.Tag に登録しておく．
    /// </summary>
    /// 
    /* --------------------------------------------------------------------- */
    public class CanvasEngine : IDisposable
    {
        /* ----------------------------------------------------------------- */
        /// constructor
        /* ----------------------------------------------------------------- */
        public CanvasEngine(PDF core)
        {
            core_ = core;
            Thumbnail = null;
        }

        /* ----------------------------------------------------------------- */
        /// Core
        /* ----------------------------------------------------------------- */
        public PDF Core
        {
            get { return core_; }
            set { core_ = value; }
        }

        /* ----------------------------------------------------------------- */
        /// Thumbnail
        /* ----------------------------------------------------------------- */
        public Thumbnail Thumbnail { get; set; }

        /* ----------------------------------------------------------------- */
        ///
        /// UpdateURL
        /// 
        /// <summary>
        /// 現在のページに記載されている URL 情報を取得する．
        /// </summary>
        /// 
        /* ----------------------------------------------------------------- */
        public void UpdateURL()
        {
            lock (lock_)
            {
                if (core_ == null) return;
                lock (core_)
                {
                    string src = null;
                    src = core_.Pages[core_.CurrentPage].Text;
                    if (src == null) return;

                    core_.PreserveSearchResults();
                    urls_.Clear();

                    // parse http/https/ftp addresses.
                    Regex http = new Regex(@"(https?|ftp)(:\/\/[\-_.!~*\'()a-zA-Z0-9;\/?:\@&=+\$,%#]+)");
                    for (var item = http.Match(src); item.Success; item = item.NextMatch())
                    {
                        var order = PDFLibNet.PDFSearchOrder.PDFSearchFromCurrent;
                        if (core_.FindFirst(item.Value, order, false, false) > 0)
                        {
                            foreach (var result in core_.SearchResults)
                            {
                                if (result.Page == core_.CurrentPage)
                                {
                                    urls_.Add(new Container.KeyValuePair<string, Rectangle>(item.Value, result.Position));
                                }
                            }
                        }
                    }

                    // parse mail addresses.
                    Regex mail = new Regex(@"([a-zA-Z0-9])+([a-zA-Z0-9\._\-\+])*@([a-zA-Z0-9_\-])+([a-zA-Z0-9\._\-]+)+");
                    for (var item = mail.Match(src); item.Success; item = item.NextMatch())
                    {
                        var order = PDFLibNet.PDFSearchOrder.PDFSearchFromCurrent;
                        if (core_.FindFirst(item.Value, order, false, false) > 0)
                        {
                            foreach (var result in core_.SearchResults)
                            {
                                if (result.Page == core_.CurrentPage)
                                {
                                    urls_.Add(new Container.KeyValuePair<string, Rectangle>("mailto:" + item.Value, result.Position));
                                }
                            }
                        }
                    }

                    core_.RecoverSearchResults();
                }
            }
        }

        /* ----------------------------------------------------------------- */
        ///
        /// GetURL
        /// 
        /// <summary>
        /// PDF ファイルの現在のページの指定された座標に URL が存在する
        /// 場合はその URL を取得する．存在しない場合は null.
        /// </summary>
        /// 
        /* ----------------------------------------------------------------- */
        public string GetURL(Point pos)
        {
            lock (lock_)
            {
                foreach (var item in urls_)
                {
                    if (pos.X >= item.Value.Left && pos.X <= item.Value.Right &&
                        pos.Y >= item.Value.Top && pos.Y <= item.Value.Bottom)
                    {
                        return item.Key;
                    }
                }
            }
            return null;
        }

        /* ----------------------------------------------------------------- */
        /// Dispose
        /* ----------------------------------------------------------------- */
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /* ----------------------------------------------------------------- */
        /// Dispose
        /* ----------------------------------------------------------------- */
        protected virtual void Dispose(bool disposing)
        {
            lock (lock_)
            {
                if (!disposed_)
                {
                    if (disposing)
                    {
                        urls_.Clear();
                        if (core_ != null) core_ = null;
                    }
                }
                disposed_ = true;
            }
        }

        /* ----------------------------------------------------------------- */
        /// メンバ変数の定義
        /* ----------------------------------------------------------------- */
        #region Variables
        private PDF core_ = null;
        private bool disposed_ = false;
        private object lock_ = new object();
        private Container.List<Container.KeyValuePair<string, Rectangle>> urls_ =
            new Container.List<Container.KeyValuePair<string, Rectangle>>();
        #endregion
    }

}
