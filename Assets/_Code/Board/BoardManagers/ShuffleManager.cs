using System.Collections.Generic;
using _Code.Enums;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Code.Board.BoardManagers
{
    public class ShuffleManager : MonoBehaviour
    {
        private Board _board;

        private void Awake()
        {
            _board = Board.Instance;
        }

        public void ShuffleBoard()
        {
            var ifShuffleCantSolveStuck = true;
            var blockColoursAndCounts = new Dictionary<BlockColor, int>();
            
            List<Cell> cellsList = new List<Cell>();
            for (int i = 0; i < _board.columns; i++)
            {
                for (int j = 0; j < _board.rows; j++)
                {
                    var cell = _board.cells[i, j];
                    cellsList.Add(cell);
                    blockColoursAndCounts[cell.Block.BlockColor] = blockColoursAndCounts.ContainsKey(cell.Block.BlockColor) ? blockColoursAndCounts[cell.Block.BlockColor] + 1 : 1;
                    
                    if(blockColoursAndCounts[cell.Block.BlockColor] == 2)
                    {
                        ifShuffleCantSolveStuck = false;
                    }
                }
            }
            if(ifShuffleCantSolveStuck)
            {
                Debug.Log("Shuffle can't solve the deadlock: Randomizing the board");
                RandomizeBoard();
            }
            else
            {
                SwapRandomBlocks(cellsList);
            }
            
        }

        private static void SwapRandomBlocks(List<Cell> cellsList)
        {
            while (cellsList.Count > 2)
            {
                var randomCell1 = cellsList[Random.Range(0, cellsList.Count)];
                var randBlock1 = randomCell1.block;
                cellsList.Remove(randomCell1);

                var randomCell2 = cellsList[Random.Range(0, cellsList.Count)];
                var randBlock2 = randomCell2.block;
                cellsList.Remove(randomCell2);

                randomCell1.SwapBlock(randBlock2);
                randomCell2.SwapBlock(randBlock1);
            }
        }

        private void RandomizeBoard()
        {
            for (int i = 0; i < _board.columns; i++)
            {
                for (int j = 0; j < _board.rows; j++)
                {
                    var cell = _board.cells[i, j];
                    cell.ClearCell();
                }
            }
            _board.PrepareBoard();
        }
        
        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                ShuffleBoard();
            }
        }
    }
}