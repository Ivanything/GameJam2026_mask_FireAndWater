using UnityEngine;

public abstract class Health : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public Death death;

    public void Start() { 
        death = GetComponent<Death>();
    }
    public virtual void Damage() {
        Damage(5);
    }
    public virtual void Damage(float dmg)
    {
        health -= dmg;
        if (health < 0)
        {
            death.Die();
        }
    }
}
