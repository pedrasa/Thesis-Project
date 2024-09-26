using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoveTest : MonoBehaviour
{
    public Vector2 sensitivity,rotation;
    // Start is called before the first frame update
    private Vector2 Getinput()
    {
        Vector2 input = new Vector2(
        Input.GetAxis("Mouse X"),
        Input.GetAxis("Mouse Y")
        );

    return input;

    }

    // Update is called once per frame
    private void Update()
    {
        Vector2 WantedVelocity = Getinput() * sensitivity;

        rotation += WantedVelocity * Time.deltaTime;

        transform.localEulerAngles = new Vector3(rotation.y, rotation.x, 0);
    }
}
