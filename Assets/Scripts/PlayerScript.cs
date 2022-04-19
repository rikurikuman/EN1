using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public Camera cameraObj;
    public float power;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Rigidbody>().AddForce(new Vector3());

        Vector3 vec = new Vector3(0, 20, -20);
        Vector3 pos = this.gameObject.transform.position;
        pos += vec;
        cameraObj.transform.SetPositionAndRotation(pos, Quaternion.Euler(45, 0, 0));
    }
}
