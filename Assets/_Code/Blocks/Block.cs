using System.Collections;
using _Code.Board;
using _Code.Enums;
using UnityEngine;

namespace _Code.Blocks
{
    public class Block : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer spriteRenderer;
        [SerializeField] private BlockColor blockColor;
        [SerializeField] private ParticleSystem blastEffect;
        [SerializeField] private BlockFallAnimation blockFallAnimation;
        [SerializeField] private BlockSwapAnimation blockSwapAnimation;
        public BlockColor BlockColor => blockColor;
        public void PrepareBlock(Cell cell,Sprite sprite,BlockColor color,Vector3 spawnPos)
        {
            spriteRenderer.enabled = true;
            ChangeSprite(sprite);
            spriteRenderer.sortingOrder = cell.GetOrderInLayer();
            transform.position = spawnPos;
            blockColor = color;
            ChangeParticleColor();
        }
        
        public void ChangeSprite(Sprite newSprite)
        {
            spriteRenderer.sprite = newSprite;
        }

        public void ChangeParticleColor()
        {
            var main = blastEffect.main;
            main.startColor = blockColor.GetColor();
        }
        
        public void Blast()
        {
            blastEffect.Play();
            spriteRenderer.enabled = false;
            StartCoroutine(DestroyWithDelay());
        }
        
        public void Fall(Cell cell)
        {
            spriteRenderer.sortingOrder = cell.GetOrderInLayer();
            blockFallAnimation.FallTo(cell);
        }
        public void Swap(Cell cell)
        {
            spriteRenderer.sortingOrder = cell.GetOrderInLayer();
            blockSwapAnimation.SwapTo(cell);
        }
        
        private IEnumerator DestroyWithDelay()
        {
            yield return new WaitForSeconds(blastEffect.main.startLifetime.constant);
            SimplePool.Despawn(gameObject);
        }
    }
}