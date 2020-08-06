using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class learntItemList : MonoBehaviour
{
    public Canvas myCanvas;
    public Text list1;
    public Text list2;
 
    List<string> learnt_item;
 
    private bool callMe;
 
 
 
    // Use this for initialization
    void Start () {
        learnt_item = new List<string>();
 
        learnt_item.Add("Finite Automata");
        learnt_item.Add ("Regular Expression");
        learnt_item.Add ("Deterministic finite automata");
        learnt_item.Add ("Non-Deterministic finite automata");
        learnt_item.Add ("Properties of regular languages");
        learnt_item.Add ("Application of finite automata");
        learnt_item.Add ("Context free Grammars");
        learnt_item.Add ("Pushdown Automata");
        
        
        learnt_item.Add("Grammar & equivalence");
        learnt_item.Add ("Properties of context-free language");
        learnt_item.Add ("Deterministic Parsing");
        learnt_item.Add ("Turing Machine");
        learnt_item.Add ("Variation of turing machine");
        learnt_item.Add ("Decidable problems and Recursive language");
        learnt_item.Add ("Halting and not halting Problems");
        learnt_item.Add ("How to use Unity with C#");
        AddText();
    }
    
    void AddText()
    {
        for (int j = 0; j < (learnt_item.Count/2); j++)
        {
            list1.text += (j +1)+" "+learnt_item[j]+"\n";
        }
        for (int j = (learnt_item.Count/2); j < learnt_item.Count; j++)
        {
            list2.text += (j +1)+" "+learnt_item[j]+"\n";
        }
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                SceneManager.LoadScene(1);
            }
        }
    }
}