using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScaleCanvas : MonoBehaviour {
    private TMP_Text tmp;
    [SerializeField] private Scale scale;

    private void Awake() {
        tmp = GetComponent<TMP_Text>();
    }

    private void UpdateDigits(float value) {
        tmp.text = value.ToString("0.00");
    }

    private void OnEnable() {
        scale.ScaleChanged += UpdateDigits;
    }

    private void OnDisable() {
        scale.ScaleChanged -= UpdateDigits;
    }
}
