using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Computational_MainMenu : MonoBehaviour
{
    public void loadPalindrome()
    {
        SceneManager.LoadScene(6);
    }
    public void loadMatchingParenthesis()
    {
        SceneManager.LoadScene(7);
    }

    public void palindromeLanguageChoosen()
    {
        SceneManager.LoadScene(8);
    }
    
    public void balancedParenthesesLanguageChoosen()
    {
        SceneManager.LoadScene(9);
    }
    
    public void returnToMainMenu()
    {
        SceneManager.LoadScene(1);
    }
}
