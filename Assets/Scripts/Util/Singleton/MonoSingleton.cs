/****************************************************
    文件：MonoSingleton.cs
	作者：LSC
    邮箱: 314623971@qq.com
    日期：2021/1/13 23:52:25
	功能：Mono类单例模版
*****************************************************/

using UnityEngine;

public class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;
    public static T Instance {
        get {
            if(_instance == null) {
                _instance = FindObjectOfType<T>();
                if(_instance == null) {
                    Debug.LogError("场景中未找到类的对象,类名为:" + typeof(T).Name);
                }
            }
            return _instance;
        }
    }

    private void Awake() {
        if(_instance == null) {
            DontDestroyOnLoad(gameObject);
        }else {
            Destroy(gameObject);
        }
    }

}