using UnityEngine;

namespace Tangrid
{
    public class InputHandler : MonoBehaviour
    {
        public static InputHandler Instance { get; private set; }
        private Transform hitObject = null;
        private Camera mainCam;
        [SerializeField] private LayerMask nodeLayer;

        // Cached
        private GamePlayManager gameplayManager;

        #region Properties
        public Transform HitObject { get { return hitObject; }  }
        #endregion

   

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            gameplayManager = GamePlayManager.Instance;
            mainCam = Camera.main;
        }

        private void Update()
        {
            if(gameplayManager.currentState == GamePlayManager.GameState.PLAYING)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    RaycastHit2D hit = Physics2D.Raycast(mainCam.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 100, nodeLayer);
                    if (hit)
                    {
                        hitObject = hit.transform;
                    }
                }
                else if (Input.GetMouseButtonUp(0))
                {
                    hitObject = null;
                }

                if (hitObject != null)
                {
                    hitObject.position = (Vector2)mainCam.ScreenToWorldPoint(Input.mousePosition);
                }
            }        
        }
    }

}
