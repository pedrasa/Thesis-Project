using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;
using UnityEditor;
using UnityEngine.Networking;
using UnityEngine;
using System;
using TMPro;

public class KeyGetter : MonoBehaviour
{
    public TMP_InputField InputField;
    public GameObject Text;
    async public void SetupKey(string key)
    {
        // build your absolute path
        // wait for the load and set your property
        string path = Application.persistentDataPath + "/Keys" +"/"+key+ ".txt";
        Debug.Log(path);
        StreamReader reader = new StreamReader(path);

        while (!reader.EndOfStream)
        {
            string inp_ln = reader.ReadLine();
            InputField.text = inp_ln;
        }
        Debug.Log(path);
        Debug.Log(reader.ReadToEnd());

        reader.Close();
    }
}
