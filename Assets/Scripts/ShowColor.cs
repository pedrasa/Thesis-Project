using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Didimo.Core.Deformables;
using UnityEngine.UI;
using UnityEditor;

public class ShowColor : MonoBehaviour
{
    public List<Color> HairColors;
    public GameObject ColorHair1;
    /*public List<Color> ClothesColors, HairColors;
    public GameObject ColorClothes, ColorHair1, ColorHair2;*/
    public GameObject Image1, Image2, Image3;
    /*public GameObject HairAV, ClothesAV, HairAV1, ClothesAV1, HairAV2, ClothesAV2;*/
    public GameObject HairAV;

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
    void Update()
    {
        //change this to choose between preset colors
        /*Image1.GetComponent<Image>().color = ClothesColors[ColorClothes.transform.GetComponent<TMP_Dropdown>().value];
        Image2.GetComponent<Image>().color = HairColors[ColorHair1.transform.GetComponent<TMP_Dropdown>().value];
        Image3.GetComponent<Image>().color = HairColors[ColorHair2.transform.GetComponent<TMP_Dropdown>().value];
        ClothesAV.GetComponent<SkinnedMeshRenderer>().material.color = ClothesColors[ColorClothes.transform.GetComponent<TMP_Dropdown>().value];
        HairAV.GetComponent<Hair>().outerHairLayer.color = HairColors[ColorHair1.transform.GetComponent<TMP_Dropdown>().value];
        HairAV.GetComponent<Hair>().innerHairLayer.color = HairColors[ColorHair2.transform.GetComponent<TMP_Dropdown>().value];
        ClothesAV1.GetComponent<SkinnedMeshRenderer>().material.color = ClothesColors[ColorClothes.transform.GetComponent<TMP_Dropdown>().value];
        HairAV1.GetComponent<Hair>().outerHairLayer.color = HairColors[ColorHair1.transform.GetComponent<TMP_Dropdown>().value];
        HairAV1.GetComponent<Hair>().innerHairLayer.color = HairColors[ColorHair2.transform.GetComponent<TMP_Dropdown>().value];
        ClothesAV2.GetComponent<SkinnedMeshRenderer>().material.color = ClothesColors[ColorClothes.transform.GetComponent<TMP_Dropdown>().value];
        HairAV2.GetComponent<Hair>().outerHairLayer.color = HairColors[ColorHair1.transform.GetComponent<TMP_Dropdown>().value];
        HairAV2.GetComponent<Hair>().innerHairLayer.color = HairColors[ColorHair2.transform.GetComponent<TMP_Dropdown>().value];*/

        Image2.GetComponent<Image>().color = HairColors[ColorHair1.transform.GetComponent<TMP_Dropdown>().value];
        HairAV.GetComponent<Hair>().outerHairLayer.color = HairColors[ColorHair1.transform.GetComponent<TMP_Dropdown>().value];
        HairAV.GetComponent<Hair>().innerHairLayer.color = HairColors[ColorHair1.transform.GetComponent<TMP_Dropdown>().value];
    }
}
