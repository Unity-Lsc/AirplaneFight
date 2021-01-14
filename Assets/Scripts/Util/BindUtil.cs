/****************************************************
    文件：BindUtil.cs
	作者：LSC
    邮箱: 314623971@qq.com
    日期：2021/1/14 12:17:55
	功能：绑定特性工具类
*****************************************************/

using System;
using System.Collections.Generic;
using UnityEngine;

public class BindUtil 
{
    private static Dictionary<string, Type> _prefabAndScriptMap = new Dictionary<string, Type>();

    public static void Bind(string path,Type type) {
        if(!_prefabAndScriptMap.ContainsKey(path)) {
            _prefabAndScriptMap.Add(path, type);
        }else {
            Debug.LogError("当前数据中已存在路径:" + path);
        }
    }

    public static Type GetType(string path) {
        if(_prefabAndScriptMap.ContainsKey(path)) {
            return _prefabAndScriptMap[path];
        }else {
            Debug.LogError("当前数据中未包含路径:" + path);
            return null;
        }
    }

}