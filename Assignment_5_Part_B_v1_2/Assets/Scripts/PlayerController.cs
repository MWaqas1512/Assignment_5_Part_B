using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MatchingParenthesisCubeController
{
    private Rigidbody _rigidbody;
    public int speed;
    private string theCubeIndex;
    private GameObject sphere;
    private int palindromeCount = 0;
    private int qq;
    
    private void Start()
    {
        _rigidbody = gameObject.GetComponent<Rigidbody>();
    }
    
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                SceneManager.LoadScene(3);
            }
        }
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal,0.2f,moveVertical);
        _rigidbody.AddForce(movement * speed);
    }

    public void checkPalindrome(Text checkIsPalindrome,Collider other)
    {
        string revs = "";
        for (int i = checkIsPalindrome.text.Length - 1; i >= 0; i--)  
        {
            revs += checkIsPalindrome.text[i].ToString();
        }
        if (revs == checkIsPalindrome.text)
        {
            other.gameObject.SetActive(false);
            sphere.gameObject.SetActive(false);
            palindromeCount += 1;
           /* if (palindromeCount == MatchingParenthesisCubeController.totalPalindromes)
            {
                collectedPalindrome = GameObject.Find("Canvas/Text").GetComponent<Text>();
                collectedPalindrome.text = "You Collect " + palindromeCount + " Palindromes";
            }*/
        }
    }
    void OnTriggerEnter(Collider other)
    {
        Text checkIsPalindrome;
        if (other.gameObject.CompareTag ("Collectables"))
        {
            theCubeIndex = Regex.Match(other.gameObject.name, @"\d+").Value;
            sphere = GameObject.Find("Sphere"+Int32.Parse(theCubeIndex));
            checkIsPalindrome = GameObject.Find("Sphere"+Int32.Parse(theCubeIndex)+"/Canvas/Text").GetComponent<Text>();
            //var reversed = new string(checkIsPalindrome.text.Reverse().ToArray());
            
            checkPalindrome(checkIsPalindrome,other);
            
            // if (checkIsPalindrome.text == reversed)
            // {
            //     sphere.gameObject.SetActive(false);
            //     other.gameObject.SetActive (false);
            //     palindromeCount += 1;
            //     if (palindromeCount == PositionController.totalPalindromes)
            //     {
            //         collectedPalindrome = GameObject.Find("Canvas/Text").GetComponent<Text>();
            //         collectedPalindrome.text = "You Collect " + palindromeCount + " Palindromes";
            //     }
            // }
        }
    }
}
