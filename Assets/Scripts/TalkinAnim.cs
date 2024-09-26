using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Didimo.Core.Deformables;
using Didimo.Core.Inspector;
using Didimo.Core.Utility;
using Didimo.Extensions;
using Didimo;
using Newtonsoft.Json.Bson;

public class TalkinAnim : MonoBehaviour
{
    public GameObject Didimo;
    public AudioSource LetterSpeech;
    public bool talking;//change this by having the player sit down and sit up/havingthe avatar finish talking
    public float x,y,z;

    void Update()
    {
        talking = LetterSpeech.isPlaying;
        if (talking == true)
        {
            Talking();
            if (y == z)
            {
                y = 0;
                ChangeMouth();
            }
            y++;
        }
        else
        {
            StopTalking();
        }
    }

    public void SetDidimo(GameObject Di)
    {
        Didimo = Di.transform.parent.gameObject;
        x = 1f;
        Talking();
        x = 0;
        StopTalking();
    }
    public void SetLetter(AudioClip LetterAudio)
    {
        LetterSpeech.clip = LetterAudio;
    }
    public void PlayLetter()
    {
        LetterSpeech.Play();
    }

    public void ChangeMouth()
    {
        x = Random.Range(0, 0.2f);
    }

    public void Talking()
    {
        Didimo.GetComponent<LegacyAnimationPoseController>().SetWeightForPose("ARKit_jawOpen", x);
    }
    public void StopTalking()
    {
        Didimo.GetComponent<LegacyAnimationPoseController>().SetWeightForPose("ARKit_jawOpen", 0);
    }
}
