﻿namespace WcfExample
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public double Add(double firstVal, double secondVal)
        {
            return firstVal + secondVal;
        }

        public double Div(double firstVal, double secondVal)
        {
            return secondVal / firstVal;
        }

        public double Mul(double firstVal, double secondVal)
        {
            return firstVal * secondVal;
        }

        public double Sub(double firstVal, double secondVal)
        {
            return firstVal - secondVal;
        }
    }
}
