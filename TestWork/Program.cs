//Не до конца понял некоторые пункты задания, но надеюсь сделал все правильно.
abstract class Vehicle{
    public string Type { get; set; }
    public double AvgConsumption { get; set; }
    public double TankVolume { get; set; }
    public double Speed { get; set; }
    public double GetPath()
    {
        return TankVolume/AvgConsumption;
    }
    public double GetPath(int fuel)
    {
        return fuel / AvgConsumption;
    }
    public virtual double? GetRange(int passengers = 0, double cargo = 0)
    {
        double value = passengers * 0.06;
        double value2 = (cargo / 200) * 0.04;
        return GetPath() * (1 - value) * (1-value2);
    }
    public double? GetTime(int fuel, double range)
    {
        if(fuel < TankVolume) { 
            if (range < GetPath(fuel))
            {
                return range / Speed;
            }
            else
            {
                Console.WriteLine("Расстояние превысило максимальный запас хода");
                return null;
            }
        }
        else
        {
            Console.WriteLine("Кол-во топлива превысило максимум");
            return null;
        }
    }
}
class Car : Vehicle
{
    public int MaxPassenger;
    public override double? GetRange(int passengers = 0, double cargo = 0)
    {
        if(passengers > MaxPassenger)
        {
            Console.WriteLine($"Максимально допустимое количество пассажиров {MaxPassenger}");
            return null;
        }
        else
        {
            return base.GetRange(passengers, cargo);
        }
    }
}
class BigCar : Vehicle
{
    public int Carrying;
    public override double? GetRange(int passengers = 0, double cargo = 0)
    {
        if (cargo > Carrying)
        {
            Console.WriteLine($"Максимально допустимый размер груза: {Carrying}");
            return null;
        }
        else
        {
            return base.GetRange(passengers, cargo);
        }
    }
}
