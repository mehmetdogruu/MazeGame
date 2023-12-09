public interface IInteractable 
{
    bool IsInteractable { get; }
    void InteractionHandle(IInteractor interactor);

}
