using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : MonoBehaviour
{
    public GameObject nextCircle;
    public MainController main;
    public int maxNewCircles = 2;
    public float cameraOffsetY = 2;
    public float cameraOffsetZ = -10;

    private Color White = new Color(1,1,1);
    private Color Red = new Color(1,0,0);

    void Start()
    {
        GetComponent<SpriteRenderer>().color = White;
    }

    void OnMouseDown()
    {
        //Move camera here
        main.FollowMe = new Vector3(transform.position.x, transform.position.y + cameraOffsetY, cameraOffsetZ);

        var newCircleLocations = PickNewPoints();

        foreach (var circleLocation in newCircleLocations)
        {
            Instantiate(nextCircle, circleLocation, Quaternion.identity);
            DrawLine(transform.position, circleLocation);
        }

        //After click/cleanup/explosion
        GetComponent<SpriteRenderer>().color = Red;
        Destroy(this); //Should just disable script
    }

    void DrawLine(Vector3 current, Vector3 target)
    {
        var emptyChild = new GameObject();
        var lineRenderer = emptyChild.AddComponent<LineRenderer>();

        var points = new List<Vector3>();
        points.Add(current);
        points.Add(target);

        lineRenderer.SetPositions(points.ToArray());
    }

    List<Vector3> PickNewPoints()
    {
        var points = new List<Vector3>();
        int numberOfCircles = Random.Range(1,3);

        for(var i = 0; i < numberOfCircles; ++i)
        {
            float[] possibleX = {-5f, 0f, 5f};
            int randomXIndex = Random.Range(0, possibleX.Length);
            float newX = transform.position.x + possibleX[randomXIndex];
            float newY = transform.position.y + 2f;
            float newZ = 0f;
            var newPoint = new Vector3(newX, newY, newZ);

            points.Add(newPoint);
        }
        
        return points;
    }
}
