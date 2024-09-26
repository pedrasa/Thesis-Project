using Didimo.Networking;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;
using Unity.VisualScripting;

public class PlayerMovementOpti : MonoBehaviour
{
    public Transform VrPlayer;

    public float lookDownAngle = 25.0f;

    public float speed = 3.0f;

    public GameObject NetworkDemo;
    public GameObject GameManagerT;
    public AudioSource footsteps;
    public GameObject Left, Right;

    [SerializeField]
    private CharacterController cc;
    [SerializeField]
    private Animator animator;
    [SerializeField] private InputActionReference JoyStitckL;

    [SerializeField] private InputActionAsset ActionAsset;

    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
        animator = this.transform.GetChild(1).GetComponent<Animator>();
        GameManagerT = GameObject.FindGameObjectWithTag("GameManager");
        GameManagerT.GetComponent<GameManager>().AddAvatars(gameObject.GetComponent<ChangeColor>().Avatar1,gameObject, gameObject.GetComponent<ChangeColor>().Avatar3);
        //NetworkDemo.GetComponent<NetworkCustomOpti>().DidimoKeyList(GameManagerT.GetComponent<GameManager>().DidimoKeys[0],GameManagerT.GetComponent<GameManager>().DidimoKeys[1], GameManagerT.GetComponent<GameManager>().DidimoKeys[2]);
        NetworkDemo.GetComponent<NetworkCustomOpti>().DidimoKeyList(GameManagerT.GetComponent<GameManager>().DidimoKeys[0]);
        NetworkDemo.GetComponent<NetworkCustomOpti>().APIKeySet(GameManagerT.GetComponent<GameManager>().APIKey);
    }

    public void SetAnimator()
    {
        animator = this.transform.GetChild(1).GetComponent<Animator>();
    }

    public void ResetLine()
    {
        Left.GetComponent<XRRayInteractor>().enabled = false;
        Right.GetComponent<XRRayInteractor>().enabled = false;
        Left.GetComponent<XRRayInteractor>().enabled = true;
        Right.GetComponent<XRRayInteractor>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (JoyStitckL.action.inProgress)
        {
            animator.SetBool("Walk", true);
            footsteps.enabled = true;
        }
        else
        {
            animator.SetBool("Walk", false);
            footsteps.enabled = false;
        }
        
    }

    public void startTeleport()
    {
        StartCoroutine(Teleport(10.0f));
    }
    public void ChangeOpti()
    {
        /*animator = NetworkDemo.GetComponent<NetworkCustomOpti>().Rootnode2.GetComponent<Animator>();
        transform.GetComponent<ChangeColor>().ChangeAvatar();
        transform.GetComponent<ChangeHair>().ChangeAvatar(NetworkDemo.GetComponent<NetworkCustomOpti>().Bald1, NetworkDemo.GetComponent<NetworkCustomOpti>().Bald2, NetworkDemo.GetComponent<NetworkCustomOpti>().Bald3);
        transform.GetComponent<ChangeAccOpti>().ChangeAvatar();*/
        animator = NetworkDemo.GetComponent<NetworkCustomOpti>().Rootnode1.GetComponent<Animator>();
        //transform.GetComponent<ChangeColor>().ChangeAvatar();
        transform.GetComponent<ChangeHair>().ChangeAvatar(NetworkDemo.GetComponent<NetworkCustomOpti>().Bald1);
        transform.GetComponent<ChangeAccOpti>().ChangeAvatar();

    }

    public IEnumerator Teleport(float f)
    {
        yield return new WaitForSeconds(f);
        transform.GetComponent<TeleportOpti>().ButtonPressFuncOpti();
    }

}
