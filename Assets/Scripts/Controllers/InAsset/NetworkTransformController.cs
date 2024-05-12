using Unity.Netcode.Components;

public class NetworkTransformController : NetworkTransform
{
    protected override bool OnIsServerAuthoritative()
    {
        return false;
    }
}