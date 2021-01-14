/****************************************************
    文件：UIUtil.cs
	作者：LSC
    邮箱: 314623971@qq.com
    日期：2021/1/14 13:29:24
	功能：UI工具类
*****************************************************/

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIUtil : MonoBehaviour 
{

    private Dictionary<string, UIUtilData> _uiUtilDataDict;

    public void Init() {
        _uiUtilDataDict = new Dictionary<string, UIUtilData>();
        RectTransform rect = transform.GetComponent<RectTransform>();
        foreach (RectTransform rectTransform in rect) {
            _uiUtilDataDict.Add(rectTransform.name, new UIUtilData(rectTransform));
        }
    }

    public UIUtilData Get(string name) {
        if(_uiUtilDataDict.ContainsKey(name)) {
            return _uiUtilDataDict[name];
        }else {//如果查找不到,可能传入的name是一个路径
            Transform tran = transform.Find(name);
            if(tran != null) {
                _uiUtilDataDict.Add(name, new UIUtilData(tran.GetComponent<RectTransform>()));
                return _uiUtilDataDict[name];
            }else {
                Debug.LogError("无法按照路径查找到物体,路径为:" + name);
                return null;
            }
        }
    }
}

public class UIUtilData {
    public GameObject Go { get; private set; }
    public RectTransform RectTran { get; private set; }
    public Button Btn { get; private set; }
    public Image Img { get; private set; }
    public Text Text { get; private set; }

    public UIUtilData(RectTransform rect) {
        this.RectTran = rect;
        this.Go = rect.gameObject;
        this.Btn = rect.GetComponent<Button>();
        this.Img = rect.GetComponent<Image>();
        this.Text = rect.GetComponent<Text>();
    }

    public void AddListener(Action action) {
        if(Btn != null) {
            Btn.onClick.AddListener(() => action());
        }else {
            Debug.LogError("当前物体上没有button组件，物体名称为" + Go.name);
        }
    }
    /// <summary>
    /// 设置Image的精灵
    /// </summary>
    /// <param name="sprite">要设置的精灵</param>
    /// <param name="isSetNativeSize">是否设置图片的原始尺寸</param>
    public void SetSprite(Sprite sprite,bool isSetNativeSize = true) {
        if (this.Img != null) {
            this.Img.sprite = sprite;
            if(isSetNativeSize) {
                this.Img.SetNativeSize();
            }
        } else {
            Debug.LogError("当前物体上没有image组件,物体名称为:" + Go.name);
        }
    }

}