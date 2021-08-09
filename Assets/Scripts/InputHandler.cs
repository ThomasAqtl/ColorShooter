using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour {

    private bool rightClick, leftClick, up, down, left, right;

    public bool RightClick { get => rightClick; set => rightClick = value; }
    public bool LeftClick { get => leftClick; set => leftClick = value; }
    public bool Up { get => up; set => up = value; }
    public bool Down { get => down; set => down = value; }
    public bool Left { get => left; set => left = value; }
    public bool Right { get => right; set => right = value; }

    // Update is called once per frame
    void Update() {
        rightClick = Input.GetMouseButton(1);
        leftClick = Input.GetMouseButton(0);
        up = Input.GetAxis("Vertical") > 0;
        down = Input.GetAxis("Vertical") < 0;
        left = Input.GetAxis("Horizontal") < 0;
        right = Input.GetAxis("Horizontal") > 0;
    }
}
