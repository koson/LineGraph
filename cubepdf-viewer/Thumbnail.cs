﻿/* ------------------------------------------------------------------------- */
/*
 *  Thumbnail.cs
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
using System.Runtime.InteropServices;
using Container = System.Collections.Generic;
using PDF = PDFLibNet.PDFWrapper;

namespace Cube {
    /* --------------------------------------------------------------------- */
    /// ThumbEventArgs
    /* --------------------------------------------------------------------- */
    public class ThumbEventArgs : EventArgs {
        /* ----------------------------------------------------------------- */
        /// Constructor
        /* ----------------------------------------------------------------- */
        public ThumbEventArgs(int page) : base() {
            page_ = page;
        }

        /* ----------------------------------------------------------------- */
        /// PageNum
        /* ----------------------------------------------------------------- */
        public int PageNum {
            get { return page_; }
        }

        /* ----------------------------------------------------------------- */
        //  メンバ変数の定義
        /* ----------------------------------------------------------------- */
        #region Member variables
        private int page_ = 0;
        #endregion
    }

    /* --------------------------------------------------------------------- */
    ///
    /// ThumbEventHandler
    /// 
    /// <summary>
    /// サムネイル画像の生成が終了すると発生するイベント．
    /// 発生するタイミングは 1ページ毎で，どのページのサムネイル画像が
    /// 生成されたのかは e.PageNum で取得できる．
    /// </summary>
    /// 
    /* --------------------------------------------------------------------- */
    public delegate void ThumbEventHandler(object sender, ThumbEventArgs e);

    /* --------------------------------------------------------------------- */
    ///
    /// ThumbEngine
    /// 
    /// <summary>
    /// サムネイル画像を実際に生成するエンジン．
    /// 通常は，Thumbnail.Tag にインスタンスを保持しておく．
    /// 生成したものは，オブジェクト内でキャッシュしておく．
    /// </summary>
    /// 
    /* --------------------------------------------------------------------- */
    public class ThumbEngine : IDisposable {
        /* ----------------------------------------------------------------- */
        /// ThumbEngine
        /* ----------------------------------------------------------------- */
        public ThumbEngine(PDF core, int width) {
            core_ = core;
            width_ = width;

            var tmp = System.Environment.GetEnvironmentVariable("tmp");
            if (tmp == null) tmp = System.Environment.GetEnvironmentVariable("temp");
            if (tmp == null) {
                var exec = System.Reflection.Assembly.GetEntryAssembly();
                tmp = System.IO.Path.GetDirectoryName(exec.Location);
            }
            cached_ = tmp + '\\' + System.IO.Path.GetRandomFileName();
            System.IO.Directory.CreateDirectory(cached_);

            worker_.DoWork -= new DoWorkEventHandler(DoWorkHandler);
            worker_.DoWork += new DoWorkEventHandler(DoWorkHandler);
            worker_.RunWorkerCompleted -= new RunWorkerCompletedEventHandler(RunCompletedHandler);
            worker_.RunWorkerCompleted += new RunWorkerCompletedEventHandler(RunCompletedHandler);
        }

        /* ----------------------------------------------------------------- */
        /// Core
        /* ----------------------------------------------------------------- */
        public PDF Core {
            get { return core_; }
            set { core_ = value; }
        }

        /* ----------------------------------------------------------------- */
        /// QueueCount
        /* ----------------------------------------------------------------- */
        public int QueueCount {
            get {
                lock (lock_) {
                    return queue_.Count;
                }
            }
        }

        /* ----------------------------------------------------------------- */
        /// QueueLimit
        /* ----------------------------------------------------------------- */
        public int QueueLimit {
            get {
                lock (lock_) {
                    return queue_limit_;
                }
            }

            set {
                lock (lock_) {
                    queue_limit_ = value;
                }
            }
        }

        /* ----------------------------------------------------------------- */
        ///
        /// CacheSize
        /// 
        /// <summary>
        /// 指定されたページ数分だけメモリ上に確保しておく．それ以外の
        /// サムネイル画像に関しては，一時ファイルを作成してそこに
        /// 保存する．
        /// </summary>
        /// 
        /* ----------------------------------------------------------------- */
        public int CacheSize {
            get {
                lock (lock_) {
                    return cache_size_;
                }
            }

            set {
                lock (lock_) {
                    cache_size_ = value;
                }
            }
        }

        /* ----------------------------------------------------------------- */
        /// Contains
        /* ----------------------------------------------------------------- */
        public bool Contains(int pagenum) {
            lock (lock_) {
                return images_.ContainsKey(pagenum);
            }
        }

        /* ----------------------------------------------------------------- */
        /// Get
        /* ----------------------------------------------------------------- */
        public Image Get(int pagenum) {
            lock (lock_) {
                if (images_.ContainsKey(pagenum)) return images_[pagenum];
            }
            return null;
        }

        /* ----------------------------------------------------------------- */
        ///
        /// Enqueue
        /// 
        /// <summary>
        /// MEMO: 不必要なキューの削除は，本来はイベントが発生した段階
        /// でクリアするはずなのだが，うまくいっていない（lock_ を奪えてない？）
        /// 現状は，必要なさそうな数（画面に表示されるサムネイルは 5 ～ 10
        /// 程度）のキューが溜まったら順次 Dequeue() で削除している．
        /// TODO: 不必要なキューの削除処理を改善する．
        /// </summary>
        /// 
        /* ----------------------------------------------------------------- */
        public void Enqueue(int pagenum) {
            lock (lock_) {
                if (!queue_.ContainsKey(pagenum)) {
                    queue_.Add(pagenum, null);
                    if (queue_.Count > queue_limit_) {
                        var first = queue_.Keys[0];
                        var last = queue_.Keys[queue_.Count - 1];
                        if (Math.Abs(pagenum - first) > Math.Abs(pagenum - last)) queue_.Remove(first);
                        else queue_.Remove(last);
                    }
                }
                if (!worker_.IsBusy) worker_.RunWorkerAsync();
            }
        }

        /* ----------------------------------------------------------------- */
        /// ClearQueue
        /* ----------------------------------------------------------------- */
        public void ClearQueue() {
            lock (lock_) {
                queue_.Clear();
            }
        }

        /* ----------------------------------------------------------------- */
        /// Clear
        /* ----------------------------------------------------------------- */
        public void Clear() {
            lock (lock_) {
                foreach (Image item in images_.Values) item.Dispose();
                images_.Clear();
                queue_.Clear();
            }
        }

        /* ----------------------------------------------------------------- */
        /// Dispose
        /* ----------------------------------------------------------------- */
        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /* ----------------------------------------------------------------- */
        ///
        /// Dispose
        /// 
        /// <summary>
        /// TODO: worker を何とかする．
        /// </summary>
        /// 
        /* ----------------------------------------------------------------- */
        protected virtual void Dispose(bool disposing) {
            if (!disposed_) {
                if (disposing) {
                    lock (internal_lock_) {
                        lock (lock_) {
                            queue_.Clear();
                        }

                        worker_.Dispose();
                        this.Clear();
                        lock (core_)
                        {
                            core_ = null;
                        }
                        try {
                            if (cached_ != null && System.IO.Directory.Exists(cached_)) {
                                System.IO.Directory.Delete(cached_, true);
                            }
                        }
                        catch (Exception err) {
                            Utility.ErrorLog(err);
                        }
                    }
                }
            }
            disposed_ = true;
        }

        /* ----------------------------------------------------------------- */
        /// ImageGenerated
        /* ----------------------------------------------------------------- */
        public event ThumbEventHandler ImageGenerated;
        protected virtual void OnImageGenerated(ThumbEventArgs e) {
            if (ImageGenerated != null) ImageGenerated(this, e);
        }

        /* ----------------------------------------------------------------- */
        //  内部処理
        /* ----------------------------------------------------------------- */
        #region Private methods

        /* ----------------------------------------------------------------- */
        /// DoWorkHandler (private)
        /* ----------------------------------------------------------------- */
        private void DoWorkHandler(object sender, DoWorkEventArgs e) {
            int pagenum = 0;
            lock (lock_) {
                if (queue_.Count > 0) {
                    pagenum = queue_.Keys[0];
                    queue_.Remove(queue_.Keys[0]);
                }
            }
            if (pagenum > 0) this.GenerateImage(pagenum);
            e.Result = pagenum;
        }

        /* ----------------------------------------------------------------- */
        /// RunCompletedHandler (private)
        /* ----------------------------------------------------------------- */
        private void RunCompletedHandler(object sender, RunWorkerCompletedEventArgs e) {
            lock (lock_) {
                if (queue_.Count > 0) {
                    lock (internal_lock_) {
                        worker_.RunWorkerAsync();
                    }
                }
            }
            
            int pagenum = (int)e.Result;
            if (pagenum > 0) {
                var args = new ThumbEventArgs(pagenum);
                this.OnImageGenerated(args);
            }
        }

        /* ----------------------------------------------------------------- */
        ///
        /// GenerateImage (private)
        ///
        /// <summary>
        /// MEMO: ロックは暫定処理．Microsoft によると public にアクセス
        /// 可能なオブジェクトを用いた lock は想定していないらしい．
        /// http://msdn.microsoft.com/ja-jp/library/c5kehkcz%28VS.80%29.aspx
        /// </summary>
        /// 
        /* ----------------------------------------------------------------- */
        private void GenerateImage(int pagenum) {
            Image image = null;
            lock (internal_lock_) {
                if (core_ == null || images_ == null || images_.ContainsKey(pagenum)) return;
                var path = this.GetArchivedPath(pagenum);
                if (System.IO.File.Exists(path)) image = Bitmap.FromFile(path);
                else {
                    lock (core_) {
                        PDFLibNet.PDFPage page;
                        if (!core_.Pages.TryGetValue(pagenum, out page)) return;
                        int rot = page.Rotation;
                        double ratio = (rot >= 45 && rot < 135) || (rot >= 225 && rot < 315) ?
                            page.Width / (double)page.Height : page.Height / (double)page.Width;
                        image = page.GetBitmap(width_, (int)(width_ * ratio));
                    }
                }
            }

            int count = 0, first = 0, last = 0;
            lock (lock_) {
                images_.Add(pagenum, image);
                count = images_.Count;
                first = images_.Keys[0];
                last  = images_.Keys[images_.Count - 1];
            }

            this.ArchiveImage(pagenum);
            if (count > this.CacheSize) {
                var archive = Math.Abs(pagenum - first) > Math.Abs(pagenum - last) ? first : last;
                this.DeleteImage(archive);
            }
        }

        /* ----------------------------------------------------------------- */
        /// ArchiveImage (private)
        /* ----------------------------------------------------------------- */
        private void ArchiveImage(int pagenum) {
            Image image = null;
            lock (internal_lock_) {
                if (core_ == null || !images_.ContainsKey(pagenum)) return;

                lock (lock_) {
                    image = images_[pagenum];
                }
            }

            var path = this.GetArchivedPath(pagenum);
            if (!System.IO.File.Exists(path)) {
                lock (image) {
                    image.Save(path);
                }
            }
        }

        /* ----------------------------------------------------------------- */
        /// DeleteImage (private)
        /* ----------------------------------------------------------------- */
        private void DeleteImage(int pagenum) {
            Image image = null;
            lock (internal_lock_) {
                if (core_ == null || !images_.ContainsKey(pagenum)) return;
                lock (lock_) {
                    image = images_[pagenum];
                    images_.Remove(pagenum);
                }
            }
            image.Dispose();
        }

        /* ----------------------------------------------------------------- */
        /// GetArchivedPath
        /* ----------------------------------------------------------------- */
        private string GetArchivedPath(int pagenum) {
            var dest = (cached_ != null && cached_.Length > 0) ? cached_ + "\\" : "";
            dest += pagenum.ToString() + ".png";
            return dest;
        }

        #endregion

        /* ----------------------------------------------------------------- */
        //  メンバ変数の定義
        /* ----------------------------------------------------------------- */
        #region Member variables
        private PDF core_ = null;
        private int width_ = 0;
        private Container.SortedList<int, object> queue_ = new Container.SortedList<int,object>();
        private int queue_limit_ = 10;
        private Container.SortedList<int, Image> images_ = new Container.SortedList<int, Image>();
        private string cached_ = null;
        private int cache_size_ = 5;
        private object lock_ = new object();
        private object internal_lock_ = new object();
        private bool disposed_ = false;
        private BackgroundWorker worker_ = new BackgroundWorker();
        #endregion
    }

    /* --------------------------------------------------------------------- */
    /// Thumbnail
    /* --------------------------------------------------------------------- */
    public class Thumbnail : ListView {
        /* ----------------------------------------------------------------- */
        ///
        /// GetInstance
        /// 
        /// <summary>
        /// 補助関数．Thumbnail オブジェクトは，何らかの Control
        /// オブジェクトに埋め込む (Controls に登録する）形で使用する為，
        /// 親となる Control オブジェクトから Thumbnail オブジェクトを
        /// 見つける際に使用する．
        /// </summary>
        /// 
        /* ----------------------------------------------------------------- */
        public static Thumbnail GetInstance(Control parent) {
            return parent.Controls["Thumbnail"] as Thumbnail;
        }

        /* ----------------------------------------------------------------- */
        /// Constructor
        /* ----------------------------------------------------------------- */
        public Thumbnail(Control parent, Control src) : base() {
            this.Create(parent, src);
        }

        /* ----------------------------------------------------------------- */
        /// Engine
        /* ----------------------------------------------------------------- */
        public ThumbEngine Engine {
            get {
                lock (lock_) {
                    return engine_;
                }
            }
        }

        /* ----------------------------------------------------------------- */
        /// Reset
        /* ----------------------------------------------------------------- */
        public void Reset() {
            lock (lock_) {
                if (this.Items.Count > 0) this.Items.Clear();
                engine_.Clear();
            }
        }

        /* ----------------------------------------------------------------- */
        /// Reset
        /* ----------------------------------------------------------------- */
        public void Reset(Control control) {
            this.Restruct(control);
        }

        /* ----------------------------------------------------------------- */
        /// EraseBackground
        /* ----------------------------------------------------------------- */
        public bool EraseBackground {
            get { return erase_background_; }
            set { erase_background_ = value; }
        }

        /* ----------------------------------------------------------------- */
        /// WndProc
        /* ----------------------------------------------------------------- */
        protected override void WndProc(ref Message m) {
            const int WM_ERASEBKGND     = 0x0014;
            const int WM_NCCALCSIZE     = 0x0083;

            const int SB_HORZ           = 0x0000;
            //const int SB_VERT           = 0x0001;

            lock (lock_) {
                if (engine_ != null) {
                    switch (m.Msg) {
                    case WM_ERASEBKGND:
                        if (erase_background_) base.WndProc(ref m);
                        return;
                    case WM_NCCALCSIZE:
                        // 水平スクロールバーは強制非表示
                        ShowScrollBar(this.Handle, SB_HORZ, false);
                        break;
                    default:
                        break;
                    }
                }
            }
            base.WndProc(ref m);
        }
        
        /* ----------------------------------------------------------------- */
        /// Dispose
        /* ----------------------------------------------------------------- */
        protected override void Dispose(bool disposing) {
            base.Dispose(disposing);
            try {
                if (disposing) {
                    lock (lock_) {
                        if (engine_ != null) {
                            engine_.ImageGenerated -= new ThumbEventHandler(ImageGeneratedHandler);
                            engine_.Dispose();
                            engine_ = null;
                        }
                    }
                }
            }
            catch (Exception err) {
                Utility.ErrorLog(err);
            }
        }

        /* ----------------------------------------------------------------- */
        /// Create (private)
        /* ----------------------------------------------------------------- */
        private void Create(Control parent, Control src) {
            if (src == null) return;
            var src_engine = src.Tag as CanvasEngine;
            if (src_engine == null) return;

            this.Name = "Thumbnail";
            this.BackColor = Color.DimGray;
            this.Alignment = ListViewAlignment.Default;
            this.MultiSelect = false;
            this.Dock = DockStyle.Fill;
            this.OwnerDraw = true;

            lock (lock_) {
                engine_ = new ThumbEngine(src_engine.Core, 256);
                engine_.ImageGenerated -= new ThumbEventHandler(ImageGeneratedHandler);
                engine_.ImageGenerated += new ThumbEventHandler(ImageGeneratedHandler);
            }

            parent.Controls.Add(this);
            this.Restruct(this);

            this.DrawItem -= new DrawListViewItemEventHandler(DrawItemHandler);
            this.DrawItem += new DrawListViewItemEventHandler(DrawItemHandler);
            this.Resize -= new EventHandler(ResizeHandler);
            this.Resize += new EventHandler(ResizeHandler);
            this.MouseEnter -= new EventHandler(MouseEnterHandler);
            this.MouseEnter += new EventHandler(MouseEnterHandler);
        }

        /* ----------------------------------------------------------------- */
        /// Restruct (private)
        /* ----------------------------------------------------------------- */
        private void Restruct(object sender) {
            lock (lock_) {
                try {
                    var control = sender as Control;
                    if (control == null || engine_ == null) return;

                    var parent = control.Parent;
                    if (parent == null) return;
                    var core = engine_.Core;

                    if (core == null) return;
                    // 水平スクロールバーが出ないサイズ．
                    // 16 は垂直スクロールバーの幅（TODO: 垂直スクロールバーの幅の取得方法）．
                    int rot = core.Pages[1].Rotation;
                    double ratio = (rot >= 45 && rot < 135) || (rot >= 225 && rot < 315) ?
                        core.Pages[1].Width / (double)core.Pages[1].Height :
                        core.Pages[1].Height / (double)core.Pages[1].Width;
                    int width = parent.ClientSize.Width;
                    if (width * ratio * core.PageCount > parent.Size.Height) width -= 20;
                    width -= 3; // NOTE: 余白を持たせる．手動で微調整したもの
                    int height = (int)(width * ratio);
                    engine_.ClearQueue();
                    engine_.QueueLimit = parent.Height / height * 2;
                    engine_.CacheSize = engine_.QueueLimit;

                    if (width != this.TileSize.Width) {
                        this.BeginUpdate();
                        this.View = View.Tile;
                        this.TileSize = new Size(width, height);
                        if (this.Items.Count > 0) this.Items.Clear();
                        for (int i = 0; i < core.PageCount; i++) this.Items.Add((i + 1).ToString());
                        this.EndUpdate();
                    }
                }
                catch (Exception err) {
                    Utility.ErrorLog(err);
                }
            }
        }

        /* ----------------------------------------------------------------- */
        //  イベントハンドラの定義
        /* ----------------------------------------------------------------- */
        #region Event handlers
        /* ----------------------------------------------------------------- */
        ///
        /// DrawItemHandler (private)
        /// 
        /// <summary>
        /// サムネイルの DrawItem イベントハンドラ．
        /// </summary>
        /// 
        /* ----------------------------------------------------------------- */
        private void DrawItemHandler(object sender, DrawListViewItemEventArgs e) {
            if (e.ItemIndex >= this.Items.Count) return;

            lock (lock_) {
                if (engine_ == null) return;

                Rectangle rect = new Rectangle(e.Bounds.Location, e.Bounds.Size);
                rect.Inflate(-5, -5);
                var image = engine_.Get(e.ItemIndex + 1);
                if (image != null) {
                    lock (image) {
                        e.Graphics.DrawImage(image, rect);
                    }
                }
                else {
                    engine_.Enqueue(e.ItemIndex + 1);
                    this.Cursor = Cursors.AppStarting;

                    // 生成されてないページは真っ白な画像を表示する．
                    using (var brush = new SolidBrush(Color.White)) {
                        e.Graphics.FillRectangle(brush, rect);
                    }
                }
                e.Graphics.DrawRectangle(Pens.LightGray, rect);

                // MEMO: キャプションを描画する方法．
                // var stringFormat = new StringFormat();
                // stringFormat.Alignment = StringAlignment.Center;
                // stringFormat.LineAlignment = StringAlignment.Center;
                // e.Graphics.DrawString(e.Item.Text, canvas.Font, Brushes.Black, new RectangleF(e.Bounds.X, e.Bounds.Y + e.Bounds.Height - 10, e.Bounds.Width, 10), stringFormat);

                if (e.ItemIndex == engine_.Core.CurrentPage - 1) {
                    using (var pen = new Pen(Color.FromArgb(255, 50, 0))) {
                        pen.Width = 2;
                        e.Graphics.DrawRectangle(pen, rect);
                    }
                }
            }
        }

        /* ----------------------------------------------------------------- */
        /// ResizeHandler
        /* ----------------------------------------------------------------- */
        private void ResizeHandler(object sender, EventArgs e) {
            this.Restruct(sender);
        }

        /* ----------------------------------------------------------------- */
        /// MouseEnterHandler
        /* ----------------------------------------------------------------- */
        private void MouseEnterHandler(object sender, EventArgs e) {
            this.Focus();
        }

        /* ----------------------------------------------------------------- */
        /// ImageGeneratedHandler
        /* ----------------------------------------------------------------- */
        private void ImageGeneratedHandler(object sender, ThumbEventArgs e) {
            if (e.PageNum <= 0 && e.PageNum >= this.Items.Count) return;
            this.Invalidate(this.Items[e.PageNum - 1].Bounds);

            var engine = sender as ThumbEngine;
            if (engine == null || engine.QueueCount <= 0) this.Cursor = Cursors.Default;
            else this.Cursor = Cursors.AppStarting;
        }

        #endregion

        /* ----------------------------------------------------------------- */
        //  使用している Win32 API
        /* ----------------------------------------------------------------- */
        #region Win32 APIs

        [DllImport("user32.dll")]
        private static extern bool ShowScrollBar(IntPtr hWnd, int wBar, bool bShow);

        #endregion

        /* ----------------------------------------------------------------- */
        //  メンバ変数の定義
        /* ----------------------------------------------------------------- */
        #region Member variables
        private bool erase_background_ = true;
        private ThumbEngine engine_ = null;
        private object lock_ = new object();
        #endregion
    }
}
