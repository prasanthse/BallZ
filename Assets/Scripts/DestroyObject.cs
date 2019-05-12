using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    public string objectTag;
    public GameObject hole;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals(objectTag) || other.gameObject.tag.Equals("Hole"))
        {
            Destroy(other.gameObject);

            if(objectTag == "LavaRock")
            {
                InitiateHole(other);
            }
        }
    }

    private void InitiateHole(Collider rock)
    {
        if(rock.transform.position.x < 1.5 && rock.transform.position.x > -1.5)
        {
            if(rock.transform.position.x > 1.25 || rock.transform.position.x < -1.25)
            {
                if(rock.transform.position.x > 1.25)
                {
                    Instantiate(hole, new Vector3((float)1.24, (float)0.03, rock.transform.position.z), Quaternion.Euler(90, 0, 0));
                }
                else
                {
                    Instantiate(hole, new Vector3((float)-1.24, (float)0.03, rock.transform.position.z), Quaternion.Euler(90, 0, 0));
                }
            }
            else
            {
                Instantiate(hole, new Vector3(rock.transform.position.x, (float)0.03, rock.transform.position.z), Quaternion.Euler(90, 0, 0));
            }
        }
    }
}
