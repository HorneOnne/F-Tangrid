using UnityEngine;

namespace Tangrid
{
    public class Line : MonoBehaviour
    {
        public LineRenderer lr;
        public Transform pointA;
        public Transform pointB;
        public bool isCollided;

        [Header("Properties")]
        [SerializeField] private Color collidedColor;
        [SerializeField] private Color notCollidedColor;

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

            // Update color
            if (isCollided)
            {
                lr.material.SetColor("_Color", collidedColor);
                Debug.Log("Uopdate collidedColor");
            }
            else
            {
                lr.material.SetColor("_Color", notCollidedColor);
                Debug.Log("Uopdate notCollidedColor");
            }
        }

       
    }

}
