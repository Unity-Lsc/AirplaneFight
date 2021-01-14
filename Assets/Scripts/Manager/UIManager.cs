/****************************************************
    文件：UIManager.cs
	作者：LSC
    邮箱: 314623971@qq.com
    日期：2021/1/14 12:47:46
	功能：UI管理类
*****************************************************/

using System;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : NormalSingleton<UIManager> 
{

    private Stack<string> _uiStack = new Stack<string>();
    private Dictionary<string, IView> _viewsDict = new Dictionary<string, IView>();
    private Canvas _canvas;
    public Canvas Canvas {
        get {
            if(_canvas == null) {
                _canvas = UnityEngine.Object.FindObjectOfType<Canvas>();
            }
            if(_canvas == null) {
                Debug.LogError("场景中没有Canvas");
            }
            return _canvas;
        }
    }
    /// <summary>
    /// 展示UI
    /// </summary>
    /// <param name="path">UI路径</param>
    /// <returns>返回展示的UI</returns>
    public IView Show(string path) {
        if(_uiStack.Count > 0) {
            string name = _uiStack.Peek();
            _viewsDict[name].Hide();
        }
        IView view = InitView(path);
        view.Show();
        _uiStack.Push(path);
        _viewsDict.Add(path, view);
        return view;
    }
    /// <summary>
    /// 初始化UI
    /// </summary>
    /// <param name="path">UI路径</param>
    /// <returns>返回初始化的UI</returns>
    private IView InitView(string path) {
        if(_viewsDict.ContainsKey(path)) {
            return _viewsDict[path];
        }
        GameObject viewGo = LoadMgr.Instance.LoadPrefab(path, Canvas.transform);
        Type type = BindUtil.GetType(path);
        Component comp = viewGo.AddComponent(type);
        IView iview = null;
        if(comp is IView) {
            iview = comp as IView;
            iview.Init();
        }else {
            Debug.LogError("当前添加脚本未继承自ViewBase");
        }
        return iview;
    }
    /// <summary>
    /// UI返回
    /// </summary>
    public void Back() {
        if(_uiStack.Count <= 1) {
            return;
        }
        //此时的栈顶页面 要关闭的页面
        string name = _uiStack.Pop();
        _viewsDict[name].Hide();
        //此时的栈顶 为要显示的页面
        name = _uiStack.Peek();
        _viewsDict[name].Show();
    }

    public void Hide(string path) {

    }

}