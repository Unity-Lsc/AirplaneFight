/****************************************************
    文件：LoadMgr.cs
	作者：LSC
    邮箱: 314623971@qq.com
    日期：2021/1/14 0:7:43
	功能：资源加载管理器
*****************************************************/

using UnityEngine;

public class LoadMgr : NormalSingleton<LoadMgr> 
{

    private ILoader _loader;

    public LoadMgr() {
        _loader = new ResourceLoader();
    }

    public GameObject LoadPrefab(string path,Transform parent = null) {
        return _loader.LoadPrefab(path, parent);
    }

}