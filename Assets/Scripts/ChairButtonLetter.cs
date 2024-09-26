using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.XR.Interaction.Toolkit;

public class ChairButtonLetter : MonoBehaviour
{
    public GameObject Player;
    public Camera m_Camera;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        m_Camera = Camera.main;

    }

    //Orient the camera after all movement is completed this frame to avoid jittering
    void LateUpdate()
    {
        transform.LookAt(transform.position + m_Camera.transform.rotation * Vector3.forward,
            m_Camera.transform.rotation * Vector3.up);
    }

    public void StartLetter()
    {
        this.gameObject.GetComponent<GetLetterAudio>().SetupAudioLetter(); //Remove if does not work (Letting it go back to start outta work normally)
        //Player.GetComponent<TalkinAnim>().PlayLetter();
    }

}
