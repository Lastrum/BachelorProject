using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menus
{
    public class GameOverMenu : MonoBehaviour
    {
        public void RespawnButton()
        {
            Debug.Log("Respawn");
            SceneManager.LoadScene("Main");
        }

        public void BackToMenuButton()
        {
            Debug.Log("Quit");
            //Back to Menu
        }
    }
}
