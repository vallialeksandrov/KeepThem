
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [Header("Joystick")]
    [SerializeField] private Joystick joystick;
    [SerializeField] private GameObject joystickPrefab;
    [SerializeField] private float joystickResist;

    [Header("Properties")]
    [SerializeField] private float sensitivity, freezeForce;
    [SerializeField] private Vector3 startPosition;

    private const string controlKey = "NumberController";

    private void Start()
    {
        startPosition = transform.position;

        if (PlayerPrefs.GetInt(controlKey) == 0)
            joystickPrefab.SetActive(false);
        else
            joystickPrefab.SetActive(true);

        joystickResist = 0.5f;
        sensitivity = 2;
        freezeForce = 1;
    }

    private void OnEnable()
    {
        ComplicationGame.onComplicated += IncreaseSpeed;
        Bonus.onFreezed += FreezeControl;
    }

    private void OnDisable()
    {
        ComplicationGame.onComplicated -= IncreaseSpeed;
        Bonus.onFreezed -= FreezeControl;
    }

    private void FixedUpdate()
    {
        transform.position = startPosition;

        if (PlayerPrefs.GetInt(controlKey) == 0)
            ControlAcceleration();
        else
            ControlJoystick();
    }

    private void ControlAcceleration()
    {
        if (Input.acceleration.x < 0 || Input.acceleration.x > 0)
            transform.Rotate(0, Input.acceleration.x * -sensitivity * freezeForce, 0);

        if (Input.acceleration.y > 0 || Input.acceleration.y < 0)
            transform.Rotate(Input.acceleration.y * -sensitivity * freezeForce, 0, 0);       
    }

    private void ControlJoystick()
    {
        if (joystick.Horizontal < 0 || joystick.Horizontal > 0)
            transform.Rotate(0, joystick.Horizontal * joystickResist * -sensitivity * freezeForce, 0);

        if (joystick.Vertical > 0 || joystick.Vertical < 0)
            transform.Rotate(joystick.Vertical * joystickResist * -sensitivity * freezeForce, 0, 0);
    }

    private void IncreaseSpeed() => sensitivity += 0.5f;

    private void FreezeControl()
    {
        freezeForce = 0.1f;
        StartCoroutine(UnFreeze());
    }

    private IEnumerator UnFreeze()
    {
        yield return new WaitForSeconds(4f);
        freezeForce = 1;
    }
}
