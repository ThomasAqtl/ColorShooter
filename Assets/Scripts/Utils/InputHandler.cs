using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour {

    private float vertical, horizontal;

    public float Vertical { get => vertical; set => vertical = value; }
    public float Horizontal { get => horizontal; set => horizontal = value; }

    void Update() {
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");
    }
}
