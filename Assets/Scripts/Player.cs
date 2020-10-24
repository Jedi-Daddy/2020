using System;
using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    private const string Vertical = "VerticalDirection";
    private const string Horizonatal = "HorizontalDirection";

    public int Speed = 15;
    public int MovementDistance = 100;

    private bool isBusy;
    private Animator _animator;
    private RectTransform _rectTransform;

    private int _verticalOrientation = 1;
    private int _horizontalOrientation = 1;

    private Coroutine _coroutine;
    public IMap _map;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _rectTransform = GetComponent<RectTransform>();
    }

    public void InverseOrientation(bool horizontalInversed, bool verticalInversed)
    {
        _verticalOrientation = verticalInversed ? -1 : 1;
        _horizontalOrientation = horizontalInversed ? -1 : 1;
    }

    public void SetMap(IMap map)
    {
        _map = map;
    }

    public void Move(Vector2 distance)
    {
        if (isBusy)
            return;

        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(MoveImpl(distance));
    }

    private IEnumerator MoveImpl(Vector2 distance)
    {
        isBusy = true;
        var currentPosition = _rectTransform.localPosition;

        var direction = Direction(distance);
        var endPoint = currentPosition + Vector3.Scale(direction, new Vector3(_verticalOrientation, _horizontalOrientation, 0)) * MovementDistance;

        if (!_map.CanGo((int)direction.x * _verticalOrientation, (int)direction.y * _horizontalOrientation))
        {
            isBusy = false;
            yield break;
        }

        TriggerAnimation(direction);

        yield return new WaitForSeconds(0.3f);

        while ((currentPosition - endPoint).magnitude > 2)
        {
            currentPosition = Vector3.Lerp(currentPosition, endPoint, Time.deltaTime * Speed);
            _rectTransform.localPosition = currentPosition;

            yield return null;
        }

        _rectTransform.localPosition = endPoint;
        _coroutine = null;
        isBusy = false;
    if(_map.IsFinish())
      {
      isBusy = false;
      var windowsManager = FindObjectOfType<WindowsManagement>();
      windowsManager.ToNextLevel();
      yield break;
    }
    if (_map.IsDead())
    {
      isBusy = false;
      var windowsManager = FindObjectOfType<WindowsManagement>();
      windowsManager.ShowEnd();
      yield break;
    }
  }

    private Vector3 Direction(Vector2 distance)
    {
        if (Math.Abs(distance.x) > Math.Abs(distance.y))
            return distance.x > 0 ? Vector3.right : Vector3.left;
        else
            return distance.y > 0 ? Vector3.up : Vector3.down;
    }

    private void TriggerAnimation(Vector3 direction)
    {
        _animator.SetFloat(Vertical, 0);
        _animator.SetFloat(Horizonatal, 0);

        var isHorizontal = Math.Abs(direction.x) > Math.Abs(direction.y);

        if (isHorizontal)
            _animator.SetFloat(Horizonatal, direction.x * _verticalOrientation);
        else
            _animator.SetFloat(Vertical, direction.y * _horizontalOrientation);
    }
}
