using System.Collections;
using System.Collections.Generic;
using Didimo.Networking;
using UnityEngine.XR;
using UnityEngine;

public class ButtonClick : MonoBehaviour
{
    public GameObject Network;
    public int x;

    public void ClickOpti()
    {
        Network.GetComponent<NetworkCustomOpti>().DidimoButton(x);
        this.gameObject.SetActive(false);
    }

}
