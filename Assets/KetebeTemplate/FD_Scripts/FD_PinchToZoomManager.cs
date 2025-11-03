using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
//Namespace degistirilecek
namespace KetebeFirtinaDolabi
{
    public class FD_PinchToZoomManager : MonoBehaviour, IPointerDownHandler
    {
        public Image zoomBtnImage;
        public Sprite[] zoomSprites;
        private bool zoom;

        public void OnPointerDown(PointerEventData eventData)
        {
            FD_PinchToZoomCamera.instance.ZoomActiverDeactiver();

            zoom = !zoom;
            if (zoom)
            {
                zoomBtnImage.sprite = zoomSprites[1];
            }
            else
            {
                zoomBtnImage.sprite = zoomSprites[0];
            }
        }
    }

}
