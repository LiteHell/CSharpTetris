using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tetris
{
    public partial class TetrisControl : Control
    {
        public int TetrisCols { get; set; } = 10;
        public int TetrisRows { get; set; } = 40; // 20 rows should be hidden but wtf does "hidden" mean?
        public Size TetriminoSize { get
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

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            using (BufferedGraphics bufferedgraphic = BufferedGraphicsManager.Current.Allocate(pe.Graphics, this.ClientRectangle))
            {
                bufferedgraphic.Graphics.Clear(Color.Black);
                Rectangle rectangle = new Rectangle(new Point(this.ClientRectangle.Left + this.ClientRectangle.Width / 2, this.ClientRectangle.Top + this.ClientRectangle.Height / 2),new Size(this.ClientRectangle.Bottom / 2, this.ClientRectangle.Height / 2));
                bufferedgraphic.Graphics.FillRectangle(Brushes.Cyan, rectangle);
                bufferedgraphic.Render();
            }
        }
    }
}
