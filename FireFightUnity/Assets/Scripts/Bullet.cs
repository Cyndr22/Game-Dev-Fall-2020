using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	//Variables
	public float speed;
	public float maxDistance;

	private GameObject triggeringEnemy;
	public float damage;

	//Methods
    void Update()
    {
    	transform.Translate(Vector3.forward * Time.deltaTime * speed);
    	maxDistance += 1 * Time.deltaTime;

    	if(maxDistance >= 3)
    		Destroy(this.gameObject);
    }

    //Method for decreasing the health of an enemy
    public void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Enemy")
		{
			triggeringEnemy = other.gameObject;
			triggeringEnemy.GetComponent<Enemy>().health -= damage;
			Destroy(this.gameObject);

		}
	}
}
