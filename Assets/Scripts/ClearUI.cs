using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearUI : MonoBehaviour
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

        float t = Mathf.Min(1, time * 2);

        float easeY = Util.EaseOutPow(t, 3, -1000, 0);
        gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, easeY, 0);
    }
}
