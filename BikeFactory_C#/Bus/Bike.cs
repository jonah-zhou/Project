using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Bike_Factory.Bus
{
    [XmlInclude(typeof(MountainBike))]
    [XmlInclude(typeof(RoadBike))]
    [Serializable]
    public abstract class Bike : Object
    {
        private long serialNumber;
        private string make;
        private string model;
        private EnumColor color;
        private double speed;
        private double newSpeed;
        private DateTime date;

        private double maxSpeed;

        public Bike()
        {
            this.serialNumber = 0;
            this.make = "Undefined";
            this.model = "Undefined";
            this.color = EnumColor.Undefined;
            this.speed = 0.00;
            this.newSpeed = 0.00;
            this.date = DateTime.Now;
        }

        public Bike(long serialNumber, string make, string model, EnumColor color, double speed, double newSpeed,DateTime date)
        {
            this.serialNumber = serialNumber;
            this.make = make;
            this.model = model;
            this.color = color;
            this.speed = speed;
            this.newSpeed = newSpeed;
            this.date = date;
        }

        public long SerialNumber
        {
            get { return this.serialNumber; }
            set { this.serialNumber = value; }
        }

        public string Make
        {
            get { return this.make; }
            set { this.make = value; }
        }

        public string Model
        {
            get { return this.model; }
            set { this.model = value; }
        }

        public EnumColor Color
        {
            get { return this.color; }
            set { this.color = value; }
        }

        public double Speed
        {
            get { return this.speed; }
            set { this.speed = value; }
        }

        public double NewSpeed
        {
            get { return this.newSpeed; }
            set { this.newSpeed = value; }
        }

        public DateTime Date
        {
            get { return this.date; }
            set { this.date = value; }
        }

        public override string ToString()
        {
            string state = this.serialNumber + "*" + this.make + "*" + this.model + "*" + this.color + "*" + this.GetMaxSpeed() + "*" + this.date.ToShortDateString();
            return state;
        }

        public virtual double GetMaxSpeed()
        {
            return this.maxSpeed = 20.00;
        }
        public abstract double SpeedUp(double newSpeed);

    }  
}
