using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Debug = UnityEngine.Debug;

public class MatchingParenthesisPlayerController : MatchingParenthesisCubeController
{
    private Rigidbody _rigidbody;
    public int speed;
    private string theCubeIndex;
    private GameObject sphere;
    private int validStringCount = 0;
    
    private void Start()
    {
        _rigidbody = gameObject.GetComponent<Rigidbody>();
    }

    private void Update()
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

    public void checkValidString(Text checkIsBalancedString,Collider other)
    {
        Text collectedValidString;
        int openP = 0;
        int closeP = 0;
        for (int i = 0; i < checkIsBalancedString.text.Length; i++)  
        {
            if (checkIsBalancedString.text[i].ToString() == "(")
            {
                openP++;
            }
            else if (checkIsBalancedString.text[i].ToString() == ")" && openP > 0)
            {
                closeP++;
            }
        }
        if (openP == closeP)
        {
            other.gameObject.SetActive(false);
            sphere.gameObject.SetActive(false);
            validStringCount += 1;
            if (validStringCount == MatchingParenthesisCubeController.totalValidStrings)
            {
                Time.timeScale = 0;
                collectedValidString = GameObject.Find("Canvas/Text").GetComponent<Text>();
                collectedValidString.text = "You Collect " + validStringCount + " Balanced Parentheses Strings";
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        Text checkIsBalancedString;
        if (other.gameObject.CompareTag ("Collectables"))
        {
            theCubeIndex = Regex.Match(other.gameObject.name, @"\d+").Value;
            sphere = GameObject.Find("Sphere"+Int32.Parse(theCubeIndex));
            checkIsBalancedString = GameObject.Find("Sphere"+Int32.Parse(theCubeIndex)+"/Canvas/Text").GetComponent<Text>();
            checkValidString(checkIsBalancedString,other);
        }
    }
}
