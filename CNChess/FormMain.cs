using System.Reflection.Metadata;

namespace CNChess
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }
        //棋盘左上角坐标
        private Point _leftTop = new Point(60, 60);
        //棋盘格子大小
        private int _rowHeight = 120;
        private int _colWidth = 120;

        //绘制棋盘
        public void DrawBoard(Graphics g)
        {
            //绘制桌面
            Bitmap deskbmp = new Bitmap("desktop.jpg"); 
            g.DrawImage(deskbmp, new Rectangle(0, 0, this.ClientSize.Width, this.ClientSize.Height));

            //创建画笔
            Pen thickPen = new Pen(Color.Black, 6);
            Pen thinPen = new Pen(Color.Black, 2);

            //绘制棋盘边框
            int gap = (int)(_rowHeight * 0.15);
            g.DrawRectangle(thickPen, new Rectangle(_leftTop.X - gap, _leftTop.Y - gap, _colWidth * 8 + gap * 2, _rowHeight * 9 + gap * 2));

            //绘制十条横线
            for (int row = 1; row <= 10; row++)
            {
                g.DrawLine(thinPen, new Point(_leftTop.X, _leftTop.Y + _rowHeight * (row - 1)), new Point(_leftTop.X + 8 * _colWidth, _leftTop.Y + _rowHeight * (row - 1)));
            }

            //绘制九条竖线
            for (int col = 1; col <= 9; col++)
            {
                //上半部分
                g.DrawLine(thinPen, new Point(_leftTop.X + _colWidth * (col - 1), _leftTop.Y), new Point(_leftTop.X + _colWidth * (col - 1), _leftTop.Y + 4 * _rowHeight));
                //下半部分
                g.DrawLine(thinPen, new Point(_leftTop.X + _colWidth * (col - 1), _leftTop.Y + 5 * _rowHeight), new Point(_leftTop.X + _colWidth * (col - 1), _leftTop.Y + 9 * _rowHeight));
            }

            //绘制楚河汉界左右两端的短竖线
            g.DrawLine(thinPen, new Point(_leftTop.X, _leftTop.Y + 4 * _rowHeight), new Point(_leftTop.X, _leftTop.Y + 5 * _rowHeight));
            g.DrawLine(thinPen, new Point(_leftTop.X + 8 * _colWidth, _leftTop.Y + 4 * _rowHeight), new Point(_leftTop.X + 8 * _colWidth, _leftTop.Y + 5 * _rowHeight));

            //绘制上方九宫格交叉线
            g.DrawLine(thinPen, new Point(_leftTop.X + 3 * _colWidth, _leftTop.Y), new Point(_leftTop.X + 5 * _colWidth, _leftTop.Y + 2 * _rowHeight));
            g.DrawLine(thinPen, new Point(_leftTop.X + 5 * _colWidth, _leftTop.Y), new Point(_leftTop.X + 3 * _colWidth, _leftTop.Y + 2 * _rowHeight));

            //绘制下方九宫格交叉线
            g.DrawLine(thinPen, new Point(_leftTop.X + 3 * _colWidth, _leftTop.Y + 7 * _rowHeight), new Point(_leftTop.X + 5 * _colWidth, _leftTop.Y + 9 * _rowHeight));
            g.DrawLine(thinPen, new Point(_leftTop.X + 5 * _colWidth, _leftTop.Y + 7 * _rowHeight), new Point(_leftTop.X + 3 * _colWidth, _leftTop.Y + 9 * _rowHeight));

            //绘制楚河汉界文字
            Font font1 = new Font("隶书", (float)(_rowHeight * 0.8), FontStyle.Regular, GraphicsUnit.Pixel);
            SolidBrush brush = new SolidBrush(Color.Black);
            g.DrawString("楚河", font1, brush, new Point(_leftTop.X + _colWidth, (int)(_leftTop.Y + _rowHeight * 4.1)));
            g.DrawString("汉界", font1, brush, new Point(_leftTop.X + _colWidth * 5, (int)(_leftTop.Y + _rowHeight * 4.1)));

            //绘制行的数字编号
            Font font2 = new Font("微软雅黑", (float)(_rowHeight * 0.5), FontStyle.Regular, GraphicsUnit.Pixel);
            for (int row = 1; row <= 10; row++)
            {
                g.DrawString(row.ToString(), font2, brush, new Point((int)(_leftTop.X + _colWidth * 8.6), (int)(_leftTop.Y - _rowHeight * 0.4 + _rowHeight * (row - 1))));
            }

            //绘制列的数字编号
            Font font3 = new Font("微软雅黑", (float)(_colWidth * 0.5), FontStyle.Regular, GraphicsUnit.Pixel);
            for (int col = 1; col <= 9; col++)
            {
                g.DrawString(col.ToString(), font3, brush, new Point((int)(_leftTop.X - _colWidth * 0.3 + _colWidth * (col - 1)),
                    (int)(_leftTop.Y + _rowHeight * 9.6)));
            }

            //书写蓝方和红方
            g.DrawString("蓝方", font3, brush, new Point((int)(_leftTop.X + _colWidth * 8 + 180), (int)(_leftTop.Y + _rowHeight * 2.2)));
            g.DrawString("红方", font3, brush, new Point((int)(_leftTop.X + _colWidth * 8 + 180), (int)(_leftTop.Y + _rowHeight * 6.4)));
        }

        public void FormMain_Paint(object sender, PaintEventArgs e)
        {
            //绘制棋盘
            DrawBoard(e.Graphics);
        }
    }
}
