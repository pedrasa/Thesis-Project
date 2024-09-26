using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowAvatar : MonoBehaviour
{
    public GameObject Avatar;
    // Start is called before the first frame update
    public void ButtonPressFunc()
    {
        Avatar.SetActive(!Avatar.activeSelf);

    }
}
