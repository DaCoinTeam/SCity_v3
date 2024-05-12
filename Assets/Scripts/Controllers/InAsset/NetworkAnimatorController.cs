using Unity.Netcode.Components;

public class NetworkAnimatorController: NetworkAnimator
{
    protected override bool OnIsServerAuthoritative()
    {
        return false;
    }
}