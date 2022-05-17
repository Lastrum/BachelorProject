using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Misc
{
    public class SwitchScene : MonoBehaviour
    {
        private void Awake()
        {
            SceneManager.LoadScene("Main");
        }
    }
}
