var g = {};
g.counter = -1; //keeps track that only 2 images are clicked at a time
g.storingArray=[]; //stores the 2 clicked covers
g.backgroundArray; //stores the background images
g.backgroundCtr=0; //counter for background images

/**
 * This method changes the background image when a new game is started
 */
function setBackground()
{
	g.backgroundCtr = g.backgroundCtr + 1;
	if(g.backgroundCtr == 5)
		g.backgroundCtr = 0;
	g.backgroundArray = new Array("images/bg1.jpg","images/bg2.jpg","images/bg4.jpg","images/bg5.jpg","images/bg6.jpg");
	g.bg = document.getElementById("bgPic");
	for(var i=0;i < 5;i++)
	{
		if(g.backgroundCtr == i)
			g.bg.src=g.backgroundArray[i];
	}
}
/**
 * Randomize array element order in-place.
 * Using Durstenfeld shuffle algorithm.
 */
function shuffleArray(array) {
    for (var i = array.length - 1; i > 0; i--) {
        var j = Math.floor(Math.random() * (i + 1));
        var temp = array[i];
        array[i] = array[j];
        array[j] = temp;
    }
    return array;
}

/*
 * Removes the eventListener from the specified object
 */
function removeEvent(obj, type, fn){
	if(obj.removeEventListener){
		obj.removeEventListener(type, fn, false);
	}
	else if(obj.detachEvent){
		obj.detachEvent("on"+type, fn);
	}
}

/*
 * Adds event listener to the specified object
 */
 function addEvent(obj, type, fn){
	if(obj.addEventListener){
		obj.addEventListener(type, fn, false);
	}
	else if(obj.attachEvent){
		obj.attachEvent("on"+type, fn);
	}
}

/*
 * Removes click event from the wrapper object
 */
function removeEventFromWrapper(){
			removeEvent(g.wrapper, "click", discoverEvent);

}
/*
 * Checks if the value is present in given array
 */
function presentInArray(value, array) {
  return array.indexOf(value) > -1;
}
/*
 *adds the events back to unclicked covers
 */
function addBackTheClickEvent(){
	//adding the clicked elements to the array
	g.arrayForAlreadyClickedCovers.push(g.storingArray[0]);
	g.arrayForAlreadyClickedCovers.push(g.storingArray[1]);

	for(var i =0;i < 16;i++)
	{
		if(! (presentInArray(""+i,g.arrayForAlreadyClickedCovers)))
		{
			var elementToAdd = document.getElementById(""+i);
			addEvent(elementToAdd,"click",discoverEvent);
		}
	}
}

/* 
 * compares the 2 middle layer pictures, 
 * if they are equal, hides them and adds the click event back to 
 * other elements excluding the clicked elements
 * if they are unequal, make the cover pictures visible, and adds the
 * click event back to othe elements including the last 2 clicked elements
 */
function comparePics(){	
		var id = "pbc"+g.storingArray[0];
		var id2 = "pbc"+g.storingArray[1];
	if (g.picOfLayer2[g.storingArray[0]] == g.picOfLayer2[g.storingArray[1]])
	{
		var e1 = document.getElementById("bpc"+g.storingArray[0]);
		setTimeout(function(){e1.style.visibility="hidden"},800);
		var e2 = document.getElementById("bpc"+g.storingArray[1]);
		setTimeout(function(){e2.style.visibility="hidden"},800);
			setTimeout(addBackTheClickEvent,2000);
	}
	else
	{		
		var elementToAdd1 = document.getElementById(g.storingArray[0]);
		var elementToAdd2 = document.getElementById(g.storingArray[1]);
		setTimeout(function(){elementToAdd1.style.visibility="visible"},800);
		setTimeout(function(){elementToAdd2.style.visibility="visible"},800);
		addEvent(elementToAdd1,"click",discoverEvent);
		addEvent(elementToAdd2,"click",discoverEvent);
		addBackTheClickEvent();
		
		
	}
}
/*
 * This method receives the id of target object,
 * it removes the click event from clicked cover picture,
 * the counter keeps track of clicked Pictures at one time
 */
function onClickMethod(id){
	g.counter++;
	g.storingArray[g.counter] = id; // stores first clicked cover
	var elementClicked = document.getElementById(id);
	if(g.counter ==0)
	{
		removeEvent(elementClicked,"click",discoverEvent);
	   //for first cover image
		elementClicked.style.visibility="hidden";
	}
	if(g.counter == 1)
	{
		removeEvent(elementClicked,"click",discoverEvent); //for  image
		elementClicked.style.visibility="hidden";

		removeEventFromWrapper();
		comparePics();
		g.counter =-1;
	}
}

/* 
 * This method takes in the charValue, string representation
 * of pressed key, and makes sure it is in range of A-K or a-k 
 * if it is valid, then the position of value is sent as an id 
 * to onClickMethod 
 */
function validateKeyInput(charValue)
{
	var charArray = new Array("A","B","C","D","E","F","G","H","I","J","K","L","M","N","O","P");
	var charArray2 = new Array("a","b","c","d","e","f","g","h","i","j","k","l","m","n","o","p");
	var present = presentInArray(charValue,charArray);
	var present2 = presentInArray(charValue,charArray2);
	if(present)
	{
		var valuePosition = charArray.indexOf(charValue);
		onClickMethod(valuePosition+"");
	}
	else
	if(present2)
	{
		var valuePosition = charArray2.indexOf(charValue);
		onClickMethod(valuePosition+"");
	}
	else{
		//do nothing because out of bounds(A-K)
	}
}

/*
 * This is an event handler for click and keypress event,
 * if the event type is click, the method is directly called,
 * if the event type is keypress, the validation is done first.
 */
function discoverEvent(e){
	var evt = e || window.event;	// reconcile event object between w3c standard and older IE browsers
	if(evt.type=="click")
	{
		var target = evt.target || evt.srcElement;
		onClickMethod(target.id+"");
	}
	if(evt.type=="keypress")
	{
		var charCode = evt.which || evt.keyCode;
		var charValue = String.fromCharCode(charCode);
		//alert("key is pressed" + charValue);
		validateKeyInput(charValue);
	}
}
/*
 * This method sets up the middle layer, it randomizes the pictures
 * and attach them to image tag in html file
 */
function layer2Setup(){
	for(var i =0; i < 16; i++)
	{  
		var x = document.getElementById("bpc"+i);
		g.picOfLayer2[i] = x.src;
	}
	g.picOfLayer2 = shuffleArray(g.picOfLayer2);
	for(var i =0;i < 16;i++)
	{
		var img = document.createElement("img");
		img.src = g.picOfLayer2[i];
		var imgElement = document.getElementById("bpc"+i);
		imgElement.src = img.src;
	}
}
/*
 * This method is used to end the game.
 * It shows the bottom layer.
 */
function endNow(){
		for(var i=0;i < 16;i++)
		{
		var element = document.getElementById(""+i);
		removeEvent(element,"click",discoverEvent);
		element.style.visibility="hidden";
		var element = document.getElementById("bpc"+i);
		element.style.visibility="hidden";
		}

	g.container1.style.visibility="hidden";
	g.background.style.visibility="visible";
}

/*
 * This method starts a new game.
 * It randomizes the layer 2 pictures, and puts the covers 
 * pictures back on layer 1.
 */ 
 function newGame(){
	g.counter = -2;
	setBackground();
	layer2Setup(); //shuffle working
	g.container1.style.visibility = "visible";
	addEvent(g.wrapper,"click",discoverEvent);
	for(var i=0;i < 16;i++)
	{
		var element = document.getElementById("bpc"+i);
		element.style.visibility="visible";
		var coverPic = document.getElementById(""+i);
		coverPic.style.visibility = "visible";
		addEvent(coverPic,"click",discoverEvent);
	}
}

/*
 * This function is called on window onload.
 * It adds the event to container1-wrapper object where 
 * delegation is used to attach events to child elements.
 * It also attaches the event to button new Game and End Now.
 */
 function init(){
	g.wrapper = document.getElementById("container2");
	addEvent(g.wrapper,"click",discoverEvent);
	addEvent(g.wrapper,"keypress",discoverEvent);

	g.arrayForAlreadyClickedCovers = [];	
	g.picOfLayer2 = [];
	g.background = document.getElementById("backgroundPicture");
	g.container1 = document.getElementById("container1");
	layer2Setup();
	g.endButton = document.getElementById("btnEndNow");
	addEvent(g.endButton,"click",endNow);
	g.playAgainButton = document.getElementById("btnPlayAgain");
	addEvent(g.playAgainButton,"click",newGame);
}
window.onload = init;