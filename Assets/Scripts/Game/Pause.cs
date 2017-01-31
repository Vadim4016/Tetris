using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Game
{
    public class Pause : MonoBehaviour
    {
        public Transform canvas;
        
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                ToggleShowCanvas();
            }
        }

        private void ToggleShowCanvas()
        {
            if (canvas.gameObject.activeInHierarchy)
            {
                canvas.gameObject.SetActive(false);
                Time.timeScale = 1;
            }
            else
            {
                canvas.gameObject.SetActive(true);
                Time.timeScale = 0;
            }
        }

        public void Continue()
        {
            ToggleShowCanvas();
        }

        public void ExitToMenu()
        {
            SceneManager.LoadScene("Menu");            
        }

        public void ExitToWindows()
        {
            Application.Quit();
        }
    }
}
