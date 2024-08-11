using UnityEngine; 

// Reference: This class is modelled after a tutorial
// url: https://www.youtube.com/watch?v=UPvW8kYqxZk&t=1235s

public class AnimatedSprite : MonoBehaviour{
    public Sprite[] sprites;
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

        if(frame >= sprites.Length){
            frame = 0;
        }
        if(frame >= 0 && frame < sprites.Length){
            spriteRenderer.sprite = sprites[frame];
        }

        Invoke(nameof(Animate), 1f/speed); //this is the part that differs from the video
    }

    


} 