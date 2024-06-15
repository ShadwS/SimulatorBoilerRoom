using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pays : MonoBehaviour
{
    [SerializeField] GameObject paysPanel;
    [SerializeField] Text valueSensa;
    private void Start()
    {
        PlayerRotation.ChangeOfSenses += TextSensUpdate;
        paysPanel.SetActive(false);
        StartCoroutine(StartPays());
    }
    private void OnDestroy()
    {
        PlayerRotation.ChangeOfSenses -= TextSensUpdate;
    }
    private IEnumerator StartPays()
    {
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Escape));
        paysPanel.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0;
        yield return new WaitUntil(() => Input.GetKeyUp(KeyCode.Escape));
        StartCoroutine(Continu());
    }
    private IEnumerator Continu()
    {
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Escape));
        Time.timeScale = 1;
        paysPanel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        yield return new WaitUntil(() => Input.GetKeyUp(KeyCode.Escape));
        StartCoroutine(StartPays());
    }
    public void TextSensUpdate(float value)
    {
        valueSensa.text = String.Format("{0:0}", value);
    }
}
