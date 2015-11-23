#pragma strict
var Player: GameObject;
function Update()
{
	this.transform.position.x = Player.transform.position.x;
	this.transform.position.z = Player.transform.position.z-20;
}
