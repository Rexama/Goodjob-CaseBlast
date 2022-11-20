using System.Collections.Generic;
using _Code.Enums;
using _Code.ScriptableObjects;
using UnityEngine;

namespace _Code.Board.BoardManagers
{
    public class HintManager : MonoBehaviour
    {
       
        [SerializeField] private BlockIcons blockIcons;
        
        
        private Board _board;
        private ShuffleManager _shuffleManager;
        readonly List<Cell> _visitedCells = new List<Cell>();
        readonly List<Cell> _colorGroup = new List<Cell>();

        private void Awake()
        {
            _board = Board.Instance;
            _shuffleManager = _board.shuffleManager;
        }

        public void UpdateHints()
        {
            bool isStuck = true;
            for (int i = 0; i < _board.columns; i++)
            {
                for (int j = 0; j < _board.rows; j++)
                {
                    if (!_visitedCells.Contains(_board.cells[i, j]))
                    {
                        UpdateColorGroupCellsList(_board.cells[i, j]);
                        UpdateGroupHints(_colorGroup);
                        if(_colorGroup.Count>1) isStuck = false;
                        _colorGroup.Clear();
                    }
                }
            }
            if(isStuck) _shuffleManager.ShuffleBoard();
            _visitedCells.Clear();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("update");
                UpdateHints();
            }
        }

        private void UpdateColorGroupCellsList(Cell cell)
        {
            BlockColor color = cell.Block.BlockColor;

            _colorGroup.Add(cell);
            _visitedCells.Add(cell);

            foreach (var neighbour in cell.Neighbours)
            {
                if (!_colorGroup.Contains(neighbour) && neighbour.Block != null && neighbour.Block.BlockColor == color)
                {
                    UpdateColorGroupCellsList(neighbour);
                }
            }
        }

        private void UpdateGroupHints(List<Cell> colorGroup)
        {
            Sprite newSprite;
            var blockColor = colorGroup[0].Block.BlockColor;
            var groupSize = colorGroup.Count;


            if (groupSize >= _board.numberA && groupSize < _board.numberB)
            {
                newSprite = blockIcons.AllAIcons[blockColor];
            }
            else if (groupSize >= _board.numberB && groupSize < _board.numberC)
            {
                newSprite = blockIcons.AllBIcons[blockColor];
            }
            else if (groupSize >= _board.numberC)
            {
                newSprite = blockIcons.AllCIcons[blockColor];
            }
            else
            {
                newSprite = blockIcons.AllDefaultIcons[blockColor];
            }

            foreach (var cell in colorGroup)
            {
                var block = cell.Block;
                block.ChangeSprite(newSprite);
            }
        }
    }
}