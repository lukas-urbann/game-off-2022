using UnityEngine;

namespace Game.Utility
{
    public class BooleanChecker : MonoBehaviour
    {
        // ReSharper disable once InconsistentNaming
        public static bool CheckSFXController()
        {
            if (Singletons.SFXController.Instance != null)
                return true;
            
            return false;
        }

        public static bool CheckSaveStatus()
        {
            
            
            return false; //Check
        }
    }
}
