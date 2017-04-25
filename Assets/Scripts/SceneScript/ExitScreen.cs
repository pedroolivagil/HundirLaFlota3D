using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitScreen : MonoBehaviour {

    // Use this for initialization
    void Start() {
        StartCoroutine(GameManager.ExitGame());
    }

    // Update is called once per frame
    void Update() {

    }
}
