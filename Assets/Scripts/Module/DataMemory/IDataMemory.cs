/****************************************************
    文件：DataMemory.cs
	作者：LSC
    邮箱: 314623971@qq.com
    日期：2021/1/14 22:28:19
	功能：数据管理接口
*****************************************************/

using UnityEngine;

public interface IDataMemory 
{
    T Get<T>(string key);
    void Set<T>(string key, T value);
    void Clear(string key);
    void ClearAll();
}