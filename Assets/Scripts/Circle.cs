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

        DrawLine(transform.position, newCircleLocation);

        main.FollowMe = newCameraLocation;
    }

    void DrawLine(Vector3 current, Vector3 target)
    {
        LineRenderer lineRenderer = gameObject.AddComponent<LineRenderer>();
        
        var points = new List<Vector3>();
        points.Add(current);
        points.Add(target);
        
        lineRenderer.SetPositions(points.ToArray());
    }
}
