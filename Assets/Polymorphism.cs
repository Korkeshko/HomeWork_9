/*
Составить иерархию Vehicle
- Включить туда Car, Ship, Plane
- Сделать абстрактный метод Go, который
печатает звук транспорта
*/

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Polymorphism : MonoBehaviour
{
    [ContextMenu(nameof(Main))]
    private void Main()
    {
        Vehicle[] vehicles = {new Car(), new Ship(), new Plane()};
        foreach (var vehicle in vehicles)
        {
            vehicle.Go(); 
            
            if(vehicle is ICar icar)
            {
                Car car = (Car)vehicle;

                icar.Environment();
                car.FuelLevel();
            }
            else if (vehicle is Ship ship)
            {     
                ship.NoFuel = true;
                
                IShip iship = (IShip)vehicle;

                iship.Environment();
                ship.FuelLevel();
            } 
            else 
            {
                Plane plane = (Plane)vehicle;  

                plane.Environment();
                plane.FuelLevel();
            }    
        }
    }
}

#region Abstract Class Vehicle
public abstract class Vehicle
{
    public abstract void Go(); 

    public virtual void FuelLevel()
    {
        Debug.Log("Full tank, let's go!");
    }
}
#endregion

#region Class
public class Car : Vehicle, ICar
{
    public override void Go()
    {
        Debug.Log("Car sound: BEEP! BEEP! HONK! HONK!");
    }  

    public override void FuelLevel()
    {
        base.FuelLevel();
    }  
}

public class Ship : Vehicle, IShip
{
    private bool noFuel;
    public bool NoFuel
    {
        get { return noFuel; }
        set { noFuel = value; }
    }

    public override void Go()
    {
        Debug.Log("Ship sound: TOOOOOOOOOO!");
    }

    public override void FuelLevel()
    {
        if (noFuel)
        {
            Debug.Log("Ship can't move. Need to refuel!");
        }
        else
        {
            base.FuelLevel();
        }
    }   
}

public class Plane : Vehicle, IPlane
{
    public override void Go()
    {
        Debug.Log("Plane sound: WHOOSH!");
    }

    public override void FuelLevel()
    {
        base.FuelLevel();
    }  

    public void Environment()
    {
        Debug.Log("Plane flies through the air");
    }
}
#endregion

#region Interface
interface ICar
{
    void Environment()
    {
        Debug.Log("Car rides on the ground");
    }
}  

interface IShip
{
    void Environment()
    {
        Debug.Log("Ship floats on the water");
    }
}  

interface IPlane
{
    void Environment();
}  
#endregion



