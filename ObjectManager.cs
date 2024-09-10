using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public GameObject prefabsSlime;
    public GameObject prefabsSkeleton;
    public GameObject prefabsHpBar;
    GameObject[] slime;
    GameObject[] skeleton;
    GameObject[] hpBar;
    GameObject[] targetPool;

    void Awake()
    {
        slime = new GameObject[10];
        skeleton = new GameObject[10];
        hpBar = new GameObject[30];
        Generate();
    }

    void Generate()
    {
        for (int index = 0; index < slime.Length; index++) {
            slime[index] = Instantiate(prefabsSlime);
            slime[index].SetActive(false);
        }

        for (int index = 0; index < skeleton.Length; index++) {
            skeleton[index] = Instantiate(prefabsSkeleton);
            skeleton[index].SetActive(false);         
        }

        for (int index = 0; index < hpBar.Length; index++) {
            hpBar[index] = Instantiate(prefabsHpBar);
            hpBar[index].SetActive(false);
        }
    }

    public GameObject MakeObject(string type)
    {
        switch(type)
        {
            case "Slime":
                targetPool = slime;
                break;
            case "Skeleton":
                targetPool = skeleton;
                break;
            case "HpBar":
                targetPool = hpBar;
                break;
        }

        for (int index = 0; index < targetPool.Length; index++) 
        {
            if (!targetPool[index].activeSelf) 
            {
                targetPool[index].SetActive(true);
                return targetPool[index];
            }
        }

        return null;
    }
}
