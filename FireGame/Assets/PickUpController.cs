using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpController : MonoBehaviour
{
    public GunController gun;
    public Rigidbody body;
    public BoxCollider box;
    public Transform player, gunBox, eyes;

    public float range;
    public float forceForward, forceUpward;

    public bool equipped;
    public static bool full;

    // Start is called before the first frame update
    void Start()
    {
        if (!equipped)
        {
            gun.enabled = false;
            body.isKinematic = false;
            box.isTrigger = false;
        }
        else 
        {
            gun.enabled = true;
            body.isKinematic = true;
            box.isTrigger = true;
            full = true;
        }
    }

    // Update is called once per frame
    private void Update()
    {
        Vector3 distanceToPlayer = player.position - transform.position;
        if (!equipped && distanceToPlayer.magnitude <= range && Input.GetKeyDown(KeyCode.E) && !full) 
        {
            PickUp();
        }

        if (equipped && Input.GetKeyDown(KeyCode.Q)) 
        {
            Drop();
        }
    }

    private void PickUp() 
    {
        equipped = true;
        full = true;

        transform.SetParent(gunBox);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.Euler(Vector3.zero);
        transform.localScale = Vector3.one;

        body.isKinematic = true;
        box.isTrigger = true;

        gun.enabled = true;
    }

    private void Drop()
    {
        float random = Random.Range(-1f, 1f);
        equipped = false;
        full = false;

        transform.SetParent(null);

        body.isKinematic = false;
        box.isTrigger = false;

        body.velocity = player.GetComponent<Rigidbody>().velocity;
        body.AddForce(eyes.forward * forceForward, ForceMode.Impulse);
        body.AddForce(eyes.up * forceUpward, ForceMode.Impulse);
        body.AddTorque(new Vector3(random, random, random) * 10);

        gun.enabled = false;
    }
}
