using UnityEngine; 

// Reference: This class is modelled after a tutorial
// url: https://www.youtube.com/watch?v=UPvW8kYqxZk&t=1235s

public class AnimatedSprite : MonoBehaviour{
    public Sprite[] runSprites;
    public Sprite[] jumpSprites;
    private int frame;
    public float speed = 10f;
    private SpriteRenderer spriteRenderer;

    private void OnEnable(){
        Invoke(nameof(Animate), 0f);
    }
    private void Awake(){
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Animate(){
        frame++;
        if(Input.GetButton("Jump")){
            AnimateMovement(jumpSprites);
        }else{
            AnimateMovement(runSprites);
        }
        Invoke(nameof(Animate), 1f/speed); //this is the part that differs from the video
    }

    private void AnimateMovement(Sprite[] frames){
        if(frame >= frames.Length){
            frame = 0;
        }
        if(frame >= 0 && frame < frames.Length){
            spriteRenderer.sprite = frames[frame];
        }
    }
} 