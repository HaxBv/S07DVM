using UnityEngine;

public class Turret : MonoBehaviour
{
    public GameObject Enemy;


    public GameObject headTurret;
    public bool aimMode;
    public float rotationSpeed;

    void Start()
    {
        
    }

    void Update()
    {
        Shoot();
    }

    public void Shoot()
    {
        /*
        Vector3 HeadDir = Enemy.transform.position;

        Quaternion targetQuaternion = Quaternion.LookRotation(HeadDir);
        //transform.rotation = targetQuaternion;
        headTurret.transform.localRotation = Quaternion.Slerp(headTurret.transform.localRotation, targetQuaternion, rotationSpeed * Time.deltaTime);

        Vector3 HeadDir = (Enemy.transform.position - headTurret.transform.localPosition).normalized;
        
        Quaternion targetQuaternion = Quaternion.LookRotation(HeadDir);
            //transform.rotation = targetQuaternion;
       headTurret.transform.localRotation = Quaternion.Slerp(headTurret.transform.localRotation,targetQuaternion, rotationSpeed * Time.deltaTime);


        */

        Vector3 HeadDir = (Enemy.transform.position - transform.position);

        Quaternion targetQuaternion = Quaternion.LookRotation(HeadDir);
        //transform.rotation = targetQuaternion;
        headTurret.transform.rotation = Quaternion.Slerp(headTurret.transform.rotation, targetQuaternion, rotationSpeed * Time.deltaTime);




    }
}
