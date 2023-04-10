using UnityEngine;

public class PhoneSoundManager : MonoBehaviour {
    public AudioSource typingSound;
    public AudioSource bloopSound;
    public AudioSource bubbleSound;

    public void type() {
        typingSound.Play();
    }

    public void stopType() {
        typingSound.Stop();
    }

    public void Bloop() {
        bloopSound.Play();
    }

    public void Bubble() {
        bubbleSound.Play();
    }
}