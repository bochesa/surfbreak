function OnloadStage() {
    var checked = getCookie("cookieaccepted")
    if (checked != "") {
        document.getElementById("gdprContainer").innerHTML = "";
    }
}

function SwitchButtons(x) {
    if (x) {
        document.getElementById('gdprbs1').innerHTML = '<center><p>Denne side bruger kun nødvændige cookies <a href="./privacy">Læs mere</a></p><input class="btn btn-primary" onclick="YouGotIt()" onfocus="LoseFocus()" onmouseover="SwitchButtons(false)" id="gdprb2" type="button" value="Jeg accepterer ikke" /> <input class="btn btn-primary" onclick="AcceptedGDPR()" id="gdprb1" type="button" value="Jeg accepterer" /></center>';
    }
    else {
        document.getElementById('gdprbs1').innerHTML = '<center><p>Denne side bruger kun nødvændige cookies <a href="./privacy">Læs mere</a></p><input class="btn btn-primary" onclick="AcceptedGDPR()" id="gdprb1" type="button" value="Jeg accepterer" /> <input class="btn btn-primary" onclick="YouGotIt()" onfocus="LoseFocus()" onmouseover="SwitchButtons(true)" id="gdprb2" type="button" value="Jeg accepterer ikke" /></center>';
    }
}

function LoseFocus() {
    document.getElementById('gdprb2').blur();
}

function YouGotIt() {
    alert("YOU CLICKED IT!");
}

function AcceptedGDPR() {
    document.cookie = "cookieaccepted=1;";
    document.getElementById('gdprbs2').style.visibility = "hidden";
    document.getElementById('gdprbs1').style.visibility = "hidden";
}

//Taget fra W3Schools
function getCookie(cname) {
    var name = cname + "=";
    var ca = document.cookie.split(';');
    for (var i = 0; i < ca.length; i++) {
        var c = ca[i];
        while (c.charAt(0) == ' ') {
            c = c.substring(1);
        }
        if (c.indexOf(name) == 0) {
            return c.substring(name.length, c.length);
        }
    }
    return "";
}
