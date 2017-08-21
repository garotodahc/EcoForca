#pragma strict


function Start () {
    LeaveScene ();
}

function LeaveScene () {
    yield WaitForSeconds (4.0);
    Application.LoadLevel("AVISO02");
}