using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene : MonoBehaviour
{
   

    public void MainScene()
    {
        SceneManager.LoadScene(0);
    }
    public void extremeScene()
    {
        SceneManager.LoadScene(1);
    }
    
}
