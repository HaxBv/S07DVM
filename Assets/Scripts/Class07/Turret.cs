using Sirenix.OdinInspector;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public AgentEnemyController Enemy;


    public GameObject headTurret;
    public bool aimMode;
    public float rotationSpeed;
    public GameObject AnchorShoot;
    public GameObject Bullet;

    public float TimeToShoot;
    private float timer = 0f;
    public float Force;

    void Start()
    {

    }

    void Update()
    {
        Apuntar();
        Shoot();
    }

    public void Apuntar()
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
        if(Enemy != null)
        {

            Vector3 HeadDir = (Enemy.transform.position - transform.position);

            Quaternion targetQuaternion = Quaternion.LookRotation(HeadDir);
            //transform.rotation = targetQuaternion;
            headTurret.transform.rotation = Quaternion.Slerp(headTurret.transform.rotation, targetQuaternion, rotationSpeed * Time.deltaTime);
        }
        else
        {
            Debug.Log("No hay enemigo asignado");
        }




    }
    [Button]
    public void EncontrarNuevoObjetivo()
    {
        Enemy = FindFirstObjectByType<AgentEnemyController>();
    }
    public void Shoot()
    {
        timer += Time.deltaTime;
        if (timer > TimeToShoot)
        {
            GameObject bullet = Instantiate(Bullet, AnchorShoot.transform.position, Quaternion.identity);

            Vector3 dir = AnchorShoot.transform.forward;
            bullet.GetComponent<Rigidbody>().AddForce(dir * Force, ForceMode.Impulse);

            timer = 0f;

        }
    }
}
