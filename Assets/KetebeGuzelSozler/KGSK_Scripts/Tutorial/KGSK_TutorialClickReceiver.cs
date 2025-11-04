using UnityEngine;
using System;

namespace KetebeFirtinaDolabi
{

    public class KGSK_TutorialClickReceiver : MonoBehaviour
    {
        private Action onClick;

        // Disaridan tetiklenecek callback baglanir
        public void Assign(Action callback)
        {
            onClick = callback;
        }

        private void OnMouseDown()
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (onClick == null)
                {
                    Debug.LogWarning($"[TutorialClickHandler] onClick atanmadı: {gameObject.name}");
                    return;
                }

                onClick.Invoke();
            }
        }
    }
}
