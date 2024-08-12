using UnityEngine; 

// Reference: This class is modelled after a tutorial
// url: https://www.youtube.com/watch?v=UPvW8kYqxZk&t=1235s

public class AnimatedSprite : MonoBehaviour{
    public Sprite[] runSprites;
    public Sprite[] jumpSprites;
    private int frame;
    //public float speed = 10f;
    private SpriteRenderer spriteRenderer;

    private bool isInAir = false;

    public bool IsInAir{
        get { return isInAir;}
        set { isInAir = value;}
    }

    private void OnEnable(){
        Invoke(nameof(Animate), 0f);
    }
    private void Awake(){
        Debug.Log("Awake was called in AnimatedSprite");
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Animate(){
        frame++;
        if(isInAir){
            AnimateMovement(jumpSprites);
        }else{
            AnimateMovement(runSprites);
        }
        Invoke(nameof(Animate), 1f/GameManager.Instance.gameSpeed); //this is the part that differs from the video
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