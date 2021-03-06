﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIManager : MonoBehaviour
{
    public Animator ChangeModeController, GreenGloveController, RedGloveController;
    public GameObject PanelMenu;
    public GameObject PanelSkins;
    public Rigidbody BallRigidbody;

    private bool VS;

    // Start is called before the first frame update
    void Start()
    {
        VS = false;
#if UNITY_EDITOR
        StartCoroutine(test());
#endif
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && !DrawLevel.gameIsRunning)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began && !EventSystem.current.IsPointerOverGameObject(touch.fingerId))
            {
                DrawLevel.gameIsRunning = true;
                BallRigidbody.isKinematic = false;
                PanelMenu.SetActive(false);
                PanelSkins.SetActive(false);
            }
        }
    }

    public void ChangeMode()
    {
        VS = !VS;
        Debug.Log("VS : " + VS);
        ChangeModeController.SetBool("VS", VS);
        GreenGloveController.SetBool("VS", VS);
        RedGloveController.SetBool("VS", VS);
    }

#if UNITY_EDITOR
    private IEnumerator test()
    {
        yield return new WaitForSeconds(11f);
        DrawLevel.gameIsRunning = true;
        BallRigidbody.isKinematic = false;
        PanelMenu.SetActive(false);
        PanelSkins.SetActive(false);
    }
#endif
}
