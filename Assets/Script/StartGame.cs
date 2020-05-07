using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public void OnButtonPress(int SceneID)
    {
        SceneManager.LoadScene(SceneID);
        Time.timeScale = 1;
    }
}
