using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleUICanvasController : Singleton<TitleUICanvasController>
{
    [SerializeField]
    private Button _suiButton;

    [SerializeField]
    private GameObject _suiUICanvas;
    
    private void Start()
    {
        _suiButton.onClick.AddListener(() =>
        {
            _suiUICanvas.SetActive(true);
            gameObject.SetActive(false);
        });
    }
}
