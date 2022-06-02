using UnityEngine;

public class TankMovement : MonoBehaviour
{
    public GameManager manager;
    public Rigidbody body;
    public AudioClip drivingAudio;

    public float runSpeed = 10f;
    public float strafeSpeed = 40f;

    protected bool strafeLeft = false;
    protected bool strafeRight = false;

    void OnCollisionEnter(Collision collision){
        if (collision.collider.tag == "Obstacle"){
            GetComponent<AudioSource>().Stop();
            GetComponent<Collider>().SendMessage("Сrashed");
            manager.EndGame();
        }

         if (collision.collider.tag == "Enemy"){
            GetComponent<AudioSource>().Stop();
            GetComponent<Collider>().SendMessage("Сrashed");
            collision.collider.GetComponent<Collider>().SendMessage("DestroyEnemy");
            manager.EndGame();
        }
        
        if (collision.collider.tag == "Finish"){
            GetComponent<AudioSource>().Stop();
            manager.GameWin();
        }
    }

    void Update(){
        if (Input.GetKey("a")){
            strafeLeft = true;
        } 
        else{
            strafeLeft = false;
        }

        if (Input.GetKey("d")){
            strafeRight = true;
        } 
        else{
            strafeRight = false;
        }

        if (transform.position.y < 0.05f){
            manager.EndGame();
        }
    }

    void FixedUpdate() {
        
        body.MovePosition(transform.position + Vector3.forward * runSpeed * Time.deltaTime);
        GetComponent<AudioSource>().clip = drivingAudio;
        GetComponent<AudioSource>().volume = 0.1f;
        if(GetComponent<AudioSource>().isPlaying == false){
            GetComponent<AudioSource>().Play();
        }
    
        if(strafeLeft){
            body.AddForce(Vector3.left * strafeSpeed * Time.deltaTime, ForceMode.VelocityChange);
        }

        if(strafeRight){
            body.AddForce(Vector3.right * strafeSpeed * Time.deltaTime, ForceMode.VelocityChange);
        }
    }
}
