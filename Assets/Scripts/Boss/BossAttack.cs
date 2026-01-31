using UnityEngine;

public class BossAttack : MonoBehaviour
{
    public Boss boss;
    public Collider[] rangeColliders, meleeColliders;
    public float radiusForFire, resetStateTimer, timeTillReset, radiusForMelee; // flaots for attacking
    
    public float dmg;
    void Start() { 
        boss = GetComponent<Boss>();

    }

    private void Update()
    {
        if (boss != null) {
            if (boss.atPoint)
            {
                Attack();
            }
            else { 
                //TODO walk
            }
        
        
        
        }
    }

    public void Attack() {
        rangeColliders = Physics.OverlapSphere(transform.position, radiusForFire);
        meleeColliders = Physics.OverlapSphere(transform.position, radiusForMelee);
        for (int i = 0; i < meleeColliders.Length; i++)
        {
            if (meleeColliders[i].tag == "Player")
            {
                print("melee");
                return;
            }

        }



        for (int i = 0; i < rangeColliders.Length; i++)
        {
            if (rangeColliders[i].tag == "Player")
            {
                print("Fire");
                return;
            }

        }
    }
}
