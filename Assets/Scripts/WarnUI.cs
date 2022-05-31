using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarnUI : MonoBehaviour
{
    public float time = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        
        if(time >= 3)
        {
            float t = Mathf.Min(1, (time - 3) * 2);

            float easeY = Util.EaseOutPow(t, 3, -125, 250);
            gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, easeY, 0);
        } else
        {
            float t = Mathf.Min(1, (time) * 2);

            float easeY = Util.EaseOutPow(t, 3, 250, -125);
            gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, easeY, 0);

        }

        if(time > 5)
        {
            Destroy(gameObject);
        }
    }
}
