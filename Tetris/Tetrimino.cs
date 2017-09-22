using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Tetris
{
    abstract class Tetrimino
    {
        protected Tetrimino(int x, int y)
        {

        }
        public int X { get; set; }
        public int Y { get; set; }
        public abstract void Move(TetriminoDirection direction);
        public abstract void Rotate(TetriminoRotation rotation);
        public abstract Color Color { get; }
        public abstract TetriminoType TetrimnoType { get; }
        public abstract IEnumerable<Point> GetPoints(Point topLeft, Size size);
    }
    public enum TetriminoRotation
    {
        Right,
        Left
    }
    public enum TetriminoType
    {
        I,
        O,
        T,
        S,
        Z,
        J,
        L
    }
    public enum TetriminoDirection
    {
        // Up, // 왜 필요?
        Down,
        Left,
        Right
    }
    // For colors, see http://tetris.wikia.com/wiki/Tetris_Guideline
    class ITetrimino : Tetrimino
    {
        public int X { get; set; }
        public int Y { get; set; }
        private bool isVerticial = false;
        public ITetrimino(int x, int y) : base(x, y)
        {
            this.X = x;
            this.Y = y;
        }
        public override Color Color => Color.Orange;

        public override TetriminoType TetrimnoType => TetriminoType.I;

        public override void Move(TetriminoDirection direction)
        {
            switch (direction)
            {
                case TetriminoDirection.Down:
                    Y++;
                    break;
                case TetriminoDirection.Left:
                    if (--X < 0) X++;
                    break;
                case TetriminoDirection.Right:
                    X++;
                    break;
            }
        }
        public override void Rotate(TetriminoRotation rotation)
        {
            isVerticial = !isVerticial;
        }
        public override IEnumerable<Point> GetPoints(Point topLeft, Size size)
        {
            for (int i = 0; i < 4; i++)
            {
                if (isVerticial)
                {
                    yield return new Point(topLeft.X + size.Width * (X + i), topLeft.Y + size.Height * Y);
                }
                else
                {
                    yield return new Point(topLeft.X + size.Width * X, topLeft.Y + size.Height * (Y + i));
                }
            }
        }
    }
}
