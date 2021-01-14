/****************************************************
    文件：InitCustomAttributes.cs
	作者：LSC
    邮箱: 314623971@qq.com
    日期：2021/1/14 12:8:8
	功能：初始化自定义的特性
*****************************************************/

using System;
using System.Reflection;
using UnityEngine;

public class InitCustomAttributes {

    public void Init() {
        Assembly assembly = Assembly.GetAssembly(typeof(BindPrefab));
        Type[] types = assembly.GetExportedTypes();
        foreach (Type type in types) {
            foreach (Attribute attribute in Attribute.GetCustomAttributes(type,true)) {
                if(attribute is BindPrefab) {
                    BindPrefab bindData = attribute as BindPrefab;
                    BindUtil.Bind(bindData.Path, type);
                }
            }
        }
    }

}