using SampleGame;
using UnityEngine;

namespace LevelManager
{
    [RequireComponent(typeof(Canvas))]
    public class Menu : MonoBehaviour
    {
        public void OnPlayPressed()
        {
            var gManager = FindObjectOfType<GameManager>();
            gManager.LoadNextLevel();
        }

        public void OnSettingsPressed()
        {
            
        }

        public void OnCreditsPressed()
        {
            
        }

        public void OnQuitPressed()
        {
            
        }
        
        public void OnBackPressed()
        {
            
        }
    }
}
