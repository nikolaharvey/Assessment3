using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    GameManager gameManager;

    // Health and damage variables
    public float health = 1000;

    // Movement variables
    public Rigidbody PlayerRB;
    public float moveForce = 10000f;
    public float rotationSpeed = 100f;

    //Weapon variables
    public float fireSpeed = 1.0f;
    private float fireTimer;
    public GameObject projectile;
    public GameObject muzzle;
	


	void Start () {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }
	

	
	void Update () {
        Shoot();
	}

    void Shoot()
    {
        // When left mouse button is clicked, fire projectile/shoot
        if (Input.GetMouseButtonDown (0) && Time.time > fireTimer)
        {
            // Fire projectile
            Instantiate(projectile, muzzle.transform.position, muzzle.transform.rotation);
            
            // Reset the fireTimer
            fireTimer = Time.time + fireSpeed;
        }
    }



    void FixedUpdate()
    {
        Movement();
    }



    public void Movement()
    {
        // Forward and backward movements
        if (Input.GetKey("w"))
            PlayerRB.AddRelativeForce(Vector3.forward * moveForce * Time.fixedDeltaTime);
        else if (Input.GetKey("s"))
            PlayerRB.AddRelativeForce(Vector3.back * moveForce * Time.fixedDeltaTime);

        // Left and right movements
        if (Input.GetKey("a"))
            transform.Rotate(Vector3.up * -rotationSpeed * Time.fixedDeltaTime);
        else if (Input.GetKey("d"))
            transform.Rotate(Vector3.up * rotationSpeed * Time.fixedDeltaTime);
    }



    public void takeDamage()
    {
        // Taking damage
        //health -= enemyDamage;
        
        // Kill the player when health reaches 0
        if (health <= 0)
        {
            // ADD DEATH EFFECT
            gameManager.playerAlive = false;
            Destroy(this.gameObject);
        }
    }
}
