using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Cysharp.Threading.Tasks;

public class StageManager : MonoBehaviour
{
    public static bool go = false;
    public static int coin = 0;
    public bool finished = false;
    public int maxCoin = 0;
    public string nextStage = "";
    public Text coinText;
    public GameObject clearUI;
    public GameObject warnUI;

    public Button skipbutton;
    public Button resetButton;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        coin = 0;
        BGMManager.Play("Game");
    }

    // Update is called once per frame
    void Update()
    {
        coinText.text = "Coins: " + coin + " / " + maxCoin;
        if (nextStage.Length == 0)
        {
            skipbutton.interactable = false;
        }
    }

    public void ClearStage()
    {
        if(!finished)
        {
            if(coin >= maxCoin)
            {
                finished = true;
                SoundManager.Play("StageClear");
                skipbutton.interactable = false;
                resetButton.interactable = false;
                clearUI.SetActive(true);
                if (nextStage.Length == 0)
                {
                    clearUI.transform.Find("NextButton").GetComponent<Button>().interactable = false;
                }
            } else
            {
                SoundManager.Play("Warn");
                Instantiate(warnUI, GameObject.Find("Canvas").transform);
            }
        }
    }

    public void NextStage()
    {
        if (nextStage.Length != 0)
        {
            if (!go)
            {
                async UniTask task()
                {
                    go = true;
                    await Shutter.Close();
                    BGMManager.Stop(1);
                    await UniTask.Delay(1000);
                    await SceneManager.LoadSceneAsync(nextStage);
                    await Shutter.Open();
                    go = false;
                }
                _ = task();
            }
        }
    }

    public void BackToTitle()
    {
        if (!go)
        {
            async UniTask task()
            {
                go = true;
                await Shutter.Close();
                BGMManager.Stop(1);
                await UniTask.Delay(1000);
                await SceneManager.LoadSceneAsync("TitleScene");
                await Shutter.Open();
                go = false;
            }
            _ = task();
        }
    }

    public void ResetStage()
    {
        if (!go)
        {
            async UniTask task()
            {
                go = true;
                await Shutter.Close();
                await UniTask.Delay(500);
                await SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
                await Shutter.Open();
                go = false;
            }
            _ = task();
        }
    }
}
