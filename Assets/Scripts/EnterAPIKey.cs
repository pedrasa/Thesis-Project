using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnterAPIKey : MonoBehaviour
{
    public GameObject Button1, Wholefield;
    public string APIkey_code;
    public TMP_InputField key_inputfield;
    public GameObject GameManager;


    public void SetKey()
    {
        APIkey_code = key_inputfield.text;
    }

    public void ResetName()
    {
        APIkey_code = "";
    }

    public void Submit()
    {
        GameManager.GetComponent<GameManager>().AddAPIKey(APIkey_code);
        Button1.SetActive(true);
        Wholefield.SetActive(false);
    }
}
