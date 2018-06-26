using System;
using System.Collections.Generic;
using System.Text;
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
    public abstract class CanvasPolicyA
    {
        public static Canvas Get(Control parent)
        {
            return (Canvas)parent.Controls["Canvas"];
        }

        public static void SetHandCursor(Cursor cursor)
        {
            hand_ = cursor;
        }

        public static Cursor GetHandCursor()
        {
            return hand_;
        }

        public static void Open(Canvas canvas, string path, string password, FitCondition which)
        {
            if (canvas == null) return;
            var engine = canvas.Tag as CanvasEngine;
            if (engine != null) CanvasPolicyA.Close(canvas);

            var core = new PDF();
            engine = new CanvasEngine(core);
            canvas.Tag = engine;
            core.UseMuPDF = true;
            core.UserPassword = password;
            core.OwnerPassword = password;

            if (core.LoadPDF(path))
            {
                core.CurrentPage = 1;
                if (which == FitCondition.Height)
                {
                    core.FitToHeight(canvas.Parent.Handle);
                    core.Zoom = core.Zoom - 1; // 暫定
                }
                else if (which == FitCondition.Width)
                {
                    core.FitToWidth(canvas.Parent.Handle);
                    core.Zoom = core.Zoom - 1; // 暫定
                }
                else core.Zoom = 100;
                canvas.Parent.Text = System.IO.Path.GetFileNameWithoutExtension(path);
                canvas.Parent.Tag = path;
                CanvasPolicyA.AsyncRender(canvas, true);
            }
        }

        public static int CurrentPage(Canvas canvas)
        {
            if (canvas == null) return 0;
            var engine = canvas.Tag as CanvasEngine;
            if (engine == null) return 0;
            var core = engine.Core;
            if (core == null) return 0;

            return core.CurrentPage;
        }

        public static int PageCount(Canvas canvas)
        {
            if (canvas == null) return 0;
            var engine = canvas.Tag as CanvasEngine;
            if (engine == null) return 0;
            var core = engine.Core;
            if (core == null) return 0;

            return core.PageCount;
        }

        public static double Zoom(Canvas canvas)
        {
            if (canvas == null) return 0.0;
            var engine = canvas.Tag as CanvasEngine;
            if (engine == null) return 0.0;
            var core = engine.Core;
            if (core == null) return 0.0;

            return core.Zoom;
        }

        public static double Zoom(Canvas canvas, double percent)
        {
            if (canvas == null) return 0.0;
            var engine = canvas.Tag as CanvasEngine;
            if (engine == null) return 0.0;
            var core = engine.Core;
            if (core == null) return 0.0;

            var prev = canvas.Size;
            if (percent < core.Zoom || core.Zoom < 400)
            {
                core.Zoom = Math.Min(percent, 400);
#if CUBE_ASYNC
                CanvasPolicy.AsyncRender(canvas, true);
#else
                CanvasPolicyA.Render(canvas, true);
#endif
            }
            return core.Zoom;
        }

        public static double ZoomIn(Canvas canvas)
        {
            if (canvas == null) return 0.0;
            var engine = canvas.Tag as CanvasEngine;
            if (engine == null) return 0.0;
            var core = engine.Core;
            if (core == null) return 0.0;

            var prev = canvas.Size;
            if (core.Zoom < 400)
            {
                core.ZoomIN();
                if (core.Zoom > 400) core.Zoom = 400;
#if CUBE_ASYNC
                CanvasPolicy.AsyncRender(canvas, true);
#else
                CanvasPolicyA.Render(canvas, true);
#endif
            }
            return core.Zoom;
        }

        public static double ZoomOut(Canvas canvas)
        {
            if (canvas == null) return 0.0;
            var engine = canvas.Tag as CanvasEngine;
            if (engine == null) return 0.0;
            var core = engine.Core;
            if (core == null) return 0.0;

            var prev = canvas.Size;
            core.ZoomOut();
#if CUBE_ASYNC
            CanvasPolicy.AsyncRender(canvas, true);
#else
            CanvasPolicyA.Render(canvas, true);
#endif
            return core.Zoom;
        }

        public static int NextPage(Canvas canvas)
        {
            if (canvas == null) return 0;
            var engine = canvas.Tag as CanvasEngine;
            if (engine == null) return 0;
            var core = engine.Core;
            if (core == null) return 0;

            core.NextPage();

#if CUBE_ASYNC
            CanvasPolicy.AsyncRender(canvas, false);
            var control = (ScrollableControl)canvas.Parent;
            control.AutoScrollPosition = new Point(0, 0);
#else
            if (CanvasPolicyA.Render(canvas, false))
            {
                engine.UpdateURL();
                var control = (ScrollableControl)canvas.Parent;
                control.AutoScrollPosition = new Point(0, 0);
            }
#endif
            return core.CurrentPage;
        }

        public static int PreviousPage(Canvas canvas)
        {
            if (canvas == null) return 0;
            var engine = canvas.Tag as CanvasEngine;
            if (engine == null) return 0;
            var core = engine.Core;
            if (core == null) return 0;

            core.PreviousPage();

#if CUBE_ASYNC
            CanvasPolicy.AsyncRender(canvas, false);
            var control = (ScrollableControl)canvas.Parent;
            control.AutoScrollPosition = new Point(0, 0);
#else
            if (CanvasPolicyA.Render(canvas, false))
            {
                engine.UpdateURL();
                var control = (ScrollableControl)canvas.Parent;
                control.AutoScrollPosition = new Point(0, 0);
            }
#endif
            return core.CurrentPage;
        }

        public static int FirstPage(Canvas canvas)
        {
            if (canvas == null) return 0;
            var engine = canvas.Tag as CanvasEngine;
            if (engine == null) return 0;
            var core = engine.Core;
            if (core == null) return 0;

            core.CurrentPage = 1;
#if CUBE_ASYNC
            CanvasPolicy.AsyncRender(canvas, false);
            var control = (ScrollableControl)canvas.Parent;
            control.AutoScrollPosition = new Point(0, 0);
#else
            if (CanvasPolicyA.Render(canvas, false))
            {
                engine.UpdateURL();
                var control = (ScrollableControl)canvas.Parent;
                control.AutoScrollPosition = new Point(0, 0);
            }
#endif
            return core.CurrentPage;
        }

        public static int LastPage(Canvas canvas)
        {
            if (canvas == null) return 0;
            var engine = canvas.Tag as CanvasEngine;
            if (engine == null) return 0;
            var core = engine.Core;
            if (core == null) return 0;

            core.CurrentPage = core.PageCount;
#if CUBE_ASYNC
            CanvasPolicy.AsyncRender(canvas, false);
            var control = (ScrollableControl)canvas.Parent;
            control.AutoScrollPosition = new Point(0, 0);
#else
            if (CanvasPolicyA.Render(canvas, false))
            {
                engine.UpdateURL();
                var control = (ScrollableControl)canvas.Parent;
                control.AutoScrollPosition = new Point(0, 0);
            }
#endif
            return core.CurrentPage;
        }

        public static int MovePage(Canvas canvas, int page)
        {
            if (canvas == null) return 0;
            var engine = canvas.Tag as CanvasEngine;
            if (engine == null) return 0;
            var core = engine.Core;
            if (core == null) return 0;

            int n = Math.Min(Math.Max(page, 1), core.PageCount);
            core.CurrentPage = n;
#if CUBE_ASYNC
            CanvasPolicy.AsyncRender(canvas, false);
            var control = (ScrollableControl)canvas.Parent;
            control.AutoScrollPosition = new Point(0, 0);
#else
            if (CanvasPolicyA.Render(canvas, false))
            {
                engine.UpdateURL();
                var control = (ScrollableControl)canvas.Parent;
                control.AutoScrollPosition = new Point(0, 0);
            }
#endif
            return core.CurrentPage;
        }

        private static PDFLibNet.PDFSearchResult PreviousSearchResult_ = null;
        public static bool Search(Canvas canvas, SearchArgs args)
        {

            if (canvas == null) return false;
            var engine = canvas.Tag as CanvasEngine;
            if (engine == null) return false;
            var core = engine.Core;
            if (core == null) return false;

            core.SearchCaseSensitive = !args.IgnoreCase;
            var order = args.WholeDocument ? PDFLibNet.PDFSearchOrder.PDFSearchFromdBegin : PDFLibNet.PDFSearchOrder.PDFSearchFromCurrent;

            int result = 0;
            if (args.FromBegin)
            {
                PreviousSearchResult_ = null;
                result = core.FindFirst(args.Text, order, false, args.WholeWord);
            }
            else if (args.FindNext) result = core.FindNext(args.Text);
            else result = core.FindPrevious(args.Text);
            //else result = core.FindText(args.Text, core.CurrentPage, order, !args.IgnoreCase, !args.FindNext, true, args.WholeWord);


            var prev = core.CurrentPage;
            if (result > 0 && (PreviousSearchResult_ == null || !Equals(PreviousSearchResult_, core.SearchResults[0])))
            {
                core.CurrentPage = core.SearchResults[0].Page;
                PreviousSearchResult_ = core.SearchResults[0];
            }
            CanvasPolicyA.Render(canvas, false);
            if (core.CurrentPage != prev) engine.UpdateURL();

            return result > 0;
        }

        private static void Close(Canvas canvas)
        {
            if (canvas == null || canvas.Tag == null) return;
            var engine = canvas.Tag as CanvasEngine;
            if (engine == null) return;
            var core = engine.Core;
            if (core == null) return;

            engine.Dispose();
            core.Dispose();
            canvas.Tag = null;

            var parent = (ScrollableControl)canvas.Parent;
            parent.Tag = null;
            parent.Text = "无标题";
        }

        public static void Destroy(Canvas canvas)
        {
            if (canvas == null) return;

            var parent = (ScrollableControl)canvas.Parent;
            foreach (var child in parent.Controls.Find("Canvas", false))
            {
                CanvasPolicyA.Close((Canvas)child);
                parent.Controls.Remove(child);
                child.Dispose();
            }
        }

        private static void AsyncRender(Canvas canvas, bool adjust)
        {
            if (canvas == null || canvas.Tag == null) return;
            var worker = new BackgroundWorker();
            worker.DoWork += new DoWorkEventHandler(DoWorkHandler);
            if (adjust) worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(Adjust_WorkCompletedHandler);
            else worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(NoAdjust_WorkCompletedHandler);
            canvas.Cursor = Cursors.WaitCursor;
            worker.RunWorkerAsync(canvas);
        }

        private static void DoWorkHandler(object sender, DoWorkEventArgs e)
        {
            var worker = sender as System.ComponentModel.BackgroundWorker;
            var canvas = e.Argument as Canvas;
            if (canvas == null) return;
            var engine = canvas.Tag as CanvasEngine;
            if (engine == null) return;
            var core = engine.Core;
            if (core == null) return;

            lock (core)
            {
                core.RenderPage(IntPtr.Zero, false, false);
                engine.UpdateURL();
            }

            e.Result = canvas;
        }

        private static void Adjust_WorkCompletedHandler(object sender, RunWorkerCompletedEventArgs e)
        {
            var canvas = e.Result as Canvas;
            if (canvas == null) return;
            canvas.Cursor = Cursors.Default;
            CanvasPolicyA.Adjust(canvas);
            canvas.Invalidate();
        }

        private static void NoAdjust_WorkCompletedHandler(object sender, RunWorkerCompletedEventArgs e)
        {
            var canvas = e.Result as Canvas;
            if (canvas == null) return;
            canvas.Cursor = Cursors.Default;
            canvas.Invalidate();
        }

        public static double FitToWidth(Canvas canvas)
        {
            if (canvas == null) return 0.0;
            var engine = canvas.Tag as CanvasEngine;
            if (engine == null) return 0.0;
            var core = engine.Core;
            if (core == null) return 0.0;

            core.FitToWidth(canvas.Parent.Handle);
            core.Zoom = core.Zoom - 1; // 暫定
#if CUBE_ASYNC
            CanvasPolicy.AsyncRender(canvas, true);
#else
            CanvasPolicyA.Render(canvas, true);
#endif
            return core.Zoom;
        }

        /// http://msdn.microsoft.com/ja-jp/library/c5kehkcz%28VS.80%29.aspx
        private static bool Render(Canvas canvas, bool adjust)
        {
            if (canvas == null) return false;
            var engine = canvas.Tag as CanvasEngine;
            if (engine == null) return false;
            var core = engine.Core;
            if (core == null) return false;

            lock (core)
            {
                var status = core.RenderPage(IntPtr.Zero, false, false);
                if (status && adjust) CanvasPolicyA.Adjust(canvas);
                canvas.Invalidate();
                return status;
            }
        }

        public static void Adjust(Canvas canvas)
        {
            if (canvas == null) return;
            var engine = canvas.Tag as CanvasEngine;
            if (engine == null) return;
            var core = engine.Core;
            if (core == null) return;

            var previous = canvas.Size;
            var parent = (ScrollableControl)canvas.Parent;
            canvas.Size = new Size(core.PageWidth, core.PageHeight);
            canvas.ClientSize = canvas.Size;

            var h = parent.HorizontalScroll.Value;
            var v = parent.VerticalScroll.Value;
            var pos = new Point(0, 0);
            var scroll = new Point(0, 0);

            // 位置情報のリセット
            canvas.Location = new Point(0, 0);
            parent.AutoScrollPosition = new Point(0, 0);

            if (parent.ClientSize.Width >= canvas.Width) pos.X = (parent.ClientSize.Width - canvas.Width) / 2;
            else scroll.X = (int)(h * canvas.Width / (double)previous.Width);
            if (parent.ClientSize.Height >= canvas.Height) pos.Y = (parent.ClientSize.Height - canvas.Height) / 2;
            else scroll.Y = (int)(v * canvas.Height / (double)previous.Height);

            canvas.Location = pos;
            parent.AutoScrollPosition = scroll;
        }

        public static double FitToPage(Canvas canvas)
        {
            if (canvas == null) return 0.0;
            var engine = canvas.Tag as CanvasEngine;
            if (engine == null) return 0.0;
            var core = engine.Core;
            if (core == null) return 0.0;

            // 横長ならばFitToWidthを、縦長ならばFitToHeightを呼ぶ
            if (GetOrientation(canvas) == Orientation.portratit)
            {
                core.FitToHeight(canvas.Parent.Handle);
            }
            else
            {
                core.FitToWidth(canvas.Parent.Handle);
            }
            core.Zoom = core.Zoom - 1; // 暫定

#if CUBE_ASYNC
            CanvasPolicy.AsyncRender(canvas, true);
#else
            CanvasPolicyA.Render(canvas, true);
#endif
            return core.Zoom;
        }

        enum Orientation
        {
            landscape,
            portratit,
        };

        private static Orientation GetOrientation(Canvas canvas)
        {
            var core = ((CanvasEngine)canvas.Tag).Core;
            int rotation = core.Pages[1].Rotation;

            double width = 0.0;
            double height = 0.0;
            if ((rotation >= 45 && rotation < 135) || (rotation >= 225 && rotation < 315))
            {
                width = core.Pages[1].Height;
                height = core.Pages[1].Width;
            }
            else
            {
                width = core.Pages[1].Width;
                height = core.Pages[1].Height;
            }
            return (width >= height) ? Orientation.landscape : Orientation.portratit;
        }

        public static Canvas Create(ScrollableControl parent)
        {
            var canvas = (Canvas)parent.Controls["Canvas"];
            if (canvas == null)
            {
                canvas = new Canvas();

                canvas.Name = "Canvas";
                canvas.BackColor = Color.Transparent;
                canvas.Size = parent.ClientSize;
                canvas.ClientSize = canvas.Size;

                canvas.Paint -= new PaintEventHandler(CanvasPolicyA.PaintHandler);
                canvas.Paint += new PaintEventHandler(CanvasPolicyA.PaintHandler);
                canvas.MouseEnter -= new EventHandler(CanvasPolicyA.MouseEnterHandler);
                canvas.MouseEnter += new EventHandler(CanvasPolicyA.MouseEnterHandler);
                canvas.MouseDown -= new MouseEventHandler(CanvasPolicyA.MouseDownHandler);
                canvas.MouseDown += new MouseEventHandler(CanvasPolicyA.MouseDownHandler);
                canvas.MouseUp -= new MouseEventHandler(CanvasPolicyA.MouseUpHandler);
                canvas.MouseUp += new MouseEventHandler(CanvasPolicyA.MouseUpHandler);
                canvas.MouseMove -= new MouseEventHandler(CanvasPolicyA.MouseMoveHandler);
                canvas.MouseMove += new MouseEventHandler(CanvasPolicyA.MouseMoveHandler);
                canvas.MouseClick -= new MouseEventHandler(CanvasPolicyA.MouseClickHandler);
                canvas.MouseClick += new MouseEventHandler(CanvasPolicyA.MouseClickHandler);

                parent.Controls.Add(canvas);
                canvas.Parent.MouseEnter -= new EventHandler(CanvasPolicyA.MouseEnterHandler);
                canvas.Parent.MouseEnter += new EventHandler(CanvasPolicyA.MouseEnterHandler);
            }
            return canvas;
        }

        private static void PaintHandler(object sender, PaintEventArgs e)
        {
            var canvas = sender as Canvas;
            if (canvas == null) return;
            var engine = canvas.Tag as CanvasEngine;
            if (engine == null) return;
            var core = engine.Core;
            if (core == null) return;

            core.ClientBounds = new Rectangle(new Point(0, 0), canvas.Size);
            Graphics g = e.Graphics;
            core.DrawPageHDC(g.GetHdc());
            g.ReleaseHdc();
        }

        private static void MouseEnterHandler(object sender, EventArgs e)
        {
            var canvas = sender as Canvas;
            if (canvas != null) canvas.Parent.Focus();
            else
            {
                var control = sender as Control;
                if (control == null) return;
                control.Focus();
            }
        }

        private static void MouseDownHandler(object sender, MouseEventArgs e)
        {
            var canvas = sender as Canvas;
            if (canvas == null) return;
            origin_ = canvas.Parent.PointToScreen(e.Location);
            is_mouse_down_ = true;
        }

        private static void MouseUpHandler(object sender, MouseEventArgs e)
        {
            is_mouse_down_ = false;
        }

        private static void MouseMoveHandler(object sender, MouseEventArgs e)
        {
            var canvas = sender as Canvas;
            if (canvas == null) return;

            if (is_mouse_down_ && e.Button == MouseButtons.Left)
            {
                var control = (ScrollableControl)canvas.Parent;
                var current = canvas.PointToScreen(e.Location);
                int x = current.X - origin_.X;
                int y = current.Y - origin_.Y;
                control.AutoScrollPosition = new Point(-x, -y);
                var cursor = CanvasPolicyA.GetHandCursor();
                if (cursor != null) canvas.Cursor = cursor;
            }
            else
            {
                var engine = canvas.Tag as CanvasEngine;
                if (engine == null) return;
                var core = engine.Core;
                if (core == null) return;

                lock (core)
                {
                    var pos = new Point((int)(e.Location.X * 72.0 / core.RenderDPI), (int)(e.Location.Y * 72.0 / core.RenderDPI));
                    var result = engine.GetURL(pos);
                    if (result != null)
                    {
                        if (canvas.Cursor == Cursors.Default)
                        {
                            canvas.Cursor = Cursors.Hand;
                            tooltip_.Show(result, canvas, 3000);
                        }
                    }
                    else
                    {
                        canvas.Cursor = Cursors.Default;
                        tooltip_.Hide(canvas);
                    }
                }
            }
        }

        private static void MouseClickHandler(object sender, MouseEventArgs e)
        {
            var canvas = sender as Canvas;
            if (canvas == null) return;

            if (canvas.Cursor == Cursors.Hand)
            {
                var engine = canvas.Tag as CanvasEngine;
                if (engine == null) return;
                var core = engine.Core;
                if (core == null) return;

                lock (core)
                {
                    var pos = new Point((int)(e.Location.X * 72.0 / core.RenderDPI), (int)(e.Location.Y * 72.0 / core.RenderDPI));
                    var addr = engine.GetURL(pos);
                    if (addr != null) System.Diagnostics.Process.Start(addr);
                }
                canvas.Cursor = Cursors.Default;
            }
            else
            {
                var cursor = CanvasPolicyA.GetHandCursor();
                if (cursor != null) canvas.Cursor = cursor;
            }
        }


        private static Cursor hand_ = null;
        private static bool is_mouse_down_ = false;
        private static Point origin_;
        private static ToolTip tooltip_ = new ToolTip();
    }
}
