using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector3 startPos;
    public float speed = 3f;
    private float repeatWidth;
    private float maxSpeed = 40;

    private PlayerController playerControllerScript;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        repeatWidth = GetComponent<BoxCollider>().size.z / 2;
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (speed < maxSpeed)
        {
            speed += 0.1f * Time.deltaTime;
        }
        

        if (playerControllerScript.gameOver != true)
        {
            transform.Translate(Vector3.forward * -speed * Time.deltaTime);
        }
        

        if (transform.position.z < startPos.z - 25)
        {
            transform.position = startPos;
        }
    }
}
