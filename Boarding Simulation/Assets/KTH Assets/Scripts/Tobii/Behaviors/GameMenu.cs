﻿//-----------------------------------------------------------------------
// Copyright 2014 Tobii Technology AB. All rights reserved.
//-----------------------------------------------------------------------
using UnityEngine;

public class GameMenu : MonoBehaviour
{
    private TitleGUI _titleGui;

    private bool _isVisible;
    private Camera _gameMenuCamera;

    /// <summary>
    /// Locate the game menu object on Awake
    /// </summary>
    public void Awake()
    {
        _titleGui = GameObject.Find("TitleGUI").GetComponent<TitleGUI>();
        if (_titleGui == null)
        {
            print("ERROR: TitleGUI not found.");
        }
    }

    /// <summary>
    /// Returns true if the game menu is visible
    /// </summary>
    public bool IsVisible
    {
        get
        {
            return _isVisible;
        }

        set
        {
            _isVisible = value;
            _gameMenuCamera.enabled = _isVisible;
            _titleGui.enabled = !_isVisible;
        }
    }

    /// <summary>
    /// Initialize game menu camera on start
    /// </summary>
    void Start()
    {
        _gameMenuCamera = gameObject.GetComponentInChildren<Camera>();
        _gameMenuCamera.enabled = false;
    }

    /// <summary>
    /// Update visibility when space is clicked
    /// </summary>
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            IsVisible = !IsVisible;
        }
    }
}
