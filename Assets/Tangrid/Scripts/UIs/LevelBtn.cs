using UnityEngine;
using UnityEngine.UI;

namespace Tangrid
{
    public class LevelBtn : TangridButton
    {
        [SerializeField] private Image iconImage;
        [SerializeField] private Sprite lockSprite;
        private LevelData levelData;

        public void UpdateUI(LevelData levelData)
        {
            iconImage.sprite = lockSprite;
            this.levelData = levelData; 
            btnText.text = $"{this.levelData.level}";

            if (levelData.isLocking)
                Lock();
            else
                UnLock();
        }

        public void Lock()
        {
            iconImage.enabled = true;
            btnText.gameObject.SetActive(false);
        }

        public void UnLock()
        {
            iconImage.enabled = false;
            btnText.gameObject.SetActive(true);
        }

        public override void OnClick()
        {
            if (levelData.isLocking) return;
            SoundManager.Instance.PlaySound(SoundType.Button, false);
            GameManager.Instance.playingLevelData = levelData;
            Loader.LoadLevel(levelData.level);
        }
    }
}
