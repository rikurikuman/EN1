using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageManager : MonoBehaviour
{
    public static int coin = 0;
    public int maxCoin = 0;
    public string nextStage = "";
    public Text coinText;
    // Start is called before the first frame update
    void Start()
    {
        coin = 0;
    }

    // Update is called once per frame
    void Update()
    {
        coinText.text = "Coins: " + coin + " / " + maxCoin;
    }

    public void ResetStage()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
