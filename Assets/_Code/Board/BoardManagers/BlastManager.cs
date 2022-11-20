using System.Collections.Generic;
using _Code.Enums;
using UnityEngine;

namespace _Code.Board.BoardManagers
{
    public class BlastManager : MonoBehaviour
    {
        private FillAndFallManager _fillAndFallManager;
        private List<Cell> colorGroup = new List<Cell>();

        private void Awake()
        {
            _fillAndFallManager = Board.Instance.fillAndFallManager;
        }

        public void OnCellTouched(Cell cell)
        {
            UpdateColorGroupCellsList(cell);
            BlastColorGroup();
            _fillAndFallManager.DoFallsAndFills();
            colorGroup.Clear();
        }
        
        private void BlastColorGroup()
        {
            if(colorGroup.Count >= 2)
            {
                foreach (Cell cell in colorGroup)
                {
                    cell.ClearCell();
                }
            }
        }
        
        private void UpdateColorGroupCellsList(Cell cell)
        {
            BlockColor color = cell.Block.BlockColor;
            
            colorGroup.Add(cell);
            
            foreach (var neighbour in cell.Neighbours)
            {
                if(!colorGroup.Contains(neighbour) && neighbour.Block!= null && neighbour.Block.BlockColor == color)
                {
                    UpdateColorGroupCellsList(neighbour);
                }
            }
        }

    }
}