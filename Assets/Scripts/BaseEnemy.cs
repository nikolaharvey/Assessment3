using UnityEngine;
using System.Collections;

public class BaseEnemy : MonoBehaviour {

    // Health and damage variables
    public float health = 350;


    public void takeDamage(float damage)
    {
        health -= damage;
        if(health <= 0)
        {
            //ADD DEATH EFFECT
            Destroy(this.gameObject);
        }
    }
}
