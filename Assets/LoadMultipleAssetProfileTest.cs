using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadMultipleAssetProfileTest : MonoBehaviour
{
    public List<GameObject> assets;
    public int loadNumber = 100;
    public List<GameObject> runtimeParents;
    // Start is called before the first frame update
    void Start()
    {
        foreach(var asset in assets)
        {
            GameObject parent = new GameObject(asset.name);
            runtimeParents.Add(parent);
            parent.transform.parent = transform;
            for(int i= 0; i < loadNumber; i++)
            {
                GameObject go = Instantiate(asset, parent.transform);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0;i< runtimeParents.Count; i++)
        {

            if (Input.GetKeyDown(KeyCode.Alpha0 + i))
            {
                runtimeParents[i].SetActive(!runtimeParents[i].activeInHierarchy);
            }
        }
    }
}
