using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Global
{
    public class MainMenu : MonoBehaviour
    {
        public void LoadGame(int index)
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(index);
        }

        public void QuitGame()
        {
            Application.Quit();
        }

        public void ToogleVisible(GameObject gameObject)
        {
            gameObject.SetActive(!gameObject.activeSelf);
        }
    }
}
