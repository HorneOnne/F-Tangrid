using System.Collections.Generic;
using UnityEngine;

namespace Tangrid
{
    public class GameLogic : MonoBehaviour
    {
        public List<Pair> pairs;
        public List<Line> lines = new List<Line>();

        [Header("Prefab")]
        [SerializeField] private Line linePrefab;
        [SerializeField] private Transform lineRoot;
        private Dictionary<Pair, Line> pairLineMap = new Dictionary<Pair, Line>();


     
        private void Start()
        {
            Load();
        }

        private void Update()
        {
            Test();
        }

        private void Load()
        {
            foreach(var pair in pairs)
            {
                var line = Instantiate(linePrefab, lineRoot);
                line.SetPoints(pair.pointA, pair.pointB);
                line.DrawLine();
                lines.Add(line);

                if(pairLineMap.ContainsKey(pair) == false)
                    pairLineMap.Add(pair, line);
            }
        }

        private void Test()
        {
            foreach(var pair in pairs)
            {
                bool isColliding = LineSegmentCollisionChecker.AreCollisionsInList(pair, pairs);
                pairLineMap[pair].isCollided = isColliding;
            }
        }
    }

    [System.Serializable]
    public class Pair
    {
        public Transform pointA;
        public Transform pointB;
    }

}
