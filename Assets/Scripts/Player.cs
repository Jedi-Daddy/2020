using System;
using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    private const string Vertical = "VerticalDirection";
    private const string Horizonatal = "HorizontalDirection";

    public int Speed = 10;
    public int MovementDistance = 100;

    private bool isBusy;
    private Animator _animator;
    private Rigidbody2D _rigidbody;

    private int _verticalOrientation = 1;
    private int _horizontalOrientation = 1;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void InverseOrientation(bool horizontalInversed, bool verticalInversed)
    {
        _verticalOrientation = verticalInversed ? -1 : 1;
        _horizontalOrientation = horizontalInversed ? -1 : 1;
    }

    public void Move(Vector2 distance)
    {
        if (isBusy)
            return;

        StartCoroutine(MoveImpl(distance));
    }

    private IEnumerator MoveImpl(Vector2 distance)
    {
        isBusy = true;
        var currentPosition = _rigidbody.position;

        var direction = Direction(distance);
        var endPoint = currentPosition + direction * MovementDistance * new Vector2(_verticalOrientation, _horizontalOrientation);

        TriggerAnimation(direction);

        yield return new WaitForSeconds(0.3f);

        while ((currentPosition - endPoint).magnitude > 1)
        {
            currentPosition = Vector3.Lerp(currentPosition, endPoint, Time.deltaTime * Speed);
            _rigidbody.MovePosition(currentPosition);

            yield return null;
        }

        isBusy = false;
    }

    private Vector2 Direction(Vector2 distance)
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
