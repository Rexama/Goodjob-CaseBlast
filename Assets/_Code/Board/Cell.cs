using System.Collections.Generic;
using _Code.Blocks;
using _Code.Enums;
using TMPro;
using UnityEngine;

namespace _Code.Board
{
    public class Cell : MonoBehaviour
    {
        [SerializeField] private TextMeshPro coordText;

        [HideInInspector] public int x;
        [HideInInspector] public int y;
        
        public bool isEmpty = true;
        public Block block;
        public Block Block => block;
        
        
        public List<Cell> Neighbours { get; private set; }
        [HideInInspector] public Cell cellBellow;
        public void PrepareCell(int newX,int newY)
        {
            x = newX;
            y = newY;
            transform.localPosition = new Vector3(x, y, 0);
            coordText.text = x + "," + y;
        }

        public void UpdateNeighbours(Board board)
        {
            Neighbours = new List<Cell>();
            var up = board.GetNeighbourWithDirection(this, Directions.Up);
            var down = board.GetNeighbourWithDirection(this, Directions.Down);
            var left = board.GetNeighbourWithDirection(this, Directions.Left);
            var right = board.GetNeighbourWithDirection(this, Directions.Right);
			
            if(up!=null) Neighbours.Add(up);
            if(down!=null) Neighbours.Add(down);
            if(left!=null) Neighbours.Add(left);
            if(right!=null) Neighbours.Add(right);

            if (down != null) cellBellow = down;
        }
        

        public int GetOrderInLayer()
        {
            return y+1;
        }
        
        public void FillCell(Block newBlock)
        {
            isEmpty = false;
            block = newBlock;
        }
        
        public void ClearCell()
        {
            isEmpty = true;
            Block.Blast();
            block = null;
        }

        public void MakeBlockOnTopFall()
        {
            var targetCell = GetFallTarget();
            block.Fall(targetCell);
            targetCell.FillCell(block);
            isEmpty = true;
            block = null;
        }

        private Cell GetFallTarget()
        {
            var targetCell = this;
            while (targetCell.cellBellow != null && targetCell.cellBellow.Block == null)
            {
                targetCell = targetCell.cellBellow;
            }
            return targetCell; 
        }

        public void SwapBlock(Block otherBlock)
        {
            block = otherBlock;
            otherBlock.Swap(this);
        }

    }
}