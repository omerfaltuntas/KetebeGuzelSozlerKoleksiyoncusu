using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace KetebeFirtinaDolabi
{
    public class FD_BlueprintDragDrop : MonoBehaviour
    {
        [Header("Distance")]
        [SerializeField] private float distanceMeasurement = 2f;

        [Header("Puzzle Elements")]
        [SerializeField] private List<FD_Slot> slots = new List<FD_Slot>();
        [SerializeField] private int pieceId;
        [SerializeField] private float placementDuration = 1f;
        [SerializeField] private float scaleDuration = 1f;

        private Vector3 originalPos;
        private bool isDragging;
        private bool isPlaced;
        public int sceneIndex;

        private Vector3 offset;

        public int oldLayerValue;

        private void Awake()
        {
            sceneIndex = SceneManager.GetActiveScene().buildIndex;
            originalPos = transform.localPosition;
            originalPos.z = -1f; // Başlangıçta z pozisyonunu -1 olarak ayarla
            transform.localPosition = originalPos;
        }

        private void OnDisable()
        {
            transform.localPosition = originalPos;
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, -1f); // z pozisyonunu -1 olarak ayarla
            this.gameObject.GetComponent<Collider2D>().enabled = true;
            isPlaced = false;
            isDragging = false;
            transform.localScale = new Vector3(1, 1, 1);
            offset.z = -1f; // Nesne devre dışı bırakıldığında offset.z değerini -1 olarak ayarla
        }

        private void Update()
        {
            if (isPlaced) return;

            if (isDragging)
            {
                var touchPos = GetTouchPos();
                transform.position = touchPos - (Vector2)offset;
                transform.position = new Vector3(transform.position.x, transform.position.y, -1f); // Sürükleme sırasında z pozisyonunu -1 olarak ayarla
            }
        }

        private void OnMouseDown()
        {
            if (Input.GetMouseButtonDown(0))
            {
                GetComponent<SpriteRenderer>().sortingOrder = 25;
                isDragging = true;
                offset = GetTouchPos() - (Vector2)transform.localPosition;
                offset.z = -1f; // Mouse aşağıdayken offset.z değerini -1 olarak ayarla
            }
        }

        private void OnMouseUp()
        {
            if (Input.GetMouseButtonUp(0))
            {
                bool isCorrectPlacement = false;

                GetComponent<SpriteRenderer>().sortingOrder = oldLayerValue;

                foreach (FD_Slot slot in slots)
                {
                    if (Vector2.Distance(transform.localPosition, slot.transform.localPosition) < distanceMeasurement)
                    {
                        isCorrectPlacement = true;
                        OnCorrectPlacement(slot);
                        offset.z = -1f; // Doğru yerleştirme sonrası offset.z değerini -1 olarak ayarla
                        break;
                    }
                }

                if (!isCorrectPlacement)
                {
                    OnIncorrectPlacement();
                }
            }
        }

        private Vector2 GetTouchPos()
        {
            return Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        private void OnCorrectPlacement(FD_Slot puzzleSlot)
        {
            if (puzzleSlot.isFilled)
            {
                OnIncorrectPlacement();
                return;
            }

            puzzleSlot.isFilled = true;
            Vector3 targetPosition = puzzleSlot.transform.localPosition;
            targetPosition.z = -1f; // Hedef pozisyonun z değerini -1 olarak ayarla
            transform.DOLocalMove(targetPosition, placementDuration);
            transform.DOScale(puzzleSlot.transform.localScale, scaleDuration);

            isPlaced = true;
            this.gameObject.GetComponent<Collider2D>().enabled = false;

            //KM_AudioManager.instance.PlayClip("PositiveSound");
        }

        private void OnIncorrectPlacement()
        {
            Vector3 targetPosition = originalPos;
            targetPosition.z = -1f; // Orijinal pozisyonun z değerini -1 olarak ayarla
            transform.DOLocalMove(targetPosition, placementDuration);
            isDragging = false;
        }
    }
}
