using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public List<Transform> bossPath = new List<Transform>();
    public Transform boss;
    public Health playerHealth;
    public Health healthBoss;
    public PlayerShooting playerammo;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void RegisterPoint(Transform point)
    {
        if (!bossPath.Contains(point))
        {
            bossPath.Add(point);
            SortPointsByDistance();
        }
    }

    void SortPointsByDistance()
    {
        if (boss == null) return;

        bossPath = bossPath.OrderBy(p => Vector3.Distance(boss.position, p.position)).ToList();
    }
}
