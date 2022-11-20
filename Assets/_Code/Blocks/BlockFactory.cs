using _Code.Board;
using _Code.Enums;
using _Code.ScriptableObjects;
using UnityEngine;
using Random = UnityEngine.Random;


namespace _Code.Blocks
{
    public class BlockFactory : Singleton<BlockFactory>
    {
        
        [SerializeField] private GameObject blockPrefab;
        [SerializeField] private BlockIcons blockIcons;
        [SerializeField] Transform blocks;
        
        private Board.Board _board;

        private void Awake()
        {
            _board = Board.Board.Instance;
        }

        public Block CreateRandomBlock(Cell cell,Vector3 spawnPos)
        {
            BlockColor randomColor = (BlockColor)Random.Range(0, _board.numberOfColors);
            var sprite = blockIcons.AllDefaultIcons[randomColor];
            
            var block = SimplePool.Spawn(blockPrefab, blocks.transform.position,Quaternion.identity).GetComponent<Block>();
            block.transform.SetParent(blocks);
            block.PrepareBlock(cell,sprite,randomColor,spawnPos);
            
            return block;
        }
    }
}