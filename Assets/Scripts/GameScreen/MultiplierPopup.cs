using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class MultiplierPopup : MonoBehaviour
{
    [SerializeField]
    private Camera _camera;
    [SerializeField]
    private RectTransform m_parent;
    [SerializeField]
    private RectTransform m_target;
    public void Display(Transform transform) {
        int multiplier = FindObjectOfType<ScoreMultiplierLogic>().CurrentMultiplier;
        var text = gameObject.GetComponent<TextMeshProUGUI>();
        text.text = $"X{multiplier}";
        // convert screen coords
        Vector2 adjustedPosition = _camera.WorldToScreenPoint(transform.position);

        adjustedPosition.x *= m_parent.rect.width / (float)_camera.pixelWidth;
        adjustedPosition.y *= m_parent.rect.height / (float)_camera.pixelHeight;
        m_target.rotation = transform.rotation;
        // set it
        m_target.anchoredPosition = adjustedPosition - m_parent.sizeDelta / 2f;
        // Trigger animation
        gameObject.GetComponentInParent<Animator>().SetTrigger("Display");
    }
}
