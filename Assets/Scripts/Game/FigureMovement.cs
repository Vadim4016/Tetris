using UnityEngine;

namespace Assets.Scripts.Game
{
    [RequireComponent(typeof(AudioSource))]
    public class FigureMovement : MonoBehaviour
    {
        public AudioClip sound;

        private AudioSource source;
        private Spawner spawner;
        private float fall = 0;
        private float fallSpeed = 1;

        void Start()
        {
            source = GetComponent<AudioSource>();
            spawner = FindObjectOfType<Spawner>();

            if (!IsValidGridPos())
            {
                GridManager.GameOver();
            }
        }

        void Update()
        {
            CheckUserInput();
        }

        /// <summary>
        /// Check user input (Move and Rotation).
        /// Default fall block down each frame
        /// </summary>
        private void CheckUserInput()
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                transform.position += Vector3.left;

                if (IsValidGridPos())
                    UpdateGrid();
                else
                    transform.position += Vector3.right;
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                transform.position += Vector3.right;

                if (IsValidGridPos())
                    UpdateGrid();
                else
                    transform.position += Vector3.left;
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                transform.Rotate(0, 0, -90);

                if (IsValidGridPos())
                    UpdateGrid();
                else
                    transform.Rotate(0, 0, 90);
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow) || Time.time - fall >= fallSpeed)
            {
                transform.position += Vector3.down;
                
                if (IsValidGridPos())
                {
                    UpdateGrid();
                }
                else
                {
                    transform.position += Vector3.up;

                    GridManager.DeleteFullRows();
                    
                    spawner.SpawnNextFigure();

                    // Disable script and sound about close
                    source.PlayOneShot(sound);
                    enabled = false;
                }

                fall = Time.time;
            }
        }

        /// <summary>
        /// Check position of figure (border and another figure) 
        /// </summary>
        /// <returns></returns>
        private bool IsValidGridPos()
        {
            foreach (Transform child in transform)
            {
                Vector2 v = GridManager.RoundVec2(child.position);
                
                if (!GridManager.IsInsideBorder(v))
                    return false;
                
                if (GridManager.grid[(int)v.x, (int)v.y] != null &&
                    GridManager.grid[(int)v.x, (int)v.y].parent != transform)
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Update position figure
        /// </summary>
        private void UpdateGrid()
        {
            // Remove old children from grid
            for (int y = 0; y < GridManager.gridHeight; ++y)
                for (int x = 0; x < GridManager.gridWidth; ++x)
                    if (GridManager.grid[x, y] != null)
                        if (GridManager.grid[x, y].parent == transform)
                            GridManager.grid[x, y] = null;

            // Add new children to grid
            foreach (Transform child in transform)
            {
                Vector2 v = GridManager.RoundVec2(child.position);
                GridManager.grid[(int)v.x, (int)v.y] = child;
            }
        }
    }
}
