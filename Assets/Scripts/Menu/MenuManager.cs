using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Menu
{
    public class MenuManager : MonoBehaviour {
        
        public void StartGame(string lavel)
        {
            SceneManager.LoadScene("Game");
        }

        public void Exit()
        {
            Application.Quit();
        }

        public void Continue()
        {
            print("Continue");
        }
    }
}
