using UnityEngine;

public class HealthPuddle : MonoBehaviour
{
    public Transform puddle;
    public int uses;
    public float downAmount;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            puddle.position -= Vector3.down * downAmount;
            uses--;
            other.GetComponent<PlayerHealth>().RefillHealth();
        }
        if (uses <= 0)
        {
            Destroy(gameObject);
        }
    }
}