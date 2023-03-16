using UnityEngine;

public abstract class Entity{
    public ASCIIWorldManager world;

    public Entity(ASCIIWorldManager w){
        world=w;
    }
    public string displayChar {set; get;}
    public virtual bool interact(){ return false;}
    // public abstract bool interact();
}

public class Wall:Entity{
    public Wall(ASCIIWorldManager w):base(w)
    {
        displayChar="#";
    }
    public override bool interact(){ return false;}

}

public class ArcadeCabinet:Entity{
    public ArcadeCabinet(ASCIIWorldManager w):base(w)
    {
        displayChar="<#A74071>A</color>";
    }
    public override bool interact(){
        world.setLabel("An arcade cabinet? At work? THATS AWESOME!");
        return true;
    }
}

public class SleepPod:Entity{
    public SleepPod(ASCIIWorldManager w):base(w)
    {
        displayChar="<#6F91B9>Z</color>";
    }
    public override bool interact(){
        world.setLabel("No one is gonna believe me when I tell them we have sleeping pods at my work.");
        return true;
    }
}


public class Server:Entity{    
    int checkNumber;
    string[] responses = new string[] {
        "These servers store the petabytes of data that we've collected on users.",
        "Every little personal thing about someone can be found on these servers."
    };

    public Server(ASCIIWorldManager w):base(w){
        displayChar="<#FFFFFF>S</color>";
        checkNumber=0;
    }
    public override bool interact(){
        world.setLabel(responses[checkNumber]);
        checkNumber = Mathf.Min(3,++checkNumber);
        return true;
    }
}

public class OfficeWorker:Entity{
    public OfficeWorker(ASCIIWorldManager w):base(w)
    {
        displayChar="<#A981C6>@</color>";
    }
    public override bool interact(){         
        world.setLabel("<#A981C6>Hey, a few of us are gonna hang out after work if you want to join!</color>");
        return true;
    }

}

public class Coffee:Entity{
    public Coffee(ASCIIWorldManager w):base(w){
        displayChar="<#C68181>C</color>";
    }
    public override bool interact(){
        world.setLabel("Mmmm, free coffee");
        return true;
    }
}

public class Snacks:Entity{
    int checkNumber;
    string[] responses = new string[] {
        "Wow! I can't believe they have free snacks here, this place rocks!",
        "Another handful of snacks? Don't mind if I do.",
        "I really hope no one notices I've been here 3 times already...",
        "The bowl is empty."
    };

    public Snacks(ASCIIWorldManager w):base(w){
        displayChar="<#F45D01>S</color>";
        checkNumber=0;
    }
    public override bool interact(){
        world.setLabel(responses[checkNumber]);
        checkNumber = Mathf.Min(3,++checkNumber);
        return true;
    }
}

public class Desk : Entity
{
    int checkNumber;
    string[] responses = new string[] {
        "I guess this is my desk. I'll come back here when I'm ready to work.",
    };

    public Desk(ASCIIWorldManager w) : base(w)
    {
        displayChar = "<#945D01>D</color>";
        checkNumber = -1;
    }
    public override bool interact()
    {
        checkNumber++;
        if (checkNumber < responses.Length && StateManager.getInstance().getDay()==0)
            world.setLabel(responses[checkNumber]);
        else{
            //Hide the world
            world.hide();
            //Transition to our final scene
            LoadingManager.instance.emailTransition(4);
        }
        return true;
    }
}

public class Player:Entity{
    public Player(ASCIIWorldManager w):base(w){
        displayChar="<#2D7DD2>@</color>";
    }
    public override bool interact(){ return false;}
}
