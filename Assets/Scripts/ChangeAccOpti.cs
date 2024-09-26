using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class ChangeAccOpti : MonoBehaviour
{
    public GameObject Avatar1, Avatar2;
    public List<GameObject> Accesories = new List<GameObject>();
    public int x, y;
    private GameObject Avatar1Bones, Avatar2Bones;
    ConstraintSource constraintSource;
    public GameObject GameManagerT;

    // Update is called once per frame
    void Start()
    {
        int z = 0;
        foreach (GameObject Acc in GameObject.FindGameObjectsWithTag("Acc"))
        {
            Accesories.Add(Acc);
            Accesories[z].SetActive(false);
            z++;
        }
        Avatar1Bones = Avatar1.transform.GetChild(0).transform.GetChild(0).gameObject;
        Avatar2Bones = Avatar2.transform.GetChild(0).transform.GetChild(0).gameObject;
        GameManagerT = GameObject.FindGameObjectWithTag("GameManager");
        x = GameManagerT.GetComponent<GameManager>().ACC[0];
        //y = GameManagerT.GetComponent<GameManager>().ACC[1];
    }

    /*public void ChangeAccessories(int x, int y)
    {
        if (x >= 1)
        {
            Accesories[x - 1].SetActive(!(Accesories[x - 1].activeSelf));
        }
        if (y >= 1)
        {
            Accesories[y].SetActive(!(Accesories[y].activeSelf));
        }
    }*/

    public void ChangeAccessories(int x)
    {
        if (x >= 1)
        {
            Accesories[x - 1].SetActive(!(Accesories[x - 1].activeSelf));
            Accesories[x].SetActive(!(Accesories[x].activeSelf));
        }
    }

    public void ChangeAvatar()
    {
        Avatar1Bones = Avatar1.transform.GetChild(0).transform.GetChild(9).gameObject;
        Avatar2Bones = Avatar2.transform.GetChild(0).transform.GetChild(9).gameObject;

        constraintSource.sourceTransform = Avatar2Bones.transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).transform.GetChild(0);
        constraintSource.weight = 1;
        Accesories[0].GetComponent<ParentConstraint>().SetSource(0, constraintSource);
        Debug.Log("Was Here");
        constraintSource.sourceTransform = Avatar1Bones.transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).transform.GetChild(0);
        constraintSource.weight = 1;
        Accesories[1].GetComponent<ParentConstraint>().SetSource(0, constraintSource);

        //ChangeAccessories(x, y);
        ChangeAccessories(x);
    }
}
