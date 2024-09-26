using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Didimo.Networking;
using UnityEngine.XR.Interaction.Toolkit;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleport : MonoBehaviour
{
    public GameObject Player, WaitingRoom;
    public GameObject TeleportGO;
    public GameObject NetworkDemo;

    void Start()
    {
        NetworkDemo = GameObject.FindGameObjectWithTag("ND");
    }
    public void ButtonPressFunc()
    {
        NetworkDemo.GetComponent<NetworkCustomOpti>().GetChildren();
        Player.transform.position = TeleportGO.transform.position;
        Destroy(WaitingRoom);
    }
}
