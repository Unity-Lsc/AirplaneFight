/****************************************************
    文件：ResourceLoader.cs
	作者：LSC
    邮箱: 314623971@qq.com
    日期：2021/1/14 0:9:27
	功能：Resource加载器
*****************************************************/

using UnityEngine;

public class ResourceLoader : ILoader 
{
    /// <summary>
    /// 加载预制体
    /// </summary>
    /// <param name="path">路径</param>
    /// <param name="parent">父物体</param>
    public GameObject LoadPrefab(string path,Transform parent = null) {
        GameObject prefab = Resources.Load<GameObject>(path);
        GameObject temp = Object.Instantiate(prefab, parent);
        return temp;
    }

}