using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RankListManager : MonoBehaviour 
{
    private dfScrollPanel panel;
    public GameObject item;

    void Awake()
    {
        panel = this.GetComponent<dfScrollPanel>();
    }

    void Start()
    {
        UpdateRankList();
    }

    public void UpdateRankList()
    {
        List<RankItem> rankItemList = GetAllRankList();
        for (int i = 0; i < rankItemList.Count; i++)
        {
            dfControl control = panel.AddPrefab(item);
            RankItem rankItem = control.GetComponent<RankItem>();
            rankItem.SetShow(i + 1, rankItemList[i].dateStr, rankItemList[i].score+"");
        }
    }

    private List<RankItem> GetAllRankList()
    {
        List<RankItem> rankItemList = new List<RankItem>();

        RankItem rankItem1 = new RankItem();
        rankItem1.dateStr = "2013-3-3";
        rankItem1.score = 1000;
        rankItemList.Add(rankItem1);

        RankItem rankItem2 = new RankItem();
        rankItem2.dateStr = "2013-3-3";
        rankItem2.score = 1000;
        rankItemList.Add(rankItem2);

        RankItem rankItem3 = new RankItem();
        rankItem3.dateStr = "2013-3-3";
        rankItem3.score = 1000;
        rankItemList.Add(rankItem3);

        return rankItemList;
    }

}
