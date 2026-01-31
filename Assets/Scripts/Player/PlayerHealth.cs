using UnityEngine;

public class PlayerHealth : Health
{
    public PlayerShooting shooter;
    public override void Damage(float dmg)
    {
        base.Damage(dmg);
        if (health < 0)
        {
            health = maxHealth / 4f;
        }
    }
    public void RefillHealth()
    {
        health = maxHealth;
        shooter.Reload();
    }
}