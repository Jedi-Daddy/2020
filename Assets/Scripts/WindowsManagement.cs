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
  public GameObject Loading;

  private int currentLevel = 0;

  void Start()
    {
    Intro.active = false;
    Level1.active = true;
    Level2.active = false;
    Level3.active = false;
    Level4.active = false;
    Loading.active = false;
    //var introVideo = Intro.GetComponentInChildren<VideoPlayer>();
    //introVideo.Play();
    //introVideo.loopPointReached += ShowLoading1;
  }

  public void ShowLoading1(VideoPlayer vp)
  {
    vp.Stop();
    Intro.active = false;
    Level1.active = false;
    Level2.active = false;
    Level3.active = false;
    Level4.active = false;
    Loading.active = true;
    var loadingVideo = Loading.GetComponentInChildren<VideoPlayer>();
    loadingVideo.Play();
    loadingVideo.loopPointReached += StartLev1;
  }

  public void ShowLoading2()
  {
    Intro.active = false;
    Level1.active = false;
    Level2.active = false;
    Level3.active = false;
    Level4.active = false;
    Loading.active = true;
    var loadingVideo = Loading.GetComponentInChildren<VideoPlayer>();
    loadingVideo.Play();
    loadingVideo.loopPointReached += StartLev2;
  }

  public void ShowLoading3()
  {
    Intro.active = false;
    Level1.active = false;
    Level2.active = false;
    Level3.active = false;
    Level4.active = false;
    Loading.active = true;
    var loadingVideo = Loading.GetComponentInChildren<VideoPlayer>();
    loadingVideo.Play();
    loadingVideo.loopPointReached += StartLev3;
  }

  public void ShowLoading4()
  {
    Intro.active = false;
    Level1.active = false;
    Level2.active = false;
    Level3.active = false;
    Level4.active = false;
    Loading.active = true;
    var loadingVideo = Loading.GetComponentInChildren<VideoPlayer>();
    loadingVideo.Play();
    loadingVideo.loopPointReached += StartLev4;
  }

  public void ShowEnd()
  {
    Intro.active = false;
    Level1.active = false;
    Level2.active = false;
    Level3.active = false;
    Level4.active = false;
  }

  public void StartLev1(VideoPlayer vp)
  {
    vp.Stop();
    Intro.active = false;
    Level1.active = true;
    Level2.active = false;
    Level3.active = false;
    Level4.active = false;
    Loading.active = false;
    currentLevel = 1;
  }

  public void StartLev2(VideoPlayer vp)
  {
    vp.Stop();
    Intro.active = false;
    Level1.active = false;
    Level2.active = true;
    Level3.active = false;
    Level4.active = false;
    currentLevel = 2;
  }

  public void StartLev3(VideoPlayer vp)
  {
    vp.Stop();
    Intro.active = false;
    Level1.active = false;
    Level2.active = false;
    Level3.active = true;
    Level4.active = false;
    currentLevel = 3;
  }

  public void StartLev4(VideoPlayer vp)
  {
    vp.Stop();
    Intro.active = false;
    Level1.active = false;
    Level2.active = false;
    Level3.active = false;
    Level4.active = true;
    currentLevel = 4;
  }

  public void ToNextLevel()
  {
    switch (currentLevel)
    {
      case 1:
        ShowLoading2();
        return;
      case 2:
        ShowLoading3();
        return;
      case 3:
        ShowLoading4();
        return;
      case 4:
        ShowEnd();
        return;

    }
  }


  // Update is called once per frame
  void Update()
    {
        
    }
}
