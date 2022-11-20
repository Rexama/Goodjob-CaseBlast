using _Code.Blocks;
using UnityEngine;

namespace _Code.Board.BoardManagers
{
    public class TouchManager : MonoBehaviour
    {
        [SerializeField] private new Camera camera;
        [SerializeField] private bool canTouch = true;
        
        private BlastManager _blastManager;
        private HintManager _hintManager;
        
        private int _blocksOnMove;
            
        private void Awake()
        {
            _blastManager = Board.Instance.blastManager;
            _hintManager = Board.Instance.hintManager;
            
            BlockFallAnimation.OnFallAnimationStarted += IncreaseMovingBlockCount;
            BlockFallAnimation.OnFallAnimationFinished += DecreaseMovingBlockCount;
            
            BlockSwapAnimation.OnSwapAnimationStarted += IncreaseMovingBlockCount;
            BlockSwapAnimation.OnSwapAnimationFinished += DecreaseMovingBlockCount;
        }

        private void Update()
        {
            if (canTouch && Input.GetMouseButtonUp(0))
            {
                var hit = Physics2D.OverlapPoint(camera.ScreenToWorldPoint(Input.mousePosition)) as BoxCollider2D;
		
                if (hit !=null && hit.gameObject.CompareTag("Cell"))
                {
                    _blastManager.OnCellTouched(hit.gameObject.GetComponent<Cell>());
                }
            }
        }
        
        private void IncreaseMovingBlockCount()
        {
            _blocksOnMove++;
            canTouch = false;
        }
        
        private void DecreaseMovingBlockCount()
        {
            _blocksOnMove--;
            if (_blocksOnMove == 0)
            {
                _hintManager.UpdateHints();
                canTouch = true;
            }
        }
    }
    
    
}