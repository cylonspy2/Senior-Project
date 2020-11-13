using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boidSpawnManager : MonoBehaviour
{

    public int maxSize;
    public float stickyRange;
    public GameObject boidParent;
    public Transform _target;

    public GameObject Boid;
    public float speed;
    public float rotSpeed;
    public float avoidRange;
    public float sightRange;
    public float rotationPercentage = 40;

    public Quaternion Kapu;

    GameObject[] swarm;
    Rigidbody[] swarmMass;
    

    Vector3 localForward;

    // Start is called before the first frame update
    void Start()
    {
        swarm = new GameObject[maxSize];
        swarmMass = new Rigidbody[maxSize];
        spawnBoids(swarm, maxSize);
    }

    // Update is called once per frame
    void Update()
    {
        //boidBaseBehaviour(swarm);
        BoidMaster();
    }


    void spawnBoids(GameObject[] boids, int ceiling)
    {
        for(int i = 0; i < ceiling; i++)
        {
            float stick = stickyRange / 2;
            Vector3 spawn = new Vector3(Random.Range(stick, -stick), Random.Range(stick, -stick), Random.Range(stick, -stick));
            GameObject spawnt = Instantiate(Boid, spawn, Quaternion.identity, boidParent.transform);
            swarm[i] = spawnt;
            swarmMass[i] = spawnt.GetComponent<Rigidbody>();
            //spawnt.transform.Rotate(Random.Range(180, -180), Random.Range(180, -180), Random.Range(180, -180));
        }
    }


    void BoidMaster()
    {
        swarmData[] currentBoid = new swarmData[swarm.Length];

        for (int i = 0; i < swarm.Length; i++)
        {
            //currentBoid[i].whereAmI = swarm[i].transform.position;
            currentBoid[i] = BoidBrain(i);
        }

        for (int i = 0; i < currentBoid.Length; i++)
        {
            
            //if (!(0.0f == currentBoid[i].output.x || 0.0f == currentBoid[i].output.y || 0.0f == currentBoid[i].output.z))
            {
                //swarm[i].transform.eulerAngles += currentBoid[i].outputRot * Time.deltaTime;
                swarm[i].transform.rotation = Quaternion.Slerp(swarm[i].transform.rotation,
                                        Quaternion.LookRotation(currentBoid[i].output),
                                        rotationPercentage * rotSpeed * Time.deltaTime);
                //swarm[i].transform.position += swarm[i].transform.position.up * speed;
            }
            /*
            else
            {
                
                swarm[i].transform.rotation = Quaternion.Slerp(swarm[i].transform.rotation,
                                        Quaternion.LookRotation(swarm[i].transform.position - _target.position),
                                        rotationPercentage * 30 * Time.deltaTime);
                
            }
            */

            swarm[i].transform.Translate(0, 0, speed * Time.deltaTime);
        }

    }



    swarmData BoidBrain(int ID)
    {
        swarmData output = new swarmData(swarm);
        int flock = 0;
        for(int i = 0; i < swarm.Length; i++)
        {
            if (swarm[i] != swarm[ID])
            {
                //float diff = (swarm[i].transform.position.x - swarm[ID].transform.position.x) * (swarm[i].transform.position.y - swarm[ID].transform.position.y) * (swarm[i].transform.position.z - swarm[ID].transform.position.z);
                float diff = (swarm[i].transform.position - swarm[ID].transform.position).magnitude;
                if (diff < sightRange * sightRange)
                {
                    output.whereAlign[i] = isAlign(swarm[i].transform.position, swarm[ID].transform.position);
                    output.whereAvoid[i] = isAvoid(swarm[i].transform.position, swarm[ID].transform.position);
                    output.whereCohese[i] = isCohese(swarm[i].transform.position, swarm[ID].transform.position);
                    flock++;
                }
            }
        }

        Vector3 ali = Align(output.whereAlign);
        //Vector3 coh = Cohese(output.whereCohese);
        Vector3 coh = (_target.position - swarm[ID].transform.position);
        Vector3 avo = (Avoid(output.whereAvoid));
        Vector3 oot = (avo + ali + coh);

        output.flock = flock;

        //if (flock > 0 && (!(coh.x == 0 || coh.y == 0 || coh.z == 0) || !(ali.x == 0 || ali.y == 0 || ali.z == 0) || !(oot.x == 0 || oot.y == 0 || oot.z == 0) ))
        {
            output.output = oot;
            //output.output += Cohese(output.whereCohese);
            //output.output /= 3;
        }
        //else
        {
            //output.output = new Vector3(0,0,0);
        }
        return output;
    }


    Vector3 isAvoid(Vector3 input, Vector3 center)
    {
        Vector3 output = new Vector3();
        output = (center-input);
        return output;
    }

    Vector3 isAlign(Vector3 input, Vector3 center)
    {
        Vector3 output = new Vector3();
            output = (input-center);

        return output;
    }

    Vector3 isCohese(Vector3 input, Vector3 center)
    {
        Vector3 output = new Vector3();

        output = (input);

        return output;
    }



    Vector3 Avoid(Vector3[] input)
    {
        Vector3 output = new Vector3(0,0,0);

        Vector3 AvgPos = new Vector3(0, 0, 0);

        int count = 0;

        foreach (Vector3 inp in input)
        {
            float diff = (inp).magnitude;
            if ((diff < avoidRange * avoidRange))
            {
                if (inp != new Vector3(0, 0, 0))
                {
                    AvgPos += inp;
                    count++;
                }
            }
        }
        //AvgPos = output / count;

        output = AvgPos;
        Debug.Log("Avoid Triggered with " + output);
        return output;
    }
    Vector3 Align(Vector3[] input)
    {
        Vector3 output = new Vector3(0, 0, 0);

        int count = 0;

        foreach (Vector3 inp in input)
        {
            float diff = (inp).magnitude;
            if (!(diff < avoidRange * avoidRange))
            {
                //if (inp != new Vector3(0, 0, 0))
                {
                    output += inp;
                    count++;
                }
            }
           
        }

        output = (output / count);
        Debug.Log("Align Triggered with " + output);
        return output;
    }
    Vector3 Cohese(Vector3[] input)
    {
        Vector3 output = new Vector3(0, 0, 0);

        Vector3 AvgPos = new Vector3(0, 0, 0);
        foreach (Vector3 inp in input)
        {
            AvgPos += inp;
        }
        AvgPos = AvgPos / input.Length;
        Debug.Log("Cohese Triggered with " + output);
        return output;
    }


    struct swarmData
    {
        public Vector3[] whereAvoid;
        public Vector3[] whereAlign;
        public Vector3[] whereCohese;
        public Vector3 whereAmI;

        public Vector3 Avoid;
        public Vector3 Align;
        public Vector3 Cohese;

        public Vector3 output;
        public Vector3 outputRot;

        public int flock;

        public swarmData(GameObject[] x)
            {
            this.whereAvoid = new Vector3[x.Length];
            this.whereAlign = new Vector3[x.Length];
            this.whereCohese = new Vector3[x.Length];
            this.whereAmI = new Vector3(0,0,0);
            this.output = new Vector3(0, 0, 0);
            this.outputRot = new Vector3(0, 0, 0);
            this.Avoid = new Vector3(0, 0, 0);
            this.Align = new Vector3(0, 0, 0);
            this.Cohese = new Vector3(0, 0, 0);
            this.flock = 0;
            //this.ID = y;

        }
    }


    /*
        void boidBaseBehaviour(GameObject[] boids)
        {

            Quaternion rotat = new Quaternion(0,0,0,0);

            for (int e = 0; e < boids.Length; e++)
            {
                GameObject i = boids[e];
                Rigidbody boo = swarmMass[e];

                if (boo.velocity.magnitude > speed)
                {

                    Vector3 boobliette = boo.velocity;
                    boo.AddForceAtPosition(-boobliette.normalized, boo.position);
                }

                if (boo.angularVelocity.magnitude > rotSpeed)
                {
                    Vector3 boobliette = boo.angularVelocity;
                    boo.AddForceAtPosition(-boobliette.normalized, boo.position);
                }

                //Vector3 ali = 
                alignment(i, swarmMass, i.GetComponent<Rigidbody>());
                //Vector3 coh = 
                cohesion(i, swarm, i.GetComponent<Rigidbody>());
                //Vector3 sep = 
                seperation(i, swarm, i.GetComponent<Rigidbody>());

                stayNearParent(i, stickyRange, i.GetComponent<Rigidbody>());

                //Vector3 acs = (ali + coh + sep)/3;

                //i.transform.LookAt(acs);
                Vector3 bobbles = i.transform.TransformDirection(Vector3.forward);
                boo.MovePosition(bobbles * speed * Time.deltaTime);
                //i.transform.Translate(Vector3.forward * speed * Time.deltaTime);
            }
        }





        void stayNearParent(GameObject bs, float radius, Rigidbody rb)
        {
            if (Vector3.Distance(bs.transform.position, boidParent.transform.position) > stickyRange)
            {
                bs.transform.LookAt(boidParent.transform.position);
                bs.transform.Translate(Vector3.forward * speed * Time.deltaTime);
            }
        }

        void seperation(GameObject bs, GameObject[] ms, Rigidbody rb)
        {
            float wakka = 0.0f;
            Vector3 location = new Vector3(0, 0, 0);
            for (int k = 0; k < ms.Length; k++)
            {
                GameObject s = ms[k];

                if (s != bs)
                {
                    float diff = Vector3.Distance(bs.transform.position, s.transform.position);

                    if (diff <= avoidRange)
                    {
                        //Vector3 rota = bs.transform.position - ms.transform.position;
                        //Vector3 rotatum = findAngle(bs.transform, ms.transform);
                        //rb.AddRelativeTorque(rota * rotSpeed * Time.deltaTime);
                        location += s.transform.position;

                        wakka++;

                    }
                }
            }

            if (wakka > 0)
            {
                location /= wakka;

                applyEuler(bs.transform, location, rb);
            }
            else
            {
                applyEuler(bs.transform, bs.transform.position, rb);
            }
            //return location;

        }
        void cohesion(GameObject bs, GameObject[] ms, Rigidbody rb)
        {
            Vector3 center = new Vector3(0,0,0);

            int oogie = 0;

            for (int k = 0; k < ms.Length; k++)
            {

                if (ms[k] != bs && Vector3.Distance(bs.transform.position, ms[k].transform.position) < sightRange && Vector3.Distance(bs.transform.position, ms[k].transform.position) > avoidRange)
                {
                    center += ms[k].transform.position;
                    oogie++;
                }
            }

            if (oogie > 0)
            {
                center = center / oogie;
                applyEuler(bs.transform, center, rb);
            }
            else
            {
                center = bs.transform.position;
                applyEuler(bs.transform, center, rb);
            }

            //return center;
            //rb.MoveRotation(center * rotSpeed * Time.deltaTime);
        }
        void alignment(GameObject bs, Rigidbody[] ms, Rigidbody rb)
        {
            float oogie = 0.0f;
            Quaternion center = rb.rotation;
            Vector3 centerVec = new Vector3(0,0,0);

            for (int k = 0; k < ms.Length; k++)
            {
                Rigidbody s = ms[k];

                if (s != bs)
                {
                    center *= s.rotation;
                    oogie++;
                }
            }

            if (oogie > 0)
            {
                centerVec = center.eulerAngles;
                center = Quaternion.Euler(centerVec.x/2, centerVec.y/2, centerVec.z/2);
                rb.MoveRotation(center * rb.rotation);
            }
            else
            {
                centerVec = bs.transform.rotation.eulerAngles;
                center = Quaternion.Euler(centerVec.x / 2, centerVec.y / 2, centerVec.z / 2);
                rb.MoveRotation(center * rb.rotation);
            }
            //return centerVec;
        }






        Vector3 findAngle(Transform a, Transform b)
        {
            float x = a.position.x - b.position.x;
            float y = a.position.y - b.position.y;
            float z = a.position.z - b.position.z;

            float x2 = x * x;
            float y2 = y * y;
            float z2 = z * z;

            float rootX = Mathf.Sqrt(x2 + z2);
            float rootY = Mathf.Sqrt(y2 + x2);
            float rootZ = Mathf.Sqrt(y2 + z2);

            Debug.Log(x + " " + y + " " + z + " and " + rootX + " " + rootY + " " + rootZ + " " + b.gameObject.name);

            float ack = 0;

            ack = (x2 + (rootX * rootX) - z2) / (2 * x * z);
            if (ack > 1.0f)
                ack = 1.0f;
            else if (ack < -1.0f)
                ack = -1.0f;
            float gammaX = Mathf.Acos(ack);

            ack = (y2 + (rootY * rootY) - x2) / (2 * y * x);
            if (ack > 1.0f)
                ack = 1.0f;
            else if (ack < -1.0f)
                ack = -1.0f;
            float gammaY = Mathf.Acos(ack);

            ack = (y2 + (rootZ * rootZ) - z2) / (2 * y * z);
            if (ack > 1.0f)
                ack = 1.0f;
            else if (ack < -1.0f)
                ack = -1.0f;
            float gammaZ = Mathf.Acos(ack);

            Vector3 Gamma = new Vector3(gammaX, gammaY, gammaZ);

            Debug.Log(Gamma);

            return Gamma;
        }



        Vector3  eulerAngleVelocity(Transform center, Vector3 target)
        {

            Vector3 targetDir = target - center.position;
            Vector3 localTarget = center.InverseTransformPoint(target);

            float angle1 = Mathf.Atan2(localTarget.y, localTarget.z) * Mathf.Rad2Deg;
            float angle = Mathf.Atan2(localTarget.x, localTarget.z) * Mathf.Rad2Deg;
            float angle2 = Mathf.Atan2(localTarget.y, localTarget.x) * Mathf.Rad2Deg;

            Vector3 eulerAngleForce = new Vector3(angle1, angle, angle2);

            return eulerAngleForce;

        }
        Quaternion sQuat(Vector3 eulerAngle)
        {
            Quaternion deltaRotation = Quaternion.Euler(eulerAngle * Time.deltaTime);
            return deltaRotation;
        }




        void applyEuler(Transform center, Vector3 target, Rigidbody localRotat)
        {
            Vector3 delta = eulerAngleVelocity(center, target);
            Quaternion deltaRotation = sQuat(delta);
            localRotat.MoveRotation(deltaRotation * localRotat.rotation);
        }
        */
}
