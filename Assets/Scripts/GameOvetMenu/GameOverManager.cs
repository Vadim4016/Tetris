using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.GameOvetMenu
{
    public class GameOverManager : MonoBehaviour {

        public void PlayAgain()
        {
            SceneManager.LoadScene("Game");
        }

        public void BackToMenu()
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
