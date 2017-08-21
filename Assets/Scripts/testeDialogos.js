#pragma strict
 import System.Collections.Generic;
 
 
 var tempo =2f; 
function Start () {

  
}

function Update () {

tempo = tempo -Time.deltaTime;

if(tempo <= 0.0f){

   Destroy(gameObject); 
   }
}