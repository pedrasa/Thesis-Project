using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Didimo.Core.Deformables;
using UnityEngine.UI;
using Unity.VisualScripting;

public class ShowClothes : MonoBehaviour
{
    public List<Material> AvatarClothesExamples;
    public List<GameObject> AvatarExamples;
    public GameObject ClothesClothing, ClothesClothing1, ClothesClothing2, ClothesChooser;
    int x, previousValue;

    public void Start()
    {
        AvatarExamples[0].GameObject().SetActive(true);
        AvatarExamples[1].GameObject().SetActive(false);
        AvatarExamples[2].GameObject().SetActive(false);
        ClothesClothing.GetComponent<SkinnedMeshRenderer>().material = AvatarClothesExamples[0];
    }
    public void addX()
    {
        x = ClothesChooser.GetComponent<TMP_Dropdown>().value;
        AvatarExamples[previousValue].GameObject().SetActive(false);
        AvatarExamples[x].GameObject().SetActive(true);
        ClothesClothing.GetComponent<SkinnedMeshRenderer>().material = AvatarClothesExamples[ClothesChooser.GetComponent<TMP_Dropdown>().value];
        ClothesClothing1.GetComponent<SkinnedMeshRenderer>().material = AvatarClothesExamples[ClothesChooser.GetComponent<TMP_Dropdown>().value];
        ClothesClothing2.GetComponent<SkinnedMeshRenderer>().material = AvatarClothesExamples[ClothesChooser.GetComponent<TMP_Dropdown>().value];
        previousValue = x;
    }
}
