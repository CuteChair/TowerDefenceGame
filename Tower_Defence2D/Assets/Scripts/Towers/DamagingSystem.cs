using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagingSystem : MonoBehaviour, IDamageSystem
{
    [SerializeField]
    private bool isDamaging = false;
    public IEnumerator DealDamage(GameObject target, float damage, float coolDown)
    {

#if EDITOR
        Debug.Log($"{gameObject.name} started attacking {target.name}");
#endif
        this.isDamaging = true;
        while (this.isDamaging)
        {
            if (target != null && target.activeInHierarchy)
            {
                
                Enemy enemy = target.GetComponent<Enemy>();

                enemy?.TakeDamage(damage);
            }


            yield return new WaitForSeconds(coolDown); // Damage every second

            if (target != null)
            {
#if EDITOR
                Debug.Log(this.gameObject.name + " did " + damage + " to " + target.name + Time.time);
#endif
            }

        }
    }

    public void StopDamage()
    {
        this.isDamaging = false;
#if EDITOR
               Debug.Log($"{gameObject.name} stopped attacking.");
#endif

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
