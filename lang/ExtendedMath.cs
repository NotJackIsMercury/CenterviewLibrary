using System;

namespace Centerview {
    public class Fraction {
        public static explicit operator double(Fraction a) => a.Value;
        
        public static implicit operator Fraction(double a) => new Fraction(a);
        
        public static explicit operator long(Fraction a) => (long) a.Value;
        
        public static implicit operator string(Fraction a) => a.ToString();
        
        public static Fraction operator+ (Fraction a) {
            return new Fraction(a);
        }
        
        public static Fraction operator- (Fraction a) {
            return new Fraction(-a.Numerator, a.Denominator);
        }
    	
    	public static Fraction operator++ (Fraction a) {
    	    return new Fraction(a.Numerator + a.Denominator, a.Denominator);
    	}
    	
    	public static Fraction operator-- (Fraction a) {
    	    return new Fraction(a.Numerator - a.Denominator, a.Denominator);
    	}
    	
    	public static Fraction operator+ (Fraction a, Fraction b) {
    	    if (a.Denominator == b.Denominator) {
    	        return new Fraction(a.Numerator + b.Numerator, a.Denominator);
    	    } else {
    	        return new Fraction(
    	            a.Numerator * b.Denominator + b.Numerator * a.Denominator,
    	            a.Denominator * b.Denominator
    	        );
    	    }
    	}
    	
    	public static Fraction operator- (Fraction a, Fraction b) {
    	    return a + -b;
    	}
    	
    	public static Fraction operator* (Fraction a, Fraction b) {
    	    return new Fraction(
    	        a.Numerator * b.Numerator,
    	        a.Denominator * b.Denominator
    	    );
    	}
    	
    	public static Fraction operator/ (Fraction a, Fraction b) {
    	    return a * b.Reciprocal();
    	}
    	
    	public static Fraction operator% (Fraction a, Fraction b) {
    		Fraction c = a * b.Reciprocal();
    		return new Fraction(c.Numerator % c.Denominator, c.Denominator);
    	}
    	
        public long Denominator { get; }
        
        public long Numerator { get; }
        
        public double Value {
            get { return (Numerator + 0.0) / Denominator; }
        }
        
        public Fraction(double dec) {
            long denominator = 1;
            
            while (dec - (long) dec != 0) {
                dec *= 10;
                denominator *= 10;
            }
            
            Numerator = (long) dec;
            Denominator = denominator;
        }
        
        public Fraction(Fraction fraction) :
        	this(fraction.Numerator, fraction.Denominator) {}
        
        public Fraction(long numerator = 0, long denominator = 1) {
            if (denominator >= 0) {
            	Numerator = numerator;
            	Denominator = denominator;
            } else {
                Numerator = -numerator;
                Denominator = -denominator;
            }
        }
        
        public Fraction Reciprocal() {
            return new Fraction(Denominator, Numerator);
        }
        
        public override string ToString() {
            return Numerator + "/" + Denominator;
        }
    }
}
