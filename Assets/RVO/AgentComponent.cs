using UnityEngine;
using System.Collections;
using RVO;

public class AgentComponent : MonoBehaviour {

    private int _agentHandler;
    public float neighborDist;
    public int maxNeighbors;
    public float timeHorizon;
    public float timeHorizonObst;
    public float radius;
    public float maxSpeed;

    public Vector3 target;
   
    // Use this for initialization
    void Start () {
        _agentHandler = Simulator.Instance.addAgent(transform.position, neighborDist, maxNeighbors, timeHorizon, timeHorizonObst, radius, maxSpeed, Vector2.zero);

    }

    public void setPosition(Vector3 pos)
    {
        Simulator.Instance.setAgentPosition(_agentHandler, pos);
    }

    void setPreferredVelocities(Vector3 velocity)
    {
        Simulator.Instance.setAgentPrefVelocity(_agentHandler, velocity);
    }

    // Update is called once per frame
    void Update () {
        transform.position = Simulator.Instance.getAgentPosition(_agentHandler);
        Simulator.Instance.setAgentPrefVelocity(_agentHandler, target - transform.position);
	}
}
