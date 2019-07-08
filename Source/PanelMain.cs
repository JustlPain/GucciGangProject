﻿using GGM.Caching;
using GGM.GUI.Pages;
using UnityEngine;

public class PanelMain : MonoBehaviour
{
    public GameObject label_credits;
    public GameObject label_multi;
    public GameObject label_option;
    public GameObject label_single;
    private int lang = -1;

    private void OnEnable()
    {
        Page.GetInstance<MainMenu>().Enable();
    }

    private void OnDisable()
    {
        Page.GetInstance<MainMenu>().Disable();
    }

    private void showTxt()
    {
        if (lang != Language.type)
        {
            lang = Language.type;
            label_single.GetComponent<UILabel>().text = Language.btn_single[Language.type];
            label_multi.GetComponent<UILabel>().text = Language.btn_multiplayer[Language.type];
            label_option.GetComponent<UILabel>().text = Language.btn_option[Language.type];
            label_credits.GetComponent<UILabel>().text = Language.btn_credits[Language.type];
        }
    }

    private void Update()
    {
        showTxt();
    }
}