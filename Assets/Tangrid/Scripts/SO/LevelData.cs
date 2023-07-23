using System.Collections.Generic;
using UnityEngine;


namespace Tangrid
{
    [CreateAssetMenu(fileName = "LevelData_", menuName = "Tangrid/LevelData", order = 51)]
    public class LevelData : ScriptableObject
    {
        [Header("Level")]
        public int level;
        public bool isLocking;
    }
}



