using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : MonoBehaviour
{
    public GameObject Circle;
    public Vector3 FollowMe;
    public float Speed = 3f;

    void Start()
    {
        FollowMe = transform.position;

        var newCircle = Instantiate(Circle, new Vector3(0, 0, 0), Quaternion.identity);
        newCircle.GetComponent<Circle>().main = this;
    }

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, FollowMe, Speed * Time.deltaTime);
    }
}
