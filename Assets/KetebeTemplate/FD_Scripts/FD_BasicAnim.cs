using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace KetebeFirtinaDolabi
{
    public class FD_BasicAnim : MonoBehaviour
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
