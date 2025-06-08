using System;

[Serializable]
public class Characteristics
{

    public int maxHealth;
    public int dammages;

    public Characteristics() { }

    public Characteristics(int maxHealth, int dammages)
    {
        this.maxHealth = maxHealth;
        this.dammages = dammages;
    }


}
