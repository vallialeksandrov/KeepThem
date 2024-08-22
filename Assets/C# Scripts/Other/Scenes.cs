using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenes : MonoBehaviour
{
    private void Start() => Time.timeScale = 1;

    public void ChangeScenes(int numberScenes) => SceneManager.LoadScene(numberScenes);

    public void Restart() => SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    public void Quit() => Application.Quit();
}
