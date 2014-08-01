using UnityEngine;
using System.Collections;

public class HelpButton : MonoBehaviour {


    public void OnClick(dfControl control, dfMouseEventArgs args)
    {
        audio.Play();
        HelpPanelCloseButton._instance.BounceIn();
    }
}
