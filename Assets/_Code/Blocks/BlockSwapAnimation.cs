using System;
using _Code.Board;
using UnityEngine;
using UnityEngine.Serialization;

namespace _Code.Blocks
{
    public class BlockSwapAnimation : MonoBehaviour
    {
        public Block block;
        [SerializeField] private float speed = 6f;
        private bool _isSwapping;
    

        
        private Vector3 _targetPosition;
        

        public static event Action OnSwapAnimationFinished;
        public static event Action OnSwapAnimationStarted;

        public void SwapTo(Cell targetCell)
        {
            _targetPosition = targetCell.transform.position;
            _isSwapping = true;
            OnSwapAnimationStarted?.Invoke();
        }

        public void Update()
        {
            if (!_isSwapping) return;
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, _targetPosition, step);
            if(transform.position == _targetPosition)
            {
                _isSwapping = false;
                OnSwapAnimationFinished?.Invoke();
            }
        }
    }
}