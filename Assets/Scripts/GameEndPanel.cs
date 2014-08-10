using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameEndPanel : MonoBehaviour 
{
    public static GameEndPanel _instance;
    public dfTweenVector3 tween;
    public dfLabel score;


    void Awake()
    {
        _instance = this;
    }

    public void Show()
    {
        dfControl control = this.GetComponent<dfControl>();
        tween.EndValue = new Vector3((Screen.width - control.Width) / 2, (Screen.height - control.Height) / 2, 0);
        score.Text = ScoreManager._instance.score + "";
        ScoreManager._instance.UpdateHighScore();
        tween.Play();
    }

}
