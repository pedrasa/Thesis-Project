using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.XR.Interaction.Toolkit;

public class ChairButtonOpti : MonoBehaviour
{
    public GameObject ButtonSit, ButtonStand;
    public GameObject Tele1, Tele2;
    public GameObject Player, Locomotion, XROrigin, Avatar, PlayerManager;
    public GameObject GameManagerT;
    public Camera m_Camera;
    public Vector3 N, O;


    [SerializeField]
    private ParentConstraint XR;



    void Start()
    {
        GameManagerT = GameObject.FindGameObjectWithTag("GameManager");
        PlayerManager = GameObject.FindGameObjectWithTag("PlayerManager");
        Player = GameObject.FindGameObjectWithTag("Player");
        Avatar = GameManagerT.GetComponent<GameManager>().GetAvatars(1).transform.GetChild(1).gameObject;
        XROrigin = GameManagerT.GetComponent<GameManager>().GetAvatars(1).transform.GetChild(0).gameObject;
        m_Camera = Camera.main;
        Locomotion = GameObject.FindGameObjectWithTag("LS");
        XR = Avatar.GetComponent<ParentConstraint>();
        N = new Vector3(-0.04500008f, 0.13f, -0.3540002f);
        O = new Vector3(-0.04500008f, -0.8650001f, -0.3540002f);

    }

    //Orient the camera after all movement is completed this frame to avoid jittering
    void LateUpdate()
    {
        transform.LookAt(transform.position + m_Camera.transform.rotation * Vector3.forward,
            m_Camera.transform.rotation * Vector3.up);
    }

    public void buttonSit()
    {

        XROrigin.transform.position = Tele1.transform.position;
        XROrigin.transform.rotation = Tele2.transform.rotation;
        XR.SetTranslationOffset(0, N);
        Avatar.SetActive(false);
        Player.GetComponent<PlayerMovementOpti>().enabled = false;
        Locomotion.GetComponent<ActionBasedContinuousMoveProvider>().enabled = false;
    }

    public void buttonStand()
    {
        XROrigin.transform.position = Tele2.transform.position;
        XROrigin.transform.rotation = Tele2.transform.rotation;
        XR.SetTranslationOffset(0, O);
        Avatar.SetActive(true);
        Player.GetComponent<PlayerMovementOpti>().enabled = true;
        Locomotion.GetComponent<ActionBasedContinuousMoveProvider>().enabled = true;
    }
}
