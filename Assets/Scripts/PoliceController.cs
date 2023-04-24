using UnityEngine.UIElements;

public class PoliceController : GameController
{
    protected override void observeVariables()
    {
    }

    public void policeIsComing()
    {
        story.ChoosePathString("policeIsComing");
    }

    protected override void initializeInterface()
    {
        view = phone.Q<GroupBox>("policeScreen");
    }
}