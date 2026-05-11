using System;
using Unity.Cinemachine;
using UnityEngine;
using Sirenix.OdinInspector;

public class GameManager : MonoBehaviour
{
    //public CinemachineCamera camA;
    //public CinemachineCamera camB;


    public static GameManager instance;
    public EnemySpawner spawner;


    public int EnemiesKilled = 0;
    public int EnemiesToKill = 50;
    /*[Button("Transition")]
    public void transition()
    {
        if (camA.Priority > camB.Priority)
        {
            camA.Priority = 0;
            camB.Priority = 1;
        }
        else
        {
            camA.Priority = 1;
            camB.Priority = 0;
        }
    }
    public void OnCameraFinished()
    {
        Debug.Log("Camera transition finished!");
    }*/




    private void Awake()
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
    void Start()
    {

    }

    void Update()
    {

    }
}
