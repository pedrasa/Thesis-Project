using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnterCCH : MonoBehaviour
{
    public GameObject GameManager;
    public GameObject Button1, Wholefield;
    public GameObject ColorHair1;
    /*public GameObject ColorClothes, ColorHair1, ColorHair2;
    public TMP_Dropdown BClothes;
    public List<Color> ClothesColors, HairColors;*/
    public List<Color> HairColors;

    void Start()
    {
        /*ClothesColors.Add(Color.white);
        ClothesColors.Add(Color.blue);
        ClothesColors.Add(Color.red);
        ClothesColors.Add(Color.black);
        ClothesColors.Add(Color.green);*/
        HairColors.Add(new Color(0.98f, 0.94f, 0.74f));
        HairColors.Add(new Color(0.30f, 0.17f, 0.10f));
        HairColors.Add(new Color(0.64f, 0.16f, 0.16f));
        HairColors.Add(Color.black);
        HairColors.Add(new Color(0.6f, 0.6f, 0.6f));
        HairColors.Add(new Color(0.8f, 0.8f, 0.8f));
    }
    public void Confirm()
    {
        /*GameManager.GetComponent<GameManager>().AddIntB(BClothes.value);
        GameManager.GetComponent<GameManager>().AddColor(ClothesColors[ColorClothes.transform.GetComponent<TMP_Dropdown>().value], HairColors[ColorHair1.transform.GetComponent<TMP_Dropdown>().value], HairColors[ColorHair2.transform.GetComponent<TMP_Dropdown>().value]);*/
        GameManager.GetComponent<GameManager>().AddColor(HairColors[ColorHair1.transform.GetComponent<TMP_Dropdown>().value]);

        Button1.SetActive(true);
        Wholefield.SetActive(false);
    }
}
