using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class unitTest : MonoBehaviour
{
    // Start is called before the first frame update
    private void Update()
    {
        Image image = GetComponent<Image>();
        image.overrideSprite = ResourceIconExtractor.instance.Search("sake");
    }

    // Update is called once per frame
}
