using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

    // Variables
    public float projectileSpeed = 50.0f;
    public float damage = 50.0f;
    public float lifeTime = 10.0f;



	void Start () {
        Destroy(this.gameObject, lifeTime);
	}
	
	

	void Update () {
        Movement();
	}



    public virtual void Movement()
    {
        transform.position += transform.forward * projectileSpeed * Time.deltaTime;
    }



    void OnTriggerEnter (Collider otherObject)
    {
        if (otherObject.tag == "Enemy")
        {
            otherObject.GetComponent<BaseEnemy>().takeDamage(damage);
            // ADD EFFECT TO PROJECTILE COLLISION
            Destroy(this.gameObject);
        }
    }
}
