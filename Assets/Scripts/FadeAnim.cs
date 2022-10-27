using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeAnim : MonoBehaviour
{
   
    Image rend;
    float transparency;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Image>();
        transparency = rend.color.a;

        transparency = 0;
        var tempColor = rend.color;
        tempColor.a = 0f;
        rend.color = tempColor;

       
        
        
    }

    void Update()
    {
        StartFading();
    }

    IEnumerator FadeTo(float aValue, float aTime)
    {
        float alpha = rend.color.a;
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
        {
            Color newColor = new Color(1, 1, 1, Mathf.Lerp(alpha, aValue, t));
            rend.color = newColor;
            yield return null;
        }
    }

    public void StartFading()
    {
        if (Input.GetKeyUp(KeyCode.T))
        {
            StartCoroutine(FadeTo(0.0f, 1.0f));
        }
        if (Input.GetKeyUp(KeyCode.F))
        {
            StartCoroutine(FadeTo(1.0f, 1.0f));
        }
    }
    // Update is called once per frame



}
