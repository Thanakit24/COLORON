using UnityEngine;
using UnityEngine.UI;

public class ColorSlider : MonoBehaviour
{
    public Slider slider;
    private Image image;

    private void Start()
    {
        image = transform.Find("Fill").GetComponent<Image>();
    }
    public void ResetTimer(SelectColor color)
    {
        slider.value = 0;
        switch (color)
        {
            case SelectColor.White:
                image.color = Color.white;
                break;

            case SelectColor.Cyan:
                image.color = Color.cyan;
                break;

            case SelectColor.Red:
                image.color = Color.red;
                break;         
        }
        
    }

    //Action = force color to change
    public void SetColorProgress(float change)
    {
        slider.value = change;
    }

}
