using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MLAgentsMenu : MonoBehaviour
{
    public void loadPenguin()
    {
        SceneManager.LoadScene(4);
    }
    public void loadHummingBird()
    {
        SceneManager.LoadScene(5);
    }
    
    public void returnToMainMenu()
    {
        SceneManager.LoadScene(1);
    }
}
