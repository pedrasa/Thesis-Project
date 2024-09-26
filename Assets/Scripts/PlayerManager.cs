using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Didimo.Networking;
using UnityEngine.Animations;
using UnityEngine.XR.Interaction.Toolkit;
using Unity.XR.CoreUtils;

public class PlayerManager : MonoBehaviour
{
    //public GameObject GameManagerT, Teleport1, Teleport2, Teleport3, Avatar1, Avatar2, Avatar3, Player, XROrigin, Locomotion;
    public GameObject GameManagerT, Teleport1, Teleport2, Avatar1, Avatar2, Player, XROrigin, Locomotion;
    public GameObject NetworkDemo;
    public Vector3 O;

    [SerializeField]
    private ParentConstraint XR;

    void Start()
    {
        GameManagerT = GameObject.FindGameObjectWithTag("GameManager");
        XROrigin = GameManagerT.GetComponent<GameManager>().GetAvatars(1).transform.GetChild(0).gameObject;
        XR = GameManagerT.GetComponent<GameManager>().GetAvatars(1).transform.GetChild(1).gameObject.GetComponent<ParentConstraint>();
        O = new Vector3(-0.04500008f, -0.8650001f, -0.3540002f);
        Locomotion = GameObject.FindGameObjectWithTag("LS");
        Locomotion.GetComponent<LocomotionSystem>().xrOrigin = XROrigin.GetComponent<XROrigin>();
        Player = GameObject.FindGameObjectWithTag("Player");
        NetworkDemo = GameObject.FindGameObjectWithTag("ND");
        Player.GetComponent<PlayerMovementOpti>().SetAnimator();
        Player.GetComponent<PlayerMovementOpti>().ResetLine();
        Avatar1 = GameManagerT.GetComponent<GameManager>().GetAvatars(1).transform.GetChild(0).gameObject;
        Avatar2 = GameManagerT.GetComponent<GameManager>().GetAvatars(2);
        Avatar1.transform.position = Teleport1.transform.position;
        Avatar2.transform.position = Teleport2.transform.position;
        //Avatar1 = GameManagerT.GetComponent<GameManager>().GetAvatars(0);
        //Avatar2 = GameManagerT.GetComponent<GameManager>().GetAvatars(1).transform.GetChild(0).gameObject;
        //Avatar3 = GameManagerT.GetComponent<GameManager>().GetAvatars(2);
        //Avatar1.transform.position = Teleport1.transform.position;
        //Avatar2.transform.position = Teleport2.transform.position;
        //Avatar3.transform.position = Teleport3.transform.position;
        XR.SetTranslationOffset(0, O);
        NetworkDemo.GetComponent<NetworkCustomOpti>().GetChildren();
        SetGameLayerRecursive(GameManagerT.GetComponent<GameManager>().GetAvatars(1).transform.GetChild(1).gameObject, 3);
        SetGameLayerRecursive(Avatar2, 7);
        /*SetGameLayerRecursive(Avatar3, 7);
        SetGameLayerRecursive(Avatar1, 7);*/
    }

    private void SetGameLayerRecursive(GameObject _go, int _layer)
    {
        _go.layer = _layer;
        foreach (Transform child in _go.transform)
        {
            child.gameObject.layer = _layer;

            Transform _HasChildren = child.GetComponentInChildren<Transform>();
            if (_HasChildren != null)
                SetGameLayerRecursive(child.gameObject, _layer);

        }
    }

}
