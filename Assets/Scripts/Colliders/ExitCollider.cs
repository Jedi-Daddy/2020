using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using UnityEngine;

namespace Assets.Scripts.Colliders
{
  public class ExitCollider : MonoBehaviour
  {
    public Camera mainCamera;
    public void OnTriggerEnter2D(Collider2D collision)
    {
      var windowsManager = mainCamera.GetComponent<WindowsManagement>();
      windowsManager.ShowLoading2();
    }
  }
}
