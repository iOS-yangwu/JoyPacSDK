using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ABTest : MonoBehaviour
{
    private const string JoyPacAppID = "b403ab2ef3";
    private Texture TextTexture;
    private Sprite bg;
    private GameObject BackGround;

    private string ABTestString = "No online parameters were obtained";
    private const string JoyPacSDkDemo = "JoyPacSDkDemo Log:        ";
    public void Start()
    {
        //打印日志
        JoyPac.Instance().SetLogEnable(true);
        //only init JoyPacSDK  
        JoyPac.Instance().InitSDK(JoyPacAppID);
    }
    private void OnEnable()
    {

        //ABTest 
        JoyPacUniversalFunc.onGetOnlineParameter += onGetOnlineParameter;


    }
    private void Awake()
    {
        
        bg = Resources.Load("Textrues/background", typeof(Sprite)) as Sprite;
        BackGround = GameObject.Find("BackGround");
        BackGround.AddComponent<Image>().sprite = bg;
        TextTexture = Resources.Load("Textrues/text", typeof(Texture)) as Texture;


    }
    void onGetOnlineParameter(string abTestString)
    {
        Debug.Log(JoyPacSDkDemo + "ABTest获取到在线参数" + abTestString);
        ABTestString = "ABTest parameter    : " + abTestString;
    }

    public void OnGUI()
    {

        GUIStyle TextStyle = new GUIStyle();
        TextStyle.alignment = TextAnchor.MiddleCenter;
        TextStyle.fontSize = (int)(0.030f * Screen.width);
        TextStyle.normal.textColor = Color.blue;
        TextStyle.normal.background = (Texture2D)TextTexture;
        ///ABTest
        Rect GUITest = new Rect(0.10f * Screen.width, 0.45f * Screen.height, 0.80f * Screen.width, 0.10f * Screen.height);

        GUI.Label(GUITest, ABTestString, TextStyle);


        Rect ReturnButton = new Rect(0.10f * Screen.width, 0.74f * Screen.height, 0.80f * Screen.width, 0.05f * Screen.height);
        if (GUI.Button(ReturnButton, "Return"))
        {
            SceneManager.LoadScene("MainScene");
        }
    }
}
