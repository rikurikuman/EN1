using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public Camera cameraObj;
    public float power = 10;
    public AudioSource audioSource;
    public AudioClip goalSE;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(-1, 0, 0) * power);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(1, 0, 0) * power);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, 1) * power);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, -1) * power);
        }

        Vector3 vec = new Vector3(0, 20, -20);
        Vector3 pos = this.gameObject.transform.position;
        pos += vec;
        cameraObj.transform.SetPositionAndRotation(pos, Quaternion.Euler(45, 0, 0));
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Goal")
        {
            audioSource.Pause();
            audioSource.PlayOneShot(goalSE);
            this.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, 1000, 0));
            Debug.Log("ÉSÅ[ÉãÅI");
        }
    }
}
