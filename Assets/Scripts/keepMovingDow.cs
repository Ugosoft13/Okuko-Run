using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keepMovingDow : MonoBehaviour
{
    public float speedA = 10f;
    private Rigidbody animalRb;
    private float zLimitA = 6f;

    private PlayerController playerControllerScriptA;

    // Start is called before the first frame update
    void Start()
    {
        animalRb = GetComponent<Rigidbody>();
        playerControllerScriptA = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
            transform.Translate(Vector3.forward * -speedA * Time.deltaTime);
            //enemyRb.AddForce(Vector3.forward * speed );
        




        DestroyOffScreenA();
    }

    // Destroy Enemy Off Screen

    public void DestroyOffScreenA()
    {
        if (transform.position.z < -zLimitA)
        {
            Destroy(gameObject);
        }
    }
}
