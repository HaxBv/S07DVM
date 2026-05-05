using UnityEngine;

public class Ray : MonoBehaviour
{
    public float lifeTime;
    public float Damage;
    void Start()
    {
        Destroy(gameObject,lifeTime);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
