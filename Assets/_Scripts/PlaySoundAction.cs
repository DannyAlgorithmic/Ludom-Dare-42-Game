using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Actions/Sound/Play")]
public class PlaySoundAction : BaseAction {
    public AudioClip clip;
    public override void TakeAction(PlayerController ctrl)
    {
        ctrl.soundSource.PlayOneShot(clip);
    }

}
