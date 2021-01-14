/****************************************************
    文件：StartView.cs
	作者：LSC
    邮箱: 314623971@qq.com
    日期：2021/1/14 11:42:33
	功能：游戏开始界面
*****************************************************/

using UnityEngine;

[BindPrefab(Paths.START_VIEW)]
public class StartView : ViewBase 
{
    public override void Init() {
        base.Init();
        Util.Get("Start").AddListener(() => {
            UIManager.Instance.Show(Paths.SELECTED_HERO_VIEW);
            Debug.Log("Enter game scene...");
        });
    }
}