using UnityEngine;

namespace _Code.Board
{
    public class Border : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer spriteRenderer;
        public void SetSize(int row ,int col)
        {
            spriteRenderer.size = new Vector2(col+0.20f, row+0.35f);
        }
        
    }
}