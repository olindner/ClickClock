using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleController : MonoBehaviour
{
    void Start() 
    {
        Debug.Log("Start!");
    }

    void OnMouseDown()
    {
        Debug.Log("Clicked!");
        GetComponent<SpriteRenderer>().color = new Color(1,0,0);
    }
}
