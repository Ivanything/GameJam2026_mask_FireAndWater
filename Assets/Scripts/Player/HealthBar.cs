using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public Health health;
    void Update()
    {
        Vector3 scale = Vector3.one;
        scale.x = Mathf.Clamp(health.health / health.maxHealth, 0, 1);
        transform.localScale = scale;
    }
}