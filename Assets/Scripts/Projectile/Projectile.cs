using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    [SerializeField] private float cooldown;
    [SerializeField] private float speed;
    [SerializeField] private int damage;

    public float Cooldown { get => cooldown; set => cooldown = value; }
    public float Speed { get => speed; set => speed = value; }
    public int Damage { get => damage; set => damage = value; }

    private void Update() {
        UpdatePosition();
    }

    private void UpdatePosition() {
        transform.Translate(transform.right * speed * Time.deltaTime, Space.World);
    }

    private void OnBecameInvisible() {
        Destroy(gameObject);
    }
}
