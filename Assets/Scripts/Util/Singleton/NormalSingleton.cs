/****************************************************
    文件：NormalSingleton.cs
	作者：LSC
    邮箱: 314623971@qq.com
    日期：2021/1/13 23:46:12
	功能：普通单例类模版
*****************************************************/

using UnityEngine;

public class NormalSingleton<T> where T : class, new() {

    private static T _instance;
    public static T Instance {
        get {
            if(_instance == null) {
                T t = new T();
                if(t is MonoBehaviour) {
                    Debug.LogError("Mono类请使用MonoSingleton");
                    return null;
                }
                _instance = t;
            }
            return _instance;
        }
    }
}