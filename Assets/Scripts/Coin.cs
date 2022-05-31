using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    float rot = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rot += Time.deltaTime * 360;
        transform.rotation = Quaternion.Euler(90, rot, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            SoundManager.Play("Coin");
            StageManager.coin++;
            Destroy(gameObject);
        }
    }
}
