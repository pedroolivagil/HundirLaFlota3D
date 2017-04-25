using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ShipConfig : MonoBehaviour {

    public int maxDistanceToObject = 50;
    public List<Transform> objTarget;

    //private Transform ship;
    private NavMeshAgent agente;
    private int currentPoint;

    // Use this for initialization
    void Start() {
        //ship = GetComponent<Transform>();
        agente = GetComponent<NavMeshAgent>();
        currentPoint = 0;
    }

    // Update is called once per frame
    void Update() {
        if (objTarget != null && objTarget.Capacity > 0) {
            SimularMovimientoOleaje();
        }
    }

    private void SimularMovimientoOleaje() {
        if (agente.remainingDistance < maxDistanceToObject) {
            if (currentPoint < (objTarget.Capacity - 1)) {
                currentPoint++;
            } else {
                currentPoint = 0;
            }
        }
        agente.SetDestination(objTarget[currentPoint].position);
    }
}
