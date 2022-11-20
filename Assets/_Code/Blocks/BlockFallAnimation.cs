using System;
using _Code.Board;
using Unity.VisualScripting;
using UnityEngine;

namespace _Code.Blocks
{
    public class BlockFallAnimation : MonoBehaviour
    {
        public Block block;
        private bool _isFalling;
        [HideInInspector] public Cell targetCell;

        private static float _startVel = 0F;
        [SerializeField] private float acceleration = 0.1F;
        private static float _maxSpeed = 20F;

        private float _vel = _startVel;

        private Vector3 _targetPosition;
        private Sequence _jumpSequence;

        public static event Action OnFallAnimationFinished;
        public static event Action OnFallAnimationStarted;

        public void FallTo(Cell targetCell)
        {
            if (this.targetCell != null && targetCell.y >= this.targetCell.y) return;
            this.targetCell = targetCell;
            _targetPosition = this.targetCell.transform.position;
            _isFalling = true;
            OnFallAnimationStarted?.Invoke();
        }

        public void Update()
        {
            if (!_isFalling) return;
            _vel += acceleration;
            _vel = _vel >= _maxSpeed ? _maxSpeed : _vel;
            var p = block.transform.position;
            p.y -= _vel * Time.deltaTime;
            if (p.y <= _targetPosition.y)
            {
                _isFalling = false;
                targetCell = null;
                p.y = _targetPosition.y;
                _vel = _startVel;
                OnFallAnimationFinished?.Invoke();
            }
            block.transform.position = p;
        }
    }
}