using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class ShowFPS : MonoBehaviour
{
    TMP_Text fpsText;
    float deltaTime;

    private void Start()
    {
        fpsText = GetComponent<TMP_Text>();
    }

    void Update()
    {
        deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
        float fps = 1.0f / deltaTime;
        fpsText.text = Mathf.Ceil(fps).ToString();
    }
}