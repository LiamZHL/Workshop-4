using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthManager : MonoBehaviour
{
    [SerializeField] private int startingHealth = 100;
    [SerializeField] private UnityEvent<float> onHealthChanged;
    [SerializeField] private UnityEvent onDeath;


    private int _currentHealth;
    private int CurrentHealth
    {
        get => this._currentHealth;
        set
        {
            this._currentHealth = value;
            var frac = this._currentHealth / (float)this.startingHealth;
            this.onHealthChanged.Invoke(frac);
            if(CurrentHealth <= 0)
            {
                this.onDeath.Invoke();
                Destroy(gameObject);
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        ResetHealthToStarting();
    }

    // Update is called once per frame
    public void ResetHealthToStarting()
    {
        CurrentHealth = this.startingHealth;
    }

    public void ApplyDamage(int damage)
    {
        _currentHealth -= damage;
    }

}
