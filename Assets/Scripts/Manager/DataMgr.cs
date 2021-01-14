/****************************************************
    文件：DataMgr.cs
	作者：LSC
    邮箱: 314623971@qq.com
    日期：2021/1/14 22:28:37
	功能：数据管理类
*****************************************************/

using UnityEngine;

public class DataMgr : NormalSingleton<DataMgr>, IDataMemory {

    private IDataMemory _dataMemory;

    public DataMgr() {
        _dataMemory = new PlayerPrefsMemory();
    }

    public T Get<T>(string key) {
       return _dataMemory.Get<T>(key);
    }

    public void Set<T>(string key, T value) {
        _dataMemory.Set<T>(key, value);
    }
    public void Clear(string key) {
        _dataMemory.Clear(key);
    }

    public void ClearAll() {
        _dataMemory.ClearAll();
    }

}