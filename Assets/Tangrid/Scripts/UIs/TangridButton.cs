using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Tangrid
{
    public class TangridButton : MonoBehaviour
    {
        [Header("References")]
        protected TextMeshProUGUI btnText;
        protected Button button;


        #region Properties
        public Button Button { get { return button; } }
        #endregion

        private void OnEnable()
        {
            button.onClick.AddListener(OnClick);
        }

        private void OnDisable()
        {
            button.onClick.RemoveListener(OnClick);
        }


        private void Awake()
        {
            button = GetComponent<Button>();
            btnText = button.GetComponentInChildren<TextMeshProUGUI>();
        }

  
        public virtual void OnClick() { }
    }
}
