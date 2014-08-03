using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RankItem : MonoBehaviour 
{
    public string dateStr;
    public int score;

    public dfTiledSprite sprite;
    public dfLabel dateLabel;
    public dfLabel scoreLabel;
    public void SetShow(int rankNumber, string dateStr, string score)
    {
        sprite.TileScroll = new Vector2(rankNumber * 0.1f, 0);
        dateLabel.Text = dateStr;
        scoreLabel.Text = score;
    }


}
