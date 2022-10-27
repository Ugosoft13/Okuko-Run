﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    Vector3 pos;
    public float offset = 3f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        pos = Input.mousePosition;
        pos.z = offset;
        transform.position = Camera.main.ScreenToWorldPoint(pos);

        pos.y = 0.87f;
    }
}
