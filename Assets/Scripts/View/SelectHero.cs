/****************************************************
    文件：SelectHero.cs
	作者：LSC
    邮箱: 314623971@qq.com
    日期：2021/1/14 17:32:44
	功能：英雄选择
*****************************************************/

using System.Collections.Generic;
using UnityEngine;

public class SelectHero : MonoBehaviour 
{
    private List<HeroItem> _itemLst;

    private void Start() {
        _itemLst = new List<HeroItem>(transform.childCount);
        HeroItem heroItem = null;
        foreach (Transform tran in transform) {
            heroItem = tran.gameObject.AddComponent<HeroItem>();
            heroItem.AddResetListener(ResetState);
            _itemLst.Add(heroItem);
        }
    }

    private void ResetState() {
        foreach (HeroItem item in _itemLst) {
            item.OnUnSelected();
        }
    }

}