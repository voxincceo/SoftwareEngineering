using System;

public class Train
{
    private int trainNumber = 0;
    private String blockPosition = "";
    private double authority = 0;
    private double speed = 0;
    public Train(int inTrainNum, String inBlockPosition, double inAuthority, double inSpeed)
	{
        this.trainNumber = inTrainNum;
        this.blockPosition = inBlockPosition;
        this.authority = inAuthority;
        this.speed = inSpeed;
	}
    public int getTrainNumber()
    {
        return this.trainNumber;
    }
    public String getBlockPosition()
    {
        return this.blockPosition;
    }
    public double getAuthority()
    {
        return this.authority;
    }
    public double getSpeed()
    {
        return this.speed;
    }
    public void setSpeed(double invar)
    {
        this.speed = invar;
    }
    public void setAuthority(double invar)
    {
        this.authority = invar;
    }
    public void setBlockPosition(String invar)
    {
        this.blockPosition = invar;
    }
}
