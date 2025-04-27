using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonGuiChange : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
	private Image imgComponent;

	public Sprite pressedBtnSprite;
	private Sprite unpressedBtnSprite;

	private void Start()
	{
		// Fallback if not manually assigned in Inspector
		if (imgComponent == null)
			imgComponent = GetComponent<Image>();

		if (imgComponent != null && unpressedBtnSprite == null)
			unpressedBtnSprite = imgComponent.sprite;
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		if (imgComponent != null && pressedBtnSprite != null)
		{
			imgComponent.sprite = pressedBtnSprite;
		}
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		if (imgComponent != null && unpressedBtnSprite != null)
		{
			imgComponent.sprite = unpressedBtnSprite;
		}
	}
}
