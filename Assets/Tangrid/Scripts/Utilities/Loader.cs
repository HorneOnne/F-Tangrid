using UnityEngine.SceneManagement;

namespace Tangrid
{
    public static class Loader
    {
        public enum Scene
        {
            MainMenu,
            Level_01,
            Level_02,
            Level_03,
            Level_04,
            Level_05,
            Level_06,
            Level_07,
            Level_08,
            Level_09,
            Level_10,
        }

        private static Scene targetScene;

        public static void Load(Scene targetScene, System.Action afterLoadScene = null)
        {
            Loader.targetScene = targetScene;
            SceneManager.LoadScene(Loader.targetScene.ToString());
        }

        public static void LoadLevel(int level, System.Action afterLoadScene = null)
        {
            Loader.targetScene = GetSceneLevel(level);
            SceneManager.LoadScene(targetScene.ToString());
        }

        public static Scene GetSceneLevel(int level)
        {
            switch (level)
            {
                default: return Scene.Level_01;
                case 1: return Scene.Level_01;
                case 2: return Scene.Level_02;
                case 3: return Scene.Level_03;
                case 4: return Scene.Level_04;
                case 5: return Scene.Level_05;
                case 6: return Scene.Level_06;
                case 7: return Scene.Level_07;
                case 8: return Scene.Level_08;
                case 9: return Scene.Level_09;
                case 10: return Scene.Level_10;
            }
        }
    }
}
