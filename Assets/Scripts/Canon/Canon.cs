using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///  Base class for canon components. Not to be used directly.
/// </summary>
public class Canon : MonoBehaviour {

    // Projectile used by this canon
    [SerializeField] private GameObject projectile;

    // Key to trigger this canon
    [SerializeField] private KeyCode triggerKey;

    // Does the player want to fire for a given canon
    private bool isTriggered;

    // Is the canon actually firing ?
    private bool firing;

    private void Start() {
        InitCanon();
    }

    private void Update() {
        UpdateIsTriggered();
        UpdateCanonState();
    }

    /// <summary>
    ///  To be overriden. Init canon trigger with left click.
    /// </summary>
    protected virtual void UpdateIsTriggered() {
        IsTriggered = Input.GetKey(triggerKey);
    }

    private void UpdateCanonState() {
        if (IsTriggered & !Firing) {
            StartCoroutine(Fire());
        }
    }

    /// <summary>
    ///  To be overriden. Init canon stats with no damages.
    /// </summary>
    protected virtual void InitCanon() {
        firing = false;
        transform.position = GetComponentInParent<Transform>().position;
        transform.position += transform.up * 0.5f;
    }

    /// <summary>
    ///  Coroutine that handles the firing process.
    /// </summary>
    /// <returns></returns>
    protected virtual IEnumerator Fire() {
        Firing = true;
        while (IsTriggered) {
            ShootNewProjectile();
            yield return new WaitForSecondsRealtime(projectile.GetComponent<Projectile>().Cooldown);
        }
        Firing = false;
    }

    /// <summary>
    ///  Instanciates projectile prefab. Its behavior is handled with its own script Projectile.cs
    /// </summary>
    protected virtual void ShootNewProjectile() {
        float direction = GetComponentInParent<MainShipController>().Angle + 90.0f;
        GameObject p = Instantiate(projectile, transform.position, Quaternion.Euler(0, 0, direction));
    }

    // Accessors
    public GameObject Projectile { get => projectile; set => projectile = value; }
    protected bool IsTriggered { get => isTriggered; set => isTriggered = value; }
    protected bool Firing { get => firing; set => firing = value; }
}
