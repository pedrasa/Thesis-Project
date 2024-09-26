using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SaveKeys : MonoBehaviour
{
    // Drag the Input Field into this.
    public TMP_InputField key_inputfield;
    public string KeyName;

    // Use a button UI that calls this function that saves the input text into Player Prefs.
    public void OnButtonClickAPI()
    {
        PlayerPrefs.SetString(KeyName, key_inputfield.text);
    }

    // If the "SomeSaveName" exists when this script is called on start, it will put the text into the inputfield.
    private void Start()
    {
        if (PlayerPrefs.HasKey(KeyName))
        {
            key_inputfield.text = PlayerPrefs.GetString(KeyName);
        }
    }
}
