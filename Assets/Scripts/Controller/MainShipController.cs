using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainShipController : MonoBehaviour {

    private InputHandler inputHandler;

    private Vector3 position;
    [SerializeField] [Range(1, 10)] private float speed;

    private float angle;

    private void Awake() {
        inputHandler = gameObject.AddComponent<InputHandler>();
        Application.targetFrameRate = 60;
    }

    private void Update() {
        UpdateAngle();
        UpdatePosition();
    }

    private void UpdateAngle() {

        Vector3 mousePosition = GetMouseScreenPosition();
        angle = Mathf.Atan2(mousePosition.y, mousePosition.x) * Mathf.Rad2Deg - 90.0f;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

    }

    public Vector3 GetMouseScreenPosition() {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = Mathf.Abs(Camera.main.transform.position.z);
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
        mousePosition.x -= screenPosition.x;
        mousePosition.y -= screenPosition.y;
        return mousePosition;
    }

    private void UpdatePosition() {

        float x = inputHandler.Horizontal;
        float y = inputHandler.Vertical;
        Vector3 movement = new Vector3(x, y, 0) * speed * Time.deltaTime;
        transform.Translate(movement, Space.World);

    }

    public Vector3 Position { get => position; set => position = value; }
    public float Speed { get => speed; set => speed = value; }
    public float Angle { get => angle; set => angle = value; }

}