using UnityEngine;
using System.Collections;

public class AirEnemy : BaseEnemy
{

    GameManager gameManager;

    public GameObject player;


    public float attackRange = 25.0f;



    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            Movement();

            if (Vector3.Distance(transform.position, player.transform.position) < attackRange)
            {
                Attack();
            }
        }
    }



    public virtual void Attack()
    {

    }

    public virtual void Movement()
    {

    }
}


