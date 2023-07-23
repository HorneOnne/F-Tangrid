using UnityEngine;
using UnityEngine.UI;

namespace Tangrid
{
    public class UIMainmenu : CustomCanvas
    {
        [Header("Prefabs")]
        [SerializeField] private Button soundFXBtn;



        [Header("Sprites")]
        [SerializeField] private Sprite soundFXSprite;
        [SerializeField] private Sprite muteSoundFXSprite;


        private void Start()
        {
            LoadSoundFXSUI();

            soundFXBtn.onClick.AddListener(() =>
            {
                SoundManager.Instance.isSoundFXActive = !SoundManager.Instance.isSoundFXActive;
                LoadSoundFXSUI();
                SoundManager.Instance.MuteSoundFX(!SoundManager.Instance.isSoundFXActive);
                SoundManager.Instance.PlaySound(SoundType.Button, false);
            });
        }

        private void OnDestroy()
        {
            soundFXBtn.onClick.RemoveAllListeners();
        }


        private void LoadSoundFXSUI()
        {
            if (SoundManager.Instance.isSoundFXActive)
                soundFXBtn.transform.GetChild(0).GetComponent<Image>().sprite = soundFXSprite;
            else
                soundFXBtn.transform.GetChild(0).GetComponent<Image>().sprite = muteSoundFXSprite;
        }
    }
}
