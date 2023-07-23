using UnityEngine;

namespace Tangrid
{
    public class LevelBtn : TangridButton
    {
        [SerializeField] private Sprite lockSprite;


        public void LoadLevel(int level)
        {
            btnText.text = $"{level}";
        }

        public void Lock()
        {
            button.image.sprite = lockSprite;
            btnText.gameObject.SetActive(false);
        }

        public void UnLock()
        {        
            btnText.gameObject.SetActive(true);
        }

        public override void OnClick()
        {
            
        }
    }
}
