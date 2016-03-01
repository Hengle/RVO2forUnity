using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using RVO;

[RequireComponent(typeof(MeshFilter))]
public class ObstacleComponent : MonoBehaviour {

    //Add Bounding box as obstacle
    Vector3[] boundingBoxPoints;
    int _obstacleHandler = -1;
    public float obstacleHeight = 1;
    // Use this for initialization
    void Start () {
        Mesh mesh = GetComponent<MeshFilter>().mesh;
        Bounds bounds = mesh.bounds;
        Vector3 extents = bounds.extents;
        boundingBoxPoints = new Vector3[8];
        boundingBoxPoints[0] = bounds.center + extents;
        boundingBoxPoints[1] = bounds.center - extents;

        extents.x = -1 * extents.x;
        boundingBoxPoints[2] = bounds.center + extents;
        boundingBoxPoints[3] = bounds.center - extents;

        extents.y = -1 * extents.y;
        boundingBoxPoints[4] = bounds.center + extents;
        boundingBoxPoints[5] = bounds.center - extents;

        extents.x = -1 * extents.x;
        boundingBoxPoints[6] = bounds.center + extents;
        boundingBoxPoints[7] = bounds.center - extents;

        _obstacleHandler = addObstacle();
    }

    int addObstacle()
    {
        Simulator.Instance.removeObstacle(_obstacleHandler);
        List<Vector3> obstaclePos = new List<Vector3>();
        foreach(Vector3 v in boundingBoxPoints)
        {
            obstaclePos.Add(transform.TransformPoint(v));
        }
        return Simulator.Instance.addObstacle(obstaclePos, obstacleHeight);
    }
	
	// Update is called once per frame
	void Update ()
    {
	    if(transform.hasChanged)
        {
            _obstacleHandler = addObstacle();
        }
	}
}
