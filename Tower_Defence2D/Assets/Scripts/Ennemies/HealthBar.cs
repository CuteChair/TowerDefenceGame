using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image healthBar;
    
    public void TakingDamage(float health, float maxHealth)
    {
        this.healthBar.fillAmount = health / maxHealth;
    }

    public void GettingHealed(float health, float maxHealth)
    {
        this.healthBar.fillAmount = health /maxHealth;
    }
}
