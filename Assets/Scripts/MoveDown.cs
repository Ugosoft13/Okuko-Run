using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDown : MonoBehaviour
{
    public float speed = 3f;
    private Rigidbody enemyRb;
    private float zLimit = 6f;

    private PlayerController playerControllerScript;
    private float maxSpeed = 40;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {


        if (speed < maxSpeed)
        {
            speed += 0.1f * Time.deltaTime;
        }

        if (playerControllerScript.gameOver == false )
        {
            transform.Translate(Vector3.forward * -speed * Time.deltaTime);
            //enemyRb.AddForce(Vector3.forward * speed );
        }
        else
        {
            transform.Translate(Vector3.forward * 0 * Time.deltaTime);

        }



        DestroyOffScreen();
    }

    // Destroy Enemy Off Screen

    public void DestroyOffScreen()
    {
        if (transform.position.z < -zLimit)
        {
            Destroy(gameObject);
        }
    }
}
