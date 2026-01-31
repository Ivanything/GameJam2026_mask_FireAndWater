using UnityEngine;

public class BossPath : MonoBehaviour
{

    void Start()
    {
        GameManager.instance.RegisterPoint(transform);
    }

  
}
