/****************************************************
    文件：ILoader.cs
	作者：LSC
    邮箱: 314623971@qq.com
    日期：2021/1/14 0:8:28
	功能：加载器接口
*****************************************************/

using UnityEngine;

public interface ILoader
{
    GameObject LoadPrefab(string path, Transform parent = null);
}