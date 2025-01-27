using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TowerEventManager : MonoBehaviour
{

    public static TowerEventManager instance;

    private void Awake()
    {
        if (instance == null)

            instance = this;
        
    }
    
    public UnityEvent<GameObject> OnEnemyEntered = new UnityEvent<GameObject>();
    public UnityEvent<GameObject> OnEnemyExit = new UnityEvent<GameObject>();
    public UnityEvent<GameObject, float> OnDamageDealt = new UnityEvent<GameObject, float>();

}
