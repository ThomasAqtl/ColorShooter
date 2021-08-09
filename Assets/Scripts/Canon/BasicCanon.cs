using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///  Inherits Canon properties. Only need to update the fire trigger and the function that shots the bullet.
/// </summary>
public class BasicCanon : Canon {

    protected override void UpdateTriggerFiring() {
        triggerFiring = inputHandler.LeftClick;
    }

    protected override IEnumerator Fire() {
        Debug.Log("Start basic firing");
        yield return StartCoroutine(base.Fire());
        Debug.Log("Stop basic firing");
    }

    protected override void ShootNewBullet() {
        Debug.Log("Shoot new basic bullet");
    }

}
