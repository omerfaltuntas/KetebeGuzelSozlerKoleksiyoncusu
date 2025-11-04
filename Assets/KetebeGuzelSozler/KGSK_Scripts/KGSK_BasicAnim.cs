using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KetebeGuzelSK
{
    public class KGSK_BasicAnim : MonoBehaviour
    {
        private void OnMouseDown()
        {
            if (Input.GetMouseButtonDown(0))
            {
                GetComponent<Animator>().enabled = true;
            }
        }
        private void OnDisable()
        {
            GetComponent<Animator>().enabled = false;
        }
    }

}
