using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Canva_control : MonoBehaviour
{
    RayShooter rayShooter;
    public GameObject candle_small;
    public GameObject convex_prefab;
    public GameObject concave_prefab2;
    public GameObject Scence_lens;
    public TextMeshProUGUI textMeshProUGUI;
    void Start()
    {
        rayShooter = candle_small.GetComponent<RayShooter>();
    }
    public void ConvexClick()
    {
        Destroy(Scence_lens);
        Scence_lens = Instantiate(convex_prefab, Vector3.zero, Quaternion.Euler(0f,90f,0f));
        rayShooter.Focal_legnth = 10f;
    }
    public void ConcaveClick()
    {
        Destroy(Scence_lens);
        Scence_lens = Instantiate(concave_prefab2, Vector3.zero, Quaternion.Euler(0f, 0f, 90f));
        rayShooter.Focal_legnth = -10f;
    }
    private void Update()
    {
        if(rayShooter.Image_location.x>0 && Mathf.Abs(rayShooter.magnification)>1)
        {
            textMeshProUGUI.text = "Image: real, inverted and enlarged";
        }
        else if (rayShooter.Image_location.x > 0 && Mathf.Abs(rayShooter.magnification) == 1)
        {
            textMeshProUGUI.text = "Image: real, inverted and same size";
        }
        else if (rayShooter.Image_location.x > 0 && Mathf.Abs(rayShooter.magnification) < 1)
        {
            textMeshProUGUI.text = "Image: real, inverted and diminished";
        }
        else if (rayShooter.Image_location.x < 0 && Mathf.Abs(rayShooter.magnification) < 1)
        {
            textMeshProUGUI.text = "Image: virtual, erect and diminished";
        }
        else if (rayShooter.Image_location.x < 0 && Mathf.Abs(rayShooter.magnification) > 1)
        {
            textMeshProUGUI.text = "Image: virtual, erect and enlarged";
        }
    }
}
