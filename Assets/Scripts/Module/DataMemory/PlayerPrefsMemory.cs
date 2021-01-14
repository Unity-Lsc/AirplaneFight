/****************************************************
    文件：PlayerPrefsMemory.cs
	作者：LSC
    邮箱: 314623971@qq.com
    日期：2021/1/14 22:37:17
	功能：Unity本地存储数据类
*****************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class PlayerPrefsMemory : IDataMemory {

    private Dictionary<Type, Func<string, object>> _dataGetterDict = new Dictionary<Type, Func<string, object>>() {
        {typeof(int),(key) => PlayerPrefs.GetInt(key,0)},
        {typeof(string),(key) => PlayerPrefs.GetString(key,"")},
        {typeof(float),(key) => PlayerPrefs.GetFloat(key,0)},
    };
    private Dictionary<Type, Action<string, object>> _dataSetterDict = new Dictionary<Type, Action<string, object>>() {
        {typeof(int),(key,value) => PlayerPrefs.SetInt(key,(int)value)},
        {typeof(string),(key,value) => PlayerPrefs.SetString(key,(string)value)},
        {typeof(float),(key,value) => PlayerPrefs.SetFloat(key,(float)value)},
    };

    public T Get<T>(string key) {
        Type type = typeof(T);
        TypeConverter typeConverter = TypeDescriptor.GetConverter(type);
        if(_dataGetterDict.ContainsKey(type)) {
            return (T)typeConverter.ConvertTo(_dataGetterDict[type](key), type);
        }else {
            Debug.LogError("当前数据存储中无此类型数据,类型名为:" + type.Name);
            return default(T);
        }
    }

    public void Set<T>(string key, T value) {
        Type type = typeof(T);
        if(_dataSetterDict.ContainsKey(type)) {
            _dataSetterDict[type](key, value);
        }else {
            Debug.LogError("当前数据存储中无此类型数据,类型名为:" + type.Name + "    key:" + key + "     value:" + value);
        }
    }

    public void Clear(string key) {
        PlayerPrefs.DeleteKey(key);
    }

    public void ClearAll() {
        PlayerPrefs.DeleteAll();
    }

}