using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class ChangeAcc : MonoBehaviour
{
    public GameObject Avatar1, Avatar2;
    public List<GameObject> Accesories = new List<GameObject>();
    public int x,x1, x2, y, y1, y2;
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
        x1 = GameManagerT.GetComponent<GameManager>().ACC[1];
        x2 = GameManagerT.GetComponent<GameManager>().ACC[2];
        y = GameManagerT.GetComponent<GameManager>().ACC[3];
        y1 = GameManagerT.GetComponent<GameManager>().ACC[4];
        y2 = GameManagerT.GetComponent<GameManager>().ACC[5];
    }

    public void ChangeAccessories(int x, int x1, int x2, int y, int y1, int y2)
    {
        if (x >= 1)
        {
            Accesories[x-1].SetActive(!(Accesories[x-1].activeSelf));
        }
        if (y >= 1)
        {
            Accesories[(y + 3)-1].SetActive(!(Accesories[(y + 3) - 1].activeSelf));
        }
        if (x1 >= 1)
        {
            Accesories[x1 - 1].SetActive(!(Accesories[x1 - 1].activeSelf));
        }
        if (y1 >= 1)
        {
            Accesories[(y1 + 3) - 1].SetActive(!(Accesories[(y1 + 3) - 1].activeSelf));
        }
        if (x2 >= 1)
        {
            Accesories[x2 - 1].SetActive(!(Accesories[x2 - 1].activeSelf));
        }
        if (y2 >= 1)
        {
            Accesories[(y2 + 3) - 1].SetActive(!(Accesories[(y2 + 3) - 1].activeSelf));
        }
    }

    public void ChangeAvatar()
    {
        Avatar1Bones = Avatar1.transform.GetChild(0).transform.GetChild(9).gameObject;
        Avatar2Bones = Avatar2.transform.GetChild(0).transform.GetChild(9).gameObject;

        int z = 0;
        while (z < Accesories.Count)
        {
            if (z < 3)
            {
                constraintSource.sourceTransform = Avatar2Bones.transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).transform;
                constraintSource.weight = 1;
                Accesories[z].GetComponent<ParentConstraint>().SetSource(0, constraintSource);
                constraintSource.sourceTransform = Avatar2Bones.transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).transform.GetChild(2).transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).transform.GetChild(2).transform.GetChild(0);
                constraintSource.weight = 1;
                Accesories[z+1].GetComponent<ParentConstraint>().SetSource(0, constraintSource);
                constraintSource.sourceTransform = Avatar2Bones.transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).transform.GetChild(0);
                constraintSource.weight = 1;
                Accesories[z+2].GetComponent<ParentConstraint>().SetSource(0, constraintSource);
                z = 3;
            }
            else
            {
                constraintSource.sourceTransform = Avatar1Bones.transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).transform;
                constraintSource.weight = 1;
                Accesories[z].GetComponent<ParentConstraint>().SetSource(0, constraintSource);
                constraintSource.sourceTransform = Avatar1Bones.transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).transform.GetChild(2).transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).transform.GetChild(1).transform.GetChild(0);
                constraintSource.weight = 1;
                Accesories[z+1].GetComponent<ParentConstraint>().SetSource(0, constraintSource);
                constraintSource.sourceTransform = Avatar1Bones.transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).transform.GetChild(0);
                constraintSource.weight = 1;
                Accesories[z+2].GetComponent<ParentConstraint>().SetSource(0, constraintSource);
                z = 6;
            }
        }
        ChangeAccessories(x, x1, x2, y, y1, y2);
    }
}
