using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bike_Factory.Bus
{
    [Serializable]
    public class MountainBike : Bike
    {
        private EnumSuspension suspension;
        private double heightFromGround;

        public EnumSuspension Suspension
        {
            get { return suspension; }
            set { this.suspension = value; }
        }

        public double HeightFromGround
        { 
            get { return heightFromGround; } 
            set { this.heightFromGround = value; }
        }

        public MountainBike():base()
        {
            this.suspension = EnumSuspension.Undefined;
            this.heightFromGround = 0.00;
        }

        public MountainBike(long serialNumber, string make, string model, EnumColor color, double speed,  double newSpeed, DateTime date, EnumSuspension suspension, double heightFromGround) :base(serialNumber, make, model, color, speed, newSpeed, date)
        {
            this.suspension = suspension;
            this.heightFromGround = heightFromGround;
        }

        public override string ToString()
        {
            string state = base.ToString() + "*" + this.SpeedUp(NewSpeed) + "*" + this.suspension + "*" + this.heightFromGround;
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
    }

}
