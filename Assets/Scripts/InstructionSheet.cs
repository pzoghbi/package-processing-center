using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionSheet : MonoBehaviour {
    [SerializeField] private GameObject instructionSheet;
    private bool toggled = false;
    private Coroutine shiftPositionRoutine;
    [SerializeField] private float shiftAnimTime = 1;
    private Vector2 startPos;
    [SerializeField] private Vector2 displayPos;
    private Vector2 SheetPos => instructionSheet.transform.position;
    
    private void Start() {
        startPos = SheetPos;
    }

    private void OnMouseDown() {
        Vector2 start, end;
        start = SheetPos;
        
        if (toggled) {
            end = startPos;
        }
        else {
            end = displayPos;
        }
        
        toggled = !toggled;
        ShiftPosition(start, end, shiftAnimTime);
    }

    private void ShiftPosition(Vector2 start, Vector2 end, float time) {
        if (shiftPositionRoutine != null) {
            StopCoroutine(shiftPositionRoutine);
        }
        
        shiftPositionRoutine = StartCoroutine(ShiftPositionRoutine(start, end, time));
    }

    private IEnumerator ShiftPositionRoutine(Vector2 start, Vector2 end, float time = 1) {
        var startTime = Time.time;
        var distance = Vector2.Distance(start, end);
        var speed = distance / time;
        var covered = (Time.time - startTime) * speed;
        var fraction = covered / distance;

        while (fraction < 1) {
            covered = (Time.time - startTime) * speed;
            fraction = covered / distance;
            instructionSheet.transform.position = Vector2.Lerp(start, end, (float)EaseOutCubic(fraction));
            yield return null;
        }
    }
    
    private double EaseOutCubic(double x) {
        return 1 - Math.Pow(1 - x, 3);
    }
}
