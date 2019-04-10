using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStatus 

{
    void modifyStat(float value);

    void modifyRate(float value);

    void modifyMax(float value);
}
