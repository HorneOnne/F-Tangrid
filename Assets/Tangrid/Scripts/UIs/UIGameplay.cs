using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace Tangrid
{
    public class UIGameplay : CustomCanvas
    {
        [Header("Buttons")]
        [SerializeField] private Button homeBtn;
        [SerializeField] private Button replayBtn;
        [SerializeField] private Button nextLevelBtn;

        [Header("Texts")]
        [SerializeField] private TextMeshProUGUI levelText;
        [SerializeField] private TextMeshProUGUI nextLevelText;

        private void OnEnable()
        {
            GamePlayManager.OnWin += SetWinState;
        }

        private void OnDisable()
        {
            GamePlayManager.OnWin -= SetWinState;

        }

        private void Start()
        {
            levelText.text = $"LEVEL\n{GameManager.Instance.playingLevelData.level} / {GameManager.Instance.TotalGameLevel}";
            SetPlayingState();

            homeBtn.onClick.AddListener(() =>
            {
                Loader.Load(Loader.Scene.MainMenu);
                SoundManager.Instance.PlaySound(SoundType.Button, false);
            });

            replayBtn.onClick.AddListener(() =>
            {
                Loader.LoadLevel(GameManager.Instance.playingLevelData.level);
                SoundManager.Instance.PlaySound(SoundType.Button, false);
            });

            nextLevelBtn.onClick.AddListener(() =>
            {
                GameManager.Instance.NextLevel();
                Loader.LoadLevel(GameManager.Instance.playingLevelData.level);
                SoundManager.Instance.PlaySound(SoundType.Button, false);
            });
        }

        private void OnDestroy()
        {
            homeBtn.onClick.RemoveAllListeners();
            replayBtn.onClick.RemoveAllListeners();
            nextLevelBtn.onClick.RemoveAllListeners();
        }

        private void SetPlayingState()
        {
            replayBtn.gameObject.SetActive(true);
            nextLevelText.gameObject.SetActive(false);
            nextLevelBtn.gameObject.SetActive(false);
        }

        private void SetWinState()
        {
            replayBtn.gameObject.SetActive(false);
            nextLevelText.gameObject.SetActive(true);
            nextLevelBtn.gameObject.SetActive(true);
        }
    }
}
