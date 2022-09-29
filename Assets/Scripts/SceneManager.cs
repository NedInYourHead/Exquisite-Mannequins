using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    public void RobertsScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }

    public void JoesScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(2);
    }

    public void ReturnToMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
