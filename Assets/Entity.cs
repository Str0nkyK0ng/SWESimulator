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
public class Cake:Entity{
    int checkNumber;
    string[] responses = new string[] {
        "Wow! I can't believe they have free snacks here, this place rocks!",
        "Another handful of snacks? Don't mind if I do.",
        "I really hope no one notices I've been here 3 times already...",
        "The bowl is empty."
    };

    public Cake(ASCIIWorldManager w):base(w){
        displayChar="<#F45D01>C</color>";
        checkNumber=0;
    }
    public override bool interact(){
        world.setLabel(responses[checkNumber]);
        checkNumber = Mathf.Min(3,++checkNumber);
        return true;
    }
}

public class Player:Entity{
    public Player(ASCIIWorldManager w):base(w){
        displayChar="<#2D7DD2>@</color>";
    }
    public override bool interact(){ return false;}
}
