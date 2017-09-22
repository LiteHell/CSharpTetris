using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Tetris.Tetriminos
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
        public static Tetrimino GetTetrimino(TetriminoType type, int x, int y) {
            switch (type)
            {
                case TetriminoType.I:
                    return new ITetrimino(x, y);
                    break;
                case TetriminoType.O:
                    return new OTetrimino(x, y);
                    break;
                case TetriminoType.T:
                    break;
                case TetriminoType.S:
                    break;
                case TetriminoType.Z:
                    break;
                case TetriminoType.J:
                    break;
                case TetriminoType.L:
                    break;
            }
        }
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
}
