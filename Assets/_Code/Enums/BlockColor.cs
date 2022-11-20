using UnityEngine;

namespace _Code.Enums
{
    public enum BlockColor
    {
        Blue = 0,
        Green = 1,
        Pink = 2,
        Purple = 3,
        Red = 4,
        Yellow = 5,

    }
    
    public static class BlockColorMethods
    {
        public static Color GetColor(this BlockColor blockColor)
        {
            switch (blockColor)
            {
                case BlockColor.Blue:
                    return Color.blue;
                case BlockColor.Green:
                    return Color.green;
                case BlockColor.Pink:
                    return new Color(255f/255f,97f/255f,216f/255f);
                case BlockColor.Purple:
                    return new Color(159f/255f,15f/255f,237f/255f);
                case BlockColor.Red:
                    return Color.red;
                case BlockColor.Yellow:
                    return Color.yellow;
                default:
                    return Color.white;
            }
        }
    }
}