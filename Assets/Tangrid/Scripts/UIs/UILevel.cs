using UnityEngine;
using UnityEngine.UI;

namespace Tangrid
{
    public class UILevel : CustomCanvas
    {
        [Header("Prefabs")]
        [SerializeField] private LevelBtn levelBtnPrefab;

        [Header("References")]
        [SerializeField] private Transform levelRoot;


        private void Start()
        {
            LoadLevelUI();
        }


        private void LoadLevelUI()
        {
            for (int i = 0; i < GameManager.Instance.TotalGameLevel; i++)
            {
                LevelBtn levelBtn = Instantiate(levelBtnPrefab, levelRoot);
                levelBtn.UpdateUI(GameManager.Instance.levelData[i]);
            }
        }
    }
}
