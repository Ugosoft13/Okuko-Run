using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartChickenScript : MonoBehaviour
{
    public float speed = 15f;
    
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0, 66.1f);
        
        // transform.eulerAngles = new Vector3(0, 0, 0);
        //transform.rotation = Quaternion.Euler(0, 0, 0); 
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        if (transform.position.z  < -26f )
        {
            transform.Rotate(0, 180, 0);
            
           
        }
      
        if (transform.position.z > 118)
        {
            transform.position = new Vector3(-24.8f, 0, 46.4f);
            transform.Rotate(0, 90, 0);

        }

        if (transform.position.x > 62.6f)
        {
            transform.Rotate(0, 180, 0);
        }

        if (transform.position.x < -56.8f)
        {
            transform.Rotate(0, 90, 0);
            transform.position = new Vector3(0, 0, 66.1f);
        }



    }

    private void RotationJutsu()
    {
        if (transform.position.z > 118)
        {
            transform.position = new Vector3(-7.6f, 0, 6.6f);
           
        }

        if (transform.position.x > 25.5f)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }

        if (transform.position.x < -21.8f)
        {
            transform.position = new Vector3(0, 0, -5.8f);
            transform.rotation = Quaternion.Euler(0, 0, -12);


        }
    }
}
