using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class WindowsManagement : MonoBehaviour
{
  public GameObject Level1;
  public GameObject Level2;
  public GameObject Level3;
  public GameObject Level4;
  public GameObject Intro;

  void Start()
    {
    Level1.active = false;
    Level2.active = false;
    Level3.active = false;
    Level4.active = false;
    var introVideo = Intro.GetComponentInChildren<VideoPlayer>();
    introVideo.Play();
  }

  public void StartLev1()
  {
    Level1.active = true;
    Level2.active = false;
    Level3.active = false;
    Level4.active = false;
  }

  public void StartLev2()
  {
    Level1.active = false;
    Level2.active = true;
    Level3.active = false;
    Level4.active = false;
  }

  public void StartLev3()
  {
    Level1.active = false;
    Level2.active = false;
    Level3.active = true;
    Level4.active = false;
  }

  public void StartLev4()
  {
    Level1.active = false;
    Level2.active = false;
    Level3.active = false;
    Level4.active = true;
  }

  // Update is called once per frame
  void Update()
    {
        
    }
}
