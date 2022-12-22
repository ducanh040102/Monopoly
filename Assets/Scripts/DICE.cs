using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DICE : MonoBehaviour
{
    //public
    public int value = 0; // dice is rolling, undetermined or invalid

    //protected
    protected Vector3 localHitNormalized; //normalized hit from center to dice face in local space
    protected float validMargin = 0.45f; //hitVector check margin

    //calculate normalized hit vector and should always return true
    //length of vector
    public bool IsRolling()
    {
        return !(GetComponent<Rigidbody>().velocity.sqrMagnitude < .1f && GetComponent<Rigidbody>().angularVelocity.sqrMagnitude < .1f);
    }

    protected bool LocalHit()
    {
        // create a Ray from above dice, moving dowards
        Ray ray = new Ray(transform.position + (new Vector3(0, 2, 0) * transform.localScale.magnitude), Vector3.up * -1);
        RaycastHit hit = new RaycastHit(); // Cast ray and validate it against this dice collider

        if(GetComponent<Collider>().Raycast(ray, out hit, 3 * transform.localScale.magnitude))
        {
            // if hit deternime the local normalized vector from dice center to the face that was hit
            //because of local space, each side will have its own local hit vector coordinates that will always be the same
            localHitNormalized = transform.InverseTransformDirection(hit.point.x, hit.point.y, hit.point.z).normalized; // world space to local space
            return true;
        }

        return false;
    }
    
    // virtual method to get dice side hitVector
    // will be override in dice type subclass
    protected virtual Vector3 HitVector(int side)
    {
        return Vector3.zero;
    }

    // validate a test value agaist a value within a specific margin
    protected bool Valid(float t, float v)
    {
        if (t > (v - validMargin) && t < (v + validMargin)) return true;
        else return false;
    }

    private void DiceValue()
    {
        value = 0; //undetermined or invalid
        float delta = 1;
        int side = 1; //start with side 1 going up
        Vector3 testHitVector;

        //check all side of this dice, the side that has a valid hitVector and smallest x, y, z delta (if more side are valid) will be the closest and this dice value
        /*
        do
        {
            // get testHitVector from current side
            // each dice type will expose all hitVectors for its side
            testHitVector = HitVector(side);
            if (testHitVector != Vector3.zero)
            {
                //this side has a hitVector do validate x, y, z value against local normalized hitVector using the margin
                if(Valid(localHitNormalized.x, testHitVector.x) &&
                   Valid(localHitNormalized.y, testHitVector.y) &&
                   Valid(localHitNormalized.z, testHitVector.z))
                {
                    //this side is valid within the margin, check the x, y, z delta to see if we can set this side as this dice's value
                    
                }
            }
        }
        while{

        }
        */
        

    }
}
