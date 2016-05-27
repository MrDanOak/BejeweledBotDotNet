using System;
using System.Collections.Generic;
using System.Threading;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Linq;
using System.Timers;

namespace DotNetBejewelledBot
{
    public class BejeweledWindowManager
    {
        private Rectangle gameFrame;
        private Bitmap screenShot;
        private Bitmap bejeweledImage;
        private Bitmap colourGrid;
        private Color[,] colorMatrix;
        private List<Matcher> matchers = new List<Matcher>();
        private List<string> usedIds = new List<string>();
        private bool[,] tempColorMatrix;
        public bool isStarted = false;
        public bool isCalibrated = false;
        public bool isDebuggingPx = false;
        public int debugX = 0;
        public int debugY = 0;
        public System.Timers.Timer calcTimer = new System.Timers.Timer();
        public System.Windows.Forms.Timer frmTimer;
        public Bitmap ScreenShot
        {
            get
            {
                return (Bitmap)bejeweledImage;
            }
        }
        public Bitmap ColourGrid
        {
            get
            {
                return colourGrid;
            }
        }
        public BejeweledWindowManager(System.Windows.Forms.Timer frTimer)
        {
            frmTimer = frTimer;

            MatchBuilder mb = new MatchBuilder();

            matchers.AddRange(mb.GetMatchers());

            screenShot = new Bitmap(Screen.PrimaryScreen.Bounds.Width,
                           Screen.PrimaryScreen.Bounds.Height,
                           PixelFormat.Format32bppArgb);
            gameFrame = new Rectangle(new Point(0, 0), new Size(320, 320));
            colorMatrix = new Color[8, 8];
            GetScreenshot();
            GetColourGrid();
            calcTimer.Interval = 100;

            calcTimer.Elapsed += OnCalc;
            calcTimer.Start();
        }
        private void OnCalc(Object source, ElapsedEventArgs e)
        {
            CalculateMoves();
        }

        public bool Calibrate()
        {
            Point Location = new Point();

            for (int x = 0; x < screenShot.Size.Width; x++)
            {
                for (int y = 0; y < screenShot.Size.Height; y++)
                {
                    if (Location == Point.Empty)
                    {
                        if (screenShot.GetPixel(x, y) == Color.FromArgb(255, 39, 19, 5))
                        {
                            Location = new Point(x, y);
                            break;
                        }
                    }
                }
                if (Location != Point.Empty)
                    break;
            }

            if (Location != Point.Empty)
            {
                gameFrame = new Rectangle(Location, gameFrame.Size);
                isCalibrated = true;
                return true;
            }
            else
            {
                return false;
            }
        }
        public void GetScreenshot()
        {
            using (Graphics gfxScreenshot = Graphics.FromImage(screenShot))
            {
                gfxScreenshot.CopyFromScreen(Screen.PrimaryScreen.Bounds.X,
                                             Screen.PrimaryScreen.Bounds.Y,
                                             0,
                                             0,
                                             Screen.PrimaryScreen.Bounds.Size,
                                             CopyPixelOperation.SourceCopy);
            }

            bejeweledImage = screenShot.Clone(gameFrame, PixelFormat.Format32bppArgb);
            usedIds.Clear();
            //m_ScreenShot.Dispose();
        }
        public void CalculateMoves()
        {
            //calibrate can start grabbing colors without making moves, helpful for debugging color recognition
            if (isStarted)
            {
                List<ResultMove> res = new List<ResultMove>();
                foreach (Color thisColor in BejeweledColor.Collection.Where(e => !e.Equals(BejeweledColor.Black)))
                {
                    //build a grid of a single color's gems
                    tempColorMatrix = new bool[8, 8];
                    for (int x = 0; x < 8; x++)
                    {
                        for (int y = 0; y < 8; y++)
                        {
                            if (thisColor == colorMatrix[x, y])
                            {
                                tempColorMatrix[x, y] = true;
                            }
                        }
                    }

                    for (int x = 0; x < 8; x++)
                    {
                        for (int y = 0; y < 8; y++)
                        {
                            int acc = 0;
                            foreach (var matcher in matchers)
                            {
                                acc = 0;
                                for (int i = 0; i < matcher.MatchMatrix.GetLength(0); i++)
                                {
                                    for (int j = 0; j < matcher.MatchMatrix.GetLength(1); j++)
                                    {
                                        if (x + i < 8 && y + j < 8 && tempColorMatrix[x + i, y + j] && matcher.MatchMatrix[i, j])
                                        {
                                            acc++;
                                        }
                                    }
                                }

                                if (acc == matcher.Value && !usedIds.Contains(string.Format("{0}", matcher.Id, x, y)))
                                {
                                    res.Add(new ResultMove() { Move = matcher.Move, XOffset = x, YOffset = y, Value = matcher.Value, MatchMatrix = matcher.MatchMatrix, Id = matcher.Id });
                                }
                                acc = 0;
                                if (matcher.Reversible)
                                {
                                    for (int i = 0; i < matcher.MatchMatrix.GetLength(0); i++)
                                    {
                                        for (int j = 0; j < matcher.MatchMatrix.GetLength(1); j++)
                                        {
                                            if (x + i < 8 && y + j < 8 && tempColorMatrix[x + i, y + j] && !matcher.MatchMatrix[i, j])
                                            {
                                                acc++;
                                            }
                                        }
                                    }
                                }
                                if (acc == matcher.Value && !usedIds.Contains(string.Format("{0}", matcher.Id, x, y)))
                                {
                                    res.Add(new ResultMove() { Move = matcher.Move, XOffset = x, YOffset = y, Value = matcher.Value, MatchMatrix = matcher.MatchMatrix, Priority = matcher.Priority, Id = matcher.Id *-1 });
                                }
                            }
                        }
                    }
                }

                Random rand = new Random();

                int counter = 0;

                ResultMove r;
                if (res.Count > 0)
                {
                    res = res.OrderBy(o => o.Priority).Reverse().ToList();
                    r = res[0];
                    //while (res[0].Value > 3)
                    //{
                    //    r = res[0];
                    //    res.RemoveAt(0);
                    //    MoveClick(r);
                    //    new ManualResetEvent(false).WaitOne(100);
                    //    counter++;
                    //}
                    if (res[0].Value > 3)
                    {
                        r = res[0];
                        res.RemoveAt(0);

                        usedIds.Add(string.Format("{0}", r.Id, r.XOffset, r.YOffset));
                        MoveClick(r);

                    }
                    //play left and right side of the board same time. Use o.YOffset for top and bottom
                    //res = res.OrderBy(o => o.XOffset).Reverse().ToList();
                    if (res.Count > 1)
                    {
                        //r = res[0];
                        //res.RemoveAt(0);

                        //usedIds.Add(r.Id);
                        //MoveClick(r);


                        while (res.Count > 0 && counter < 3)
                        {
                            r = res[0];
                            res.RemoveAt(0);

                            usedIds.Add(string.Format("{0}", r.Id, r.XOffset, r.YOffset));
                            MoveClick(r);

                            counter++;
                        }


                        //r = res[res.Count - 1];
                        //MoveClick(r);
                    }
                    //else just make a move
                    else if (res.Count > 0)
                    {
                        r = res[0];
                        res.RemoveAt(0);

                        usedIds.Add(string.Format("{0}", r.Id, r.XOffset, r.YOffset));
                        MoveClick(r);

                    }
                    else
                    {
                        //experiment to make random moves when no moves can be found
                        //int xMove = 8;
                        //int yMove = 8;
                        //int xbit = 0;
                        //int ybit = 0;
                        //while (xMove > 7)
                        //{
                        //    xMove = rand.Next(8);
                        //    xbit = rand.Next(2) == 1 ? 1 : 0;
                        //}

                        //while (yMove > 7)
                        //{
                        //    yMove = rand.Next(8);
                        //    if (xbit == 0) ybit = 1;
                        //}

                        //ResultMove rr = new ResultMove();
                        //rr.XOffset = xMove;
                        //rr.YOffset = yMove;
                        //rr.Move = new PieceMove() { FromX = 0, ToX = xbit, FromY = 0, ToY = ybit };
                        //MoveClick(rr);
                        //new ManualResetEvent(false).WaitOne(50);
                    }
                    //Thread.Sleep(150);
                }
            }
        }
        public void MoveClick(ResultMove r)
        {
            WinAPI.SetCursorPos(gameFrame.Left + ((r.XOffset + r.Move.FromX) * 40) + 20, gameFrame.Top + ((r.YOffset + r.Move.FromY) * 40) + 20);
            WinAPI.DoMouseClick();
            Thread.Sleep(25);
            WinAPI.SetCursorPos(gameFrame.Left + ((r.XOffset + r.Move.ToX) * 40) + 20, gameFrame.Top + ((r.YOffset + r.Move.ToY) * 40) + 20);
            WinAPI.DoMouseClick();
        }
        public void MouseMove()
        {

            WinAPI.SetCursorPos(gameFrame.Left + debugX, gameFrame.Top + debugY);
        }
        public void GetColourGrid()
        {

            colourGrid = new Bitmap(gameFrame.Width, gameFrame.Height, PixelFormat.Format32bppArgb);

            using (Graphics gfxColourgrid = Graphics.FromImage(colourGrid))
            {
                if (isDebuggingPx)
                {
                    Color blockColor = GetClosestColor(BejeweledColor.Collection, bejeweledImage.GetPixel(debugX, debugY));
                    gfxColourgrid.FillRectangle(new SolidBrush(blockColor), new Rectangle(0, 0, bejeweledImage.Size.Width / 2, bejeweledImage.Size.Height));
                    gfxColourgrid.FillRectangle(new SolidBrush(bejeweledImage.GetPixel(debugX, debugY)), new Rectangle(bejeweledImage.Size.Width / 2, 0, bejeweledImage.Size.Width, bejeweledImage.Size.Height));

                }
                else {
                    for (int x = 0; x < bejeweledImage.Size.Width; x += 40)
                    {
                        for (int y = 0; y < bejeweledImage.Size.Height; y += 40)
                        {
                            Color blockColor = GetClosestColor(BejeweledColor.Collection, bejeweledImage.GetPixel(x + 20, y + 21));

                            //check 2 nearby colors to see if they resolve to the same color
                            if (!blockColor.Equals(BejeweledColor.Black) && !blockColor.Equals(BejeweledColor.White))
                            {
                                colorMatrix[x / 40, y / 40] = blockColor;
                                gfxColourgrid.FillRectangle(new SolidBrush(blockColor), new Rectangle(x, y, 40, 40));
                            }
                            else
                            {
                                //experimental, detect multiplier blocks as fallback
                                blockColor = GetClosestColor(BejeweledColor.Collection, bejeweledImage.GetPixel(x + 20, y + 29));
                                //blockColor2 = GetClosestColor(BejeweledColor.Collection, bejeweledImage.GetPixel(x + 18, y + 5));
                                if (!blockColor.Equals(BejeweledColor.Black))
                                {
                                    colorMatrix[x / 40, y / 40] = blockColor;
                                    gfxColourgrid.FillRectangle(new SolidBrush(blockColor), new Rectangle(x, y, 40, 40));
                                }
                                else
                                {
                                    colorMatrix[x / 40, y / 40] = BejeweledColor.Black;
                                    gfxColourgrid.FillRectangle(new SolidBrush(BejeweledColor.Black), new Rectangle(x, y, 40, 40));
                                }
                            }
                        }
                    }
                }
            }
        }
        private static Color GetClosestColor(List<Color> colorArray, Color baseColor)
        {
            var colors = colorArray.Select(x => new { Value = x, Diff = GetDiff(x, baseColor) }).ToList();
            var min = colors.Min(x => x.Diff);
            return colors.Find(x => x.Diff == min).Value;
        }
        private static int GetDiff(Color color, Color baseColor)
        {
            int a = color.A - baseColor.A,
                r = color.R - baseColor.R,
                g = color.G - baseColor.G,
                b = color.B - baseColor.B;
            return a * a + r * r + g * g + b * b;
        }
    }
    class WindowNotFoundException : Exception { }
}
