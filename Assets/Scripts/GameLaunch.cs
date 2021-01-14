/****************************************************
    文件：GameLaunch.cs
	作者：LSC
    邮箱: 314623971@qq.com
    日期：2021/1/14 11:49:8
	功能：游戏启动入口
*****************************************************/

using UnityEngine;

public class GameLaunch : MonoBehaviour 
{
    private void Start() {

        InitCustomAttributes initAttri = new InitCustomAttributes();
        initAttri.Init();

        UIManager.Instance.Show(Paths.START_VIEW);
    }
}