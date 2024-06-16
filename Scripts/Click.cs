using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Click : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    private Coroutine _coroutine;

    private float _delay = 0.5f;

    private int _score = 0;
    private bool IsWork = true;

    private void Update()
    {
        TheClick();
    }

    private void TheClick()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (IsWork == false)
            {
                StopCoroutine(_coroutine);
                _text.color = Color.black;
                IsWork = true;
            }
            else
            {
                _coroutine = StartCoroutine(Score());
                _text.color = Color.red;
                IsWork = false;
            }
        }
    }

    private IEnumerator Score()
    {
        var waiting = new WaitForSecondsRealtime(_delay);

        while (IsWork == true || IsWork == false)
        {
            yield return waiting;
            _score++;

            _text.text = _score.ToString();
        }
    }
}
