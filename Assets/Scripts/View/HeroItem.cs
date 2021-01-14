/****************************************************
    文件：HeroItem.cs
	作者：LSC
    邮箱: 314623971@qq.com
    日期：2021/1/14 17:33:21
	功能：英雄Item
*****************************************************/

using DG.Tweening;
using System;
using UnityEngine;
using UnityEngine.UI;

public class HeroItem : MonoBehaviour 
{
    private const float _time = 0.5f;
    private Color _defaultColor = Color.gray;
    private Color _selectColor = Color.white;
    private Image _img;
    private Action _callBack;

    private void Start() {
        _img = GetComponent<Image>();
        GetComponent<Button>().onClick.AddListener(OnSelected);
        _img.color = _defaultColor;
    }

    private void OnSelected() {
        if(_callBack != null) {
            _callBack();
        }
        _img.DOKill();
        _img.DOColor(_selectColor, _time);
    }

    public void OnUnSelected() {
        _img.DOKill();
        _img.DOColor(_defaultColor, _time);
    }

    public void AddResetListener(Action action) {
        _callBack = action;
    }

}