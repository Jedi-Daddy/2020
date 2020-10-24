using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowsManagement : MonoBehaviour
{
  public GameObject Level1;
  public GameObject Level2;
  public GameObject Level3;
  public GameObject Level4;

  void Start()
    {
    Level1.active = false;
    Level2.active = false;
    Level3.active = false;
    Level4.active = false;


  }

  public void StartLev1()
  {
    Level1.active = true;
    Level2.active = false;
    Level3.active = false;
    Level4.active = false;
  }

    // Update is called once per frame
    void Update()
    {
        
    }
}
