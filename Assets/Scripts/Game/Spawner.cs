using UnityEngine;

namespace Assets.Scripts.Game
{
    public class Spawner : MonoBehaviour
    {
        public GameObject[] figure;
        public Vector2 previewPosition;

        private GameObject _figure;
        private GameObject _nextFigure;
        private bool _IsStartedGame;

        void Start ()
        {
            previewPosition = transform.FindChild("PreviewPos").position;
            SpawnNextFigure();
        }
	
        /// <summary>
        /// Spanw figure
        /// </summary>
        public void SpawnNextFigure()
        {
            if (!_IsStartedGame)
            {
                _IsStartedGame = true;

                _figure = (GameObject)Instantiate(GetRandomFigure(), transform.position, Quaternion.identity);
                _nextFigure = (GameObject)Instantiate(GetRandomFigure(), previewPosition, Quaternion.identity);
                _nextFigure.GetComponent<FigureMovement>().enabled = false;
            }
            else
            {
                _nextFigure.transform.position = transform.position;
                _figure = _nextFigure;
                _figure.GetComponent<FigureMovement>().enabled = true;

                _nextFigure = (GameObject)Instantiate(GetRandomFigure(), previewPosition, Quaternion.identity);
                _nextFigure.GetComponent<FigureMovement>().enabled = false;
            }
        }

        /// <summary>
        /// Get random figure
        /// </summary>
        /// <returns>Return figure</returns>
        private GameObject GetRandomFigure()
        {
            int i = Random.Range(0, figure.Length);
            return figure[i];
        }
    }
}
