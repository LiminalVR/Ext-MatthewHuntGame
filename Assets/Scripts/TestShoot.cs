using Liminal.SDK.VR;
using Liminal.SDK.VR.Input;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TestShoot : MonoBehaviour
{
    //Area from were the ball will come from 
    public GameObject Ball_Emitter;
    //the ball game object itself
    public GameObject Ball;
    //the float which controlls how fast the ball will go forward
    public float Ball_forward_force;
    public GameManager GameManager;

    private IVRInputDevice m_Device;

    
    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.IsGameOver)
            return;

        if (m_Device == null)
        {
            m_Device = VRDevice.Device.PrimaryInputDevice;
            return;
        }

        if (!GameManager.Instance.HasGameStarted) 
            return;

        if (Time.timeScale == 0)
            return;

        if (m_Device.GetButtonDown(VRButton.One))
        {
            StartCoroutine("FireBall");
            gameObject.GetComponent<AudioSource>().Play();

            GameManager.Instance.TimesFired++;
        }

    }


    IEnumerator FireBall()
    {


        //The Ball spawns from this instatiate following the postion and rotation of the object
        GameObject Temporary_ball_handler;
        Temporary_ball_handler = Instantiate(Ball, Ball_Emitter.transform.position, Ball_Emitter.transform.rotation) as GameObject;

        //going to retrieve the rigidbody from the ball to add a force in order to send the ball forward
        Rigidbody Temporary_Rigidbody;
        Temporary_Rigidbody = Temporary_ball_handler.GetComponent<Rigidbody>();

        // this line tells the ball how much force is going to be applied to the ball in order to propell it forward
        Temporary_Rigidbody.AddForce(Ball_Emitter.transform.forward * Ball_forward_force);


        Destroy(Temporary_ball_handler, 10f);
        //Temporary_ball_handler.GetComponentInChildren<ParticleSystem>().Play(); 


        yield return new WaitForSeconds(2f);

    }





}
