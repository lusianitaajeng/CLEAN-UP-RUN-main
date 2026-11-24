using UnityEngine;
using UnityEngine.InputSystem;

public class RunnerMoves : MonoBehaviour
{
    public float jarakJalur = 0.5f;
    public float kecepatanGeser = 5f;

    private int jalur = 0;
    private float posisiAwalX;

    void Start()
    {
        posisiAwalX = transform.position.x;
    }

    void Update()
    {
        if (Keyboard.current == null)
            return;

        if (Keyboard.current.leftArrowKey.wasPressedThisFrame)
            jalur = Mathf.Max(jalur - 1, -1);

        if (Keyboard.current.rightArrowKey.wasPressedThisFrame)
            jalur = Mathf.Min(jalur + 1, 1);

        Vector3 target = transform.position;
        target.x = posisiAwalX + jalur * jarakJalur;

        transform.position = Vector3.MoveTowards(
            transform.position,
            target,
            kecepatanGeser * Time.deltaTime
        );
    }
}