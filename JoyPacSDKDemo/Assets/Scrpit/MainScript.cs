using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainScript: MonoBehaviour
{




    private Sprite bg;
    private GameObject BackGround;
    private const string JoyPacSDkDemo = "JoyPacSDkDemo Log:        ";



    private const string JoyPacAppID = "b403ab2ef3";
    private const string AdjustToken = "pp2zrnqzf8xs";
    private const string GAKey = "83363fe6455d0c5ec00cb9920621a9b0";
    private const string GASecret = "26a4395188ecfbfe57c573e6de05ba8171c17395";

    private void Awake()
    {
       
        bg = Resources.Load("Textrues/background", typeof(Sprite)) as Sprite;
        BackGround = GameObject.Find("BackGround");
        BackGround.AddComponent<Image>().sprite = bg;

    

    }
    public void Start()
    {
        //打印日志  Print log
        //JoyPac.Instance().SetLogEnable(true);


        //only init JoyPacSDK  
        //JoyPac.Instance().InitSDK(JoyPacAppID);

        //init  init Adjust和GA 不使用广告和abtest功能 Do not use ads or ABTest functionality
        //JoyPac.Instance().InitSDK(AdjustToken, GAKey, GASecret);

        //SDK init JoyPacSDK Adjust和GA 
        //JoyPac.Instance().InitSDK(JoyPacAppID, AdjustToken, GAKey, GASecret);


    }



    public void OnGUI()
    {

        GUI.skin.button.fontSize = (int)(0.030f * Screen.width);

     

   
        Rect AdvertisingButton = new Rect(0.10f * Screen.width, 0.25f * Screen.height, 0.80f * Screen.width, 0.05f * Screen.height);
        if (GUI.Button(AdvertisingButton, "Advertising"))
        {

         
            SceneManager.LoadScene("Advertising");

        }
        Rect ABTestButton = new Rect(0.10f * Screen.width, 0.10f * Screen.height, 0.80f * Screen.width, 0.05f * Screen.height);

        if (GUI.Button(ABTestButton, "ABTest"))
        {
            SceneManager.LoadScene("ABTest");
        }




        Rect TrackEventButton = new Rect(0.10f * Screen.width, 0.40f * Screen.height, 0.80f * Screen.width, 0.05f * Screen.height);
        if (GUI.Button(TrackEventButton, "TrackEvent"))
        {
            SceneManager.LoadScene("TrackEvent");
        }

      
    }

}

