using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transporter : MonoBehaviour {

    public GameObject pointToTransport;

    private void OnTriggerEnter(Collider other) {
        other.transform.position = pointToTransport.transform.position;
    }
}
