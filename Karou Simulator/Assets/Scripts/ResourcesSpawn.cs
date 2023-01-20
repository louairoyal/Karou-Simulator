using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class ResourcesSpawn : MonoBehaviour
{
    public GameObject[] Resources;
    public int[] ResourcesCount;
    private GameObject[] _Resource;
    public Transform parentForResources;

    void Start()
    {
        SpawnLI();
    }
    public void SpawnLI()
    {
        _Resource = new GameObject[Resources.Length];
        if (ResourcesCount.Length < Resources.Length)
        {
            ResourcesCount = new int[Resources.Length];
        }
        for (int i = 0; i < Resources.Length; i++)
        {
            for (int y = 0; y < ResourcesCount[i]; y++)
            {
                _Resource[i] = Instantiate(Resources[i], new Vector3(UnityEngine.Random.Range(-3.35f * 3f, 3.35f * 3f), .5f, UnityEngine.Random.Range(-4.34f * 3f, 4.34f * 3f)), Quaternion.identity, parentForResources);
                string ResName = "";
                for (int k = 1; k < _Resource[i].name.Length; k++)
                {
                    if (_Resource[i].name[k] != '$')
                    {
                        ResName += _Resource[i].name[k];
                    }
                    else
                    {
                        ResName += _Resource[i].name[k];
                        break;
                    }
                }
                _Resource[i].name = ResourcesCount[i].ToString()+ "$" + ResName;
            }
        }
    }
}