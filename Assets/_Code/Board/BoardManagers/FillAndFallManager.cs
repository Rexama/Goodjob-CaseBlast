using _Code.Blocks;
using UnityEngine;

namespace _Code.Board.BoardManagers
{
    public class FillAndFallManager : MonoBehaviour
    {
        private Board _board;
        private BlockFactory _blockFactory;

        private void Awake()
        {
            _board = Board.Instance;
            _blockFactory = _board.blockFactory;
        }


        public void DoFallsAndFills()
        {
            
            DoFalls();
            DoFills();
        }
        private void DoFalls()
        {
            for (int i = 0; i < _board.columns; i++)
            {
                for (int j = 0; j < _board.rows; j++)
                {
                    var cell = _board.cells[i, j];
                    if (!cell.isEmpty && cell.cellBellow != null && cell.cellBellow.isEmpty)
                    {
                        cell.MakeBlockOnTopFall();
                    }
                }
            }
        }
        
        private void DoFills()
        {
            for (int i = 0; i < _board.columns; i++)
            {
                int offset = 0;
                for (int j = 0; j < _board.rows; j++)
                {
                    var cell = _board.cells[i, j];
                    if (cell.isEmpty)
                    {
                        //var newBlock = _blockFactory.CreateRandomFillBlock(cell, new Vector3(cell.transform.position.x,_board.rows+offset,0));
                        var newBlockPos = new Vector3(cell.transform.position.x, _board.rows + offset, 0);
                        var newBlock = _blockFactory.CreateRandomBlock(cell, newBlockPos);
                        newBlock.Fall(cell);
                        cell.FillCell(newBlock);
                        offset++;
                    }
                }

            }
        }

    }
}