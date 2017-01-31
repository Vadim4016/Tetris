using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Game
{
    public class LinesManager : MonoBehaviour
    {
        [SerializeField]
        private Text textLines;

        public static int CountLines { get; set; }

        void Update()
        {
            UpdateUI();
        }

        /// <summary>
        /// Update text on canvas
        /// </summary>
        public void UpdateUI()
        {
            textLines.text = CountLines.ToString();
        }
    }
}
