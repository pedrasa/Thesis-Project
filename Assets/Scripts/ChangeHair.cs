using Didimo.Core.Deformables;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class ChangeHair : MonoBehaviour
{
    /*public GameObject Avatar1, Avatar2, Avatar3;
    public Color Color1, Color2, Color3, Color4, Color5, Color6;
    private GameObject Avatar1Hair, Avatar2Hair, Avatar3Hair;
    public int Bald1, Bald2, Bald3;*/
    public GameObject Avatar1, Avatar2;
    public Color Color1, Color2;
    private GameObject Avatar1Hair, Avatar2Hair;
    public int Bald1;
    ConstraintSource constraintSource;
    public GameObject GameManagerT;
    void Start()
    {
        Avatar1Hair = Avatar1.transform.GetChild(0).transform.GetChild(8).gameObject;
        Avatar2Hair = Avatar2.transform.GetChild(0).transform.GetChild(8).gameObject;
        //Avatar3Hair = Avatar3.transform.GetChild(0).transform.GetChild(8).gameObject;
        GameManagerT = GameObject.FindGameObjectWithTag("GameManager");
        Color1 = GameManagerT.GetComponent<GameManager>().HairColor[0];
        Color2 = GameManagerT.GetComponent<GameManager>().HairColor[0];
        /*Color2 = GameManagerT.GetComponent<GameManager>().HairColor[1];
        Color3 = GameManagerT.GetComponent<GameManager>().HairColor[2];
        Color4 = GameManagerT.GetComponent<GameManager>().HairColor[3];
        Color5 = GameManagerT.GetComponent<GameManager>().HairColor[4];
        Color6 = GameManagerT.GetComponent<GameManager>().HairColor[5];*/
    }

    public void ChangeC()
    {
        /*if (Bald3 != 1)
        {
            Avatar3Hair.GetComponent<Hair>().outerHairLayer.color = Color5;
            Avatar3Hair.GetComponent<Hair>().innerHairLayer.color = Color6;
        }
        if (Bald2 != 1)
        {
            Avatar2Hair.GetComponent<Hair>().outerHairLayer.color = Color3;
            Avatar2Hair.GetComponent<Hair>().innerHairLayer.color = Color4;
        }*/
        if (Bald1 != 1)
        {
            Avatar1Hair.GetComponent<Hair>().outerHairLayer.color = Color1;
            Avatar1Hair.GetComponent<Hair>().innerHairLayer.color = Color2;
            Avatar2Hair.GetComponent<Hair>().outerHairLayer.color = Color1;
            Avatar2Hair.GetComponent<Hair>().innerHairLayer.color = Color2;
        }
    }

    /*public void ChangeAvatar(int x,int y, int z)
    {
        Bald1 = x;
        Bald2 = y;
        Bald3 = z;
        Avatar1Hair = Avatar1.transform.GetChild(0).transform.GetChild(17).gameObject;
        Avatar2Hair = Avatar2.transform.GetChild(0).transform.GetChild(17).gameObject;
        Avatar3Hair = Avatar3.transform.GetChild(0).transform.GetChild(17).gameObject;
        ChangeC();
    }*/

    public void ChangeAvatar(int x)
    {
        Bald1 = x;
        Avatar1Hair = Avatar1.transform.GetChild(0).transform.GetChild(17).gameObject;
        Avatar2Hair = Avatar2.transform.GetChild(0).transform.GetChild(17).gameObject;
        ChangeC();
    }
}
