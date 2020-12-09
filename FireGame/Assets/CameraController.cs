using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //float newX = transform.position.x - offset.x;
        //float newZ = transform.position.z - offset.z;

        transform.position = player.transform.position + offset;//new Vector3(newX, transform.position.y, newZ);
    }
}
