using UnityEngine;

namespace Tangrid
{
    public class InputHandler : MonoBehaviour
    {
        private Transform dragObject = null;
        private Vector3 offset;
        private Camera mainCam;
        [SerializeField] private LayerMask nodeLayer;
        private void Start()
        {
            mainCam = Camera.main;  
        }

        private void Update()
        {
            if(Input.GetMouseButtonDown(0))
            {
                RaycastHit2D hit = Physics2D.Raycast(mainCam.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 100, nodeLayer);
                if(hit)
                {
                    dragObject = hit.transform;

                    offset = dragObject.position - mainCam.ScreenToWorldPoint(Input.mousePosition);
                }
            }
            else if(Input.GetMouseButtonUp(0))
            {
                dragObject = null;
            }

            if (dragObject != null)
            {
                dragObject.position = (Vector2)mainCam.ScreenToWorldPoint(Input.mousePosition);
            }
        }
    }

}
