using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StatPanelCloseButton : MonoBehaviour 
{
    public static StatPanelCloseButton _instance;
    public dfTweenVector3 tween;

    public void Awake()
    {
        _instance = this;
    }

    public void BounceIn()
    {
        tween.EndValue = new Vector3(0, 0, 0);
        tween.Play();
    }

    public void BounceOut()
    {
        tween.EndValue = new Vector3(Screen.width, 0, 0);
        tween.Play();
    }

	public void OnClick( dfControl control, dfMouseEventArgs mouseEvent )
	{
        audio.Play();
        BounceOut();
	}

}
