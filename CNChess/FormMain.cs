using System.Reflection.Metadata;
using System.Collections.Generic;
using System.Drawing;
using System.DirectoryServices;
namespace CNChess
{
    //棋子的枚举类型
    public enum Piece
    {
        none=0, 
        red_pawn = 1,red_cannon=2,red_chariot=3,red_elephant=4,red_knight=5,red_advisor=6,red_king=7,
        blue_pawn = 8, blue_cannon = 9, blue_chariot = 10, blue_elephant = 11, blue_knight = 12, blue_advisor = 13, blue_king = 14,
    }

    public partial class FormMain : Form
    {
        //棋盘左上角坐标
        private Point _leftTop = new Point(60, 60);
        //棋盘格子大小
        private int _rowHeight = 120;
        private int _colWidth = 120;

        //保存棋盘的所有棋子值
        private Piece[,] _chess = new Piece[11, 10];
        //棋子半径
        private int _pieceR = 59;

        //棋子的位图表
        private Dictionary<Piece, Bitmap> _pieceImages;

        //保存拾起的棋子值
        private Piece _pickChess = Piece.none;
        //保存拾起的棋子原位置
        private int _pickRow = 0, _pickCol = 0;
        //保存落下的棋子位置
        private int _dropRow = 0, _dropCol = 0;
        public FormMain()
        {
            InitializeComponent();

            //根据分辨率设置方格大小
            _rowHeight = Screen.PrimaryScreen.Bounds.Size.Height / 14;
            _colWidth = _rowHeight;
            _pieceR = _rowHeight / 2 - 1;
            //设置左上角坐标
            _leftTop.X = 2 * _rowHeight;
            _leftTop.Y = _leftTop.X;
            //加载棋子图
            LoadPieceImages();
            //初始化棋子数组为“无子”
            for (int row = 1; row <= 10; ++row)
            {
                for (int col = 1; col <= 9; ++col)
                {
                    _chess[row, col] = Piece.none;
                }
            }
        }
        // 加载所有棋子图
        private void LoadPieceImages()
        {
            _pieceImages = new Dictionary<Piece, Bitmap>();

            // 红方
            _pieceImages.Add(Piece.red_pawn, new Bitmap("assets/red_pawn.bmp"));
            _pieceImages.Add(Piece.red_cannon, new Bitmap("assets/red_cannon.bmp"));
            _pieceImages.Add(Piece.red_chariot, new Bitmap("assets/red_chariot.bmp"));
            _pieceImages.Add(Piece.red_elephant, new Bitmap("assets/red_elephant.bmp"));
            _pieceImages.Add(Piece.red_knight, new Bitmap("assets/red_knight.bmp"));
            _pieceImages.Add(Piece.red_advisor, new Bitmap("assets/red_advisor.bmp"));
            _pieceImages.Add(Piece.red_king, new Bitmap("assets/red_king.bmp"));

            // 蓝方
            _pieceImages.Add(Piece.blue_pawn, new Bitmap("assets/blue_pawn.bmp"));
            _pieceImages.Add(Piece.blue_cannon, new Bitmap("assets/blue_cannon.bmp"));
            _pieceImages.Add(Piece.blue_chariot, new Bitmap("assets/blue_chariot.bmp"));
            _pieceImages.Add(Piece.blue_elephant, new Bitmap("assets/blue_elephant.bmp"));
            _pieceImages.Add(Piece.blue_knight, new Bitmap("assets/blue_knight.bmp"));
            _pieceImages.Add(Piece.blue_advisor, new Bitmap("assets/blue_advisor.bmp"));
            _pieceImages.Add(Piece.blue_king, new Bitmap("assets/blue_king.bmp"));
        }
        //绘制棋盘
        public void DrawBoard(Graphics g)
        {
            //绘制桌面
            Bitmap deskbmp = new Bitmap("assets/desktop.jpg");
            g.DrawImage(deskbmp, new Rectangle(0, 0, this.ClientSize.Width, this.ClientSize.Height));

            //创建画笔
            Pen thickPen = new Pen(Color.Black, 6);
            Pen thinPen = new Pen(Color.Black, 3);

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

            //绘制第3行炮营营地
            DrawCamp(g, new Point(_leftTop.X + _colWidth, _leftTop.Y + _rowHeight * 2), true, true);
            DrawCamp(g, new Point(_leftTop.X + _colWidth * 7, _leftTop.Y + _rowHeight * 2), true, true);
            //绘制第4行兵营营地
            DrawCamp(g, new Point(_leftTop.X + _colWidth * 0, _leftTop.Y + _rowHeight * 3), false, true);
            DrawCamp(g, new Point(_leftTop.X + _colWidth * 2, _leftTop.Y + _rowHeight * 3), true, true);
            DrawCamp(g, new Point(_leftTop.X + _colWidth * 4, _leftTop.Y + _rowHeight * 3), true, true);
            DrawCamp(g, new Point(_leftTop.X + _colWidth * 6, _leftTop.Y + _rowHeight * 3), true, true);
            DrawCamp(g, new Point(_leftTop.X + _colWidth * 8, _leftTop.Y + _rowHeight * 3), true, false);
            //绘制第七行兵营
            DrawCamp(g, new Point(_leftTop.X + _colWidth * 0, _leftTop.Y + _rowHeight * 6), false, true);
            DrawCamp(g, new Point(_leftTop.X + _colWidth * 2, _leftTop.Y + _rowHeight * 6), true, true);
            DrawCamp(g, new Point(_leftTop.X + _colWidth * 4, _leftTop.Y + _rowHeight * 6), true, true);
            DrawCamp(g, new Point(_leftTop.X + _colWidth * 6, _leftTop.Y + _rowHeight * 6), true, true);
            DrawCamp(g, new Point(_leftTop.X + _colWidth * 8, _leftTop.Y + _rowHeight * 6), true, false);
            //绘制第八行炮营
            DrawCamp(g, new Point(_leftTop.X + _colWidth, _leftTop.Y + _rowHeight * 7), true, true);
            DrawCamp(g, new Point(_leftTop.X + _colWidth * 7, _leftTop.Y + _rowHeight * 7), true, true);
        }


        //绘制营地标志
        public void DrawCamp(Graphics g, Point center, Boolean drawLeft, Boolean drawRight)
        {
            //偏移量和线段长度
            int offset = (int)(_rowHeight * 0.08);
            int length = (int)(_rowHeight * 0.16);
            //直角点坐标
            Point corner = new Point();
            //画笔对象
            Pen thinpen = new Pen(Color.Black, 2);

            //是否需要绘制左标志
            if (drawLeft)
            {
                //绘制左上角直角边
                corner.X = center.X - offset;
                corner.Y = center.Y - offset;
                g.DrawLine(thinpen, new Point(corner.X, corner.Y), new Point(corner.X - length, corner.Y));
                g.DrawLine(thinpen, new Point(corner.X, corner.Y), new Point(corner.X, corner.Y - length));
                //绘制左下角直角边
                corner.X = center.X - offset;
                corner.Y = center.Y + offset;
                g.DrawLine(thinpen, new Point(corner.X, corner.Y), new Point(corner.X - length, corner.Y));
                g.DrawLine(thinpen, new Point(corner.X, corner.Y), new Point(corner.X, corner.Y + length));
            }
            //是否需要绘制右标志
            if (drawRight)
            {
                //绘制右上角
                corner.X = center.X + offset;
                corner.Y = center.Y - offset;
                g.DrawLine(thinpen, new Point(corner.X, corner.Y), new Point(corner.X + length, corner.Y));
                g.DrawLine(thinpen, new Point(corner.X, corner.Y), new Point(corner.X, corner.Y - length));
                //绘制右下角
                corner.X = center.X + offset;
                corner.Y = center.Y + offset;
                g.DrawLine(thinpen, new Point(corner.X, corner.Y), new Point(corner.X + length, corner.Y));
                g.DrawLine(thinpen, new Point(corner.X, corner.Y), new Point(corner.X, corner.Y + length));
            }
        }

        public void FormMain_Paint(object sender, PaintEventArgs e)
        {
            //绘制棋盘
            DrawBoard(e.Graphics);
            //绘制棋子
            DrawPiece(e.Graphics);
        }

        public void DrawPiece(Graphics g)
        {
            //逐行逐列绘制
            for (int row = 1; row <= 10; ++row)
            {
                for (int col = 1; col <= 9; ++col)
                {
                    //如果该位置存在棋子
                    if (_chess[row, col] != Piece.none)
                    {
                        //装载对应位图
                        Bitmap piecebmp = _pieceImages[_chess[row, col]];
                        //设置透明色
                        piecebmp.MakeTransparent(Color.White);
                        //在棋盘交点绘制棋子
                        g.DrawImage(piecebmp, _leftTop.X + (col - 1) * _colWidth - _pieceR, _leftTop.Y + (row - 1) * _rowHeight - _pieceR, _pieceR * 2, _pieceR * 2);
                    }
                }
            }
        }

        private void MenuItemBegin_Click(object sender, EventArgs e)
        {
            //初始化棋子数组为“无子”
            for (int row = 1; row <= 10; ++row)
            {
                for (int col = 1; col <= 9; ++col)
                {
                    _chess[row, col] = Piece.none;
                }
            }
            //保存拾起的棋子值
            _pickChess = Piece.none;
            //保存拾起的棋子原位置
            _pickRow = 0;
            _pickCol = 0;
            //保存落下的棋子位置
            _dropRow = 0;
            _dropCol = 0;

        //初始化蓝方棋子
        _chess[1, 1] = Piece.blue_chariot;
            _chess[1, 2] = Piece.blue_knight;
            _chess[1, 3] = Piece.blue_elephant;
            _chess[1, 4] = Piece.blue_advisor;
            _chess[1, 5] = Piece.blue_king;
            _chess[1, 6] = Piece.blue_advisor;
            _chess[1, 7] = Piece.blue_elephant;
            _chess[1, 8] = Piece.blue_knight;
            _chess[1, 9] = Piece.blue_chariot;
            _chess[3, 2] = Piece.blue_cannon;
            _chess[3, 8] = Piece.blue_cannon;
            _chess[4, 1] = Piece.blue_pawn; _chess[4, 3] = Piece.blue_pawn; _chess[4, 5] = Piece.blue_pawn; _chess[4, 7] = Piece.blue_pawn; _chess[4, 9] = Piece.blue_pawn;
            //初始化红方棋子
            _chess[10, 1] = Piece.red_chariot;
            _chess[10, 2] = Piece.red_knight; _chess[10, 3] = Piece.red_elephant; _chess[10, 4] = Piece.red_advisor;
            _chess[10, 5] = Piece.red_king; _chess[10, 6] = Piece.red_advisor;
            _chess[10, 7] = Piece.red_elephant; _chess[10, 8] = Piece.red_knight; _chess[10, 9] = Piece.red_chariot;
            _chess[8, 2] = Piece.red_cannon; _chess[8, 8] = Piece.red_cannon;
            _chess[7, 1] = Piece.red_pawn; _chess[7, 3] = Piece.red_pawn; _chess[7, 5] = Piece.red_pawn; _chess[7, 7] = Piece.red_pawn; _chess[7, 9] = Piece.red_pawn;
            //使窗口失效并发送Paint信息，触发Paint事件重绘窗口
            Invalidate();
        }

        //将鼠标点击位置转换为棋盘行列号
        public bool ConvertPointToRowCol(Point pt, out int row, out int col)
        {
            row = 0; col = 0;
            //计算点击位置与棋盘左上角的相对坐标
            int x = pt.X - _leftTop.X;
            int y = pt.Y - _leftTop.Y;
            //根据格子大小计算行列号
            if (x >= -_colWidth / 2 && x <= 8 * _colWidth + _colWidth / 2 && y >= -_rowHeight / 2 && y <= 10 * _rowHeight + _rowHeight / 2)
            {
                col = (x + _colWidth / 2) / _colWidth + 1;
                row = (y + _rowHeight / 2) / _rowHeight + 1;
                return true;
            }
            return false;
        }

        private void FormMain_MouseDown(object sender, MouseEventArgs e)
        {
            //把鼠标点击位置转换为棋盘行列号
            int row, col;
            bool valid = ConvertPointToRowCol(e.Location, out row, out col);

            //如果转换成功则显示信息
            if (valid)
            {
                //MessageBox.Show("你点击了第" + row + "行，第" + col + "列", "提示");

                //处理拾起动作
                if (_pickChess == Piece.none)
                {
                    //如果该位置有棋子则拾起
                    if (_chess[row, col] != Piece.none)
                    {
                        _pickChess = _chess[row, col];
                        _pickRow = row;
                        _pickCol = col;
                        //MessageBox.Show("你拾起了第" + row + "行，第" + col + "列的棋子", "提示");
                        Invalidate(); //重绘窗口显示拾起效果
                    }

                }
                //处理落下
                else
                {
                    _chess[_pickRow, _pickCol] = Piece.none;
                    _chess[row, col] = _pickChess;
                    _pickChess = Piece.none;
                    _dropRow = row;
                    _dropCol = col;
                    //MessageBox.Show("你落下了第" + row + "行，第" + col + "列的棋子", "提示");
                    Invalidate();
                }
            }
            
        }
    }
}
