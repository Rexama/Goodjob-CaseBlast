using System;
using _Code.Blocks;
using _Code.Board.BoardManagers;
using _Code.Enums;
using UnityEngine;

namespace _Code.Board
{
    public class Board : Singleton<Board>
    {
        [Header("Board Settings")]
        [SerializeField] public int rows;
        [SerializeField] public int columns;
        [Space(15)]
        
        [Header("Game Settings")]
        [SerializeField] public int numberOfColors;
        [SerializeField] public int numberA;
        [SerializeField] public int numberB;
        [SerializeField] public int numberC;
        [Space(15)]
        
        [Header("Board Managers")]
        public BlockFactory blockFactory;
        public BlastManager blastManager;
        public HintManager hintManager;
        public FillAndFallManager fillAndFallManager;
        public ShuffleManager shuffleManager;
        public TouchManager touchManager;
        
        [Space(15)]
        [SerializeField] private Border border;
        [SerializeField] private Transform cellsParent;
        [SerializeField] private GameObject cellPrefab;

        public Cell[,] cells;
        
        private void Start()
        {
            PrepareBoard();
        }

        public void PrepareBoard()
        {
            border.SetSize(rows, columns);
            CreateCells();
            SetCellNeighbours();
            CreateBlocks();
            hintManager.UpdateHints();
        }

        private void CreateCells()
        {
            cells = new Cell[columns, rows];
            cellsParent.transform.position = new Vector3((columns - 1) * -0.5f, (rows - 1) * -0.5f, 0);
            for (int i = 0; i < columns; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    var newCell = Instantiate(cellPrefab, new Vector3(0, 0, 0), Quaternion.identity, cellsParent)
                        .GetComponent<Cell>();
                    newCell.PrepareCell(i, j);
                    cells[i, j] = newCell;
                }
            }
        }

        private void SetCellNeighbours()
        {
            for (int i = 0; i < columns; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    cells[i, j].UpdateNeighbours(this);
                }
            }
        }

        private void CreateBlocks()
        {
            for (int i = 0; i < columns; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    var cell = cells[i, j];
                    var newBlock = blockFactory.CreateRandomBlock(cell,cell.transform.position);
                    cells[i, j].FillCell(newBlock);
                }
            }
        }

        public Cell GetNeighbourWithDirection(Cell cell, Directions direction)
        {
            var x = cell.x;
            var y = cell.y;
            switch (direction)
            {
                case Directions.None:
                    break;
                case Directions.Up:
                    y += 1;
                    break;
                case Directions.Right:
                    x += 1;
                    break;
                case Directions.Down:
                    y -= 1;
                    break;
                case Directions.Left:
                    x -= 1;
                    break;

                default:
                    throw new ArgumentOutOfRangeException("direction", direction, null);
            }

            if (x >= columns || x < 0 || y >= rows || y < 0) return null;

            return cells[x, y];
        }

    }
}