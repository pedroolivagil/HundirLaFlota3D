using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateActor : MonoBehaviour {

    public float speed;
    private Transform trans;
    private RectTransform rectTransform;

    // Use this for initialization
    void Start() {
        if (GetComponent<Transform>()) {
            trans = GetComponent<Transform>();
        } else if (GetComponent<RectTransform>()) {
            rectTransform = GetComponent<RectTransform>();
        }
    }

    // Update is called once per frame
    void Update() {
        if (trans) {
            trans.Rotate(Vector3.forward * speed * Time.deltaTime);
        } else if (rectTransform) {
            rectTransform.Rotate(Vector3.forward * speed * Time.deltaTime);
        }
    }
}
