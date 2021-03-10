using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate float EasingFunction(float k);
public class Easing
{
    public static float Linear(float k)
    {
        return k;
    }

    public class Quadratic
    {
        public static float In(float k)
        {
            return k*k; 
        }

        public static float Out(float k)
        {
            return k*(2f - k);
        }

        public static float InOut (float k) {
			if ((k *= 2f) < 1f) return 0.5f*k*k;
			return -0.5f*((k -= 1f)*(k - 2f) - 1f);
		}

		/* 
		 * Quadratic.Bezier(k,0) behaves like Quadratic.In(k)
		 * Quadratic.Bezier(k,1) behaves like Quadratic.Out(k)
		 *
		 * If you want to learn more check Alan Wolfe's post about it http://www.demofox.org/bezquad1d.html
		 */

		public static float Bezier (float k, float c) {
			return c*2*k*(1 - k) + k*k;
		}
    }
}
