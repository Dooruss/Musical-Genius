using System.Collections;
using TMPro;
using UnityEngine;

public class ErrorPopup : MonoBehaviour
{
    public GameObject panel;
    public TMP_Text errorText;
    public float displayTime = 3f;
    private Coroutine hideRoutine;

    public void ShowError(string message)
    {
        panel.SetActive(true);
        errorText.text = message;

        if (hideRoutine != null) StopCoroutine(hideRoutine);

        hideRoutine = StartCoroutine(HideAfterTime());
    }

    IEnumerator HideAfterTime()
    {
        yield return new WaitForSeconds(displayTime);
        panel.SetActive(false);
    }

}