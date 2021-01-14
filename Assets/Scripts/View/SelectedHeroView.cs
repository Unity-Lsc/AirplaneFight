/****************************************************
    文件：SelectedHeroView.cs
	作者：LSC
    邮箱: 314623971@qq.com
    日期：2021/1/14 16:55:33
	功能：选择角色页面
*****************************************************/

using UnityEngine;

[BindPrefab(Paths.SELECTED_HERO_VIEW)]
public class SelectedHeroView : ViewBase 
{
    public override void Init() {
        base.Init();
        Util.Get("OK/Start").AddListener(() => {
            Debug.Log("进入开始游戏界面...");
        });
        Util.Get("Strengthen").AddListener(() => {
            Debug.Log("点击强化按钮...");
        });
        Util.Get("Heros").Go.AddComponent<SelectHero>();
        Util.Get("Exit").AddListener(() => {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        });
    }
}