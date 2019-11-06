using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: Bonus - make this class a Singleton!

[System.Serializable]
public class BulletPoolManager : MonoBehaviour
{
    public GameObject bullet;
    public int size;

    //TODO: create a structure to contain a collection of bullets

    private Queue<GameObject> objectPool;

    //Create a singleton to make sure the pool only create one time
    #region Singleton

    public static BulletPoolManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        // TODO: add a series of bullets to the Bullet Pool
        objectPool = new Queue<GameObject>();

        for (int i = 0; i < size; i++)
        {
            GameObject ob = MonoBehaviour.Instantiate(bullet);
            ob.SetActive(false);
            objectPool.Enqueue(ob);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //TODO: modify this function to return a bullet from the Pool
    public GameObject GetBullet(Vector3 pos, Quaternion rot)
    {
        if (objectPool.Count != 0)
        {
            //Take off the first object of pool's queue
            GameObject objectGoGet = objectPool.Dequeue();

            //Set this object active and in certain position and rotation
            objectGoGet.SetActive(true);
            objectGoGet.transform.position = pos;
            objectGoGet.transform.rotation = rot;

            return objectGoGet;
        }
        else
        {
            Debug.Log("Bullet is loading!!");
            return null;
        }
    }

    //TODO: modify this function to reset/return a bullet back to the Pool 
    public void ResetBullet(GameObject bullet)
    {
        bullet.SetActive(false);

        //Put this object to the end of pool's  queue
        objectPool.Enqueue(bullet);
    }
}
