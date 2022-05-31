using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public float time = 0;
    public float maxtime = 1;
    public GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(time >= maxtime)
        {
            time = 0;
            Instantiate(bullet, transform.position, transform.rotation, transform);
        }
    }
}
