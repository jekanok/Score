using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Click : MonoBehaviour
{
    [SerializeField] private Text Text;

    private Coroutine _coroutine;

    private int _score = 0;
    private bool IsWork = true;

    private void Update()
    {
        OnClick();
    }

    public void OnClick()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (IsWork == false)
            {
                IsWork = true;
                StopCoroutine(_coroutine);
            }
            else
            {
                IsWork = false;
                _coroutine = StartCoroutine(Score());
            }
        }
        
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            StopCoroutine(_coroutine);
            _score = 0;
            Text.text = _score.ToString();
        }
    }

    private IEnumerator Score()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            _score++;

            Text.text = _score.ToString();
        }
    }
}
