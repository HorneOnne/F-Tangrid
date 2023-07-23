using UnityEngine;

namespace Tangrid
{
    public class Line : MonoBehaviour
    {
        public static event System.Action OnLineCollidedStateChanged;
        public LineRenderer lr;
        public Transform pointA;
        public Transform pointB;
        private bool isCollided;

        [Header("Properties")]
        [SerializeField] private Color collidedColor;
        [SerializeField] private Color notCollidedColor;


        #region Properties
        public bool IsCollided { get { return isCollided; } }
        #endregion

        private void OnEnable()
        {
            OnLineCollidedStateChanged += UpdateMatColor;
        }

        private void OnDisable()
        {
            OnLineCollidedStateChanged -= UpdateMatColor;
        }

        private void Start ()
        {
            lr.positionCount = 2;
        }

        private void Update()
        {
            if (pointA == null || pointB == null) return;
            DrawLine();
        }

        public void SetPoints(Transform pointA, Transform pointB)
        {
            lr.positionCount = 2;
            this.pointA = pointA;   
            this.pointB = pointB;                  
        }
        public void DrawLine()
        {          
            lr.SetPosition(0, pointA.position);
            lr.SetPosition(1, pointB.position); 
        }

       

        public void SetIsCollided(bool isCollided)
        {
            if (this.isCollided != isCollided)
            {
                this.isCollided = isCollided;
                OnLineCollidedStateChanged?.Invoke();
            }
           
        }

        private void UpdateMatColor()
        {
            // Update color
            if (isCollided)
            {
                lr.material.SetColor("_Color", collidedColor);
            }
            else
            {
                lr.material.SetColor("_Color", notCollidedColor);
            }
        }

    }

}
