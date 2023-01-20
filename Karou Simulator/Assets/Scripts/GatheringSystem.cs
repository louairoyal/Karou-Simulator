using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatheringSystem : MonoBehaviour
{
    public Transform StartRaycast;
    public GameObject collectText;
    public int x;
    public float rclengh;
    [SerializeField]bool canCollect;
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(StartRaycast.position, StartRaycast.TransformDirection(Vector3.forward), out hit, rclengh))
        {
            Debug.DrawRay(StartRaycast.position, StartRaycast.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            Debug.Log(hit.collider.name);
            collectText.SetActive(false);
            if (!canCollect)
            {
                foreach (var character in hit.collider.name)
                {
                    if (character == '$')
                    {
                        canCollect = true;
                        break;
                    }
                }
            }
            if (canCollect)
            {
                collectText.transform.position = new Vector3(hit.collider.transform.position.x, hit.collider.transform.position.y + 1.5f, hit.collider.transform.position.z);
                collectText.SetActive(true);
                collectText.transform.LookAt(StartRaycast);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    int quantity = Int16.Parse(hit.collider.name.Substring(0, 1));
                    quantity--;
                    hit.collider.name = quantity.ToString() + hit.collider.name.Substring(1, hit.collider.name.Length - 1);
                    string ResourceName = "";
                    for (int i = 1; i < hit.collider.name.Length; i++)
                    {

                    }
                    SaveData.addLoot(hit.collider.name, +1);
                    if (quantity == 0)
                    {
                        canCollect = false;
                        collectText.SetActive(false);
                        Destroy(hit.collider.gameObject);
                    }
                }
            }
        }
        else
        {
            canCollect = false;
            collectText.SetActive(false);
        }
    }
}