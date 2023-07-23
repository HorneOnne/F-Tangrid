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
           
        }
    }
}
