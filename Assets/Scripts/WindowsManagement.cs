using UnityEngine;
using UnityEngine.Video;
using Unity;
using UnityEngine.Experimental.UIElements;
using Assets.Scripts;

public class WindowsManagement : MonoBehaviour
{
  public GameObject Level1;
  public GameObject Level2;
  public GameObject Level3;
  public GameObject Level4;
  public GameObject Intro;
  public GameObject Loading;

  public GameObject Menu;

  private int currentLevel = 0;

  void Start()
    {
    Menu.GetComponentInChildren<ButtonScript>().ActionDelegate += ShowRestart;
    Menu.GetComponentInChildren<ButtonScriptExit>().ActionDelegate += ExitGame;

    //Intro.active = true;
    //Level1.active = false;
    //Level2.active = false;
    //Level3.active = false;
    //Level4.active = false;
    //Loading.active = false;
    //Menu.active = false;
    var introVideo = Intro.GetComponentInChildren<VideoPlayer>();
    //introVideo.Play();
    //introVideo.loopPointReached += ShowLoading1;
    StartLev1(introVideo);
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
    Level1.active = false;
    Level2.active = false;
    Level3.active = false;
    Level4.active = false;
    Menu.active = true;
  }
  public void ShowRestart()
  {
    Menu.active = false;
    var loadingVideo = Loading.GetComponentInChildren<VideoPlayer>();
    switch (currentLevel)
    {
      case 1:
        var map1 = Level1.GetComponentInChildren<Map1>();
        map1.SetStartPosition();
        StartLev1(loadingVideo);
        return;
      case 2:
        var map21 = Level2.GetComponentInChildren<Map2>();
        map21.SetStartPosition();
        var map22 = Level2.GetComponentInChildren<Map2_Invert>();
        map22.SetStartPosition();
        StartLev2(loadingVideo);
        return;
      case 3:
        var map31 = Level3.GetComponentInChildren<Map3>();
        map31.SetStartPosition();
        var map32 = Level3.GetComponentInChildren<Map3_Invert2>();
        map32.SetStartPosition();
        StartLev3(loadingVideo);
        return;
      case 4:
        var map41 = Level4.GetComponentInChildren<Map4>();
        map41.SetStartPosition();
        var map42 = Level4.GetComponentInChildren<Map4_Invert>();
        map42.SetStartPosition();
        StartLev4(loadingVideo);
        return;
    }
  }

  public void ExitGame()
  {
    Application.Quit();
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
    Loading.active = false;
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
    Loading.active = false;
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
    Loading.active = false;
    currentLevel = 4;
  }
  public void GameEnd()
  {
    Intro.active = true;
    Level1.active = false;
    Level2.active = false;
    Level3.active = false;
    Level4.active = false;
    Loading.active = false;
    var introVideo = Intro.GetComponentInChildren<VideoPlayer>();
    introVideo.Play();
    //introVideo.loopPointReached += ShowLoading1;
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
