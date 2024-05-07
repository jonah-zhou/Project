using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bike_Factory.Bus
{

    [Serializable]
    public class RoadBike : Bike
    {
        private double seatHeight;
        private double maxSpeed;

        public double SeatHeight
        {
            get { return this.seatHeight; }
            set { this.seatHeight = value; }
        }

        public RoadBike():base()
        {
            this.seatHeight = 0.00;
        }

        public RoadBike(long serialNumber, string make, string model, EnumColor color, double speed, double newSpeed, DateTime date, double seatHeight):base(serialNumber,make,model,color,speed, newSpeed, date)
        {
            this.seatHeight = seatHeight;
        }

        public override string ToString()
        {
            string state = base.ToString() + "*" + this.SpeedUp(NewSpeed) + "*" + this.seatHeight;
            return state;
        }
        
        public override double SpeedUp(double newSpeed)
        {
            double result = Speed + NewSpeed;
            
            if (result < GetMaxSpeed())
            {
                return result;
            }
            else
            {
                return Speed;
            }           
        }
        
        public override double GetMaxSpeed()
        {
            return this.maxSpeed = 40.00;
        }
    }
}
