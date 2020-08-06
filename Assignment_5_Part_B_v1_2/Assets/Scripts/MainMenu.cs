using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void loadMLAgentsMenu()
    {
        SceneManager.LoadScene(2);
    }
    public void loadComputationalModelsMenu()
    {
        SceneManager.LoadScene(3);
    }

    public void learntItemList()
    {
        SceneManager.LoadScene(10);
    }
    public void instructorWebsite()
    {
        Application.OpenURL("http://www.niazilab.com");
    }
    public void exitGame()
    {
        #if (UNITY_EDITOR || DEVELOPMENT_BUILD)
                Debug.Log(this.name+" : "+this.GetType()+" : "+System.Reflection.MethodBase.GetCurrentMethod().Name); 
        #endif
        #if (UNITY_EDITOR)
                UnityEditor.EditorApplication.isPlaying = false;
        #elif (UNITY_STANDALONE) 
            Application.Quit();
        #elif (UNITY_WEBGL)
            Application.OpenURL("about:blank");
        #endif
    }
}
