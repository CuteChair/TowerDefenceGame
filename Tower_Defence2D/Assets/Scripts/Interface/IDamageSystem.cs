using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageSystem 
{
    IEnumerator DealDamage(GameObject target, float damage, float coolDown);

    void StopDamage();

    
}
