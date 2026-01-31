using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    public float speed;
    public float lifeTime;
    public float damage;
    public GameObject deathParticle;
    void Start()
    {
        if (lifeTime <= 0) lifeTime = 20;
        Destroy(gameObject, lifeTime);
    }
    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }
    void OnDestroy()
    {
        Destroy(Instantiate(deathParticle, transform.position, Quaternion.identity), 2);
    }
    private void OnTriggerEnter(Collider other)
    {
        Health otherhealth = other.GetComponent<Health>();
        if (otherhealth)
        {
            otherhealth.Damage(damage);
        }
        if (!other.isTrigger)
            Destroy(gameObject);
    }
}