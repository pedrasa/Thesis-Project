using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowButton : MonoBehaviour
{
    public GameObject Button;
    // Start is called before the first frame update
    public void showButton()
    {
        Button.SetActive(true);
    }

    // Update is called once per frame
    public void unshowButton()
    {
        Button.SetActive(false);
    }

}
