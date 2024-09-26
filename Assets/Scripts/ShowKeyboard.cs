using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowKeyboard : MonoBehaviour
{
    public GameObject keyboard;

    public void Showkeyboard()
    {
        keyboard.SetActive(true);
    }

    public void Hidekeyboard()
    {
        keyboard.SetActive(false);
    }
}
