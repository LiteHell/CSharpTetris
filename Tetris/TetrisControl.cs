using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tetris
{
    public partial class TetrisControl : Control
    {
        public int TetrisCols { get; set; } = 10;
        public int TetrisRows { get; set; } = 40; // 20 rows should be hidden but wtf does "hidden" mean?
        private Tetrimino currentTetrimino;
        private Tetrimino heldTetrimino;
        private Thread loopThr;
        public Size TetriminoSize {
            get
            {
                return new Size(this.ClientRectangle.Width / TetrisCols, this.ClientRectangle.Height / TetrisRows);
            }
        }
        // Buffered Graphics from http://alexissharper.blogspot.kr/2014/01/c-gdi-bufferedgraphics.html
        public TetrisControl()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
        }
        private void internalLoop()
        {
            while (true)
            {
                Thread.Sleep(500);
                currentTetrimino.Move(TetriminoDirection.Down);
                this.Invoke(new Action(() => Refresh()));
            }
        }
        private void getInitialPosition(Tetrimino tetrimino, out int x, out int y)
        {
            switch(tetrimino.TetrimnoType)
            {
                case TetriminoType.I:
                    x = 5;
                    y = 0;
                    break;
                default:
                    throw new Exception();
            }
        }
        public void HoldTetrimino()
        {
            heldTetrimino = currentTetrimino;
            currentTetrimino = new ITetrimino(5, 0);
        }
        public void UnholdTetrimino()
        {
            getInitialPosition(heldTetrimino, out int x, out int y);
            heldTetrimino.X = x;
            heldTetrimino.Y = y;
            currentTetrimino = heldTetrimino;
        }
        public void RotateTetrimino(TetriminoRotation rotationDirection)
        {
            currentTetrimino.Rotate(rotationDirection);
        }

        public void Start()
        {
            currentTetrimino = new ITetrimino(5, 0);
            loopThr = new Thread(internalLoop);
            loopThr.Start();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            if (currentTetrimino == null) return;
            Point topLeftPoint = new Point(this.ClientRectangle.Left, this.ClientRectangle.Top);
            using (BufferedGraphics bufferedgraphic = BufferedGraphicsManager.Current.Allocate(pe.Graphics, this.ClientRectangle))
            {
                bufferedgraphic.Graphics.Clear(Color.Black);
                foreach (Point i in currentTetrimino.GetPoints(topLeftPoint, TetriminoSize))
                {
                    Rectangle rectangle = new Rectangle(i, TetriminoSize);
                    bufferedgraphic.Graphics.FillRectangle(new SolidBrush(currentTetrimino.Color), rectangle);
                    bufferedgraphic.Render();
                }
            }
        }
    }
}
