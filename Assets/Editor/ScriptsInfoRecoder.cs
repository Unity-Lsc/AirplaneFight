﻿/************************************************************
    文件: ScriptsInfoRecoder.cs
	作者: LSC
    邮箱: 314623971@qq.com
    日期: 2020/01/13 23:16
	功能: 记录脚本信息
*************************************************************/

using System;
using System.IO;

public class ScriptsInfoRecoder : UnityEditor.AssetModificationProcessor {
    private static void OnWillCreateAsset(string path) {
        path = path.Replace(".meta", "");
        if (path.EndsWith(".cs")) {
            string str = File.ReadAllText(path);
            str = str.Replace("#CreateAuthor#", Environment.UserName).Replace(
                              "#CreateTime#", string.Concat(DateTime.Now.Year, "/", DateTime.Now.Month, "/",
                                DateTime.Now.Day, " ", DateTime.Now.Hour, ":", DateTime.Now.Minute, ":", DateTime.Now.Second));
            File.WriteAllText(path, str);
        }
    }
}