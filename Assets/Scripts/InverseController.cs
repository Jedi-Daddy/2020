﻿using UnityEngine;

public class InverseController : MonoBehaviour
{
    public bool VerticalInversed = false;
    public bool HorizontalInversed = false;

    private Player _player;

  //private void Awake()
  //{
  //    _player = GetComponentInChildren<Player>();
  //    InversePlayerController();
  //}
  public void Start()
  {
    _player = GetComponentInChildren<Player>();
    InversePlayerController();
  }
  private void InversePlayerController()
    {
        _player.InverseOrientation(HorizontalInversed, VerticalInversed);
    }    
}
