#pragma strict
var Player: GameObject;
var offsetX : float = 2;
var offsetZ : float = -10;

var maximumDistance : float = 2;
var playerVelocity  : float = 10;

var positionY : float = 20;
var positionX : float = 0;
var positionZ : float = 0;
var movementX : float;
var movementZ : float;

function Update()
{
	movementX = (Player.transform.position.x + offsetX - this.transform.position.x)/maximumDistance;
	movementZ = (Player.transform.position.z + offsetZ - this.transform.position.z)/maximumDistance;
	this.transform.position += new Vector3((movementX*playerVelocity*Time.deltaTime),0,(movementZ*playerVelocity*Time.deltaTime));
}
