using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Game
{
    public class GridManager : MonoBehaviour {

        public static int gridWidth = 10;
        public static int gridHeight = 20;
        public static Transform[,] grid = new Transform[gridWidth, gridHeight];
        
        /// <summary>
        /// Round position of vector
        /// </summary>
        /// <param name="v">Vector2</param>
        /// <returns>rounded vector</returns>
        public static Vector2 RoundVec2(Vector2 v)
        {
            return new Vector2(Mathf.Round(v.x), Mathf.Round(v.y));
        }

        /// <summary>
        /// Check position inside of border
        /// </summary>
        /// <param name="pos">figure</param>
        /// <returns>true or false</returns>
        public static bool IsInsideBorder(Vector2 pos)
        {
            return (int)pos.x >= 0 && (int)pos.x < gridWidth && (int)pos.y >= 0;
        }

        /// <summary>
        /// Delete row
        /// </summary>
        /// <param name="y">height grid</param>
        public static void DeleteRow(int y)
        {
            for (int x = 0; x < gridWidth; ++x)
            {
                Destroy(grid[x, y].gameObject);
                grid[x, y] = null;
            }
        }

        /// <summary>
        /// Decrease row
        /// </summary>
        /// <param name="y">height grid</param>
        public static void DecreaseRow(int y)
        {
            for (int x = 0; x < gridWidth; ++x)
            {
                if (grid[x, y] != null)
                {
                    // Move one towards bottom
                    grid[x, y - 1] = grid[x, y];
                    grid[x, y] = null;

                    // Update Block position
                    grid[x, y - 1].position += new Vector3(0, -1, 0);
                }
            }
        }

        /// <summary>
        /// Decrease rows above
        /// </summary>
        /// <param name="y">height grid</param>
        public static void DecreaseRowsAbove(int y)
        {
            for (int i = y; i < gridHeight; ++i)
                DecreaseRow(i);
        }

        /// <summary>
        /// Check row on full
        /// </summary>
        /// <param name="y"></param>
        /// <returns>bool</returns>
        public static bool IsRowFull(int y)
        {
            for (int x = 0; x < gridWidth; ++x)
                if (grid[x, y] == null)
                    return false;

            ScoreManager.FullRow++;
            LinesManager.CountLines++;
            return true;
        }

        /// <summary>
        /// Delete full rows
        /// </summary>
        public static void DeleteFullRows()
        {
            for (int y = 0; y < gridHeight; ++y)
            {
                if (IsRowFull(y))
                {
                    DeleteRow(y);
                    DecreaseRowsAbove(y + 1);
                    --y;
                }
            }
        }

        /// <summary>
        /// Show Game Over
        /// </summary>
        public static void GameOver()
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
