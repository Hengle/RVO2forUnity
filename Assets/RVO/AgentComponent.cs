using UnityEngine;
using System.Collections;
using RVO;

public class AgentComponent : MonoBehaviour {

    private int _agentHandler;
    private float _neighborDist;
    public float neighborDist
    {
        set{
            _neighborDist = value;
            Simulator.Instance.setAgentNeighborDist(_agentHandler, value);
        }

        get
        {
            return _neighborDist;
        }
    }

    private int _maxNeighbor;
    public int maxNeighbors
    {
        set
        {
            _maxNeighbor = value;
            Simulator.Instance.setAgentMaxNeighbors(_agentHandler, value);
        }

        get
        {
            return _maxNeighbor;
        }
    }

    private float _timeHorizon;
    public float timeHorizon
    {
        set
        {
            _timeHorizon = value;
            Simulator.Instance.setAgentTimeHorizon(_agentHandler, value);
        }

        get
        {
            return _timeHorizon;
        }
    }
    private float _timeHorizonObst;
    public float timeHorizonObst
    {
        set
        {
            _timeHorizonObst = value;
            Simulator.Instance.setAgentTimeHorizonObst(_agentHandler, value);
        }

        get
        {
            return _timeHorizonObst;
        }
    }
    private float _radius;
    public float radius
    {
        set
        {
            _radius = value;
            Simulator.Instance.setAgentRadius(_agentHandler, value);
        }

        get
        {
            return _radius;
        }
    }

    private float _maxSpeed;
    public float maxSpeed
    {
        set
        {
            _maxSpeed = value;
            Simulator.Instance.setAgentMaxSpeed(_agentHandler, value);
        }

        get
        {
            return _maxSpeed;
        }
    }

    public Vector3 position
    {
        set
        {
            Simulator.Instance.setAgentPosition(_agentHandler, value);
        }

        get
        {
            return transform.position;
        }
    }
    // Use this for initialization
    void Start () {
        _agentHandler = Simulator.Instance.addAgent(new Vector2(transform.position.x, transform.position.z), neighborDist, maxNeighbors, timeHorizon, timeHorizonObst, radius, maxSpeed, Vector2.zero);

    }

    void setPreferredVelocities(Vector3 velocity)
    {
        Simulator.Instance.setAgentPrefVelocity(_agentHandler, velocity);
    }

    // Update is called once per frame
    void Update () {
	
	}
}
