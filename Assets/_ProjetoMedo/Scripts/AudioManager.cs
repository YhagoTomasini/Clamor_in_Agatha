using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // Referência para o AudioSource principal do jogo
    public AudioSource MenuAudio;
    public AudioSource GameAudio;
    public AudioSource CatstepAudio;
    public AudioSource PowereffectAudio;
    public AudioSource MonsterstepAudio;
    public AudioSource SonareffectAudio;
    public AudioSource CutpowerAudio;
    public AudioSource JumppowerAudio;


    // Método para alternar entre mutar e desmutar o som
    public void ToggleMuteMenu()
    {
        // Inverte o estado de mudo do AudioSource principal
        MenuAudio.mute = !MenuAudio.mute;
    }

    public void ToggleMuteGame()
    {
        // Inverte o estado de mudo do AudioSource principal
        GameAudio.mute = !GameAudio.mute;
    }

    public void ToggleMuteCatstep()
    {
        // Inverte o estado de mudo do AudioSource principal
        CatstepAudio.mute = !CatstepAudio.mute;
    }

    public void ToggleMuteMonsterstep()
    {
        // Inverte o estado de mudo do AudioSource principal
        MonsterstepAudio.mute = !MonsterstepAudio.mute;
    }

    public void ToggleMuteSonareffect()
    {
        // Inverte o estado de mudo do AudioSource principal
        SonareffectAudio.mute = !SonareffectAudio.mute;
    }

    public void ToggleMutePowereffect()
    {
        // Inverte o estado de mudo do AudioSource principal
        PowereffectAudio.mute = !PowereffectAudio.mute;
    }

    public void ToggleMuteCutpower()
    {
        // Inverte o estado de mudo do AudioSource principal
        CutpowerAudio.mute = !CutpowerAudio.mute;
    }

    public void ToggleMuteJumppower()
    {
        // Inverte o estado de mudo do AudioSource principal
        JumppowerAudio.mute = !JumppowerAudio.mute;
    }

   
}

