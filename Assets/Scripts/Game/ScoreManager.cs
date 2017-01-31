using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Game
{
    public class ScoreManager : MonoBehaviour {

        public static int scoreOneLine = 50;
        public static int scoreTwoLine = 150;
        public static int scoreThreeLine = 300;
        public static int scoreFourLine = 1000;
        public static int currentScore = 0;

        public Text scoreText;
        public AudioClip oneLine;
        public AudioClip twoLine;
        public AudioClip threeLine;
        public AudioClip foureLine;

        public static int FullRow { get; set; }

        private AudioSource _audioSource;
        private bool _isFirstLine;

        void Start()
        {
            _audioSource = GetComponent<AudioSource>();
            _isFirstLine = true;
        }

        void Update()
        {
            UpdateScore();

            UpdateUI();
        }

        /// <summary>
        /// Logic update variable "currentScore"
        /// </summary>
        public void UpdateScore()
        {
            if (FullRow > 0)
            {
                switch (FullRow)
                {
                    case 1:
                        currentScore += scoreOneLine;

                        if (_isFirstLine)
                        {
                            _audioSource.PlayOneShot(oneLine);
                            _isFirstLine = false;
                        }
                        break;
                    case 2:
                        currentScore += scoreTwoLine;
                        _audioSource.PlayOneShot(twoLine);
                        break;
                    case 3:
                        currentScore += scoreThreeLine;
                        _audioSource.PlayOneShot(threeLine);
                        break;
                    case 4:
                        currentScore += scoreFourLine;
                        _audioSource.PlayOneShot(foureLine);
                        break;
                }

                FullRow = 0;
            }
        }

        /// <summary>
        /// Update text on canvas
        /// </summary>
        public void UpdateUI()
        {
            scoreText.text = currentScore.ToString();
        }
    }
}
