﻿using UnityEngine;

public class PreloaderAnimator : MonoBehaviour
{
    public static PreloaderAnimator Instance;
    private Animator _animator;

    void Awake()
    {
        Instance = this;
        _animator = GetComponentInChildren<Animator>();
    }

    public void Play(string name)
    {
        _animator.SetTrigger(name);
    }

    public void Restart()
    {
        var windowsManager = FindObjectOfType<WindowsManagement>();
        windowsManager.ShowEnd();
    }
}