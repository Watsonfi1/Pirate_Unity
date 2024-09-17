using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void Map1()
    {
        SceneManager.LoadScene("Scenes/Map1");  
    }

    public void Map2()
    {
        SceneManager.LoadScene("Scenes/Map2");  
    }

    public void LoadNextInBuild()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
