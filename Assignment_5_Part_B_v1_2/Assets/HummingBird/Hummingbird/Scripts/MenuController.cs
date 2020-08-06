using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    // Start is called before the first frame update
    public void loadPenguinScene()
    {
        SceneManager.LoadScene(2);
    }
    public void loadHummingBirdScene()
    {
        SceneManager.LoadScene(3);
    }
}
