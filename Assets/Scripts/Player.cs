using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    GameManager gameManager;

    // Health and damage variables
    public float health = 1000;
    public float playerDamage = 100;

    // Movement variables
    public Rigidbody rb;
    public float moveForce = 1000f;
    public float rotationSpeed = 500f;

	// Use this for initialization
	void Start () {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }
	
	// Update is called once per frame
	void Update () {
        
	}

    void FixedUpdate()
    {
        movement();
    }

    public void movement()
    {
        // Forward and backward movements
        if (Input.GetKey("w"))
            rb.AddRelativeForce(Vector3.forward * moveForce * Time.fixedDeltaTime);
        else if (Input.GetKey("s"))
            rb.AddRelativeForce(Vector3.back * moveForce * Time.fixedDeltaTime);

        // Left and right movements
        if (Input.GetKey("a"))
            rb.AddRelativeForce(Vector3.left * -rotationSpeed * Time.fixedDeltaTime);
        else if (Input.GetKey("d"))
            rb.AddRelativeForce(Vector3.right * rotationSpeed * Time.fixedDeltaTime);
    }

    public void takeDamage()
    {
        // Taking damage
        //health -= enemyDamage;
        
        // Killing the player
        if (health <= 0)
        {
            gameManager.playerAlive = false;
            Destroy(this.gameObject);
        }
    }
}
