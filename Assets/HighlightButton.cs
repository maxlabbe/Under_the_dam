using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HighlightButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Image image;
    public Sprite deselectedSprite;
    public Sprite selectedSprite;
    // Start is called before the first frame update
    void Start()
    {
        //Récupère le material de notre objet
        image = GetComponent<Image>();

        // On vient setter la couleur de l'outline
        image.sprite = deselectedSprite;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        image.sprite = selectedSprite;
        Debug.Log("Enter");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        image.sprite = deselectedSprite;
    }
}
