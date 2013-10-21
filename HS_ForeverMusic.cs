using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HS_ForeverMusic : MonoBehaviour {
    public static HS_ForeverMusic Instance {get;set;}
    public List<AudioClip> tracks;
    public bool playOnAwake;

    public int currentTrack = 0;

    void Awake() {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(this);
            if (playOnAwake)
                Play();
        } else {
            Destroy(this);
        }
    }

    void Update() {
        if (Input.GetKeyUp(KeyCode.A))
            NextTrack();
        if (Input.GetKeyUp(KeyCode.B))
            PrevTrack();
    }

    private void PlayTrack(int trackId) {
        currentTrack = trackId;
        audio.clip = tracks[trackId];
        audio.Play();
    }

    public void NextTrack() {
        if (currentTrack == tracks.Count-1)
            PlayTrack(0);
        else
            PlayTrack(currentTrack+1);
    }

    public void PrevTrack() {
        if (currentTrack == 0)
            PlayTrack(tracks.Count-1);
        else
            PlayTrack(currentTrack-1);
    }

    public void Play() {
        if (audio.clip == null)
            PlayTrack(currentTrack);
    }

    public void Stop() {
        audio.Stop();
    }
}