using System;
using System.Collections.Generic;
using System.Text;

namespace CNChess
{
    internal class Step
    {
        private Player _player;
        private Piece _pickChess;
        private int _pickRow;
        private int _pickCol;
        private Piece _dropChess;
        private int _dropRow;
        private int _dropCol;

        public Player Player { get => _player;
            set
            {
                if(value == Player.none)
                {
                    throw new ArgumentOutOfRangeException("走棋方不能为none");
                }
                else
                {
                    _player = value;
                }
            }
        }
        public Piece PickChess { get => _pickChess;
            set
            {
                if(value == Piece.none)
                {
                    throw new ArgumentOutOfRangeException("被选中的棋子不能为none");
                }
                else
                {
                    _pickChess = value;
                }
            }
        }
        public int PickRow { get => _pickRow;
            set {                 
                if(value <= 0 || value > 10)
                {
                    throw new ArgumentOutOfRangeException("被选中的棋子行数必须在1-10之间");
                }
                else
                {
                    _pickRow = value;
                }
            }
        }
        public int PickCol { get => _pickCol;
            set
            {
                if(value <= 0 || value > 9)
                {
                    throw new ArgumentOutOfRangeException("被选中的棋子列数必须在1-9之间");
                }
                else
                {
                    _pickCol = value;
                }
            }
        }
        public Piece DropChess { get => _dropChess; set => _dropChess = value; }
        public int DropRow { get => _dropRow;
            set
            {
                if (value <= 0 || value > 10)
                {
                    throw new ArgumentOutOfRangeException("被放置的棋子行数必须在1-10之间");
                }
                else
                {
                    _dropRow = value;
                }
            }
        }
        public int DropCol
        {
            get => _dropCol;
            set
            {
                if (value <= 0 || value > 9)
                {
                    throw new ArgumentOutOfRangeException("被放置的棋子列数必须在1-9之间");
                }
                else
                {
                    _dropCol = value;
                }
            }
        }
    }
}
