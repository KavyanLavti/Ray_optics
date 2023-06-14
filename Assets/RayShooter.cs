using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class RayShooter : MonoBehaviour
{
    //[SerializeField] private float coneAngle = 30f;
    [SerializeField] private float coneLength = 10f;
    //[SerializeField] private float angularResolution = 1f;
    public Transform lens_transform;
    public GameObject Light_emmitor;
    public float Candle_speed;
    Camera_movement camera_Movement;
    public GameObject CAMRA;


    [Header("Image_calculation")]
    public float Focal_legnth;
    Vector3 Object_location;
    public Vector3 Image_location;
    //Vector3 Object_dimentions;
    //Vector3 Image_dimentions;
    public float magnification;
    //float Latreal_magnification;
    Vector3 Object_scale;
    public bool Lens_type;
    // true means convex, false means concave

    [Header("Image_formation")]
    public GameObject Object;
    GameObject Image = null;
    int i;

    [Header("movement")]
    float X_move;
    float Y_move;
    public float Lend_height;
    public float candle_height;
    Vector3 ini_pos;

    [Header("Draw_ray")]
    LineRenderer ln;
    LineRenderer lr;
    Vector3 Image_light_emittor;
    Vector3 parll_line;
    public TextMeshProUGUI text;
    private void Start()
    {
        Object_scale = transform.localScale;
        i = 0;
        camera_Movement = CAMRA.GetComponent<Camera_movement>();
        ln = Light_emmitor.GetComponent<LineRenderer>();
        lr = GetComponent<LineRenderer>();
        ln.positionCount = 6;
        ini_pos = transform.position;
    }
    private void draw_ray()
    {
        ln.SetPosition(0, Light_emmitor.transform.position);
        ln.SetPosition(1, lens_transform.position);
        ln.SetPosition(2, Image_light_emittor);
        ln.SetPosition(3, Light_emmitor.transform.position);
        Vector3 secondRay_direction = Light_emmitor.transform.right;
        RaycastHit hit;
        if (Physics.Raycast(Light_emmitor.transform.position, secondRay_direction, out hit , 25f))
        {
            ln.SetPosition(4,hit.point);
            if(magnification>0)
            {
                lr.SetPosition(0, hit.point);
                parll_line.x = (hit.point.x - Image_light_emittor.x) * 50 + Image_light_emittor.x;
                parll_line.y = (hit.point.y - Image_light_emittor.y) * 50 + Image_light_emittor.y;
                parll_line.z = (hit.point.z - Image_light_emittor.z) * 50 + Image_light_emittor.z;
            }
        }
        else
        {
            ln.SetPosition(4,lens_transform.position+new Vector3(0,Lend_height/3,0));
        }
        if(magnification>0) 
        {
            lr.SetPosition(1, parll_line);
        }
        else if(magnification<0)
        {
            lr.SetPosition(0, Vector3.zero);
            lr.SetPosition(1, Vector3.zero);
        }
        ln.SetPosition(5, Image_light_emittor);
    }
    void Movement()
    {
        if(X_move != 0)
        {
            if (transform.position.x < -4f && X_move > 0)
            {
                transform.Translate(X_move * transform.right * Time.fixedDeltaTime * Candle_speed);
            }
            else if(X_move<0 && transform.position.x > -2*camera_Movement._camera.orthographicSize)
            {
                transform.Translate(X_move * transform.right * Time.fixedDeltaTime * Candle_speed);
            }
            i=0;
            if (Image != null)
            {
                Destroy(Image);
            }
        }
        if (Y_move != 0 )
        {
            if (Y_move>0 && transform.position.y < lens_transform.position.y + Lend_height / 2 - candle_height / 2)
            {
                transform.Translate(Y_move * transform.up * Time.fixedDeltaTime * Candle_speed);
            }
            else if (Y_move<0 && transform.position.y > lens_transform.position.y - Lend_height / 2 - candle_height / 2)
            {
                transform.Translate(Y_move * transform.up * Time.fixedDeltaTime * Candle_speed);
            }
            i = 0;
            if (Image != null)
            {
                Destroy(Image);
            }
        }
    }
    void Image_calculation()
    {
        Object_location.x = transform.position.x - lens_transform.position.x;
        Object_location.y = transform.position.y - lens_transform.position.y;
        Object_location.z = transform.position.z - lens_transform.position.z;

        if (Object_location.x + Focal_legnth == 0)
        {
            text.text = "Image formed at Infinity";
        }
        else
        {
            Image_location.x = (Object_location.x * Focal_legnth) / (Object_location.x + Focal_legnth);
        }
        magnification = Image_location.x/Object_location.x;
        Image_location.y = Object_location.y * magnification;
        Image_location.z = Object_location.z * magnification;

        Image_light_emittor = Image_location + new Vector3(0f, candle_height * magnification, 0f);
    }
    void Image_formation()
    {
        if (i < 1)
        {
            Image = Instantiate(Object, new Vector3(Image_location.x + lens_transform.position.x, Image_location.y +lens_transform.position.y, Image_location.z +lens_transform.position.z), Quaternion.identity);
            Image.transform.localScale = Object_scale * magnification;
            //Debug.Log(magnification);
        }
        i++;
        //draw_ray();
    }
    private void FixedUpdate()
    {
        X_move = Input.GetAxisRaw("Horizontal");
        Y_move = Input.GetAxisRaw("Vertical");
        Movement();
        Image_calculation();
        if(X_move==0 && Y_move==0) 
        {
            Image_formation();
        }
        draw_ray();
        //if(Input.GetKeyDown(KeyCode.R))
        {
            //transform.position = ini_pos;
        }    
    }
}
