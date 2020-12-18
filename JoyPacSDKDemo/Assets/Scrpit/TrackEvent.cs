using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TrackEvent : MonoBehaviour
{
    private const string AdjustToken = "pp2zrnqzf8xs";
    private const string GAKey = "83363fe6455d0c5ec00cb9920621a9b0";
    private const string GASecret = "26a4395188ecfbfe57c573e6de05ba8171c17395";
    private Sprite bg;
    private GameObject BackGround;
    private const string JoyPacSDkDemo = "JoyPacSDkDemo Log:        ";

    public void Start()
    {
        //打印日志
        JoyPac.Instance().SetLogEnable(true);



        //init  init Adjust和GA 不使用广告和abtest功能  Do not use ads or ABTest functionality
        JoyPac.Instance().InitSDK(AdjustToken, GAKey, GASecret);



    }


    private void Awake()
    {
       
        bg = Resources.Load("Textrues/background", typeof(Sprite)) as Sprite;
        BackGround = GameObject.Find("BackGround");
        BackGround.AddComponent<Image>().sprite = bg;



    }
    private void OnGUI()
    {

        ///TrackEvent
        Rect GA_TrackEventButton = new Rect(0.10f * Screen.width, 0.10f * Screen.height, 0.80f * Screen.width, 0.05f * Screen.height);

        if (GUI.Button(GA_TrackEventButton, "Only TrackEvent GA"))
        {
            Debug.Log(JoyPacSDkDemo + "Only TrackEvent GA");
            JoyPac.Instance().GA_TrackEvent("GA_TrackEventTest", 1);

        }

        Rect Adjust_TrackEventButton = new Rect(0.10f * Screen.width, 0.25f * Screen.height, 0.80f * Screen.width, 0.05f * Screen.height);

        if (GUI.Button(Adjust_TrackEventButton, "Only TrackEvent  Adjust"))
        {
            Debug.Log(JoyPacSDkDemo + "Only TrackEvent  Adjust");
            JoyPac.Instance().Adjust_TrackEvent("Adjust_TrackEventTest");

        }
        Rect TrackEventButton = new Rect(0.10f * Screen.width, 0.40f * Screen.height, 0.80f * Screen.width, 0.05f * Screen.height);

        if (GUI.Button(TrackEventButton, "TrackEvent GA and Adjust"))
        {
            Debug.Log(JoyPacSDkDemo + "TrackEvent GA and Adjust");
            JoyPac.Instance().TrackEvent("Adjust_TrackEventTest", "GA_TrackEventTest", 1);

        }
        Rect ReturnButton = new Rect(0.10f * Screen.width, 0.74f * Screen.height, 0.80f * Screen.width, 0.05f * Screen.height);
        if (GUI.Button(ReturnButton, "Return"))
        {
            SceneManager.LoadScene("MainScene");
        }
    }

}
