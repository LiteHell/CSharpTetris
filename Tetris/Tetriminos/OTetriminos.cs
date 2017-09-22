using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Tetris.Tetriminos
{
    // For colors, see http://tetris.wikia.com/wiki/Tetris_Guideline
    class OTetrimino : Tetrimino
    {
        public int X { get; set; }
        public int Y { get; set; }
        public OTetrimino(int x, int y) : base(x, y)
        {
            this.X = x;
            this.Y = y;
        }
        public override Color Color => Color.Yellow;

        public override TetriminoType TetrimnoType => TetriminoType.O;

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
            return;
        }
        public override IEnumerable<Point> GetPoints(Point topLeft, Size size)
        {
            for (int i = 0; i < 4; i++)
            {
                if (i < 2)
                    yield return new Point(topLeft.X + size.Width * (X + i), topLeft.Y + size.Height * Y);
                else 
                    yield return new Point(topLeft.X + size.Width * (X - 2), topLeft.Y + size.Height * (Y + 1));
            }
        }
    }
}
