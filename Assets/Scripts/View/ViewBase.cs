/****************************************************
    文件：ViewBase.cs
	作者：LSC
    邮箱: 314623971@qq.com
    日期：2021/1/14 12:54:46
	功能：UI基类
*****************************************************/

using UnityEngine;

public abstract class ViewBase : MonoBehaviour, IView {

    private UIUtil _util;
    public UIUtil Util {
        get {
            if(_util == null) {
                _util = gameObject.AddComponent<UIUtil>();
                _util.Init();
            }
            return _util;
        }
    }

    public virtual void Init() {

    }

    public virtual void Show() {
        gameObject.SetActive(true);
    }

    public virtual void Hide() {
        gameObject.SetActive(false);
    }
}