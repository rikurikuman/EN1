using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public Camera cameraObj;
    public float power = 10;
    public StageManager manager;
    public ParticleSystem particle;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.A))
        {
            gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(-1, 0, 0) * power);
        }
        if (Input.GetKey(KeyCode.D))
        {
            gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(1, 0, 0) * power);
        }
        if (Input.GetKey(KeyCode.W))
        {
            gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, 1) * power);
        }
        if (Input.GetKey(KeyCode.S))
        {
            gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, -1) * power);
        }

        Vector3 vec = new Vector3(0, 30, -5);
        Vector3 pos = gameObject.transform.position;
        pos += vec;
        cameraObj.transform.SetPositionAndRotation(pos, Quaternion.LookRotation(transform.position - pos));

        if(transform.position.y <= -50)
        {
            SoundManager.Play("Explode");
            Instantiate(particle, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            SoundManager.Play("Explode");
            Instantiate(particle, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Goal")
        {
            manager.ClearStage();
        }
    }
}
