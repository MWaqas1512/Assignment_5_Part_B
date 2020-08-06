using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;

public class MatchingParenthesisCubeController : MonoBehaviour
{
    public GameObject theCube;
    public GameObject theSphere;
    public float maxPos= 0f;
    public float minPos = 30f;
    private string createdRandomString;
    private int thestringlength;
    private static int totalValidStringsLength;
    private Vector3 theNewPos;
    public void spawn()
    {
        List<int> validStringsIndexes = new List<int>();
        
        
        setValidStringsIndexes(validStringsIndexes);
        createCubes(validStringsIndexes);
    }

    private void setValidStringsIndexes(List<int> validStringsIndexes)
    {
        int validStringIndex;
        int i = 0;
        while (i<totalValidStringsLength)
        {
            validStringIndex = Random.Range(0, 52);
            if (!validStringsIndexes.Contains(validStringIndex) || validStringsIndexes.Count == 0)
            {
                validStringsIndexes.Add(validStringIndex);
                i++;
            }
        }
    }

    private void createCubes(List<int> validStringsIndexes)
    {
        Text randomString;
        int cubeNumber = 0;
        
        while (cubeNumber<52)
        {
            int openP = 0;
            createdRandomString = "";
            float theXPosition = Random.Range(minPos, maxPos);
            float theZPosition = Random.Range(minPos, maxPos);
            theNewPos= new Vector3 (theXPosition,0.5f,theZPosition);
            if (Physics.CheckSphere(theNewPos, 0.36f))
            {
                continue;
            }
            else
            {
                GameObject sphere = Instantiate(theSphere);
                GameObject cube = Instantiate(theCube);
                sphere.name = "Sphere" + cubeNumber;
                cube.name = "Cube" + cubeNumber;
                sphere.transform.position = new Vector3(theXPosition,1.1f,theZPosition);
                cube.transform.position = theNewPos;
                randomString = GameObject.Find("Sphere"+cubeNumber+"/Canvas/Text").GetComponent<Text>();
                string[] characters = new string[] { "x", "w", "3","(",")"};
                thestringlength = Random.Range(9, 16);
                if (validStringsIndexes.Contains(cubeNumber))
                {
                    int aa = 0;
                    while( aa < thestringlength)
                    {
                        
                        int rand = Random.Range(0, 5);
                        if (rand == 3)
                        {
                            if (aa == (thestringlength - 1))
                            {
                                
                            }
                            else
                            {
                                if (openP == (thestringlength - aa))
                                {
                                    for (int i = 0; i < openP; i++)
                                    {
                                        createdRandomString = createdRandomString + characters[4];
                                        openP--;
                                        aa++; 
                                    }
                                }
                                else
                                {
                                    createdRandomString = createdRandomString + characters[3];
                                    openP++;
                                    aa++;   
                                    if (openP > (thestringlength - aa))
                                    {
                                        createdRandomString = createdRandomString.Remove(createdRandomString.Length - 1,1);
                                        aa--;
                                        openP--;
                                        for (int i = 0; i < openP; i++)
                                        {
                                            createdRandomString = createdRandomString + characters[4];
                                            openP--;
                                            aa++; 
                                        }
                                    }
                                }   
                            }
                        }
                        else if(rand == 4)
                        {
                            if (openP > 0)
                            {
                                if (openP == (thestringlength - aa))
                                {
                                    for (int i = 0; i < openP; i++)
                                    {
                                        createdRandomString = createdRandomString + characters[4];
                                        openP--;
                                        aa++; 
                                    }
                                }
                                else
                                {
                                    createdRandomString = createdRandomString + characters[4];
                                    openP--;
                                    aa++;
                                }
                            }
                            else
                            {
                                
                            }
                        }
                        else
                        {
                            if (openP == (thestringlength - aa))
                            {
                                for (int i = 0; i < openP; i++)
                                {
                                    createdRandomString = createdRandomString + characters[4];
                                    openP--;
                                    aa++; 
                                }
                            }
                            else
                            {
                                createdRandomString = createdRandomString + characters[rand];
                                aa++;
                                if (openP > (thestringlength - aa))
                                {
                                    createdRandomString = createdRandomString.Remove(createdRandomString.Length - 1,1);
                                    aa--;
                                    for (int i = 0; i < openP; i++)
                                    {
                                        createdRandomString = createdRandomString + characters[4];
                                        openP--;
                                        aa++; 
                                    }
                                }
                            }
                        }
                    }

                }
                else
                {
                    for (int j = 0; j < thestringlength; j++) 
                    {
                        createdRandomString = createdRandomString + characters[Random.Range(0, characters.Length)]; 
                    }   
                }
                randomString.text = createdRandomString;
                cubeNumber++;
            }
        }
    }

    public static int _totalValidStrings;
    protected static int totalValidStrings
    {
        get
        { 
            return _totalValidStrings;
        }
        private  set
        {
            _totalValidStrings = value;
        }

    }

    void Start()
    {
        totalValidStringsLength = 53/3;
        MatchingParenthesisCubeController.totalValidStrings = totalValidStringsLength;
        spawn();
    }
}