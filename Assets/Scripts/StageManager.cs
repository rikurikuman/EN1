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
    public GameObject clearUI;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        coin = 0;
    }

    // Update is called once per frame
    void Update()
    {
        coinText.text = "Coins: " + coin + " / " + maxCoin;
    }

    public void ClearStage()
    {
        clearUI.SetActive(true);
        if(nextStage.Length == 0)
        {
            clearUI.transform.Find("NextButton").GetComponent<Button>().interactable = false;
        }
    }

    public void NextStage()
    {

    }

    public void BackToTitle()
    {
        SceneManager.LoadScene("TitleScene");
    }

    public void ResetStage()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
