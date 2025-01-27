using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Tower : MonoBehaviour
{
    //Variables/References to other scripts
    private TargetingSystem _targetingSystem;
    [SerializeField]
    private ScriptableObject _towerDataSO;
    private ITowerData _towerData;
    private ITargetSystem _targetSystem;
    private IDamageSystem _damageSystem;

    //Own Coroutine for each tower class
    private Coroutine _damageCoroutine;


    //when a tower instance is placed, this awake method is called
    private void Awake()
    {
        Initialize();
    }

    //Initialize :
    //Find all the components necessery such as :
    //_targetingSystem [1st] (for the CurrentTarget),
    //_towerData (for the data about how much damage, the cooldown, etc),
    //_targetSystem [2nd] (for connecting OnTargetAcquired/Lost events to the Start/StopAttacking methods)
    //We use as ITargetSystem/IDamageSystem in both _targetSystem & _damageSystem to retrieve the methods / events through
    //the interface with the implemention of their respective class so that tower class doesnt depend directly on those classes
    //Then we look if _targetSystem is not null
    //if it isnt : we subscribe to the events OnTargetAcquired/Lost
    //Else : error message
    private void Initialize()
    {
        _targetingSystem = GetComponentInChildren<TargetingSystem>();
        _towerData = _towerDataSO as ITowerData;
        _targetSystem = GetComponentInChildren<TargetingSystem>() as ITargetSystem;
        _damageSystem = GetComponentInChildren<DamagingSystem>() as IDamageSystem;

        if (_targetSystem != null)
        {
            _targetSystem.OnTargetAcquired += StartAttacking;
            _targetSystem.OnTargetLost += StopAttacking;
        }
        else
            Debug.Log("Target system is not found in tower script");

    }

    //StartAttcking :
    //We look if _damageCoroutine is not null
    //if it isnt, we start the _damageCoroutine to ensure only one enemy is triggering the Coroutine
    //We look if _targetingSystem.CurrentTarget is not null
    //if it isnt, we start the _damageSystem.DealDamage Coroutine with the appropriate parameter (target, damage, cooldown)
    //Else : error message
    private void StartAttacking()
    {
        if (_damageCoroutine != null)
        {
            StopCoroutine(_damageCoroutine);  // Stop the current coroutine before starting a new one
        }

        if (_targetingSystem.CurrentTarget != null)
        {
            _damageCoroutine = StartCoroutine(_damageSystem.DealDamage(_targetingSystem.CurrentTarget, _towerData.Damage, _towerData.Cooldown));
        }
        else
        {
            Debug.Log("No valid target found");
        }

    }


    //StopAttacking : 
    //We look if _damageCoroutine is not null
    //if it isnt : we stop it and set it to null
    //we then use the _damageSystem.StopDamage method which switches the isDamaging bool off
    private void StopAttacking()
    {
        if (_damageCoroutine != null)
        {
            StopCoroutine(_damageCoroutine);  // Stop only the coroutine running for this tower
            _damageCoroutine = null;
        }

        _damageSystem.StopDamage();
    }
}

    //GOES TO DAMAGINGSYSTEM
    //private IEnumerator DealDamage()
    //{
    //    Debug.Log(this.gameObject.name + " is dealing damage");
    //    isDamaging = true;
    //    while (this.isDamaging)
    //    {
    //        if (this._currentTarget != null)
    //        {
    //            // Assuming the target has a Health component
    //            Enemy enemy = this._currentTarget.GetComponent<Enemy>();

    //            if (enemy != null)
    //            {
    //                enemy.TakeDamage(this._currentDamage);
    //            }
    //            else
    //                Debug.LogWarning("enemy is null");
    //        }

           
    //        yield return new WaitForSeconds(this._currentCD); // Damage every second

    //        if (this._currentTarget != null)
    //        {
    //            Debug.Log(this.gameObject.name + " did " + this._currentDamage + " to " + this._currentTarget.name + Time.time);
    //        }
           
    //    }
    //}

    //private void StopDamage()
    //{
    //    this.isDamaging = false;
    //}

    //////////////////////////////////////////////////////////////////////////////////////

    //Goes to Targeting system
    //private void OnTriggerEnter2D(Collider2D collision)
    //{

    //    if (collision.CompareTag("Enemy"))
    //    {

    //        this.targets.Add(collision.gameObject);
    //        if (this.targets.Count == 1 && isDamaging == false)
    //        {
    //            StartCoroutine(DealDamage());
    //        }
    //        Debug.Log(collision.gameObject.name + " has been added to targets list");
    //        Debug.Log("Current targets : ");
    //        foreach (GameObject target in this.targets)
    //        {
    //            Debug.Log($"{target.name}");
    //        }
    //    }
    //}
    //private void FindTarget()
    //{
    //    if (this._currentTarget == null && this.targets.Count > 0)
    //    {
    //        this._currentTarget = this.targets[0].gameObject;

    //        Debug.Log($"{_currentTarget.name} is the current target");
    //    }
    //    if(this.targets.Count > 0)
    //    {
    //        if (this._currentTarget != this.targets[0].gameObject)
    //        {
    //            Debug.Log("Current target not found, assigning new target");
    //            this._currentTarget = null;
    //        }
    //    }

    //}

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    targets.Remove(collision.gameObject);
    //    Debug.Log(collision.gameObject.name + " has been removed from targets list");
    //    Debug.Log("Current target list : ");
    //    foreach (GameObject target in this.targets)
    //    {
    //        Debug.Log(target.name);
    //    }
    //    if (this.targets.Count == 0)
    //    {
    //        this.StopDamage();
    //        Debug.Log($"No enemies to target, {this.gameObject.name} stopped shooting");
    //    }
    //}

