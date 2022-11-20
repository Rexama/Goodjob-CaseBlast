using System.Collections.Generic;
using _Code.Enums;
using UnityEngine;



namespace _Code.ScriptableObjects
{
    [CreateAssetMenu(fileName = "BlockIcons", menuName = "ScriptableObjects/BlockIcons", order = 1)]
    public class BlockIcons : ScriptableObject
    {
        [SerializeField] private Sprite blueDefault;
        [SerializeField] private Sprite blueA;
        [SerializeField] private Sprite blueB;
        [SerializeField] private Sprite blueC;
        
        [Space(10)]
        [SerializeField] private Sprite greenDefault;
        [SerializeField] private Sprite greenA;
        [SerializeField] private Sprite greenB;
        [SerializeField] private Sprite greenC;
        
        [Space(10)]
        [SerializeField] private Sprite pinkDefault;
        [SerializeField] private Sprite pinkA;
        [SerializeField] private Sprite pinkB;
        [SerializeField] private Sprite pinkC;
        
        [Space(10)]
        [SerializeField] private Sprite purpleDefault;
        [SerializeField] private Sprite purpleA;
        [SerializeField] private Sprite purpleB;
        [SerializeField] private Sprite purpleC;
        
        [Space(10)]
        [SerializeField] private Sprite redDefault;
        [SerializeField] private Sprite redA;
        [SerializeField] private Sprite redB;
        [SerializeField] private Sprite redC;
        
        [Space(10)]
        [SerializeField] private Sprite yellowDefault;
        [SerializeField] private Sprite yellowA;
        [SerializeField] private Sprite yellowB;
        [SerializeField] private Sprite yellowC;
        
        private Dictionary<BlockColor, Sprite> allDefaultIcons = new Dictionary<BlockColor, Sprite>();
        private Dictionary<BlockColor, Sprite> allAIcons = new Dictionary<BlockColor, Sprite>();
        private Dictionary<BlockColor, Sprite> allBIcons = new Dictionary<BlockColor, Sprite>();
        private Dictionary<BlockColor, Sprite> allCIcons = new Dictionary<BlockColor, Sprite>();
        public Dictionary<BlockColor, Sprite> AllDefaultIcons => allDefaultIcons;
        public Dictionary<BlockColor, Sprite> AllAIcons => allAIcons;
        public Dictionary<BlockColor, Sprite> AllBIcons => allBIcons;
        public Dictionary<BlockColor, Sprite> AllCIcons => allCIcons;
        
        private void OnEnable()
        {
            allDefaultIcons.Add(BlockColor.Blue, blueDefault);
            allDefaultIcons.Add(BlockColor.Green, greenDefault);
            allDefaultIcons.Add(BlockColor.Pink, pinkDefault);
            allDefaultIcons.Add(BlockColor.Purple, purpleDefault);
            allDefaultIcons.Add(BlockColor.Red, redDefault);
            allDefaultIcons.Add(BlockColor.Yellow, yellowDefault);
            
            allAIcons.Add(BlockColor.Blue, blueA);
            allAIcons.Add(BlockColor.Green, greenA);
            allAIcons.Add(BlockColor.Pink, pinkA);
            allAIcons.Add(BlockColor.Purple, purpleA);
            allAIcons.Add(BlockColor.Red, redA);
            allAIcons.Add(BlockColor.Yellow, yellowA);
            
            allBIcons.Add(BlockColor.Blue, blueB);
            allBIcons.Add(BlockColor.Green, greenB);
            allBIcons.Add(BlockColor.Pink, pinkB);
            allBIcons.Add(BlockColor.Purple, purpleB);
            allBIcons.Add(BlockColor.Red, redB);
            allBIcons.Add(BlockColor.Yellow, yellowB);
            
            allCIcons.Add(BlockColor.Blue, blueC);
            allCIcons.Add(BlockColor.Green, greenC);
            allCIcons.Add(BlockColor.Pink, pinkC);
            allCIcons.Add(BlockColor.Purple, purpleC);
            allCIcons.Add(BlockColor.Red, redC);
            allCIcons.Add(BlockColor.Yellow, yellowC);
        }
    }
}