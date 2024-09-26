using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportOpti : MonoBehaviour
{
    public GameObject Player, GameManager, Accesories, NetworkDemo;
    public GameObject Avatar1, Avatar2, Avatar3;
    public GameObject TeleportGO;

    // Start is called before the first frame update

    /*void Awake()
    {
        GameManager = GameObject.FindGameObjectWithTag("GameManager");
    }*/

    void Start()
    {
        GameManager = GameObject.FindGameObjectWithTag("GameManager");
    }

    /*public void AssignAvatars(GameObject x, GameObject y, GameObject z)
    {
        Avatar1 = x.transform.parent.gameObject;
        Avatar2 = y.transform.parent.gameObject;
        Avatar3 = z.transform.parent.gameObject;
    }*/

    public void AssignAvatars(GameObject x, GameObject y)
    {
        Avatar1 = x.transform.parent.gameObject;
        Avatar2 = y.transform.parent.gameObject;
    }
    public void ButtonPressFuncOpti()
    {
        DontDestroyOnLoad(GameManager);
        //DontDestroyOnLoad(GameManager.GetComponent<GameManager>().GetAvatars(0));
        DontDestroyOnLoad(GameManager.GetComponent<GameManager>().GetAvatars(1));
        DontDestroyOnLoad(GameManager.GetComponent<GameManager>().GetAvatars(2));
        DontDestroyOnLoad(Avatar1);
        DontDestroyOnLoad(Avatar2);
        //DontDestroyOnLoad(Avatar3);
        DontDestroyOnLoad(NetworkDemo);
        DontDestroyOnLoad(Accesories);
        SceneManager.LoadScene("Therapy Room");
    }
}
