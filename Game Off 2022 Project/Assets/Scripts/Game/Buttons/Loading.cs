using Scenes;
using UnityEngine;

namespace Game.Buttons
{
    public class Loading : MonoBehaviour
    {
        private enum Type
        {
            Game,
            System
        }

        [SerializeField] private Type exitType;

        public void ExitAction()
        {
            switch (exitType)
            {
                case Type.Game:
                    LoadingScreen.Instance.StartLoading("MainMenu");
                    break;
                case Type.System:
                    #if UNITY_EDITOR
                        UnityEditor.EditorApplication.isPlaying = false;
                    #else
                        Application.Quit(0);
                    #endif
                    break;
            }
        }
    }
}
