using System.Collections;
using TMPro;
using UnityEngine;

public class Click : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    private Coroutine _coroutine;

    private float _delay = 0.5f;
    private int _score = 0;
    private bool IsWork = false;

    private void Start()
    {
        _coroutine = StartCoroutine(IsScore());
    }

    private void Update()
    {
        IsClick();
    }

    private void IsClick()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (IsWork != true)
            {
                IsWork = true;
                StartCoroutine(IsScore());
                _text.color = Color.red;
            }
            else
            {
                IsWork = false;

                if (_coroutine != null)
                {
                    StopCoroutine(_coroutine);
                }

                _text.color = Color.black;
            }
        }
    }

    private IEnumerator IsScore()
    {
        var waiting = new WaitForSecondsRealtime(_delay);

        while (IsWork)
        {
            _score++;
            _text.text = _score.ToString();

            yield return waiting;
        }
    }
}
