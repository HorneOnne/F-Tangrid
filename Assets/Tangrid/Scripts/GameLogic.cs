using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Tangrid
{
    public class GameLogic : MonoBehaviour
    {
        public List<Pair> pairs;
        [Header("Prefab")]
        [SerializeField] private Line linePrefab;
        [SerializeField] private Transform lineRoot;
        private Dictionary<Pair, Line> pairLineMap = new Dictionary<Pair, Line>();

        [Header("Properties")]
        [SerializeField] private float waitTimeWinning = 0.5f;

        // Cached
        private GamePlayManager gameplayManager;
        private InputHandler inputHandler;
        private float updateFrequency = 0.15f;
        private float updateTimer = 0.0f;

        private void Start()
        {
            Load();
            inputHandler = InputHandler.Instance;
            gameplayManager = GamePlayManager.Instance;
        }

        private void Update()
        {
            if(gameplayManager.currentState == GamePlayManager.GameState.PLAYING)
            {
                // Only check if being click or drag node.
                if (inputHandler.HitObject != null)
                {
                    // Make it better peformance by reduce update frequency.
                    if (Time.time - updateTimer > updateFrequency)
                    {
                        updateTimer = Time.time;
                        CheckCollidedOnEachLineSegment();
                    }

                }
            }           
        }

        private void Load()
        {
            foreach(var pair in pairs)
            {
                var line = Instantiate(linePrefab, lineRoot);
                line.SetPoints(pair.pointA, pair.pointB);
                line.DrawLine();

                if(pairLineMap.ContainsKey(pair) == false)
                    pairLineMap.Add(pair, line);
            }
        }

        private void CheckCollidedOnEachLineSegment()
        {
            bool hasAtLeastOneCollided = false;
            foreach(var pair in pairs)
            {
                bool isColliding = LineSegmentCollisionChecker.AreCollisionsInPairs(pair, pairs);
                pairLineMap[pair].SetIsCollided(isColliding);

                if(hasAtLeastOneCollided == false)
                    hasAtLeastOneCollided = isColliding;
            }

            if(hasAtLeastOneCollided == false)
            {
                StartCoroutine(Utilities.WaitAfter(waitTimeWinning, () =>
                {
                    // Check collided in waiting time.
                    bool hasAtLeastOneCollided = false;
                    foreach (var pair in pairLineMap)
                    {
                        hasAtLeastOneCollided = pair.Value.IsCollided;
                        if (hasAtLeastOneCollided == true)
                            return;
                    }

                    // If still not have any collided -> WIN
                    gameplayManager.ChangeGameState(GamePlayManager.GameState.WIN);
                }));           
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
