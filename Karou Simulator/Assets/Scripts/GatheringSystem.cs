using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatheringSystem : MonoBehaviour
{
    public Transform StartRaycast;
    public int x;
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(StartRaycast.position, StartRaycast.TransformDirection(Vector3.forward), out hit, 4f))
        {
            Debug.DrawRay(StartRaycast.position, StartRaycast.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            bool canCollect = false;
            foreach (var character in hit.collider.name)
            {
                if (character == '$')
                {
                    canCollect = true;
                }
            }
            if (canCollect && Input.GetKeyDown(KeyCode.E))
            {
                int quantity = Int16.Parse(hit.collider.name.Substring(0, 1));
                quantity--;
                hit.collider.name = quantity.ToString() + hit.collider.name.Substring(1, hit.collider.name.Length - 1);
                x++;
                if (quantity == 0)
                {
                    Destroy(hit.collider.gameObject);
                }
            }
        }
    }
}