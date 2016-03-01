using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using RVO;

[RequireComponent(typeof(MeshFilter))]
public class ObstacleComponent : MonoBehaviour {

    //Add Bounding box as obstacle
    Vector3[] boundingBoxPoints;
    int _obstacleHandler = -1;
    float obstacleHeight;
    // Use this for initialization
    void Start () {
        Mesh mesh = GetComponent<MeshFilter>().mesh;
        Bounds bounds = mesh.bounds;
        Vector3 extents = bounds.extents;
        boundingBoxPoints = new Vector3[4];
        boundingBoxPoints[0] = bounds.center - extents;
        extents.x = -1 * extents.x;
        boundingBoxPoints[1] = bounds.center - extents;
        extents.y = -1 * extents.z;
        boundingBoxPoints[2] = bounds.center - extents;
        extents.x = -1 * extents.x;
        boundingBoxPoints[3] = bounds.center - extents;

        Vector3 heightVector = bounds.size;
        heightVector.x = 0;
        heightVector.z = 0;
        obstacleHeight = transform.TransformVector(heightVector).magnitude;
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
        int obstacleNum = Simulator.Instance.addObstacle(obstaclePos, obstacleHeight);
        Simulator.Instance.processObstacles();
        return obstacleNum;
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
