using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    public Color Color1, Color2, Color3;
    public GameObject Avatar1, Avatar2, Avatar3;
    public List<Material> ClothesMaterial;
    public int x,y,z;
    private GameObject Avatar1Clothing, Avatar2Clothing, Avatar3Clothing;
    public GameObject GameManagerT;

    void Start()
    {
        Avatar1Clothing = Avatar1.transform.GetChild(0).transform.GetChild(7).gameObject;
        Avatar2Clothing = Avatar2.transform.GetChild(0).transform.GetChild(7).gameObject;
        Avatar3Clothing = Avatar3.transform.GetChild(0).transform.GetChild(7).gameObject;
        GameManagerT = GameObject.FindGameObjectWithTag("GameManager");
        x = GameManagerT.GetComponent<GameManager>().Clothes[0];
        y = GameManagerT.GetComponent<GameManager>().Clothes[1];
        z = GameManagerT.GetComponent<GameManager>().Clothes[2];
        Color1 = GameManagerT.GetComponent<GameManager>().ClothesColor[0];
        Color2 = GameManagerT.GetComponent<GameManager>().ClothesColor[1];
        Color3 = GameManagerT.GetComponent<GameManager>().ClothesColor[2];
    }

    public void ChangeAvatar()
    {
        Avatar1Clothing = Avatar1.transform.GetChild(0).transform.GetChild(16).gameObject;
        Avatar1Clothing.GetComponent<SkinnedMeshRenderer>().material = ClothesMaterial[x];
        Avatar2Clothing = Avatar2.transform.GetChild(0).transform.GetChild(16).gameObject;
        Avatar2Clothing.GetComponent<SkinnedMeshRenderer>().material = ClothesMaterial[y];
        Avatar3Clothing = Avatar3.transform.GetChild(0).transform.GetChild(16).gameObject;
        Avatar3Clothing.GetComponent<SkinnedMeshRenderer>().material = ClothesMaterial[z];
        Avatar1Clothing.GetComponent<SkinnedMeshRenderer>().material.color = Color1;
        Avatar2Clothing.GetComponent<SkinnedMeshRenderer>().material.color = Color2;
        Avatar3Clothing.GetComponent<SkinnedMeshRenderer>().material.color = Color3;
    }
}
