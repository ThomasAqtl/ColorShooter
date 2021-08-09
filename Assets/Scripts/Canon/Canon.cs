using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///  Base class for canon components. Not to be used directly.
/// </summary>
public class Canon : MonoBehaviour {

    protected InputHandler inputHandler;

    // Does the player want to fire ?
    protected bool triggerFiring;

    // Is the canon actually firing ?
    protected bool firing;

    // On-hit damages
    protected int damage;

    // Duration between each bullet 
    protected float cooldown;

    // Bullet travel speed
    protected float speed;

    private void Awake() {
        InitCanonStats();
        inputHandler = gameObject.AddComponent<InputHandler>();
    }

    private void Update() {
        UpdateTriggerFiring();
        UpdateCanonState(triggerFiring);
    }

    /// <summary>
    ///  To be overriden. Init canon trigger with left click.
    /// </summary>
    protected virtual void UpdateTriggerFiring() {
        triggerFiring = InputHandler.LeftClick;
    }

    private void UpdateCanonState(bool tf) {
        if (tf & !firing) {
            StartCoroutine(Fire());
        }
    }

    /// <summary>
    ///  To be overriden. Init canon stats with no damages.
    /// </summary>
    protected virtual void InitCanonStats() {
        damage = Constantes.DefaultFireDamage;
        cooldown = Constantes.DefaultFireCooldown;
        speed = Constantes.DefaultFireSpeed;
        firing = false;
    }

    /// <summary>
    ///  Coroutine that handles the firing process.
    /// </summary>
    /// <returns></returns>
    protected virtual IEnumerator Fire() {
        firing = true;
        while (triggerFiring) {
            ShootNewBullet();
            yield return new WaitForSecondsRealtime(cooldown);
        }
        firing = false;
    }

    /// <summary>
    ///  To be overriden, according to every canon type.
    /// </summary>
    protected virtual void ShootNewBullet() {
        Debug.Log("Shooting new empty bullet");
    }

    // Accessors

    public int Damage { get => damage; set => damage = value; }
    public float Cooldown { get => cooldown; set => cooldown = value; }
    public float Speed { get => speed; set => speed = value; }
    public InputHandler InputHandler { get => inputHandler; set => inputHandler = value; }
    public bool Firing { get => firing; set => firing = value; }
    public bool TriggerFiring { get => triggerFiring; set => triggerFiring = value; }
}
