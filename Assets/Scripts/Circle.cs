using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : MonoBehaviour
{
    public GameObject nextCircle;
    public MainController main;

    void Start()
    {
        GetComponent<SpriteRenderer>().color = new Color(1,1,1);
    }

    void OnMouseDown()
    {
        GetComponent<SpriteRenderer>().color = new Color(1,0,0);

        var newCircleLocation = new Vector3(transform.position.x, transform.position.y + 2, 0);
        var newCameraLocation = new Vector3(transform.position.x, transform.position.y + 2, -10);

        Instantiate(nextCircle, newCircleLocation, Quaternion.identity);

        main.FollowMe = newCameraLocation;
    }
}
