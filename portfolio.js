var g = {};
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
function addEvent(obj, type, fn){
	if(obj.addEventListener){
		obj.addEventListener(type, fn, false);
	}
	else if(obj.attachEvent){
		obj.attachEvent("on"+type, fn);
	}
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
	circ.setAttribute("stroke","#00cccc");
}
function displayText(){
	g.dest = document.getElementById("textDestination");
	g.text = ' void main() { <br/> &nbsp &nbsp &nbsp &nbsp printf("Rafia Anwar"); <br/> &nbsp &nbsp &nbsp &nbsp printf("Software Developer"); <br/> } <br/> // Scroll Down ';
	g.currentChar=0;
	type();
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


function serverRequest(params,async){
	if (window.XMLHttpRequest)
		{
			// code for IE7+, Firefox, Chrome, Opera, Safari
			g.request=new XMLHttpRequest();
		}
	else
		{// code for IE6, IE5
		g.request=new ActiveXObject("Microsoft.XMLHTTP");
		}
	g.request.open("post", "chatpgm.php", async);
	g.request.setRequestHeader("Content-type", "application/x-www-form-urlencoded");
	g.request.setRequestHeader("Content-length", params.length);
	g.request.setRequestHeader("Connection", "close");
	g.request.onreadystatechange = processServerData;

	g.request.send(params);
	
}
function processServerData(){
	if(g.request.readyState == 4 && g.request.status==200)
	{
		var fieldText = g.request.responseText;
		//alert("fieldText " + fieldText);

	if (window.DOMParser){
		var parser = new DOMParser(); //w3c version
		var	xmldoc = parser.parseFromString(fieldText, "text/xml");	
	}
	else{
		xmldoc=new ActiveXObject("Microsoft.XMLDOM"); //I.E. version
		xmldoc.async = false; 
		xmldoc.loadXML(fieldText); 
	}
	
	var last = xmldoc.getElementsByTagName("chat");
	g.msgNo = last[0].id;
	var msgNums = xmldoc.getElementsByTagName("msgNo");
	var users = xmldoc.getElementsByTagName("username");
	var msgArray = xmldoc.getElementsByTagName("msg");	

	var username;
	var msgs;
	for(var i=0; i < msgArray.length;i++)
	{
		username = users[i].childNodes[0].nodeValue;
		if(msgArray[i].childNodes.length > 0)
		{
		msgs=msgArray[i].childNodes[0].nodeValue ;
		g.showMessagesBox.innerHTML+= username + " : " + msgs+ "\n";
		}
		
	}
	}
}
function activateChat(){
	g.btnStart.style.visibility="hidden";
	g.username.style.visibility="hidden";
	g.lblUser.style.visibility="hidden";
	g.btnSend.style.visibility="visible";
	g.lblChat.style.visibility="visible";
	g.showMessagesBox.style.visibility="visible";
	g.lblMsgBox.style.visibility="visible";
	g.msgBox.style.visibility="visible";
	
	var params = "msgNo="+g.msgNo+"&username="+g.username.value+"&msg="+"none";
	serverRequest(params,false); // true
	setInterval(periodicRetrieval,3000);
}
function periodicRetrieval(){
	var params = "msgNo="+g.msgNo+"&username="+g.username.value+"&msg="+"none";
	serverRequest(params,true);

}
function sendMessage(){
	if(g.msgBox.value){		
	
	var params = "msgNo="+g.msgNo+"&username="+g.username.value+"&msg="+g.msgBox.value;
	serverRequest(params,true);
	g.msgBox.value="";
	g.msgBox.focus();
	}
}
function init(){
	
	addEvent(window,'scroll',parallex);
	displayText();
	changeCircleWidth();
	addLinks();
	//chatroom code
	g.msgNo=0;
	g.username = document.getElementById("username");
	var val = g.username.value;
	g.showMessagesBox = document.getElementById("showMessages");
	g.msgBox = document.getElementById("messageBox");
	g.btnStart = document.getElementById("btnStart");
	g.btnSend = document.getElementById("btnSend");
	g.lblUser = document.getElementById("lblUser");
	g.lblChat = document.getElementById("lblChat");
	g.lblMsgBox = document.getElementById("lblMsgBox");

	addEvent(g.btnStart,"click",activateChat);
	addEvent(g.btnSend,"click",sendMessage)
	
	}

window.onload=init;