using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1 : Enemy01 {

    protected override bool IsStunnable() {
        return false;
    }

    protected override void DropLoot() {
    }
}
