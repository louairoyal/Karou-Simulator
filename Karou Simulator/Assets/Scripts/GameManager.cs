using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform PlayerTr;
    public Vector3 SpawnPoint;

    void Start()
    {
        SpawnPoint= transform.position;
    }
    void Update()
    {
        if (PlayerTr.transform.position.y < -5)
        {
            Respawn();
        }
    }

    private void Respawn()
    {
        PlayerTr.transform.position = SpawnPoint;
    }
}
