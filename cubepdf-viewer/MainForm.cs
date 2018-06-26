﻿/* ------------------------------------------------------------------------- */
/*
 *  MainForm.cs
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
 *  Last-modified: Mon 18 Oct 2010 18:40:00 JST
 */
/* ------------------------------------------------------------------------- */
using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using System.Diagnostics;
using System.ComponentModel;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.IO;

using MySettings = Cube.Properties.Settings;

namespace Cube
{

    public partial class MainForm : Form
    {
        string pdfpath = @"..\..\Bin64\Ref\3DData\DOC\";
        string explorerPath = @"..\..\Bin64\Ref\3DData\DOC\";

        public MainForm()
        {
            this.Initialize();
        }

  
        public MainForm(string path)
        {
            this.Initialize();
            this.Tag = path;
        }


        private void Initialize()
        {
            InitializeComponent();

            var exec = System.Reflection.Assembly.GetEntryAssembly();
            var dir = System.IO.Path.GetDirectoryName(exec.Location);
            var path = dir + @"\cubepdf-viewer.log";
            if (System.IO.File.Exists(path)) System.IO.File.Delete(path);
            Utility.SetupLog(path);

            int x = Screen.PrimaryScreen.Bounds.Height - 100;
            this.Size = (setting_.Size.Width > 0 && setting_.Size.Height > 0) ?
                setting_.Size : new Size(System.Math.Max(x, 0), x);
            this.StartPosition = FormStartPosition.Manual;
            var pos = new Point(Math.Min(Math.Max(setting_.Position.X, 0), (int)(Screen.PrimaryScreen.Bounds.Width * 0.9)),
                Math.Min(Math.Max(setting_.Position.Y, 0), (int)(Screen.PrimaryScreen.Bounds.Height * 0.9)));
            this.Location = setting_.Position;

            this.MenuToolStrip.Renderer = new CustomToolStripRenderer();
            this.MenuSplitContainer.SplitterDistance = this.MenuToolStrip.Height;
            this.NavigationSplitContainer.Panel1Collapsed = (setting_.Navigaion == NavigationCondition.None);
            this.NavigationSplitContainer.SplitterDistance = Math.Max(setting_.ThumbWidth, this.NavigationSplitContainer.Panel1MinSize);

            this.UpdateFitCondition(setting_.Fit);
            CreateTabContextMenu(this.PageViewerTabControl);

            this.DefaultTabPage.MouseWheel += new MouseEventHandler(TabPage_MouseWheel);

            if (setting_.UseAdobeExtension) {
                InitializeAdobe();
                if (adobe_.Length > 0) {
                    this.AdobeButton.Enabled = true;
                    this.AdobeButton.Visible = true;
                }
            }

            this.Text = Cube.Properties.Settings.Default.DEFAULT_WINDOW_TITLE;

            System.Reflection.Assembly asm = System.Reflection.Assembly.GetExecutingAssembly();
            CanvasPolicyA.SetHandCursor(new Cursor(asm.GetManifestResourceStream(MySettings.Default.HAND_CURSOR_LOCATION)));

            if (!pdfpath.Equals(""))
                getFolderView(pdfpath);
        }

 
        private void getFolderView(string path)
        {
            explorerPath = path;

            try
            {
                this.listView_show.Items.Clear();
                DirectoryInfo TheFolder = new DirectoryInfo(path);
                //遍历文件夹
                foreach (DirectoryInfo NextFolder in TheFolder.GetDirectories())
                {
                    this.listView_show.Items.Add("【" + NextFolder.Name + "】");

                }
                //遍历文件
                foreach (FileInfo NextFile in TheFolder.GetFiles())
                    this.listView_show.Items.Add(NextFile.Name); //再添加文件大小显示
            }
            catch (Exception)
            {

            }
        }

        private void listView_show_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {
                string filename = this.listView_show.SelectedItems[0].SubItems[0].Text;
                if (filename.StartsWith("【")) //目录处理方式
                {
                    filename = filename.Replace("【", "");
                    filename = filename.Replace("】", "");
                    string newPath = explorerPath + "\\" + filename;
                    getFolderView(newPath);//遍历该层文件                    
                }
                else //文件处理方式
                {
                    string newPath = explorerPath + "\\" + filename;

                    //OpenFile(newPath);

                    this.Open(this.PageViewerTabControl, newPath);
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                //MessageBox.Show(ex.ToString());
            }

        }

        /* ----------------------------------------------------------------- */
        /// UpdateFitCondtion
        /* ----------------------------------------------------------------- */
        private void UpdateFitCondition(FitCondition which)
        {
            setting_.Fit = which;
            this.FitToWidthButton.Checked = ((setting_.Fit & FitCondition.Width) != 0);
            this.FitToPageButton.Checked = ((setting_.Fit & FitCondition.Height) != 0);
        }

        /* ----------------------------------------------------------------- */
        ///
        /// Refresh
        /// 
        /// <summary>
        /// システムの Refresh() を呼ぶ前に，必要な情報を全て更新する．
        /// MEMO: サムネイル画面を更新するとちらつきがひどいので，
        /// 最小限の更新になるようにしている．
        /// ステータスバーを除去した．現状は，message はどこにも表示させて
        /// いない (2010/09/30)．
        /// </summary>
        /// 
        /* ----------------------------------------------------------------- */
        private void Refresh(PictureBox canvas, string message) {
            if (canvas == null || canvas.Tag == null) {
                this.CurrentPageTextBox.Text = "0";
                this.TotalPageLabel.Text = "0";
                this.ZoomDropDownButton.Text = "100%";
            }
            else {
                this.CurrentPageTextBox.Text = CanvasPolicyA.CurrentPage(canvas).ToString();
                this.TotalPageLabel.Text = CanvasPolicyA.PageCount(canvas).ToString();
                this.ZoomDropDownButton.Text = ((int)CanvasPolicyA.Zoom(canvas)).ToString() + "%";

                // scrollbar の smallchangeの更新
                var control = (ScrollableControl)canvas.Parent;
                var vsb = control.VerticalScroll;
                var hsb = control.HorizontalScroll;
                vsb.SmallChange = Math.Max(1, (vsb.Maximum - vsb.Minimum - vsb.LargeChange) / 20);
                hsb.SmallChange = Math.Max(1, (hsb.Maximum - hsb.Minimum - hsb.LargeChange) / 20);
            }

            if (this.MainMenuStrip != null) this.MainMenuStrip.Refresh();
            if (this.PageViewerTabControl != null) this.PageViewerTabControl.Refresh();
        }

        /* ----------------------------------------------------------------- */
        /// Refresh
        /* ----------------------------------------------------------------- */
        private void Refresh(PictureBox canvas) {
            this.Refresh(canvas, "");
        }

        /* ----------------------------------------------------------------- */
        ///
        /// ChangeTitlebarText
        /// 
        /// <summary>
        /// 引数無しで呼び出すとタイトルバーのテキストをデフォルトに戻す．
        /// </summary>
        /// <param name="filename"></param>
        /// 
        /* ----------------------------------------------------------------- */
        private void ChangeTitlebarText(string filename) {
            if (filename == "") this.Text = Cube.Properties.Settings.Default.DEFAULT_WINDOW_TITLE;
            else this.Text = filename + " - " + Cube.Properties.Settings.Default.DEFAULT_WINDOW_TITLE;
        }

        /* ----------------------------------------------------------------- */
        /// Open
        /* ----------------------------------------------------------------- */
        private void Open(TabPage tab, string path, string password)
        {
            var canvas = CanvasPolicyA.Create(tab);
            var message = "";

            try
            {
                CanvasPolicyA.Open(canvas, path, password, setting_.Fit);
                if (!this.NavigationSplitContainer.Panel1Collapsed)
                {
                    this.CreateThumbnail(canvas);
                }
                ChangeTitlebarText(System.IO.Path.GetFileNameWithoutExtension(path));
            }
            catch (System.Security.SecurityException /* err */)
            {
                PasswordDialog dialog = new PasswordDialog(path);
                dialog.ShowDialog();
                if (dialog.Password.Length > 0) this.Open(tab, path, dialog.Password);
            }
            catch (Exception err)
            {
                Utility.ErrorLog(err);
                message = err.Message;
            }
            finally
            {
                canvas.Parent.Focus();
                this.Refresh(canvas, message);
            }
        }

        /* ----------------------------------------------------------------- */
        ///
        /// Open
        /// 
        /// <summary>
        /// 開く前に，ファイルを既に開いているかどうかのチェックを行う．
        /// 既にファイルを開いていた場合は，そのタブをアクティブにして
        /// 終了する．
        /// </summary>
        /// 
        /* ----------------------------------------------------------------- */
        private void Open(TabControl control, string path, string password) {
            foreach (TabPage item in control.TabPages) {
                var s = item.Tag as string;
                if (s != null && s == path) {
                    this.PageViewerTabControl.SelectedTab = item;
                    return;
                }
            }
            this.Open(this.CreateTab(control), path, password);
        }

        /* ----------------------------------------------------------------- */
        /// Open
        /* ----------------------------------------------------------------- */
        private void Open(TabControl control, string path) {
            this.Open(control, path, "");
        }

        /* ----------------------------------------------------------------- */
        /// NextPage
        /* ----------------------------------------------------------------- */
        private bool NextPage(TabPage tab) {
            var canvas = CanvasPolicyA.Get(tab);
            if (canvas == null) return false;

            var status = true;
            var message = "";
            try {
                int prev = CanvasPolicyA.CurrentPage(canvas);
                if (prev >= CanvasPolicyA.PageCount(canvas)) return true;
                if (CanvasPolicyA.NextPage(canvas) == prev) status = false;
                this.RefreshThumbnail(this.NavigationSplitContainer.Panel1, CanvasPolicyA.CurrentPage(canvas), prev);
                this.Refresh(canvas, message);
            }
            catch (Exception err) {
                Utility.ErrorLog(err);
                status = false;
                message = err.Message;
            }
            return status;
        }

        /* ----------------------------------------------------------------- */
        /// PreviousPage
        /* ----------------------------------------------------------------- */
        private bool PreviousPage(TabPage tab)
        {
            var canvas = CanvasPolicyA.Get(this.PageViewerTabControl.SelectedTab);
            if (canvas == null) return false;

            var status = true;
            var message = "";
            try
            {
                int prev = CanvasPolicyA.CurrentPage(canvas);
                if (prev <= 1) return true;
                if (CanvasPolicyA.PreviousPage(canvas) == prev) status = false;
                this.RefreshThumbnail(this.NavigationSplitContainer.Panel1, CanvasPolicyA.CurrentPage(canvas), prev);
                this.Refresh(canvas, message);
            }
            catch (Exception err)
            {
                Utility.ErrorLog(err);
                status = false;
                message = err.Message;
            }
            return status;
        }

        /* ----------------------------------------------------------------- */
        /// Search
        /* ----------------------------------------------------------------- */
        private void Search(TabPage tab, string text, bool next)
        {
            var canvas = CanvasPolicyA.Get(tab);
            if (canvas == null || text.Length <= 0) return;

            var message = "";

            try
            {
                int previousPageNumber = CanvasPolicyA.CurrentPage(canvas);
                var args = new SearchArgs(text);
                args.FromBegin = begin_;
                args.IgnoreCase = true;
                args.WholeDocument = true;
                args.WholeWord = false;
                args.FindNext = next;

                var result = CanvasPolicyA.Search(canvas, args);
                // begin_ = !result; // 最後まで検索したら始めに戻る
                if (!result) this.SearchTextBox.BackColor = Color.FromArgb(255, 102, 102);
                else begin_ = false;
                this.RefreshThumbnail(this.NavigationSplitContainer.Panel1, CanvasPolicyA.CurrentPage(canvas), previousPageNumber);
                this.Refresh(canvas, message);
            }
            catch (Exception err) {
                Utility.ErrorLog(err);
                message = err.Message;
            }
        }

        /* ----------------------------------------------------------------- */
        ///
        /// ResetSearch
        /// 
        /// <summary>
        /// MEMO: ライブラリが，検索結果を描画する状態を解除する方法を
        /// 持っていないため，空の文字列で検索してリセットする．
        /// </summary>
        /// 
        /* ----------------------------------------------------------------- */
        private void ResetSearch(TabPage tab)
        {
            var canvas = CanvasPolicyA.Get(tab);

            try
            {
                var dummy = new SearchArgs();
                CanvasPolicyA.Search(canvas, dummy);
            }
            catch (Exception /* err */) { }
            finally
            {
                begin_ = true;
                this.Refresh(canvas);
            }
        }

        /* ----------------------------------------------------------------- */
        /// Adjust
        /* ----------------------------------------------------------------- */
        private void Adjust(TabPage tab)
        {
            var canvas = CanvasPolicyA.Get(tab);
            var message = "";
            
            try
            {
                if (this.FitToWidthButton.Checked) CanvasPolicyA.FitToWidth(canvas);
                else if (this.FitToPageButton.Checked) CanvasPolicyA.FitToPage(canvas);
                else CanvasPolicyA.Adjust(canvas);
            }
            catch (Exception err)
            {
                Utility.ErrorLog(err);
                message = err.Message;
            }
            finally
            {
                this.Refresh(canvas, message);
            }
        }

        /* ----------------------------------------------------------------- */
        /// AsyncAdjust
        /* ----------------------------------------------------------------- */
        private void AsyncAdjust(TabPage tab)
        {
            var worker = new BackgroundWorker();
            worker.DoWork += new DoWorkEventHandler(AdjustDoWorkHandler);
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(AdjustRunCompletedHandler);
            worker.RunWorkerAsync(tab);

            var canvas = CanvasPolicyA.Get(tab);
            if (canvas == null) return;
            
            canvas.Cursor = Cursors.WaitCursor;
            this.Refresh(canvas);
        }

        /* ----------------------------------------------------------------- */
        /// AdjustDoWorkHandler
        /* ----------------------------------------------------------------- */
        private void AdjustDoWorkHandler(object sender, DoWorkEventArgs e)
        {
            var tab = e.Argument as TabPage;
            var canvas = (tab != null) ? CanvasPolicyA.Get(tab) : null;
            if (canvas == null) return;

            var message = "";
            try
            {
                if (this.FitToWidthButton.Checked) CanvasPolicyA.FitToWidth(canvas);
                else if (this.FitToPageButton.Checked) CanvasPolicyA.FitToPage(canvas);
                else CanvasPolicyA.Adjust(canvas);
            }
            catch (Exception err)
            {
                Utility.ErrorLog(err);
                message = err.Message;
            }
        }

        /* ----------------------------------------------------------------- */
        /// AdjustRunCompletedHandler
        /* ----------------------------------------------------------------- */
        private void AdjustRunCompletedHandler(object sender, RunWorkerCompletedEventArgs e)
        {
            var tab = this.PageViewerTabControl.SelectedTab;
            var canvas = CanvasPolicyA.Get(tab);
            if (canvas == null) return;

            canvas.Cursor = Cursors.Default;
            this.Refresh(canvas);
        }

        /* ----------------------------------------------------------------- */
        ///
        /// CreateTab
        /// 
        /// <summary>
        /// 新しい「空のタブ」を生成する．
        /// 「空のタブ」は，同時には 1 つしか存在できないようにしている．
        /// </summary>
        /// 
        /* ----------------------------------------------------------------- */
        public TabPage CreateTab(TabControl parent)
        {
            foreach (TabPage item in parent.TabPages)
            {
                if (item.Tag == null)
                {
                    parent.SelectedTab = item;
                    return item;
                }
            }

            var tab = new TabPage();

            // TabPage設定
            tab.AllowDrop = true;
            tab.AutoScroll = true;
            tab.BackColor = Color.DimGray;
            tab.BorderStyle = BorderStyle.None;
            tab.ContextMenuStrip = new ContextMenuStrip();
            tab.Text = Cube.Properties.Settings.Default.DEFAULT_TAB_TEXT;
            tab.Scroll += new ScrollEventHandler(TabPage_Scroll);
            tab.DragEnter += new DragEventHandler(TabPage_DragEnter);
            tab.DragDrop += new DragEventHandler(TabPage_DragDrop);
            tab.MouseWheel += new MouseEventHandler(TabPage_MouseWheel);
            parent.Controls.Add(tab);
            parent.SelectedIndex = parent.TabCount - 1;

            return tab;
        }

        /* ----------------------------------------------------------------- */
        /// DestroyTab
        /* ----------------------------------------------------------------- */
        public void DestroyTab(TabPage tab)
        {
            if (tab == null) return;
            var parent = tab.Parent as TabControl;
            if (parent == null) return;

            var canvas = CanvasPolicyA.Get(tab);
            if (canvas == null) return;
            var engine = canvas.Tag as CanvasEngine;
            if (engine == null) return;

            //engine.Thumbnail = null;
            this.DestroyThumbnail(this.NavigationSplitContainer.Panel1);
            CanvasPolicyA.Destroy(canvas);
            if (this.PageViewerTabControl.TabCount > 1)
            {
                parent.TabPages.Remove(tab);
                tab.Dispose();
            }
        }

        public void CreateTabContextMenu(TabControl parent)
        {
            var menu = new ContextMenuStrip();
            var elem = new ToolStripMenuItem();
            elem.Text = "閉じる";
            elem.Click -= new EventHandler(TabCloseMenuItem_Click);
            elem.Click += new EventHandler(TabCloseMenuItem_Click);
            menu.Items.Add(elem);
            parent.MouseDown -= new MouseEventHandler(PageViewerTabControl_MouseDown);
            parent.MouseDown += new MouseEventHandler(PageViewerTabControl_MouseDown);
            parent.ContextMenuStrip = menu;

            foreach (TabPage child in parent.TabPages)
            {
                child.ContextMenuStrip = new ContextMenuStrip();
            }
        }

        /* ----------------------------------------------------------------- */
        /// CreateThumbnail
        /* ----------------------------------------------------------------- */
        private void CreateThumbnail(PictureBox canvas)
        {
            Thumbnail thumb = null;
            var control = this.NavigationSplitContainer.Panel1;
            var engine = canvas.Tag as CanvasEngine;

            // キャッシュしてあるサムネイルを復元．
            if (engine != null && engine.Thumbnail != null)
            {
                thumb = engine.Thumbnail;
                control.Controls.Add(thumb);
                thumb.Reset(control);
            }
            else thumb = new Thumbnail(control, canvas);

            thumb.SelectedIndexChanged -= new EventHandler(Thumbnail_SelectedIndexChanged);
            thumb.SelectedIndexChanged += new EventHandler(Thumbnail_SelectedIndexChanged);
        }

    
        private void SaveThumbnail(PictureBox canvas)
        {
            if (canvas == null) return;
            var engine = canvas.Tag as CanvasEngine;
            if (engine == null) return;

            var thumb = Thumbnail.GetInstance(this.NavigationSplitContainer.Panel1);
            if (thumb == null) return;
            thumb.SelectedIndexChanged -= new EventHandler(Thumbnail_SelectedIndexChanged);
            this.NavigationSplitContainer.Panel1.Controls.Remove(thumb);

            // thumbnail を停止させて CanvasEngine に保存する．
            thumb.Reset();
            engine.Thumbnail = thumb;
        }

        /* ----------------------------------------------------------------- */
        ///
        /// DestroyThumbnail
        /// 
        /// <summary>
        /// MEMO: SelectedIndexChanged イベントハンドラを早い段階で除いて
        /// おかないと，別の TabPage が SelectedIndexChanged イベントの
        /// 影響を受けてしまう模様．
        /// </summary>
        /// 
        /* ----------------------------------------------------------------- */
        private void DestroyThumbnail(Control parent) {
            var thumb = Thumbnail.GetInstance(parent);
            if (thumb == null) return;
            thumb.SelectedIndexChanged -= new EventHandler(Thumbnail_SelectedIndexChanged);
            parent.Controls.Remove(thumb);
            thumb.Dispose();
        }

        /* ----------------------------------------------------------------- */
        ///
        /// RefreshThumbnail
        /// 
        /// <summary>
        /// 選択ページを表す枠線を再描画する．index0, index1 がそれぞれ
        /// 遷移元ページ，現在の選択ページに対応するインデックスを表す．
        /// 選択ページについては，Selected プロパティを更新する事によって
        /// DrawItem イベントが自動的に発生する模様．
        /// </summary>
        /// 
        /* ----------------------------------------------------------------- */
        private void RefreshThumbnail(Control parent, int current, int previous) {
            var thumb = Thumbnail.GetInstance(parent);
            if (thumb == null) return;

            var index0 = Math.Min(Math.Max(previous - 1, 0), thumb.Items.Count);
            var index1 = Math.Min(Math.Max(current - 1, 0), thumb.Items.Count);
            thumb.Invalidate(thumb.Items[index0].Bounds);
            thumb.Items[index1].Selected = true;
            thumb.Items[index1].EnsureVisible();
        }

        /* ----------------------------------------------------------------- */
        /// WndProc
        /* ----------------------------------------------------------------- */
        protected override void WndProc(ref Message m) {
            try {
                switch (m.Msg) {
                case Program.WM_COPYDATA:
                    // 既にプログラムが起動している場合に PDF ファイルが
                    // ダブルクリックされた場合，起動しているプログラムに
                    // 新たなタブを生成して描画する．
                    var mystr = new Program.COPYDATASTRUCT();
                    mystr = (Program.COPYDATASTRUCT)m.GetLParam(typeof(Program.COPYDATASTRUCT));
                    var path = mystr.lpData;
                    this.Open(this.PageViewerTabControl, path);
                    break;
                default:
                    break;
                }
            }
            catch (Exception err) {
                Utility.ErrorLog(err);
            }
            finally {
                base.WndProc(ref m);
            }
        }

        /* ----------------------------------------------------------------- */
        //  キーボード・ショートカット一覧
        /* ----------------------------------------------------------------- */
        #region Keybord shortcuts

        /* ----------------------------------------------------------------- */
        ///
        /// MainForm_KeyDown
        ///
        /// <summary>
        /// キーボード・ショートカット一覧．
        /// KeyPreview を有効にして，全てのキーボードイベントを一括で
        /// 処理している．
        /// </summary>
        /// 
        /* ----------------------------------------------------------------- */
        private void MainForm_KeyDown(object sender, KeyEventArgs e) {
            switch (e.KeyCode) {
            case Keys.Enter:
                if (this.SearchTextBox.Focused && this.SearchTextBox.Text.Length > 0) {
                    this.SearchButton_Click(this.SearchButton, e);
                }
                e.SuppressKeyPress = true;
                break;
            case Keys.Escape:
                this.ResetSearch(this.PageViewerTabControl.SelectedTab);
                e.SuppressKeyPress = true;
                break;
            case Keys.Right:
                this.NextPageButton_Click(this.NextPageButton, e);
                break;
            case Keys.Down:
                //if (e.Control) this.ZoomInButton_Click(this.ZoomInButton, e);
                //else this.NextPageButton_Click(this.NextPageButton, e);
                break;
            case Keys.Left:
                this.PreviousPageButton_Click(this.PreviousPageButton, e);
                break;
            case Keys.Up:
                //if (e.Control) this.ZoomOutButton_Click(this.ZoomOutButton, e);
                //else this.PreviousPageButton_Click(this.PreviousPageButton, e);
                break;
            case Keys.F3: // 検索
                if (this.SearchTextBox.Text.Length > 0) this.Search(this.PageViewerTabControl.SelectedTab, this.SearchTextBox.Text, !e.Shift);
                break;
            case Keys.F4: // 閉じる
                if (e.Control) this.DestroyTab(this.PageViewerTabControl.SelectedTab);
                break;
            case Keys.F8: // メニューの表示/非表示
                this.MenuModeButton_Click(this.MenuModeButton, e);
                break;
            case Keys.F:  // 検索ボックスにフォーカス
                if (e.Control) this.SearchTextBox.Focus();
                break;
            case Keys.M:  // メニューの表示/非表示
                if (e.Control) this.MenuModeButton_Click(this.MenuModeButton, e);
                break;
            case Keys.N:  // 新規タブ
                if (e.Control) this.NewTabButton_Click(this.PageViewerTabControl, e);
                break;
            case Keys.O:  // ファイルを開く
                if (e.Control) this.OpenButton_Click(this.PageViewerTabControl.SelectedTab, e);
                break;
            case Keys.T: // サムネイルの表示/非表示
                if (e.Control) this.ThumbButton_Click(this.ThumbButton, e);
                break;
            case Keys.W:  // ファイルを閉じる
                if (e.Control) this.CloseButton_Click(this.PageViewerTabControl.SelectedTab, e);
                break;
            default:
                break;
            }
        }

        #endregion

        /* ----------------------------------------------------------------- */
        //  メインフォームに関する各種イベント・ハンドラ
        /* ----------------------------------------------------------------- */
        #region MainForm Event handlers

        /* ----------------------------------------------------------------- */
        /// MainForm_Shown
        /* ----------------------------------------------------------------- */
        private void MainForm_Shown(object sender, EventArgs e) {
            this.Refresh();
            if (this.Tag != null) {
                var path = (string)this.Tag;
                this.Open(this.PageViewerTabControl, path);
                this.Tag = null;
            }
        }

        /* ----------------------------------------------------------------- */
        ///  MainForm_FormClosing
        /* ----------------------------------------------------------------- */
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e) {
            if (this.WindowState == FormWindowState.Normal) {
                setting_.Position = this.Location;
                setting_.Size = this.Size;
            }
            setting_.ThumbWidth = this.NavigationSplitContainer.SplitterDistance;
            setting_.Save();
        }

        /* ----------------------------------------------------------------- */
        ///
        /// MainForm_Resize
        ///
        /// <summary>
        /// NOTE: メイン画面のリサイズ処理がサムネイル画面の描画を待たせて
        /// いるため，リサイズ処理を BackgroundWorker() で実行してみる．
        /// しばらく様子見．
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void MainForm_Resize(object sender, EventArgs e) {
            if (!this.Visible) return;
            
            //if ((resize_ & 0x01) == 0) this.Adjust(this.PageViewerTabControl.SelectedTab);
            if ((resize_ & 0x01) == 0) this.AsyncAdjust(this.PageViewerTabControl.SelectedTab);
            resize_ |= 0x02;
        }

        /* ----------------------------------------------------------------- */
        ///
        /// MainForm_ResizeBegin
        /// 
        /// <summary>
        /// ドラッグ形式のリサイズの場合，リアルタイムに変更すると動作が
        /// 重くなるため，ドラッグ中はリサイズを行わないようにする．
        /// また，サムネイル画像のちらつきを抑えるため，サムネイル画像
        /// への背景消去 (WM_ERASEBKGND) メッセージを無効にする．
        /// 
        /// MEMO: ユーザの操作と発生するイベント
        ///  1. ドラッグによるのリサイズ: ReizeBegin -> Resize -> ResizeEnd
        ///  2. 最大化: Resize
        ///  3. ドラッグによる移動: ResizeBegin -> ResizeEnd
        /// </summary>
        /// 
        /* ----------------------------------------------------------------- */
        private void MainForm_ResizeBegin(object sender, EventArgs e) {
            if (!this.Visible) return;

            resize_ = 0;
            resize_ |= 0x01;
            var thumb = Thumbnail.GetInstance(this.NavigationSplitContainer.Panel1);
            if (thumb != null) thumb.EraseBackground = false;
        }

        /* ----------------------------------------------------------------- */
        /// MainForm_ResizeEnd
        /* ----------------------------------------------------------------- */
        private void MainForm_ResizeEnd(object sender, EventArgs e) {
            if (!this.Visible) return;

            if ((resize_ & 0x02) != 0) {
                this.Adjust(this.PageViewerTabControl.SelectedTab);
                setting_.Position = this.Location;
                setting_.Size = this.Size;
            }

            resize_ = 0;
            var thumb = Thumbnail.GetInstance(this.NavigationSplitContainer.Panel1);
            if (thumb != null) {
                thumb.EraseBackground = true;
                thumb.Invalidate();
            }
        }

        #endregion

        /* ----------------------------------------------------------------- */
        //  メインフォームに登録している各種コントロールのイベントハンドラ
        /* ----------------------------------------------------------------- */
        #region Other controls event handlers

        /* ----------------------------------------------------------------- */
        /// NewTabButton_Click
        /* ----------------------------------------------------------------- */
        private void NewTabButton_Click(object sender, EventArgs e) {
            this.CreateTab(this.PageViewerTabControl);
        }


        private void OpenButton_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.Filter = "PDF(*.pdf)|*.pdf";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                this.Open(this.PageViewerTabControl, dialog.FileName);
            }
        }

        /* ----------------------------------------------------------------- */
        /// CloseButton_Click
        /* ----------------------------------------------------------------- */
        private void CloseButton_Click(object sender, EventArgs e) {
            var tab = this.PageViewerTabControl.SelectedTab;
            this.DestroyTab(tab);
        }

 
        private void PrintButton_Click(object sender, EventArgs e)
        {
            var canvas = CanvasPolicyA.Get(this.PageViewerTabControl.SelectedTab);
            if (canvas == null) return;
            var engine = canvas.Tag as CanvasEngine;
            if (engine == null) return;
            var core = engine.Core;
            if (core == null) return;

            using (var prd = new PrintDialog())
            using (var document = new System.Drawing.Printing.PrintDocument()) {
                var path = this.PageViewerTabControl.SelectedTab.Tag as string;
                document.DocumentName = System.IO.Path.GetFileNameWithoutExtension(path);
                prd.AllowCurrentPage = true;
                prd.AllowSelection = false; // ページを選択する方法を提供しないのでfalse
                prd.AllowSomePages = true;
                prd.PrinterSettings.MinimumPage = 1;
                prd.PrinterSettings.MaximumPage = core.PageCount;
                prd.PrinterSettings.FromPage = core.CurrentPage;
                prd.PrinterSettings.ToPage = core.PageCount;
                prd.UseEXDialog = true;

                if (prd.ShowDialog() == DialogResult.OK)
                {
                    document.PrinterSettings = prd.PrinterSettings;
                    document.DefaultPageSettings = document.PrinterSettings.DefaultPageSettings; // プリンターのデフォルト設定に変更してみる
                    if (Utility.IsPSPrinter(document.PrinterSettings.PrinterName) && !core.NoEmbedFontExists()) {
                        var ps = Utility.TempPath() + ".ps";
                        int first = 1;
                        int last = core.PageCount;
                        if (document.PrinterSettings.PrintRange == PrintRange.SomePages) {
                            first = document.PrinterSettings.FromPage;
                            last = document.PrinterSettings.ToPage;
                        }

                        if (core.PrintToFile(ps, first, last) >= 0)
                        {
                            try
                            {
                                var docname = canvas.Parent.Tag as string;
                                if (docname == null) docname = "document";
                                RawPrinterHelper.SendFileToPrinter(prd.PrinterSettings.PrinterName, ps, System.IO.Path.GetFileNameWithoutExtension(docname));
                            }
                            catch (Exception err) {
                                Utility.ErrorLog(err);
                                this.PrintBitmap(document, core);
                            }
                        }
                        else this.PrintBitmap(document, core);
                    }
                    else this.PrintBitmap(document, core);
                }
            }
        }

        /* ----------------------------------------------------------------- */
        /// PrintBitmap
        /* ----------------------------------------------------------------- */
        private void PrintBitmap(System.Drawing.Printing.PrintDocument document, PDFLibNet.PDFWrapper core) {
            var settings = new { page = core.CurrentPage, zoom = core.Zoom };
            document.PrintPage += new PrintPageEventHandler(PrintDocument_PrintPage);
            core.CurrentPage = (document.PrinterSettings.PrintRange == PrintRange.AllPages) ?
                1 : document.PrinterSettings.FromPage;
            document.Print();
            core.CurrentPage = settings.page;
            core.Zoom = settings.zoom;
            core.RenderPage(IntPtr.Zero, false, false);
        }

        /* ----------------------------------------------------------------- */
        ///
        /// PrintDocument_PrintPage
        ///
        /// <summary>
        /// フォントが埋め込まれていないときに使用する印刷方法．
        /// 
        /// MEMO: 綺麗に印刷するためにはプリンタの解像度に合わせた画像を
        /// 生成しなければならないが，画像サイズが大きすぎて PC がフリーズ
        /// する恐れがある．そのため，現状は「少し大きめ」の画像を生成
        /// し，それを拡大して印刷している．
        /// </summary>
        /// 
        /* ----------------------------------------------------------------- */
        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs ev) {
            int ratio = 3; // (int)(600 / 72.0);

            var control = this.PageViewerTabControl;
            var canvas = CanvasPolicyA.Get(this.PageViewerTabControl.SelectedTab);
            if (canvas == null) return;
            var engine = canvas.Tag as CanvasEngine;
            if (engine == null) return;
            var core = engine.Core;
            if (core == null) return;

            PDFLibNet.PDFPage page;
            if (!core.Pages.TryGetValue(core.CurrentPage, out page)) return;
            int width = ev.PageSettings.PaperSize.Width;
            int height = ev.PageSettings.PaperSize.Height;

            try {
                using (var image = page.GetBitmap(width * ratio, height * ratio)) {
                    var rect = new Rectangle(new Point(0, 0), new Size(image.Width, image.Height));
                    ev.Graphics.DrawImage(image, ev.Graphics.VisibleClipBounds, rect, GraphicsUnit.Pixel);
                }

                // If more lines exist, print another page.
                if (ev.PageSettings.PrinterSettings.PrintRange == PrintRange.AllPages) {
                    if (core.CurrentPage < core.PageCount) {
                        core.NextPage();
                        ev.HasMorePages = true;
                    }
                    else ev.HasMorePages = false;
                }
                else if (ev.PageSettings.PrinterSettings.PrintRange == PrintRange.SomePages) {
                    if (core.CurrentPage < ev.PageSettings.PrinterSettings.ToPage) {
                        core.NextPage();
                        ev.HasMorePages = true;
                    }
                    else ev.HasMorePages = false;
                }
                else ev.HasMorePages = false;
            }
            catch (OutOfMemoryException err) {
                Utility.ErrorLog(err);
                var message = String.Format("{0}これ以降のページは無視されます。\nエラーの発生したページ番号: {1}", err.Message, core.CurrentPage);
                MessageBox.Show(message, "印刷エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ev.HasMorePages = false;
            }
            catch (Exception err) {
                Utility.ErrorLog(err);
            }
        }

        /* ----------------------------------------------------------------- */
        /// ZoomInButton_Click
        /* ----------------------------------------------------------------- */
        private void ZoomInButton_Click(object sender, EventArgs e)
        {
            this.UpdateFitCondition(FitCondition.None);
            var canvas = CanvasPolicyA.Get(this.PageViewerTabControl.SelectedTab);
            if (canvas == null) return;

            var message = "";
            try
            {
                CanvasPolicyA.ZoomIn(canvas);
            }
            catch (Exception err)
            {
                Utility.ErrorLog(err);
                message = err.Message;
            }
            finally
            {
                this.Refresh(canvas, message);
            }
        }


        private void ZoomOutButton_Click(object sender, EventArgs e)
        {
            this.UpdateFitCondition(FitCondition.None);
            var canvas = CanvasPolicyA.Get(this.PageViewerTabControl.SelectedTab);
            if (canvas == null) return;

            var message = "";
            try
            {
                CanvasPolicyA.ZoomOut(canvas);
            }
            catch (Exception err)
            {
                Utility.ErrorLog(err);
                message = err.Message;
            }
            finally
            {
                this.Refresh(canvas, message);
            }
        }

        /* ----------------------------------------------------------------- */
        /// ZoomDropDownButton_DropDownItemClicked
        /* ----------------------------------------------------------------- */
        private void ZoomDropDownButton_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            this.UpdateFitCondition(FitCondition.None);
            var canvas = CanvasPolicyA.Get(this.PageViewerTabControl.SelectedTab);
            if (canvas == null) return;

            var message = "";
            try
            {
                var zoom = e.ClickedItem.Text.Replace("%", "");
                CanvasPolicyA.Zoom(canvas, int.Parse(zoom));
            }
            catch (Exception err)
            {
                Utility.ErrorLog(err);
                message = err.Message;
            }
            finally
            {
                this.Refresh(canvas, message);
            }
        }

        /* ----------------------------------------------------------------- */
        /// FitToWidthButton_Click
        /* ----------------------------------------------------------------- */
        private void FitToWidthButton_Click(object sender, EventArgs e) {
            this.UpdateFitCondition(this.FitToWidthButton.Checked ? FitCondition.Width : FitCondition.None);
            var canvas = CanvasPolicyA.Get(this.PageViewerTabControl.SelectedTab);
            if (canvas == null) return;

            var message = "";
            try {
                if (this.FitToWidthButton.Checked) CanvasPolicyA.FitToWidth(canvas);
            }
            catch (Exception err) {
                Utility.ErrorLog(err);
                message = err.Message;
            }
            finally {
                this.Refresh(canvas, message);
            }
        }

        /* ----------------------------------------------------------------- */
        /// FitToPageButton_Click
        /* ----------------------------------------------------------------- */
        private void FitToPageButton_Click(object sender, EventArgs e) {
            this.UpdateFitCondition(this.FitToPageButton.Checked ? FitCondition.Height : FitCondition.None);
            var canvas = CanvasPolicyA.Get(this.PageViewerTabControl.SelectedTab);
            if (canvas == null) return;

            var message = "";
            try {
                if (this.FitToPageButton.Checked) CanvasPolicyA.FitToPage(canvas);
            }
            catch (Exception err) {
                Utility.ErrorLog(err);
                message = err.Message;
            }
            finally {
                this.Refresh(canvas, message);
            }
        }

        /* ----------------------------------------------------------------- */
        /// NextPageButton_Click
        /* ----------------------------------------------------------------- */
        private void NextPageButton_Click(object sender, EventArgs e) {
            NextPage(this.PageViewerTabControl.SelectedTab);
        }

        /* ----------------------------------------------------------------- */
        /// PreviousPageButton_Click
        /* ----------------------------------------------------------------- */
        private void PreviousPageButton_Click(object sender, EventArgs e) {
            PreviousPage(this.PageViewerTabControl.SelectedTab);
        }

        /* ----------------------------------------------------------------- */
        /// FirstPageButton_Click
        /* ----------------------------------------------------------------- */
        private void FirstPageButton_Click(object sender, EventArgs e) {
            var tab = this.PageViewerTabControl.SelectedTab;
            var canvas = CanvasPolicyA.Get(tab);
            if (canvas == null) return;

            var message = "";
            try {
                var prev = CanvasPolicyA.CurrentPage(canvas);
                if (prev <= 1) return;
                if (CanvasPolicyA.FirstPage(canvas) == prev) return;
                this.RefreshThumbnail(this.NavigationSplitContainer.Panel1, CanvasPolicyA.CurrentPage(canvas), prev);
                this.Refresh(canvas, message);
            }
            catch (Exception err) {
                Utility.ErrorLog(err);
                message = err.Message;
            }
        }

        /* ----------------------------------------------------------------- */
        /// LastPageButton_Click
        /* ----------------------------------------------------------------- */
        private void LastPageButton_Click(object sender, EventArgs e) {
            var tab = this.PageViewerTabControl.SelectedTab;
            var canvas = CanvasPolicyA.Get(tab);
            if (canvas == null) return;

            var message = "";
            try {
                var prev = CanvasPolicyA.CurrentPage(canvas);
                if (prev >= CanvasPolicyA.PageCount(canvas)) return;
                if (CanvasPolicyA.LastPage(canvas) == prev) return;
                this.RefreshThumbnail(this.NavigationSplitContainer.Panel1, CanvasPolicyA.CurrentPage(canvas), prev);
                this.Refresh(canvas, message);
            }
            catch (Exception err) {
                Utility.ErrorLog(err);
                message = err.Message;
            }
        }

        /* ----------------------------------------------------------------- */
        /// CurrentPageTextBox_KeyDown
        /* ----------------------------------------------------------------- */
        private void CurrentPageTextBox_KeyDown(object sender, KeyEventArgs e) {
            var tab = this.PageViewerTabControl.SelectedTab;
            var canvas = CanvasPolicyA.Get(tab);
            if (canvas == null) return;

            if (e.KeyCode == Keys.Enter) {
                var message = "";
                try {
                    var control = (ToolStripTextBox)sender;
                    var page = int.Parse(control.Text);
                    var prev = CanvasPolicyA.CurrentPage(canvas);
                    if (page == prev) return;
                    if (CanvasPolicyA.MovePage(canvas, page) == prev) return;
                    this.RefreshThumbnail(this.NavigationSplitContainer.Panel1, CanvasPolicyA.CurrentPage(canvas), prev);
                    this.Refresh(canvas, message);
                }
                catch (Exception err) {
                    Utility.ErrorLog(err);
                    message = err.Message;
                }
            }
        }

        /* ----------------------------------------------------------------- */
        /// SearchTextBox_TextChanged
        /* ----------------------------------------------------------------- */
        private void SearchTextBox_TextChanged(object sender, EventArgs e) {
            begin_ = true;
            this.SearchTextBox.BackColor = Color.White;
        }

        /* ----------------------------------------------------------------- */
        /// SearchButton_Click
        /* ----------------------------------------------------------------- */
        private void SearchButton_Click(object sender, EventArgs e) {
            this.Search(this.PageViewerTabControl.SelectedTab, this.SearchTextBox.Text, true);
        }

        /* ----------------------------------------------------------------- */
        /// MenuModeButton_Click
        /* ----------------------------------------------------------------- */
        private void MenuModeButton_Click(object sender, EventArgs e) {
            if (!this.MenuSplitContainer.Panel1Collapsed && setting_.ShowMenuInfo) {
                var dialog = new MenuDialog();
                dialog.ShowDialog(this);
                setting_.ShowMenuInfo = !dialog.NoShowNext;
            }

            this.MenuSplitContainer.Panel1Collapsed = !this.MenuSplitContainer.Panel1Collapsed;
            this.Adjust(this.PageViewerTabControl.SelectedTab);
        }

        /* ----------------------------------------------------------------- */
        /// ThumbButton_Click
        /* ----------------------------------------------------------------- */
        private void ThumbButton_Click(object sender, EventArgs e) {
            this.NavigationSplitContainer.Panel1Collapsed = !this.NavigationSplitContainer.Panel1Collapsed;
            if (!this.NavigationSplitContainer.Panel1Collapsed) {
                setting_.Navigaion = NavigationCondition.Thumbnail;
                var control = this.NavigationSplitContainer.Panel1;
                if (Thumbnail.GetInstance(control) == null) {
                    var canvas = CanvasPolicyA.Get(this.PageViewerTabControl.SelectedTab);
                    if (canvas == null) return;
                    this.CreateThumbnail(canvas);
                }
            }
            else setting_.Navigaion = NavigationCondition.None;
            this.Adjust(this.PageViewerTabControl.SelectedTab);
        }

        /* ----------------------------------------------------------------- */
        /// NavigationSplitContainer_SplitterMoved
        /* ----------------------------------------------------------------- */
        private void NavigationSplitContainer_SplitterMoved(object sender, SplitterEventArgs e) {
            this.Adjust(this.PageViewerTabControl.SelectedTab);
            NavigationSplitContainer.Panel1.Refresh();
        }

        /* ----------------------------------------------------------------- */
        ///
        /// PageViewerTabControl_Deselected
        /// 
        /// <summary>
        /// 別のタブが選択されたときに発生するイベントハンドラ．
        /// この段階では SelectedIndex は選択前のタブのインデックスに
        /// なっている (e.g., 0 から 1 の遷移の場合，0)．
        /// </summary>
        /// 
        /* ----------------------------------------------------------------- */
        private void PageViewerTabControl_Deselected(object sender, TabControlEventArgs e) {
            var control = sender as TabControl;
            if (control == null) return;

            var tab = control.SelectedTab;
            if (tab == null) return;

            var canvas = CanvasPolicyA.Get(tab);
            if (canvas == null) return;
            this.SaveThumbnail(canvas);
        }

        /* ----------------------------------------------------------------- */
        /// PageViewerTabControl_SelectedIndexChanged
        /* ----------------------------------------------------------------- */
        private void PageViewerTabControl_SelectedIndexChanged(object sender, EventArgs e) {
            var control = sender as TabControl;
            if (control == null) return;

            var tabname = control.SelectedTab.Text;
            if (tabname == Cube.Properties.Settings.Default.DEFAULT_TAB_TEXT) ChangeTitlebarText("");
            else ChangeTitlebarText(tabname);

            var canvas = CanvasPolicyA.Get(control.SelectedTab);
            if (canvas == null) return;
            
            var tab = control.SelectedTab;
            tab.Focus();
            this.Adjust(tab);
            this.CreateThumbnail(canvas);
        }


      
        /* ----------------------------------------------------------------- */
        /// PageViewerTabControl_TabClosing
        /* ----------------------------------------------------------------- */
        private void PageViewerTabControl_TabClosing(object sender, TabControlCancelEventArgs e) {
            var control = (CustomTabControl)sender;
            var index = control.SelectedIndex;
            this.DestroyTab(e.TabPage);
            if (control.TabCount <= 1) e.Cancel = true;
            else if (e.TabPageIndex == index) control.SelectedIndex = Math.Max(index - 1, 0);
        }

        /* ----------------------------------------------------------------- */
        /// PageViewerTabControl_MouseDown
        /* ----------------------------------------------------------------- */
        private void PageViewerTabControl_MouseDown(object sender, MouseEventArgs e) {
            if (e.Button == System.Windows.Forms.MouseButtons.Right) {
                var control = sender as TabControl;
                if (control == null || control.ContextMenuStrip == null) return;
                var context = control.ContextMenuStrip;
                context.Tag = e.Location;
            }
        }

        /* ----------------------------------------------------------------- */
        /// TabPage_Scroll
        /* ----------------------------------------------------------------- */
        private void TabPage_Scroll(object sender, ScrollEventArgs e) {
            var control = (TabPage)sender;
            var scroll = control.VerticalScroll;
            if (e.NewValue == e.OldValue) {
                var maximum = 1 + scroll.Maximum - scroll.LargeChange;
                if (scroll.Value == scroll.Minimum && e.Type == ScrollEventType.SmallDecrement) {
                    if (this.PreviousPage(control)) scroll.Value = maximum;
                }
                else if (scroll.Value == maximum && e.Type == ScrollEventType.SmallIncrement) {
                    this.NextPage(control);
                }
            }
        }

        /* ----------------------------------------------------------------- */
        ///
        /// TabPage_MouseWheel
        /// 
        /// <summary>
        /// マウスホイールによるスクロールの処理．
        /// MEMO: VerticalScroll.Value の値は 2 回指定しないと反映され
        /// ない．原因を要調査．
        /// </summary>
        /// 
        /* ----------------------------------------------------------------- */
        private void TabPage_MouseWheel(object sender, MouseEventArgs e) {
            if (Math.Abs(e.Delta) < 120) return;

            var tab = this.PageViewerTabControl.SelectedTab;
            var scroll = tab.VerticalScroll;
            if (!scroll.Visible) {
                if (e.Delta < 0) this.NextPage(tab);
                else this.PreviousPage(tab);
            }
            else {
                var canvas = CanvasPolicyA.Get(tab);
                if (canvas == null) return;

                var maximum = 1 + scroll.Maximum - scroll.LargeChange; // ユーザの操作で取りうる最大値
                var delta = -(e.Delta / 120) * scroll.SmallChange;
                if (scroll.Value == scroll.Minimum && delta < 0) {
                    if (wheel_counter_ > 1) {
                        var horizon = tab.HorizontalScroll.Value;
                        if (CanvasPolicyA.CurrentPage(canvas) > 1 && this.PreviousPage(tab)) {
                            tab.HorizontalScroll.Value = horizon;
                            tab.HorizontalScroll.Value = horizon;
                            tab.VerticalScroll.Value = maximum;
                            tab.VerticalScroll.Value = maximum;
                        }
                        wheel_counter_ = 0;
                    }
                    else wheel_counter_++;
                }
                else if (scroll.Value == maximum && delta > 0) {
                    if (wheel_counter_ > 1) {
                        var horizon = tab.HorizontalScroll.Value;
                        if (CanvasPolicyA.CurrentPage(canvas) < CanvasPolicyA.PageCount(canvas) && this.NextPage(tab)) {
                            tab.HorizontalScroll.Value = horizon;
                            tab.HorizontalScroll.Value = horizon;
                            tab.VerticalScroll.Value = 0;
                            tab.VerticalScroll.Value = 0;
                        }
                        wheel_counter_ = 0;
                    }
                    else wheel_counter_++;
                }
                else {
                    var value = Math.Min(Math.Max(scroll.Value + delta, scroll.Minimum), maximum);
                    tab.VerticalScroll.Value = value;
                    tab.VerticalScroll.Value = value;
                    wheel_counter_ = 0;
                }
            }
        }

        /* ----------------------------------------------------------------- */
        /// TabPage_DragEnter
        /* ----------------------------------------------------------------- */
        private void TabPage_DragEnter(object sender, DragEventArgs e) {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.All;
            else e.Effect = DragDropEffects.None;
        }

        /* ----------------------------------------------------------------- */
        /// TabPage_DragDrop
        /* ----------------------------------------------------------------- */
        private void TabPage_DragDrop(object sender, DragEventArgs e) {
            var tab = (TabPage)sender;
            var control = (TabControl)tab.Parent;

            if (e.Data.GetDataPresent(DataFormats.FileDrop)) {
                var files = (string[])e.Data.GetData(DataFormats.FileDrop);
                foreach (var path in files) {
                    if (System.IO.Path.GetExtension(path).ToLower() != ".pdf") continue;
                    this.Open(control, path);
                }
            }
        }

        /* ----------------------------------------------------------------- */
        ///
        /// TabCloseMenuItem_Click
        /// 
        /// <summary>
        /// コンテキストメニューの「閉じる」が押された時のイベントハンドラ．
        /// </summary>
        /// 
        /* ----------------------------------------------------------------- */
        private void TabCloseMenuItem_Click(object sender, EventArgs e) {
            try {
                var control = this.PageViewerTabControl;
                var item = sender as ToolStripMenuItem;
                var context = item.Owner as ContextMenuStrip;
                if (control == null || context == null) return;
                
                var pos = (Point)context.Tag;
                var index = control.SelectedIndex;
                for (int i = 0; i < control.TabCount; i++) {
                    var rect = control.GetTabRect(i);
                    if (pos.X > rect.Left && pos.X < rect.Right && pos.Y > rect.Top && pos.Y < rect.Bottom) {
                        TabPage tab = control.TabPages[i];
                        this.DestroyTab(tab);
                        if (i == index) control.SelectedIndex = Math.Max(index - 1, 0);
                        break;
                    }
                }
            }
            catch (Exception err) {
                Utility.ErrorLog(err);
            }
        }

        /* ----------------------------------------------------------------- */
        /// Thumbnail_SelectedIndexChanged
        /* ----------------------------------------------------------------- */
        private void Thumbnail_SelectedIndexChanged(object sender, EventArgs e) {
            var thumb = sender as Thumbnail;
            if (thumb == null || thumb.SelectedItems.Count == 0) return;
            var page = thumb.SelectedItems[0].Index + 1;

            var tab = this.PageViewerTabControl.SelectedTab;
            var canvas = CanvasPolicyA.Get(tab);
            CanvasPolicyA.MovePage(canvas, page);
            this.Refresh(canvas);
        }


        #endregion

        /* ----------------------------------------------------------------- */
        //  メニューボタンの外観の調整
        /* ----------------------------------------------------------------- */
        #region Icon settings for MenuToolStrip

        /* ----------------------------------------------------------------- */
        /// OpenButton_MouseEnter
        /* ----------------------------------------------------------------- */
        private void OpenButton_MouseEnter(object sender, EventArgs e) {
            var control = (ToolStripButton)sender;
            control.Image = Properties.Resources.open_over;
        }

        /* ----------------------------------------------------------------- */
        /// OpenButton_MouseLeave
        /* ----------------------------------------------------------------- */
        private void OpenButton_MouseLeave(object sender, EventArgs e) {
            var control = (ToolStripButton)sender;
            control.Image = Properties.Resources.open;
        }

        /* ----------------------------------------------------------------- */
        /// OpenButton_MouseDown
        /* ----------------------------------------------------------------- */
        private void OpenButton_MouseDown(object sender, MouseEventArgs e) {
            var control = (ToolStripButton)sender;
            control.Image = Properties.Resources.open_press;
        }

        /* ----------------------------------------------------------------- */
        ///
        /// OpenButton_MouseUp
        /// 
        /// <summary>
        /// MEMO: 開くのようにボタンを押すことで何らかのダイアログが
        /// 出るタイプのものは，ボタンの状態が戻らない事がある．
        /// そのため，マウスオーバー状態のものではなく，デフォルトの
        /// ボタンに戻す．
        /// </summary>
        /// 
        /* ----------------------------------------------------------------- */
        private void OpenButton_MouseUp(object sender, MouseEventArgs e) {
            var control = (ToolStripButton)sender;
            control.Image = Properties.Resources.open;
        }

        /* ----------------------------------------------------------------- */
        /// PrintButton_MouseEnter
        /* ----------------------------------------------------------------- */
        private void PrintButton_MouseEnter(object sender, EventArgs e) {
            var control = (ToolStripButton)sender;
            control.Image = Properties.Resources.print_over;
        }

        /* ----------------------------------------------------------------- */
        /// PrintButton_MouseLeave
        /* ----------------------------------------------------------------- */
        private void PrintButton_MouseLeave(object sender, EventArgs e) {
            var control = (ToolStripButton)sender;
            control.Image = Properties.Resources.print;
        }

        /* ----------------------------------------------------------------- */
        /// PrintButton_MouseDown
        /* ----------------------------------------------------------------- */
        private void PrintButton_MouseDown(object sender, MouseEventArgs e) {
            var control = (ToolStripButton)sender;
            control.Image = Properties.Resources.print_press;
        }

        /* ----------------------------------------------------------------- */
        ///
        /// PrintButton_MouseUp
        /// 
        /// <summary>
        /// MEMO: 印刷ボタンを押して設定を行うと，遅れて MouseUp イベントが
        /// 発生しているようでボタンがマウスオーバーされた状態のままに
        /// なってしまうため，暫定処置．
        /// </summary>
        /// 
        /* ----------------------------------------------------------------- */
        private void PrintButton_MouseUp(object sender, MouseEventArgs e) {
            var control = (ToolStripButton)sender;
            control.Image = Properties.Resources.print;
        }

        /* ----------------------------------------------------------------- */
        /// FirstPageButton_MouseEnter
        /* ----------------------------------------------------------------- */
        private void FirstPageButton_MouseEnter(object sender, EventArgs e) {
            var control = (ToolStripButton)sender;
            control.Image = Properties.Resources.arrow_first_over;
        }

        /* ----------------------------------------------------------------- */
        /// FirstPageButton_MouseLeave
        /* ----------------------------------------------------------------- */
        private void FirstPageButton_MouseLeave(object sender, EventArgs e) {
            var control = (ToolStripButton)sender;
            control.Image = Properties.Resources.arrow_first;
        }

        /* ----------------------------------------------------------------- */
        /// FirstPageButton_MouseDown
        /* ----------------------------------------------------------------- */
        private void FirstPageButton_MouseDown(object sender, MouseEventArgs e) {
            var control = (ToolStripButton)sender;
            control.Image = Properties.Resources.arrow_first_press;
        }

        /* ----------------------------------------------------------------- */
        /// FirstPageButton_MouseUp
        /* ----------------------------------------------------------------- */
        private void FirstPageButton_MouseUp(object sender, MouseEventArgs e) {
            var control = (ToolStripButton)sender;
            control.Image = Properties.Resources.arrow_first_over;
        }

        /* ----------------------------------------------------------------- */
        /// PreviousPageButton_MouseEnter
        /* ----------------------------------------------------------------- */
        private void PreviousPageButton_MouseEnter(object sender, EventArgs e) {
            var control = (ToolStripButton)sender;
            control.Image = Properties.Resources.arrow_prev_over;
        }

        /* ----------------------------------------------------------------- */
        /// PreviousPageButton_MouseLeave
        /* ----------------------------------------------------------------- */
        private void PreviousPageButton_MouseLeave(object sender, EventArgs e) {
            var control = (ToolStripButton)sender;
            control.Image = Properties.Resources.arrow_prev;
        }

        /* ----------------------------------------------------------------- */
        /// PreviousPageButton_MouseDown
        /* ----------------------------------------------------------------- */
        private void PreviousPageButton_MouseDown(object sender, MouseEventArgs e) {
            var control = (ToolStripButton)sender;
            control.Image = Properties.Resources.arrow_prev_press;
        }

        /* ----------------------------------------------------------------- */
        /// PreviousPageButton_MouseUp
        /* ----------------------------------------------------------------- */
        private void PreviousPageButton_MouseUp(object sender, MouseEventArgs e) {
            var control = (ToolStripButton)sender;
            control.Image = Properties.Resources.arrow_prev_over;
        }

        /* ----------------------------------------------------------------- */
        /// NextPageButton_MouseEnter
        /* ----------------------------------------------------------------- */
        private void NextPageButton_MouseEnter(object sender, EventArgs e) {
            var control = (ToolStripButton)sender;
            control.Image = Properties.Resources.arrow_next_over;
        }

        /* ----------------------------------------------------------------- */
        /// NextPageButton_MouseLeave
        /* ----------------------------------------------------------------- */
        private void NextPageButton_MouseLeave(object sender, EventArgs e) {
            var control = (ToolStripButton)sender;
            control.Image = Properties.Resources.arrow_next;
        }

        /* ----------------------------------------------------------------- */
        /// NextPageButton_MouseDown
        /* ----------------------------------------------------------------- */
        private void NextPageButton_MouseDown(object sender, MouseEventArgs e) {
            var control = (ToolStripButton)sender;
            control.Image = Properties.Resources.arrow_next_press;
        }

        /* ----------------------------------------------------------------- */
        /// NextPageButton_MouseUp
        /* ----------------------------------------------------------------- */
        private void NextPageButton_MouseUp(object sender, MouseEventArgs e) {
            var control = (ToolStripButton)sender;
            control.Image = Properties.Resources.arrow_next_over;
        }

        /* ----------------------------------------------------------------- */
        /// LastPageButton_MouseEnter
        /* ----------------------------------------------------------------- */
        private void LastPageButton_MouseEnter(object sender, EventArgs e) {
            var control = (ToolStripButton)sender;
            control.Image = Properties.Resources.arrow_last_over;
        }

        /* ----------------------------------------------------------------- */
        /// LastPageButton_MouseLeave
        /* ----------------------------------------------------------------- */
        private void LastPageButton_MouseLeave(object sender, EventArgs e) {
            var control = (ToolStripButton)sender;
            control.Image = Properties.Resources.arrow_last;
        }

        /* ----------------------------------------------------------------- */
        /// LastPageButton_MouseDown
        /* ----------------------------------------------------------------- */
        private void LastPageButton_MouseDown(object sender, MouseEventArgs e) {
            var control = (ToolStripButton)sender;
            control.Image = Properties.Resources.arrow_last_press;
        }

        /* ----------------------------------------------------------------- */
        /// LastPageButton_MouseUp
        /* ----------------------------------------------------------------- */
        private void LastPageButton_MouseUp(object sender, MouseEventArgs e) {
            var control = (ToolStripButton)sender;
            control.Image = Properties.Resources.arrow_last_over;
        }

        /* ----------------------------------------------------------------- */
        /// SearchButton_MouseEnter
        /* ----------------------------------------------------------------- */
        private void SearchButton_MouseEnter(object sender, EventArgs e) {
            var control = (ToolStripButton)sender;
            control.Image = Properties.Resources.search_over;
        }

        /* ----------------------------------------------------------------- */
        /// SearchButton_MouseLeave
        /* ----------------------------------------------------------------- */
        private void SearchButton_MouseLeave(object sender, EventArgs e) {
            var control = (ToolStripButton)sender;
            control.Image = Properties.Resources.search;
        }

        /* ----------------------------------------------------------------- */
        /// SearchButton_MouseDown
        /* ----------------------------------------------------------------- */
        private void SearchButton_MouseDown(object sender, MouseEventArgs e) {
            var control = (ToolStripButton)sender;
            control.Image = Properties.Resources.search_press;
        }

        /* ----------------------------------------------------------------- */
        /// SearchButton_MouseUp
        /* ----------------------------------------------------------------- */
        private void SearchButton_MouseUp(object sender, MouseEventArgs e) {
            var control = (ToolStripButton)sender;
            control.Image = Properties.Resources.search_over;
        }

        /* ----------------------------------------------------------------- */
        /// ZoomInButton_MouseEnter
        /* ----------------------------------------------------------------- */
        private void ZoomInButton_MouseEnter(object sender, EventArgs e) {
            var control = (ToolStripButton)sender;
            control.Image = Properties.Resources.zoomin_over;
        }

        /* ----------------------------------------------------------------- */
        /// ZoomInButton_MouseLeave
        /* ----------------------------------------------------------------- */
        private void ZoomInButton_MouseLeave(object sender, EventArgs e) {
            var control = (ToolStripButton)sender;
            control.Image = Properties.Resources.zoomin;
        }

        /* ----------------------------------------------------------------- */
        /// ZoomInButton_MouseDown
        /* ----------------------------------------------------------------- */
        private void ZoomInButton_MouseDown(object sender, MouseEventArgs e) {
            var control = (ToolStripButton)sender;
            control.Image = Properties.Resources.zoomin_press;
        }

        /* ----------------------------------------------------------------- */
        /// ZoomInButton_MouseUp
        /* ----------------------------------------------------------------- */
        private void ZoomInButton_MouseUp(object sender, MouseEventArgs e) {
            var control = (ToolStripButton)sender;
            control.Image = Properties.Resources.zoomin_over;
        }

        /* ----------------------------------------------------------------- */
        /// ZoomOutButton_MouseEnter
        /* ----------------------------------------------------------------- */
        private void ZoomOutButton_MouseEnter(object sender, EventArgs e) {
            var control = (ToolStripButton)sender;
            control.Image = Properties.Resources.zoomout_over;
        }

        /* ----------------------------------------------------------------- */
        /// ZoomOutButton_MouseLeave
        /* ----------------------------------------------------------------- */
        private void ZoomOutButton_MouseLeave(object sender, EventArgs e) {
            var control = (ToolStripButton)sender;
            control.Image = Properties.Resources.zoomout;
        }

        /* ----------------------------------------------------------------- */
        /// ZoomOutButton_MouseDown
        /* ----------------------------------------------------------------- */
        private void ZoomOutButton_MouseDown(object sender, MouseEventArgs e) {
            var control = (ToolStripButton)sender;
            control.Image = Properties.Resources.zoomout_press;
        }

        /* ----------------------------------------------------------------- */
        /// ZoomOutButton_MouseUp
        /* ----------------------------------------------------------------- */
        private void ZoomOutButton_MouseUp(object sender, MouseEventArgs e) {
            var control = (ToolStripButton)sender;
            control.Image = Properties.Resources.zoomout_over;
        }

        /* ----------------------------------------------------------------- */
        /// FitToWidthButton_MouseEnter
        /* ----------------------------------------------------------------- */
        private void FitToWidthButton_MouseEnter(object sender, EventArgs e) {
            var control = (ToolStripButton)sender;
            control.Image = Properties.Resources.fit2width_over;
        }

        /* ----------------------------------------------------------------- */
        /// FitToWidthButton_MouseLeave
        /* ----------------------------------------------------------------- */
        private void FitToWidthButton_MouseLeave(object sender, EventArgs e) {
            var control = (ToolStripButton)sender;
            control.Image = control.Checked ? Properties.Resources.fit2width_over : Properties.Resources.fit2width;
        }

        /* ----------------------------------------------------------------- */
        /// FitToWidthButton_MouseDown
        /* ----------------------------------------------------------------- */
        private void FitToWidthButton_MouseDown(object sender, MouseEventArgs e) {
            var control = (ToolStripButton)sender;
            control.Image = Properties.Resources.fit2width_press;
        }

        /* ----------------------------------------------------------------- */
        /// FitToWidthButton_MouseUp
        /* ----------------------------------------------------------------- */
        private void FitToWidthButton_MouseUp(object sender, MouseEventArgs e) {
            var control = (ToolStripButton)sender;
            control.Image = Properties.Resources.fit2width_over;
        }

        /* ----------------------------------------------------------------- */
        /// FitToWidthButton_CheckedChanged
        /* ----------------------------------------------------------------- */
        private void FitToWidthButton_CheckedChanged(object sender, EventArgs e) {
            var control = (ToolStripButton)sender;
            control.Image = control.Checked ? Properties.Resources.fit2width_over : Properties.Resources.fit2width;
        }

        /* ----------------------------------------------------------------- */
        /// FitToPageButton_MouseEnter
        /* ----------------------------------------------------------------- */
        private void FitToPageButton_MouseEnter(object sender, EventArgs e) {
            var control = (ToolStripButton)sender;
            control.Image = Properties.Resources.fit2height_over;
        }

        /* ----------------------------------------------------------------- */
        /// FitToPageButton_MouseLeave
        /* ----------------------------------------------------------------- */
        private void FitToPageButton_MouseLeave(object sender, EventArgs e) {
            var control = (ToolStripButton)sender;
            control.Image = control.Checked ? Properties.Resources.fit2height_over : Properties.Resources.fit2height;
        }

        /* ----------------------------------------------------------------- */
        /// FitToPageButton_MouseDown
        /* ----------------------------------------------------------------- */
        private void FitToPageButton_MouseDown(object sender, MouseEventArgs e) {
            var control = (ToolStripButton)sender;
            control.Image = Properties.Resources.fit2height_press;
        }

        /* ----------------------------------------------------------------- */
        /// FitToPageButton_MouseUp
        /* ----------------------------------------------------------------- */
        private void FitToPageButton_MouseUp(object sender, MouseEventArgs e) {
            var control = (ToolStripButton)sender;
            control.Image = Properties.Resources.fit2height_over;
        }

        /* ----------------------------------------------------------------- */
        /// FitToPageButton_CheckedChanged
        /* ----------------------------------------------------------------- */
        private void FitToPageButton_CheckedChanged(object sender, EventArgs e) {
            var control = (ToolStripButton)sender;
            control.Image = control.Checked ? Properties.Resources.fit2height_over : Properties.Resources.fit2height;
        }

        /* ----------------------------------------------------------------- */
        /// MenuModeButton_MouseEnter
        /* ----------------------------------------------------------------- */
        private void MenuModeButton_MouseEnter(object sender, EventArgs e) {
            var control = (ToolStripButton)sender;
            control.BackgroundImage = Properties.Resources.hidemenu_over;
        }

        /* ----------------------------------------------------------------- */
        /// MenuModeButton_MouseLeave
        /* ----------------------------------------------------------------- */
        private void MenuModeButton_MouseLeave(object sender, EventArgs e) {
            var control = (ToolStripButton)sender;
            control.BackgroundImage = Properties.Resources.hidemenu;
        }

        /* ----------------------------------------------------------------- */
        /// ThumbButton_MouseEnter
        /* ----------------------------------------------------------------- */
        private void ThumbButton_MouseEnter(object sender, EventArgs e) {
            var control = (ToolStripButton)sender;
            control.BackgroundImage = Properties.Resources.thumbnail_over;
        }

        /* ----------------------------------------------------------------- */
        /// ThumbButton_MouseLeave
        /* ----------------------------------------------------------------- */
        private void ThumbButton_MouseLeave(object sender, EventArgs e) {
            var control = (ToolStripButton)sender;
            control.BackgroundImage = Properties.Resources.thumbnail;
        }

        /* ----------------------------------------------------------------- */
        /// ThumbButton_MouseDown
        /* ----------------------------------------------------------------- */
        private void ThumbButton_MouseDown(object sender, MouseEventArgs e) {
            var control = (ToolStripButton)sender;
            control.BackgroundImage = Properties.Resources.thumbnail_press;
        }

        /* ----------------------------------------------------------------- */
        /// ThumbButton_MouseUp
        /* ----------------------------------------------------------------- */
        private void ThumbButton_MouseUp(object sender, MouseEventArgs e) {
            var control = (ToolStripButton)sender;
            control.BackgroundImage = Properties.Resources.thumbnail_over;
        }

        #endregion

        /* ----------------------------------------------------------------- */
        // Adobe Reader との連携関係
        /* ----------------------------------------------------------------- */
        #region Adobe extensions

        private Image adobe_icon_ = null;
        private Image adobe_icon_selected_ = null;

        /* ----------------------------------------------------------------- */
        /// InitializeAdobe
        /* ----------------------------------------------------------------- */
        private void InitializeAdobe() {
            adobe_ = "";

            var registry = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"Software\Adobe\Acrobat Reader");
            if (registry == null) registry = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"Software\Wow6432Node\Adobe\Acrobat Reader");
            if (registry == null) registry = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"Software\Adobe\Adobe Acrobat");
            if (registry == null) registry = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"Software\Wow6432Node\Adobe\Adobe Acrobat");
            if (registry == null) return;

            string version = "";
            foreach (var elem in registry.GetSubKeyNames()) {
                try {
                    var x = double.Parse(elem);
                    if (version.Length == 0 || x > double.Parse(version)) version = elem;
                }
                catch (Exception err) {
                    Utility.ErrorLog(err);
                }
            }
            if (version.Length == 0) return;

            var subkey = registry.OpenSubKey(version + @"\InstallPath");
            if (subkey == null) return;

            var path = (string)subkey.GetValue("");
            if (path == null) return;

            adobe_ = path + @"\AcroRd32.exe";

            var original = Utility.GetIcon(adobe_).ToBitmap();

            adobe_icon_ = new Bitmap(32, 32);
            var normal = Graphics.FromImage(adobe_icon_);
            normal.DrawImage(original, 4, 4, adobe_icon_.Width - 8, adobe_icon_.Height - 8);
            normal.Dispose();

            adobe_icon_selected_ = new Bitmap(32, 32);
            var selected = Graphics.FromImage(adobe_icon_selected_);
            selected.FillRectangle(SystemBrushes.GradientActiveCaption, new Rectangle(0, 0, adobe_icon_selected_.Width - 2, adobe_icon_selected_.Height - 2));
            selected.DrawImage(original, 4, 4, adobe_icon_.Width - 8, adobe_icon_.Height - 8);
            selected.DrawRectangle(SystemPens.Highlight, new Rectangle(0, 0, adobe_icon_selected_.Width - 2, adobe_icon_selected_.Height - 2));
            selected.Dispose();

            original.Dispose();

            this.AdobeButton.MouseEnter += new EventHandler(AdobeButton_MouseEnter);
            this.AdobeButton.MouseLeave += new EventHandler(AdobeButton_MouseLeave);
            this.AdobeButton.Image = adobe_icon_;
        }

        /* ----------------------------------------------------------------- */
        ///
        /// OpenWithAdobe
        ///
        /// <summary>
        /// 現在，表示されている PDF ファイルを Adobe Reader で開く．
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void OpenWithAdobe(TabPage tab, string path) {
            if (path == null || adobe_ == null || adobe_.Length == 0) return;

            try {
                var info = new System.Diagnostics.ProcessStartInfo();
                info.FileName = adobe_;
                info.Arguments = path;
                info.CreateNoWindow = false;
                info.UseShellExecute = false;
                var proc = new System.Diagnostics.Process();
                proc.StartInfo = info;
                proc.Start();
            }
            catch (Exception err) {
                Utility.ErrorLog(err);
            }
        }

        /* ----------------------------------------------------------------- */
        /// AdobeButton_Click
        /* ----------------------------------------------------------------- */
        private void AdobeButton_Click(object sender, EventArgs e) {
            var tab = this.PageViewerTabControl.SelectedTab;
            var path = (string)tab.Tag;
            this.OpenWithAdobe(tab, path);
        }

        /* ----------------------------------------------------------------- */
        /// AdobeButton_MouseEnter
        /* ----------------------------------------------------------------- */
        private void AdobeButton_MouseEnter(object sender, EventArgs e) {
            var control = (ToolStripButton)sender;
            if (adobe_icon_selected_ != null) control.Image = adobe_icon_selected_;
        }

        /* ----------------------------------------------------------------- */
        /// AdobeButton_MouseLeave
        /* ----------------------------------------------------------------- */
        private void AdobeButton_MouseLeave(object sender, EventArgs e) {
            var control = (ToolStripButton)sender;
            if (adobe_icon_ != null) control.Image = adobe_icon_;
        }

        #endregion

        /* ----------------------------------------------------------------- */
        //  メンバ変数の定義
        /* ----------------------------------------------------------------- */
        #region Member variables
        private UserSetting setting_ = new UserSetting();
        private bool begin_ = true;
        private int wheel_counter_ = 0;
        private int resize_ = 0;
        private string adobe_;
        #endregion
    }
}
