using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public ScriptableEnemy scriptableEnemy;

    public HealthBar healthBar;

    private float _currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        this._currentHealth = scriptableEnemy.health;
        Debug.Log(this.gameObject.name + " health set to : " + this._currentHealth);
    }

    public void TakeDamage(float damage)
    {
        this._currentHealth -= damage;
        Debug.Log(this.gameObject.name + " was hit, HP : " + this._currentHealth);

        this.healthBar.TakingDamage(this._currentHealth, scriptableEnemy.maxHealth);

        if (this._currentHealth <= 0 )
        {
            Death();
        }
    }

    private void Death()
    {
        Debug.Log(this.gameObject.name + " has died");
        Destroy(this.gameObject);

    }

    public void Heal(float heal)
    {
        if (this._currentHealth > 0 && this._currentHealth < scriptableEnemy.maxHealth)
        {
            this._currentHealth += heal;


            if (this._currentHealth > scriptableEnemy.maxHealth)
            {
                this._currentHealth = scriptableEnemy.maxHealth;
            }

            this.healthBar.GettingHealed(this._currentHealth, scriptableEnemy.maxHealth);
        }
    }
}
