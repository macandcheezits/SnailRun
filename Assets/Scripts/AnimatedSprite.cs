using System;
using UnityEngine;

// Reference: This class is modelled after a tutorial
// url: https://www.youtube.com/watch?v=UPvW8kYqxZk&t=1235s

public class AnimatedSprite : MonoBehaviour
{

    [SerializeField]
    private Sprite[] runSprites, jumpSprites, injuredSprites;

    private int frame;
    public SpriteRenderer spriteRenderer;

    private bool isInAir = false;

    private void OnEnable()
    {
        Debug.Log("OnEnable() has been invoked in AnimatedSprite");
        Invoke(nameof(AnimateMovement), 0f);
    }
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void AnimateMovement()
    {   
        if (!GameManager.Instance.isGameOver)
        {
            frame++;
            if (isInAir)
            {
                AnimateFrames(jumpSprites);
            }
            else
            {
                AnimateFrames(runSprites);
            }

            Invoke(nameof(AnimateMovement), 1f / GameManager.Instance.gameSpeed);
            //Debug.Log("Invoked Animate() inside Animate() of AnimatedSprite class ");
        }
    }

    public void AnimateFrames(Sprite[] frames)
    {
        if (frame >= frames.Length)
        {
            frame = 0;
        }
        if (frame >= 0 && frame < frames.Length)
        {
            spriteRenderer.sprite = frames[frame];
            //Debug.Log(spriteRenderer.sprite.name);
        }
    }

    // REQUIRES: Must be called only in SnailScript class
    // MODIFIES: Sprite
    // EFFECTS: The sprite will be changed to another image given by argument
    public void SetSpriteImg(Sprite s)
    {
        spriteRenderer.sprite = s;
    }

    public void OnDisable()
    {
        Debug.Log("OnEnable() in AnimatedSprite class has been disabled");
    }

    public bool GetIsInAir(){
        return this.isInAir;
    }

    public void SetIsInAir(bool b){
        this.isInAir = b;
    }

    public int GetFrame(){
        return this.frame;
    }
}