var g = {};

function addEvent(obj, type, fn){
	if(obj.addEventListener){
		obj.addEventListener(type, fn, false);
	}
	else if(obj.attachEvent){
		obj.attachEvent("on"+type, fn);
	}
}
function type(){
		var text = g.text.substr(g.currentChar,1);
		//alert(g.currentChar + " " + text);
		if(text=='<')
		{
			text=g.text.substr(g.currentChar,5);
			g.currentChar+=4;
		}
		if(text=='&')
		{
			text=g.text.substr(g.currentChar,6);
			g.currentChar+=4;
		}
		if(g.currentChar > '141')
			text = text.fontcolor("#009933");
		g.dest.innerHTML+=text;
		g.currentChar++;
		if(g.currentChar<g.text.length)
		{
			setTimeout(type,50);
		}
}

function displayText(){
	g.dest = document.getElementById("textDestination");
	g.text = ' void main() { <br/> &nbsp &nbsp &nbsp &nbsp printf("Rafia Anwar"); <br/> &nbsp &nbsp &nbsp &nbsp printf("Software Developer"); <br/> } <br/> // Scroll Down ';
	g.currentChar=0;
	type();
}
function parallex(){
	var pos = window.pageYOffset;
	var firstPage = document.getElementById("div1");
	firstPage.style.top = pos * 0.4 + 'px';
}
function getColors() {
    var nums = '0123456789ABCDEF'.split('');
    var random = '#';
    for (var i = 0; i < 6; i++ ) {
        random += nums[Math.floor(Math.random() * 16)];
    }
    return random;
}
function increaseWidth(e){
	var evt = e || window.event;	// reconcile event object between w3c standard and older IE browsers
	var target = evt.target || evt.srcElement;
	var circ = document.getElementById(""+target.id);
	circ.setAttribute("stroke-width",9);
	var color = getColors();
	circ.setAttribute("stroke",color);
}
function decreaseWidth(e){
	var evt = e || window.event;	// reconcile event object between w3c standard and older IE browsers
	var target = evt.target || evt.srcElement;
	var circ = document.getElementById(""+target.id);
	circ.setAttribute("stroke-width",5);
	circ.setAttribute("stroke","#b14e62");
}

function changeCircleWidth(){
	g.circles = document.getElementsByTagName("circle");
	for(var i=0; i < 6;i++)
	{
		addEvent(g.circles[i],'mouseover',increaseWidth);
	}
	for(var i=0; i < 6;i++)
	{
		addEvent(g.circles[i],'mouseout',decreaseWidth);
	}
}
function addLinks(){
	var sizeLocation = "width=800,height=500,top=20,left=250";
	g.td1 = document.getElementById("tdh1");
	addEvent(g.td1,'click',function(){
			window.open("links/tetris.html", "index.html", sizeLocation);
				});
	g.td2 = document.getElementById("tdh2");
	addEvent(g.td2,'click',function(){
			window.open("jsprojectpc/project1.html", "index.html", "width=800,height=640,top=20,left=250");
				});
	g.td3 = document.getElementById("tdh3");
	addEvent(g.td3,'click',function(){
			window.open("links/tictactoe.html", "index.html", "width=800,height=500,top=20,left=250");
				});
	g.td4 = document.getElementById("tdh4");
	addEvent(g.td4,'click',function(){
			window.open("links/bmi.html", "index.html", "width=800,height=500,top=20,left=250");
				});
	g.td5 = document.getElementById("tdh5");
	addEvent(g.td5,'click',function(){
			window.open("links/website.html", "index.html", "width=800,height=500,top=20,left=250");
				});
	g.td6 = document.getElementById("tdh6");
	addEvent(g.td6,'click',function(){
			window.open("links/battleship.html", "index.html", "width=800,height=500,top=20,left=250");
				});

}

function changeMode(){
	var element = document.body;
	  element.classList.toggle("dark-mode");
}

function init(){
	addEvent(window,'scroll',parallex);
	displayText();
	changeCircleWidth();
	addLinks();
	changeMode();


	}

window.onload=init;
