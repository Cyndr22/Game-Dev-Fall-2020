using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    public float speed;
    public int damage;

    private GameObject triggerFire;
    private GameObject triggerEnemy;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        Destroy(gameObject, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    public void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Fire") 
        {
            triggerFire = other.gameObject;
            triggerFire.GetComponent<FireController>().Damage(damage);
            Destroy(gameObject);
        }

        if (other.tag == "Enemy")
        {
            triggerEnemy = other.gameObject;
            triggerEnemy.GetComponent<Enemy>().health -= damage;
            Destroy(this.gameObject);

        }

        if (other.tag == "Player")
        {
            player.GetComponent<PlayerController>().health -= 20;
        }
    }
}
