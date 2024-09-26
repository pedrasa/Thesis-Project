using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LowerHigherCaseSwitch : MonoBehaviour
{
    TMP_Dropdown CaseSwitch;
    public GameObject KeyboardLower, KeyboardHigher;

    void Awake()
    {
        CaseSwitch = GetComponent<TMP_Dropdown>();
    }

    public void CaseSwitcher()
    {
        if (CaseSwitch.value == 0)
        {
            KeyboardLower.SetActive(true);
            KeyboardHigher.SetActive(false);
        }
        else
        {
            KeyboardLower.SetActive(false);
            KeyboardHigher.SetActive(true);
        }
    }
}
