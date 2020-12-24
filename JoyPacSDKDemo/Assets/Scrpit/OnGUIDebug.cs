using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class OnGUIDebug:MonoBehaviour
{

    private static OnGUIDebug s_instance;
    public static OnGUIDebug Instance
    {
        get
        {
            if (s_instance == null)
            {
                GameObject GUIDebug = new GameObject();
                GUIDebug.name = "OnGUIDebug";
                s_instance = GUIDebug.AddComponent<OnGUIDebug>();
                //DontDestroyOnLoad(GUIDebug);
            }
            return s_instance;
        }
    }


    public int FontSize = (int)(0.030f * Screen.width);

    public int LabelHeight = 40;

    float labelPos_Y = 0;

    //消息list

    static List<string> msgList = new List<string>();

    GUIStyle style = null;

    void Awake()
    {
        style = new GUIStyle();

        style.fontSize = FontSize;

        style.normal.textColor = Color.red;

    }



    public  void AddMsg(string msg)
    {
       msgList.Add(msg);
    }

    public void RemoveAll()
    {
        msgList.Clear();
    }

    void OnGUI()
    {

        labelPos_Y = 0.70f * Screen.height;
        for (int i = 0; i < msgList.Count; i++)
        {

            Rect lable= new Rect(0.20f * Screen.width, labelPos_Y, 0.35f * Screen.width, 0.05f * Screen.height);
            GUI.Label(lable, msgList[i], style);
            labelPos_Y += LabelHeight;

        }

        if (labelPos_Y >= 0.95f*Screen.height)
        {

            if (msgList.Count > 0)
                msgList.RemoveAt(0);
        }

    }





}

