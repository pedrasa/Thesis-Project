using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPress : MonoBehaviour
{
    public GameObject LastCategory;
    public GameObject NextCategory;
    // Start is called before the first frame update
    public void ButtonPressFunc()
    {
        NextCategory.SetActive(true);
        LastCategory.SetActive(false);

    }
}
 