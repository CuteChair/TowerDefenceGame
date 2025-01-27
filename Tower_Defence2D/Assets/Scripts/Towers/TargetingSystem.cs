using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using static UnityEngine.GraphicsBuffer;


public class TargetingSystem : MonoBehaviour, ITargetSystem
{
    public event Action OnTargetAcquired;
    public event Action OnTargetLost;

    [SerializeField]
    private ScriptableObject _towerDataSO;

    private ITowerData _towerData;

    [SerializeField]
    private List<GameObject> _targets = new List<GameObject>();


    public GameObject CurrentTarget { get; private set; }

    private void OnEnable()
    {
        Initialize();
    }
    private void Initialize()
    {
        _towerData = _towerDataSO as ITowerData;
        if (_towerData != null)
            this.transform.localScale = Vector3.one * _towerData.Range;
        else
            Debug.Log("TowerData is null in TargetingSystem");
    }
    private void OnTriggerEnter2D(Collider2D collision)
   
    {
        if (collision.CompareTag("Enemy"))
        {
            this._targets.Add(collision.gameObject);
            if(this.CurrentTarget == null)
            {
                this.CurrentTarget = collision.gameObject;
                this.OnTargetAcquired?.Invoke();
            }
           
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            _targets.Remove(collision.gameObject);

            if (CurrentTarget == collision.gameObject)
            {
                // Notify to stop attacking the current target
                OnTargetLost?.Invoke();
                CurrentTarget = null;

                if (_targets.Count > 0)
                {
                    // Switch to the next target and start attacking it
                    CurrentTarget = _targets[0];
                    OnTargetAcquired?.Invoke();
                }
            }
        }
    }


}

//private void OnTriggerEnter2D(Collider2D collision)
//[SerializeField]
//private GameObject _currentTarget;
//void Update()
//{
//    _currentTarget = FindTarget(_currentTarget);
//}

//public GameObject FindTarget(GameObject currentTarget)
//{
//    if (currentTarget == null && this._targets.Count > 0)
//    {
//        currentTarget = this._targets[0].gameObject;

//        Debug.Log($"{currentTarget.name} is the current target");
//    }
//    if (this._targets.Count > 0)
//    {
//        if (currentTarget != this._targets[0].gameObject)
//        {
//            Debug.Log("Current target not found, assigning new target");
//            currentTarget = null;
//        }
//    }
//        return currentTarget;
//}
//{
//    if (collision.CompareTag("Enemy"))
//    {
//        _targets.Add(collision.gameObject);
//        if (CurrentTarget == null)
//        {
//            CurrentTarget = collision.gameObject;
//            OnTargetAcquired?.Invoke(CurrentTarget);
//        }
//this._targets.Add(collision.gameObject);
//if (this._targets.Count > 0 /*&& isDamaging == false*/)
//{
//    //StartCoroutine();
//}
//Debug.Log($"|{this.gameObject.name}|" + collision.gameObject.name + " has been added to targets list");
//Debug.Log("Current targets : ");
//foreach (GameObject target in this._targets)
//{
//    Debug.Log($"{target.name}");
//}
//    }
//}

//private void OnTriggerExit2D(Collider2D collision)
//{
//    if (collision.CompareTag("Enemy"))
//    {
//        _targets.Remove(collision.gameObject);
//        if (_targets.Count == 0)
//        {
//            OnTargetLost?.Invoke(CurrentTarget);
//            CurrentTarget = null;
//        }
//        //OnLocalEnemyExit.Invoke(collision.gameObject);
//        //this._targets.Remove(collision.gameObject);
//        //Debug.Log($"|{this.gameObject.name}|" + collision.gameObject.name + " has been removed from targets list");
//        //Debug.Log("Current target list : ");
//        //foreach (GameObject target in this._targets)
//        //{
//        //    Debug.Log(target.name);
//        //}
//        //if (this._targets.Count == 0)
//        //{
//        //    //this.StopDamage();
//        //    Debug.Log($"No enemies to target, {this.gameObject.name} stopped shooting");
//        //}

//    }
//}
