using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public List<string> DidimoKeys;
    public List<Color> ClothesColor, HairColor;
    public List<int> Clothes,ACC;
    public string APIKey;
    private GameObject Avatar1, Avatar2, Avatar3;

    public void AddString(string x)
    {
        DidimoKeys.Add(x);
    }

    public void AddAPIKey(string x)
    {
        APIKey = x;
    }

    public void AddColor(Color x)
    {
        HairColor.Add(x);
    }

    /*public void AddColor(Color x, Color y, Color z)
    {
        ClothesColor.Add(x);
        HairColor.Add(y);
        HairColor.Add(z);
    }*/

    public void AddInt(int x)
    {
        ACC.Add(x);
    }

    /*public void AddInt(int x, int z)
    {
        Clothes.Add(x);
        ACC.Add(z);
    }*/

    /*public void AddIntB(int x)
    {
        Clothes.Add(x);
    }*/

    public void AddAvatars(GameObject x, GameObject y, GameObject z)
    {
        Avatar1 = x;
        Avatar2 = y;
        Avatar3 = z;
    }

    public GameObject GetAvatars(int x)
    {
        if (x == 0)
        {
            return Avatar1;
        }
        else if (x == 1)
        {
            return Avatar2;
        }
        else
        {
            return Avatar3;
        }
    }

    public void PlayOPTI()
    {
        DontDestroyOnLoad(this);
        SceneManager.LoadScene("Waiting Room");
    }
}
