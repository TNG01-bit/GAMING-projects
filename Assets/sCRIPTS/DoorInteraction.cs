using System;
using System.Collections;
using UnityEngine;

public class DoorInteration : MonoBehaviour
{
    [SerializeField] float openAngle = 4f;
    [SerializeField] float openSpeed = 2f;
    [SerializeField] float openRange = 4f;
    [SerializeField] int KeyNeeded = 0;
    [SerializeField] bool isOpen = false;

    private Quaternion _closedRotation;
    private Quaternion _openRotation;
    private Coroutine _currentCoroutine;


    void Start()
    {
        _closedRotation = transform.rotation;
        _openRotation = Quaternion.Euler(transform.eulerAngles + new Vector3(0, openAngle, 0));
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && PlayerMovement.instance.PlayerKeys >= KeyNeeded)
        { 
            Vector3 player = PlayerMovement.instance.transform.position - gameObject.transform.position;
            float dist = player.magnitude;
            if (dist < openRange)
            {
                if (_currentCoroutine != null)
                {
                    StopCoroutine(_currentCoroutine);
                }
                _currentCoroutine = StartCoroutine(ToggleDoor());
            }
        }
    }

    private IEnumerator ToggleDoor()
    {
        Quaternion targetRotation = isOpen ? _closedRotation : _openRotation;
        isOpen = !isOpen;

        while (Quaternion.Angle(transform.rotation, targetRotation) > 0.01f)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * openSpeed);
            yield return null;
        }

        transform.rotation = targetRotation;
    }
}

