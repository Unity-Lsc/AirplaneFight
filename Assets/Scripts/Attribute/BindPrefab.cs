/****************************************************
    文件：BindPrefab.cs
	作者：LSC
    邮箱: 314623971@qq.com
    日期：2021/1/14 12:1:46
	功能：脚本绑定预制体特性
*****************************************************/

using System;
using UnityEngine;

[AttributeUsage(AttributeTargets.Class)]
public class BindPrefab : Attribute 
{
    public string Path { get; private set; }

    public BindPrefab(string path) {
        this.Path = path;
    }
}