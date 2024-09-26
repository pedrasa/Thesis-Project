using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnterKey : MonoBehaviour
{
    public GameObject Button1, Wholefield;
    public string key_code;
    public TMP_InputField key_inputfield;
    public GameObject GameManager;


    public void SetKey()
    {
        key_code = key_inputfield.text;
    }

    public void ResetName()
    {
        key_code = "";
    }

    public void Submit()
    {
        GameManager.GetComponent<GameManager>().AddString(key_code); 
        Button1.SetActive(true);
        Wholefield.SetActive(false);
    }
}
