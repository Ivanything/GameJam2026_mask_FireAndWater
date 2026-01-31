using UnityEngine;

public class BossDeath : Death
{
    public override void Die()
    {
        Destroy(gameObject);
    }
}
