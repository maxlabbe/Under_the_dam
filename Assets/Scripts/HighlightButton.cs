using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HighlightButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Sprite deselectedSprite;
    public Sprite selectedSprite;
    public GameObject imageObject;
    public AudioSource sound;

    private Image m_image;
    private bool wasClicked = false;
    
    // Start is called before the first frame update
    void Start()
    {
        // Find the image component on the object
        m_image = imageObject.GetComponent<Image>();

        // Set the image to the deselected image
        m_image.sprite = deselectedSprite;
    }

    void Update()
    {
        if(wasClicked)
        {
            m_image.sprite = deselectedSprite;
            wasClicked = false;
        }
    }

    // What happendened when the mousse enter the button
    public void OnPointerEnter(PointerEventData eventData)
    {
        // Set the image to the selected one
        m_image.sprite = selectedSprite;

        //play the audio source
        sound.Play();
    }

    // What happendened when the mousse exit the button
    public void OnPointerExit(PointerEventData eventData)
    {
        // Set the image to the deselcted one
        m_image.sprite = deselectedSprite;

        //reload the audio source
        sound.Stop();
    }

    public void OnClic()
    {
        wasClicked = true;
    }
}
