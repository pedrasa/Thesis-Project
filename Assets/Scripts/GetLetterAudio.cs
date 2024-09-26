using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;
using UnityEditor;
using UnityEngine.Networking;
using UnityEngine;
using System;

public class GetLetterAudio : MonoBehaviour
{
    public AudioClip CurrentClip; //Works!! So just set everything up!
    public GameObject Player;
    async void Start()
    {
        /*
        Player = GameObject.FindGameObjectWithTag("Player");
        // build your absolute path
        var path = Path.Combine(Application.dataPath, "Audio", "sounds", "LetterAudio.wav");
 
        var builder = new UriBuilder(path) { Scheme = Uri.UriSchemeFile }; 

        var uri = builder.ToString();
        // wait for the load and set your property
        CurrentClip = await LoadClip(uri);

        SetAudio();
        */
    }

    async public void SetupAudioLetter()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        // build your absolute path
        var path = Path.Combine(Application.persistentDataPath, "Audio", "sounds", "LetterAudio.wav");

        var builder = new UriBuilder(path) { Scheme = Uri.UriSchemeFile };

        var uri = builder.ToString();
        // wait for the load and set your property
        CurrentClip = await LoadClip(uri);

        SetAudio();
    }

    public void SetAudio()
    {
        Player.GetComponent<TalkinAnim>().SetLetter(CurrentClip);
        Player.GetComponent<TalkinAnim>().PlayLetter(); //was added delete if not working
    }

    async Task<AudioClip> LoadClip(string path)
    {
        AudioClip clip = null;
        using (UnityWebRequest uwr = UnityWebRequestMultimedia.GetAudioClip(path, AudioType.WAV))
        {
            uwr.SendWebRequest();

            // wrap tasks in try/catch, otherwise it'll fail silently
            try
            {
                while (!uwr.isDone) await Task.Delay(5);

                if (uwr.result == UnityWebRequest.Result.ConnectionError || uwr.result == UnityWebRequest.Result.ProtocolError) Debug.Log($"{uwr.error}");
                else
                {
                    clip = DownloadHandlerAudioClip.GetContent(uwr);
                }
            }
            catch (Exception err)
            {
                Debug.Log($"{err.Message}, {err.StackTrace}");
            }
        }

        return clip;
    }
}
