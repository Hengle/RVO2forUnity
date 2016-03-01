using UnityEngine;
using System.Collections;
using RVO;

public class SimulatorComponent : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(DoStep());
	}

    IEnumerator DoStep()
    {
        while (true)
        {
            yield return new WaitForEndOfFrame();
            Simulator.Instance.setTimeStep(Time.deltaTime * 10);
            yield return Simulator.Instance.doStep();
        }
            
    }
    
}
